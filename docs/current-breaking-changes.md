<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    # Current Breaking Changes

    ## Release X.0.0 - January 2017

    The following cmdlets were affected by this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```
-->

# Current Breaking Changes

## Release 3.0.0 - December 2019

* Subscription
  * [Get-PartnerCustomerAzurePlanEntitlement](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerAzurePlanEntitlement) output has changed

    ```output
    # Old
    ContinuationToken :
    Items             : {9681cddd-4b96-4d67-96e5-399a827d5375}
    TotalCount        : 1
    Links             : Microsoft.Store.PartnerCenter.Models.StandardResourceCollectionLinks
    Attributes        : Microsoft.Store.PartnerCenter.Models.ResourceAttributes

    # New
    FriendlyName    Id                                   Status SubscriptionId
    ------------    --                                   ------ --------------
    Microsoft Azure 9681cddd-4b96-4d67-96e5-399a827d5375 active 0d066578-66b7-40f6-afad-6e179df3ad80
    ```

  * [New-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/Neew-PartnerAzureSubscription) the `CustomerName` parameter will be replaced by the `CustomerId` parameter starting wth version 3.0.1

    ```powershell
    # Old
    New-PartnerAzureSubscription -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerName 'Contoso' -DisplayName 'Microsoft Azure'

    # New
    New-PartnerAzureSubscription -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId '1e5a6ab0-e5ef-4f4e-a208-399e792b5ed4' -DisplayName 'Microsoft Azure'
    ```

## Release 2.0.1910.1 - October 2019

* Usage
  * Removed the `Get-PartnerCustomerSubscriptionUsage` command due to changes with the Partner Center SDK for .NET. This command will be replaced with the [Get-PartnerCustomerSubscriptionMeterUsage](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionMeterUsage) and [Get-PartnerCustomerSubscriptionResourceUsage](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionResourceUsage) commands

## Release 2.0.1909.1 - September 2019

* Authentication
  * Environments have been renamed to match the Azure PowerShell module. The new values are: *AzureChinaCloud*, *AzureCloud*, *AzureGermanCloud*, *AzurePPE*, and *AzureUSGovernment*
  * Replaced the `Consent` parameter with the `UseAuthorizationCode` parameter for the `New-PartnerAccessToken` cmdlet
  * Replaced the `Resource` parameter with the `Scopes` parameter for the `Connect-PartnerCenter` and `New-PartnerAccessToken` cmdlets
  * ServicePrincipal parameter is now required when using a confidential client with the `Connect-PartnerCenter` and `New-PartnerAccessToken` cmdlets
  * When using the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/new-partneraccesstoken) command and the `UseAuthorizationCode` parameter you will be prompted to authentication interactively using the authorization code flow. The redirect URI value will generated dynamically. This generation process will attempt to find a port between 8400 and 8999 that is not in use. Once an available port has been found, the redirect URL value will be constructed (e.g. <http://localhost:8400>). So, it is important that you have configured the redirect URI value for your Azure Active Directory application accordingly.
* Module
  * The `PartnerCenter` module now supports PowerShell 5.1 and PowerShell, as a result the `PartnerCenter.NetCore` module will be retired

## Release 1.5.1906.1 - June 2019

* Agreements
  * The *UserId* parameter will be removed from the [New-PartnerCustomerAgreement](https://docs.microsoft.com/powershell/module/partnercenter/new-partnercustomeragreement) command. Enhancements to the API have been to derive this value based on the authenticated user

## Release 1.5.1905.1 - May 2019

* Subscriptions
  * The *AutoRenew* flag will be removed from the [Set-PartnerCustomerSubscription](https://docs.microsoft.com/powershell/module/partnercenter/set-partnercustomersubscription) command
