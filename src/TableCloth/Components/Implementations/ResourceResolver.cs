﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TableCloth.Models;
using TableCloth.Models.Catalog;
using TableCloth.Resources;

namespace TableCloth.Components.Implementations;

public sealed class ResourceResolver(
    ICatalogDeserializer catalogDeserializer,
    IHttpClientFactory httpClientFactory) : IResourceResolver
{
    private DateTimeOffset? _catalogLastModified = default;

    public DateTimeOffset? CatalogLastModified => _catalogLastModified;

    public async Task<ApiInvokeResult<CatalogDocument?>> DeserializeCatalogAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var httpClient = httpClientFactory.CreateTableClothHttpClient();
            var uriBuilder = new UriBuilder(new Uri(ConstantStrings.CatalogUrl, UriKind.Absolute));

            var queryKeyValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryKeyValues[ConstantStrings.QueryString_Timestamp_Key] = DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);
            uriBuilder.Query = queryKeyValues.ToString();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
            httpRequest.Headers.CacheControl = new CacheControlHeaderValue() { NoCache = true, NoStore = true, };
            httpRequest.Headers.UserAgent.TryParseAdd(ConstantStrings.UserAgentText);

            var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            _catalogLastModified = httpResponse.Content.Headers.LastModified;

            using var catalogStream = await httpResponse.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var document = catalogDeserializer
                .Deserialize(catalogStream, new UTF8Encoding(false))
                .EnsureNotNull(StringResources.Error_With_Exception(ErrorStrings.Error_CatalogLoadFailure, null));

            return (ApiInvokeResult<CatalogDocument?>)document;
        }
        catch (Exception ex)
        {
            return new ApiInvokeResult<CatalogDocument?>(ex);
        }
    }

    public async Task<ApiInvokeResult<string?>> GetLatestVersionAsync(string owner, string repoName, CancellationToken cancellationToken = default)
    {
        try
        {
            var targetUri = new Uri($"https://api.github.com/repos/{owner}/{repoName}/releases/latest", UriKind.Absolute);
            var httpClient = httpClientFactory.CreateTableClothHttpClient();

            using var licenseDescription = await httpClient.GetStreamAsync(targetUri, cancellationToken).ConfigureAwait(false);
            var jsonDocument = await JsonDocument.ParseAsync(licenseDescription, cancellationToken: cancellationToken).ConfigureAwait(false);
            return jsonDocument.RootElement.GetProperty("tag_name").GetString()?.TrimStart('v');
        }
        catch (Exception ex)
        {
            return new ApiInvokeResult<string?>(ex);
        }
    }

    public async Task<ApiInvokeResult<Uri?>> GetReleaseDownloadUrlAsync(string owner, string repoName, CancellationToken cancellationToken = default)
    {
        try
        {
            var targetUri = new Uri($"https://api.github.com/repos/{owner}/{repoName}/releases/latest", UriKind.Absolute);
            var httpClient = httpClientFactory.CreateTableClothHttpClient();

            using var licenseDescription = await httpClient.GetStreamAsync(targetUri, cancellationToken).ConfigureAwait(false);
            var jsonDocument = await JsonDocument.ParseAsync(licenseDescription, cancellationToken: cancellationToken).ConfigureAwait(false);

            if (Uri.TryCreate(jsonDocument.RootElement.GetProperty("html_url").GetString(), UriKind.Absolute, out var result))
                return result;
            else
                return new Uri($"https://github.com/{owner}/{repoName}/releases", UriKind.Absolute);
        }
        catch (Exception ex)
        {
            return new ApiInvokeResult<Uri?>(ex);
        }
    }

    public async Task<ApiInvokeResult<string?>> GetLicenseDescriptionForGitHubAsync(string owner, string repoName, CancellationToken cancellationToken = default)
    {
        try
        {
            var targetUri = new Uri($"https://api.github.com/repos/{owner}/{repoName}/license", UriKind.Absolute);
            var httpClient = httpClientFactory.CreateTableClothHttpClient();

            using var licenseDescription = await httpClient.GetStreamAsync(targetUri, cancellationToken).ConfigureAwait(false);
            var jsonDocument = await JsonDocument.ParseAsync(licenseDescription, cancellationToken: cancellationToken).ConfigureAwait(false);
            return jsonDocument.RootElement.GetProperty("license").GetProperty("name").GetString();
        }
        catch (Exception ex)
        {
            return new ApiInvokeResult<string?>(ex);
        }
    }

    public async Task LoadSiteImagesAsync(
        IEnumerable<CatalogInternetService> services,
        string imageDirectoryPath,
        CancellationToken cancellationToken = default)
    {
        if (!Directory.Exists(imageDirectoryPath))
            Directory.CreateDirectory(imageDirectoryPath);

        var httpClient = httpClientFactory.CreateTableClothHttpClient();

        foreach (var eachSite in services)
        {
            var targetFilePath = Path.Combine(imageDirectoryPath, eachSite.Id + ".png");

            if (!File.Exists(targetFilePath))
            {
                try
                {
                    var targetUrl = $"{ConstantStrings.ImageUrlPrefix}/{eachSite.Category}/{eachSite.Id}.png";
                    var imageStream = await httpClient.GetStreamAsync(targetUrl, cancellationToken).ConfigureAwait(false);

                    using var fileStream = File.OpenWrite(targetFilePath);
                    await imageStream.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    try { await File.WriteAllBytesAsync(targetFilePath, Properties.Resources.SandboxIcon, cancellationToken).ConfigureAwait(false); }
                    catch { }
                }
            }

            var targetIconFilePath = Path.Combine(
                imageDirectoryPath,
                Path.GetFileNameWithoutExtension(targetFilePath) + ".ico");

            if (!File.Exists(targetIconFilePath))
            {
                try
                {
                    await File.WriteAllBytesAsync(targetIconFilePath, ConvertImageToIcon(targetFilePath), cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    var memStream = new MemoryStream();
                    Properties.Resources.SandboxIconWin32.Save(memStream);
                    memStream.Seek(0L, SeekOrigin.Begin);

                    try { await File.WriteAllBytesAsync(targetIconFilePath, memStream.ToArray(), cancellationToken).ConfigureAwait(false); }
                    catch { }
                }
            }
        }
    }

    // https://stackoverflow.com/questions/21387391/how-to-convert-an-image-to-an-icon-without-losing-transparency
    private static byte[] ConvertImageToIcon(string imageFilePath)
    {
        using var ms = new MemoryStream();
        using var bw = new BinaryWriter(ms);
        using var fs = File.OpenRead(imageFilePath);
        using var img = System.Drawing.Image.FromStream(fs);

        // Header
        bw.Write((short)0);   // 0 : reserved
        bw.Write((short)1);   // 2 : 1=ico, 2=cur
        bw.Write((short)1);   // 4 : number of images

        // Image directory
        var w = img.Width;
        if (w >= 256) w = 0;
        bw.Write((byte)w);    // 0 : width of image

        var h = img.Height;
        if (h >= 256) h = 0;
        bw.Write((byte)h);    // 1 : height of image

        bw.Write((byte)0);    // 2 : number of colors in palette
        bw.Write((byte)0);    // 3 : reserved
        bw.Write((short)0);   // 4 : number of color planes
        bw.Write((short)0);   // 6 : bits per pixel

        var sizeHere = ms.Position;
        bw.Write(0);     // 8 : image size

        var start = (int)ms.Position + 4;
        bw.Write(start);      // 12: offset of image data

        // Image data
        img.Save(ms, ImageFormat.Png);
        var imageSize = (int)ms.Position - start;
        ms.Seek(sizeHere, SeekOrigin.Begin);
        bw.Write(imageSize);
        ms.Seek(0L, SeekOrigin.Begin);

        return ms.ToArray();
    }
}
