# Microsoft Partner Center PowerShell

This repository contains a set of PowerShell cmdlets for developers and administrators to manage Cloud Solution Provider program resources.

## Installation

### PowerShell Gallery

Currently, there is only a pre-release version of the Partner Center module available. To install pre-release items using the _Install-Module_ command the latest version of _PowerShellGet_ must be installed. If you do not have the latest version installed, run the following command from an elevated PowerShell session:

```powershell
Install-Module -Name PowerShellGet -Force
```

 Run the following command in an elevated PowerShell session to install the Partner Center module:

```powershell
Install-Module -Name PartnerCenter -AllowPrerelease
```

If you have an earlier version of the Partner Center PowerShell modules installed from the PowerShell Gallery and would like to update to the latest version, run the following commands from an elevated PowerShell session.

**Note:** `Update-Module` installs the new version, however, it does not remove the old version.

```powershell
# Install the latest version of the Partner Center PowerShell module
Update-Module -Name PartnerCenter
```

## Usage

### Configure Azure AD Native App

**Important:** This module only supports the app + user authentication.

You must create and configure an Azure Active Directory (AD) application. To do this, complete the following steps:

1. Sign in to the [Partner Dashboard](https://partner.microsoft.com) using credentials that have *Admin Agent* and *Global Admin* privileges
2. Click on _Dashboard_  at the top of the page, then click on the cog icon in the upper right, and then click the _Partner settings_.
3. Add a new native application if one does not exist already.
4. Sign in to the [Azure management portal](https://portal.azure.com) using the same credentials from step 1.
5. Click on the _Azure Active Directory_ icon in the toolbar.
6. Click _App registrations_ -> Select _All apps_ from the drop down -> Click on the application created in step 3.
7. Click _Settings_ and then click _Redirect URIs_
8. Add **urn:ietf:wg:oauth:2.0:oob** as one of the available Redirect URIs. Be sure to click the _Save_ button to ensure the changes are saved.  

### Log in to Partner Center

To connect to Partner Center, use the [`Connect-PartnerCenter`](docs/help/Connect-PartnerCenter.md) cmdlet.

```powershell
# Interactive login - a dialog box will appear for you to provide your Partner Center credentials
Connect-PartnerCenter -ApplicationId '<Native-AAD-AppId-for-PartnerCenter>'

# Non-interactive login
$PSCredential = Get-Credential
Connect-PartnerCenter -ApplicationId '<Native-AAD-AppId-for-PartnerCenter>' -Credential $PSCredential
```

To log into a specific cloud (_ChinaCloud_, _GlobalCloud_, _GermanCloud_, _USGovernment_), use the `Environment` parameter:

```powershell
# Log into a specific cloud - in this case, the German cloud
Connect-PartnerCenter -Environment GermanCloud
```

### Discovering cmdlets

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