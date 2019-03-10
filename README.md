# Microsoft Partner Center PowerShell

![Build status](https://dev.azure.com/partnercenter/powershell/_apis/build/status/partner-center-powershell-CI) ![Deployment status](https://vsrm.dev.azure.com/partnercenter/_apis/public/Release/badge/330fa980-0fb5-4550-8242-f162a4c6d7c7/1/1)

[![PartnerCenter](https://img.shields.io/powershellgallery/v/PartnerCenter.svg?style=flat-square&label=PartnerCenter)](https://www.powershellgallery.com/packages/PartnerCenter/) [![GitHub issues](https://img.shields.io/github/issues/Microsoft/Partner-Center-PowerShell.svg)](https://github.com/Microsoft/Partner-Center-PowerShell/issues/) [![GitHub pull-requests](https://img.shields.io/github/issues-pr/Microsoft/Partner-Center-PowerShell.svg)](https://gitHub.com/Microsoft/Partner-Center-PowerShell/pull/)

This repository contains a set of PowerShell commands for administrators and developers to manage Cloud Solution Provider program resources.

## Installation

Run the following command in an elevated PowerShell session to install the Partner Center module:

```powershell
# Install the Partner Center PowerShell module
Install-Module -Name PartnerCenter

# Install the Partner Center PowerShell module for PowerShell Core
Install-Module -Name PartnerCenter.NetCore
```

If you have an earlier version of the Partner Center PowerShell modules installed from the PowerShell Gallery and would like to update to the latest version, run the following commands from an elevated PowerShell session.

**Note:** `Update-Module` installs the new version, however, it does not remove the old version.

```powershell
# Install the latest version of the Partner Center PowerShell module
Update-Module -Name PartnerCenter

# Install the latest version of the Partner Center PowerShell module for PowerShell Core
Update-Module -Name PartnerCenter.NetCore
```

## Usage

### Connecting to Partner Center

To connect to Partner Center, use the [`Connect-PartnerCenter`](docs/help/Connect-PartnerCenter.md) command.

#### Service Principal

The following example demonstrates how to connect using a service principal. It is important to note that not all Partner Center operations support this type of authentication. If you have not already created an Azure AD application, then follow the steps documented in the [Web App](#Web-App) section below.

```powershell
# Service principal login
$appId = '<Web-AAD-AppId-for-PartnerCenter>'
$appSecret = '<Web-AAD-AppSecret>' | ConvertTo-SecureString -AsPlainText -Force
$credential = New-Object System.Management.Automation.PSCredential $appId $appSecret

Connect-PartnerCenter -Credential $credential -TenantId '<TenantId>'
```

#### User Credentials

The following examples demonstrate how to connect using user credentials. Using this approach will leverage app + user authentication. If you have not already configured an Azure AD application for use with this command then, see the steps documented in the [Native App](#Native-App) section below.

```powershell
# Interactive login - a dialog box will appear for you to provide your Partner Center credentials
Connect-PartnerCenter -ApplicationId '<Native-AAD-AppId-for-PartnerCenter>'
```

#### Access Token

The following example demonstrates how to connect using an access token. It is important to note that this type of authentication can leverage either the app only or app + user authentication flows. The example below shows how you can obtain an access token using the app only authentication flow.

```powershell
$appId = '<AAD-AppId-for-PartnerCenter>'
$appSecret = '<AAD-AppSecret>' | ConvertTo-SecureString -AsPlainText -Force
$PSCredential = New-Object System.Management.Automation.PSCredential $appId, $appSecret

$token = New-PartnerAccessToken -Credential $PSCredential -TenantId '<TenantId>'

Connect-PartnerCenter -AccessToken $token.AccessToken -ApplicationId '<AAD-AppId-for-PartnerCenter>' -TenantId '<TenantId>'
```

#### Sovereign Cloud

To log into a specific cloud (_ChinaCloud_, _GlobalCloud_, _GermanCloud_, _USGovernment_), use the `Environment` parameter:

```powershell
# Log into a specific cloud - in this case, the German cloud
Connect-PartnerCenter -Environment GermanCloud
```

### Discovering Commands

Use the `Get-Command` cmdlet to discover cmdlets within a specific module, or cmdlets that follow a specific search pattern:

```powershell
# View all cmdlets in the Partner Center module
Get-Command -Module PartnerCenter

# View all cmdlets that contain "Customer" in the PartnerCenter module
Get-Command -Module PartnerCenter -Name "*Customer*"
```

### Cmdlet help and examples

To view the cmdlet help content, use the `Get-Help` cmdlet:

```powershell
# View the basic help content for Get-PartnerCustomer
Get-Help -Name Get-PartnerCustomer

# View the examples for Get-PartnerCustomer
Get-Help -Name Get-PartnerCustomer -Examples

# View the full help content for Get-PartnerCustomer
Get-Help -Name Get-PartnerCustomer -Full
```

## Configuring Azure AD Application

### Native App

1. Sign in to the [Partner Center](https://partner.microsoft.com/cloud-solution-provider/csp-partner) using credentials that have *Admin Agent* and *Global Admin* privileges
2. Click on _Dashboard_  at the top of the page, then click on the cog icon in the upper right, and then click the _Partner settings_.
3. Add a new native application if one does not exist already.
4. Sign in to the [classic portal](https://portal.azure.com) using the same credentials from step 1.
5. Click on the _Azure Active Directory_ icon in the toolbar.
6. Click _App registrations_ -> Select _All apps_ from the drop down -> Click on the application created in step 3.
7. Click _Settings_ and then click _Redirect URIs_
8. Add **urn:ietf:wg:oauth:2.0:oob** as one of the available Redirect URIs. Be sure to click the _Save_ button to ensure the changes are saved.  

### Web App

1. Sign in to the [Partner Center](https://partner.microsoft.com/cloud-solution-provider/csp-partner) using credentials that have *Admin Agent* and *Global Admin* privileges
2. Click on _Dashboard_  at the top of the page, then click on the cog icon in the upper right, and then click the _Partner settings_.
3. Add a new web application if one does not exist already.
