﻿using System.Collections.Generic;
using System.Linq;
using TableCloth.Resources;
using TableCloth.ViewModels;

namespace TableCloth.Components.Implementations;

public sealed class CommandLineComposer(
    ISharedLocations sharedLocations) : ICommandLineComposer
{
    public string ComposeCommandLineExpression(ITableClothViewModel viewModel, bool allowMultipleItems)
    {
        var targetFilePath = sharedLocations.ExecutableFilePath;
        var args = this.ComposeCommandLineArguments(viewModel, allowMultipleItems);
        return $"\"{targetFilePath}\" {args}";
    }

    public string ComposeCommandLineArguments(ITableClothViewModel viewModel, bool allowMultipleItems)
    {
        var options = new List<string>();

        if (viewModel.EnableMicrophone)
            options.Add(ConstantStrings.TableCloth_Switch_EnableMicrophone);
        if (viewModel.EnableWebCam)
            options.Add(ConstantStrings.TableCloth_Switch_EnableCamera);
        if (viewModel.EnablePrinters)
            options.Add(ConstantStrings.TableCloth_Switch_EnablePrinter);
        if (viewModel.InstallEveryonesPrinter)
            options.Add(ConstantStrings.TableCloth_Switch_InstallEveryonesPrinter);
        if (viewModel.InstallAdobeReader)
            options.Add(ConstantStrings.TableCloth_Switch_InstallAdobeReader);
        if (viewModel.InstallHancomOfficeViewer)
            options.Add(ConstantStrings.TableCloth_Switch_InstallHancomOfficeViewer);
        if (viewModel.InstallRaiDrive)
            options.Add(ConstantStrings.TableCloth_Switch_InstallRaiDrive);
        if (viewModel.EnableInternetExplorerMode)
            options.Add(ConstantStrings.TableCloth_Switch_EnableIEMode);
        if (viewModel.MapNpkiCert)
            options.Add(ConstantStrings.TableCloth_Switch_EnableCert);

        var firstSite = viewModel.SelectedServices.FirstOrDefault();

        if (firstSite != null)
            options.Add(firstSite.Id);

        if (allowMultipleItems)
            foreach (var eachSite in viewModel.SelectedServices.Skip(1).ToList())
                options.Add(eachSite.Id);

        return string.Join(' ', [.. options]);
    }
}
