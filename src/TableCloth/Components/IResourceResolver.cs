﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TableCloth.Models.Catalog;

namespace TableCloth.Components;

public interface IResourceResolver
{
    DateTimeOffset? CatalogLastModified { get; }

    Task<CatalogDocument> DeserializeCatalogAsync(CancellationToken cancellationToken = default);
    Task<Uri> GetDownloadUrl(string owner, string repoName);
    Task<string?> GetLatestVersion(string owner, string repoName);
    Task<string?> GetLicenseDescriptionForGitHub(string owner, string repoName);
    Task LoadSiteImagesAsync(IEnumerable<CatalogInternetService> services, string imageDirectoryPath, CancellationToken cancellationToken = default);
}