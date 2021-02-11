# Partner Center PowerShell

[![Build Status](https://dev.azure.com/isaiahwilliams/public/_apis/build/status/partner-center-powershell?branchName=master)](https://dev.azure.com/isaiahwilliams/public/_build/latest?definitionId=57&branchName=master) ![Deployment status](https://vsrm.dev.azure.com/partnercenter/_apis/public/Release/badge/330fa980-0fb5-4550-8242-f162a4c6d7c7/6/9)

[![PartnerCenter](https://img.shields.io/powershellgallery/v/PartnerCenter.svg?style=flat-square&label=PartnerCenter)](https://www.powershellgallery.com/packages/PartnerCenter/) [![GitHub issues](https://img.shields.io/github/issues/Microsoft/Partner-Center-PowerShell.svg)](https://github.com/Microsoft/Partner-Center-PowerShell/issues/) [![GitHub pull-requests](https://img.shields.io/github/issues-pr/Microsoft/Partner-Center-PowerShell.svg)](https://gitHub.com/Microsoft/Partner-Center-PowerShell/pull/)

Partner Center PowerShell is commonly used by partners to manage their Partner Center resources. It is an open source project maintained by the partner community. Since this module is maintained by the partner community, it is not officially supported by Microsoft. You can [get help from the community](https://stackoverflow.com/questions/tagged/partner+center) or open an [issue](https://github.com/microsoft/partner-center-powershell/issues) on GitHub.

## Requirements

Partner Center PowerShell works with PowerShell 5.1 or higher on Windows, or PowerShell Core 6.x and later on
all platforms. If you aren't sure if you have PowerShell, or are on macOS or Linux,
[install the latest version of PowerShell Core](https://docs.microsoft.com/powershell/scripting/install/installing-powershell#powershell-core).

To check your PowerShell version, run the command:

```powershell
$PSVersionTable.PSVersion
```

To run Partner Center PowerShell in PowerShell 5.1 on Windows:

1. Update to [Windows PowerShell 5.1](https://docs.microsoft.com/powershell/scripting/install/installing-windows-powershell#upgrading-existing-windows-powershell) if needed. If you're on Windows 10, you already
  have PowerShell 5.1 installed.
2. Install [.NET Framework 4.7.2 or later](https://docs.microsoft.com/dotnet/framework/install).

There are no additional requirements for Partner Center PowerShell when using PowerShell Core.

## Install the Partner Center PowerShell module

The recommended install method is to only install for the active user:

```powershell
Install-Module -Name PartnerCenter -AllowClobber -Scope CurrentUser
```

If you want to install for all users on a system, this requires administrator privileges. From an elevated PowerShell session either
run as administrator or with the `sudo` command on macOS or Linux:

```powershell
Install-Module -Name PartnerCenter -AllowClobber -Scope AllUsers
```

By default, the PowerShell gallery isn't configured as a trusted repository for PowerShellGet. The first time you use the PSGallery you see the following prompt:

```output
Untrusted repository

You are installing the modules from an untrusted repository. If you trust this repository, change
its InstallationPolicy value by running the Set-PSRepository cmdlet.

Are you sure you want to install the modules from 'PSGallery'?
[Y] Yes  [A] Yes to All  [N] No  [L] No to All  [S] Suspend  [?] Help (default is "N"):
```

Answer `Yes` or `Yes to All` to continue with the installation.

### Discovering cmdlets

Use the `Get-Command` cmdlet to discover cmdlets within a specific module, or cmdlets that follow a specific search pattern:

```powershell
# List all cmdlets in the PartnerCenter module
Get-Command -Module PartnerCenter

# List all cmdlets that contain Azure
Get-Command -Name '*Azure*'

# List all cmdlets that contain Azure in the PartnerCenter module
Get-Command -Module PartnerCenter -Name '*Azure*'
```

### Cmdlet help and examples

To view the help content for a cmdlet, use the `Get-Help` cmdlet:

```powershell
# View the basic help content for Get-PartnerCustomerSubscription
Get-Help -Name Get-PartnerCustomerSubscription

# View the examples for Get-PartnerCustomerSubscription
Get-Help -Name Get-PartnerCustomerSubscription -Examples

# View the full help content for Get-PartnerCustomerSubscription
Get-Help -Name Get-PartnerCustomerSubscription -Full

# View the help content for Get-PartnerCustomerSubscription on https://docs.microsoft.com
Get-Help -Name Get-PartnerCustomerSubscription -Online
```
