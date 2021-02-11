<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->

# Change Log

## Upcoming Release

* Dependencies
  * Updating dependencies to support the latest version of PowerShell Core

## 3.0.10 - July 2020

* Module 
  * Added a custom assembly resolve to help address conflicts
* Network 
  * Increased the HTTP timeout to contend with server latency

## 3.0.9 - May 2020

* Module
  * Addressed issue [#295](https://github.com/microsoft/Partner-Center-PowerShell/issues/295) and [#300](https://github.com/microsoft/Partner-Center-PowerShell/issues/300) where the module was digitally signed

## 3.0.8 - April 2020

* Authentication
  * Addressed issue [#266](https://github.com/microsoft/Partner-Center-PowerShell/issues/266) that was impacting the persistent token cache on Linux when libsecret was not installed
* Devices
  * Addressed issue [#281](https://github.com/microsoft/Partner-Center-PowerShell/issues/281) that was causing the incorrect output for the creation date of a device batch
* Module
  * Addressed issue [#261](https://github.com/microsoft/Partner-Center-PowerShell/issues/261) that was preventing the module from being loaded if the Az module was load first
* Users
  * Addressed issue [#290](https://github.com/microsoft/Partner-Center-PowerShell/issues/290) that was causing unexpected behavior when using `ReturnDeletedUsers:$false`

## 3.0.7 - February 2020

* Devices
  * Addressed issue [#271](https://github.com/microsoft/Partner-Center-PowerShell/issues/271) that was preventing the `Policies` property from being populated

## 3.0.6 - January 2020

* Authentication
  * Addressed issue [#268](https://github.com/microsoft/Partner-Center-PowerShell/issues/268) that was impacting the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command when trying to get an access token for Exchange Online with a refresh token
* Agreements
  * Addressed issue [#262](https://github.com/microsoft/Partner-Center-PowerShell/issues/262) that was preventing [Get-PartnerAgreementDocument](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAgreementDocument) from being invoked when the `Language` parameter was specified
* Qualifications
  * Addressed issue [#258](https://github.com/microsoft/Partner-Center-PowerShell/issues/258) with the [Set-PartnerCustomerQualification](https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerCustomerQualification) command that was preventing API exception information from being parsed as excepted

## 3.0.5 - January 2020

* Authentication
  * Addressed issue [#254](https://github.com/microsoft/Partner-Center-PowerShell/issues/254) with the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) where the Scope parameter was incorrectly being required
  * Addressed an issue where NullReferenceException exception was being encountered when invoking [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) using a certificate
  * Addressed an issue where NullReferenceException exception was being encountered when invoking [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) using a certificate
  * Defined the refresh token parameter set for the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command to make it easier to ensure all the appropriate parameters have been specified when exchanging a refresh token for an access token
* Module
  * All commands now perform operations asynchronously

## 3.0.4 - January 2020

* Authentication
  * Addressed an issue where NullReferenceException exception was being encountered when invoking [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) using a certificate
  * Addressed an issue where NullReferenceException exception was being encountered when invoking [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) using a certificate
  * Defined the refresh token parameter set for the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command to make it easier to ensure all the appropriate parameters have been specified when exchanging a refresh token for an access token
* Module
  * All commands now perform operations asynchronously

## 3.0.3 - December 2019

* Authentication
  * Added the [Register-PartnerTokenCache](https://docs.microsoft.com/powershell/module/partnercenter/Register-PartnerTokenCache) to create, and delete, the control file that determines if a in-memory token cache should be used instead of the default persistent token cache
  * Addressed an issue where an InvalidOperationException exception was being encountering with the [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) and [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) commands when specifying an environment
  * Addressed an issue where an InvalidOperationException exception was being encountered under certain circumstances when invoking [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) and attempting to authenticate interactively
  * Addressed issue [#234](https://github.com/microsoft/Partner-Center-PowerShell/issues/234) that was preventing the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command from executing successfully when being invoked through an Azure Function app
* Invoice
  * Added the [Get-PartnerUnbilledInvoiceLineItem](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUnbilledInvoiceLineItem) command to get unbilled invoice line items
  * Removed the `Period` parameter from the [Get-PartnerInvoiceLineItem](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerInvoiceLineItem) command because the functionality it enabled has been replaced with the [Get-PartnerUnbilledInvoiceLineItem](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUnbilledInvoiceLineItem) command
* Network
  * Addressed an issue where the HTTP response from [Get-PartnerUser](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUser) and [Get-PartnerUserSignInActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignInActivity) was not being correctly written to the debug pipeline
* Product Upgrades
  * Addressed an issue with starting the upgrade process for an Azure Plan
* Subscription
  * Added the `PartnerId` parameter to the [Set-PartnerCustomerSubscription](https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerCustomerSubscription) command
  * Addressed issue [#228](https://github.com/microsoft/Partner-Center-PowerShell/issues/228) that was causing issues with enabling and suspend an Azure subscription that is part of an Azure Plan

## 3.0.2 - December 2019

* Authentication
  * Addressed issue [#230](https://github.com/microsoft/Partner-Center-PowerShell/issues/230) that was caused by a deadlock

## 3.0.1 - December 2019

* Authentication
  * Updating the [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) command to make the `CertificateThumbprint` parameter required for the `ServicePrincipalCertificate` parameter set
* Security
  * Addressed issue [#194](https://github.com/microsoft/Partner-Center-PowerShell/issues/194) that was preventing the [Get-PartnerUserSignActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignActivity) command from executing as expected in all scenarios
* Subscription
  * Added [Enable-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/Enable-PartnerAzureSubscription) command to enable a suspend Azure subscription that is part of an Azure Plan
  * Added [Suspend-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/Suspend-PartnerAzureSubscription) command to suspend an Azure subscription that is part of an Azure Plan
  * Removed the `CustomerName` parameter from the [New-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAzureSubscription)

## 3.0.0 - December 2019

* Agreement
  * Added the [Get-PartnerAgreementStatus](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAgreementStatus) command to get the status of acceptance of the Microsoft Partner Agreement for the specified partner
* Authentication
  * Updated how [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) writes warnings during an authentication attempt
  * Updated how [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) prompts for interaction
  * When using [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) with an access token the account and tenant information are now extracted from the access token
* Azure
  * Added the [Get-PartnerAzureBillingPolicy](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAzureBillingPolicy) to get the billing policy for the specified customer
  * Added the [Set-PartnerAzureBillingPolicy](https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerAzureBillingPolicy) to update the billing policy for the specified customer
* Build
  * Updating the test project from .NET Core 2.2 to .NET 3.0
* Dependency
  * Updated to the latest version of the Partner Center SDK for .NET
* Invoice
  * Added the `Period` parameter to the [Get-PartnerInvoiceLineItem](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerInvoiceLineItem) command to provide a way for the user to specify if they want the current or previous unbilled line items
  * Addressed issue [#202](https://github.com/microsoft/Partner-Center-PowerShell/issues/202) that was returning request for invoice line items with no errors
* Module
  * Addressed issue [#217](https://github.com/microsoft/Partner-Center-PowerShell/issues/217) that was impacting executing commands through Azure Automation
  * Updated the transient error strategy for network operations
  * When running any command with with the `Debug` parameter the request and response from the API will be written to the console in addition to any operation specific debug information
* Security
  * Modified the [Get-PartnerUser](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUser) command to leverage a task scheduler for requesting from Microsoft Graph
  * Modified the [Get-PartnerUserSignActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignActivity) command to leverage a task scheduler for requesting from Microsoft Graph
  * Updated how [Test-PartnerSecurityRequirement](https://docs.microsoft.com/powershell/module/partnercenter/Test-PartnerSecurityRequirement) prompts for interaction
* Subscription
  * Addressed an issue where the request for subscriptions by partner was causing an `InvalidCastException` to be thrown
  * Corrected the output for the [Get-PartnerCustomerAzurePlanEntitlement](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerAzurePlanEntitlement) command
* Validation
  * Addressed a scenario where a `NullReferenceException` could be thrown when running the [Test-PartnerAddress](https://docs.microsoft.com/powershell/module/partnercenter/Test-PartnerAddress) command

## 2.0.1911.6 - November 2019

* Authentication
  * Updated how [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) writes warnings during an authentication attempt
  * Updated how [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) prompts for interaction
* Azure
  * Added the [Set-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerAzureSubscription) command to update the display name of an Azure subscription provided through an Azure Plan

## 2.0.1911.5 - November 2019

* Security
  * Optimized the [Get-PartnerUser](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgrade) command
  * Optimized the [Get-PartnerUserSignActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignActivity) command

## 2.0.1911.4 - November 2019

* Azure
  * Added the [Get-PartnerAzureBillingAccount](https://docs.microsoft.com/powershell/module/partnercenter/get-partnerazurebillingaccount) command to get billing accounts where the authenticated user has access
  * Added the [Get-PartnerAzureBillingProfile](https://docs.microsoft.com/powershell/module/partnercenter/get-partnerazurebillingprofile) to get billing profiles for specified billing account
  * Added the [New-PartnerAzureSubscription](https://docs.microsoft.com/powershell/module/partnercenter/new-partnerazuresubscription) to create a new Azure subscription for Microsoft Partner Agreement billing account
* Security
  * Updated the [Get-PartnerUser](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgrade) command to ensure all user accounts are returned
  * Updated the [Get-PartnerUserSignActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignActivity) command to ensure all user sign-in activities are returned

## 2.0.1911.3 - November 2019

* Authentication
  * Addressed issue [#186](https://github.com/microsoft/Partner-Center-PowerShell/issues/186) that was preventing access token from being generated when using the device code flow
* Security
  * Addressed issue preventing the [Test-PartnerSecurityRequirement](https://docs.microsoft.com/powershell/module/partnercenter/test-partnersecurityrequirement) command from working as expected

## 2.0.1911.2 - November 2019

* Dependencies
  * Addressed issues [#183](https://github.com/microsoft/Partner-Center-PowerShell/issues/181) and [#183](https://github.com/microsoft/Partner-Center-PowerShell/issues/183) caused by an assembly binding issue

## 2.0.1911.1 - November 2019

* Authentication
  * Addressed issue preventing CTRL+C from interrupting the waiting for a response during the interactive authentication scenario
* Invoicing
  * [Daily Rated Usage Line Item](https://github.com/microsoft/Partner-Center-PowerShell/blob/master/src/PowerShell/Models/Invoices/PSDailyRatedUsageLineItem.cs)
    * Added the *EntitlementId*, *EntitlementDescription*, *PCToBCExchangeRate*, *PCToBCExchangeRateDate*, *EffectiveUnitPrice*, and *RateOfPartnerEarnedCredit* properties
    * Modified the type for the *AdditionalInfo* and *Tags* properties from string to *Dictionary<string, string>*
  * [One Time Invoice Line Item](https://github.com/microsoft/Partner-Center-PowerShell/blob/master/src/PowerShell/Models/Invoices/PSOneTimeInvoiceLineItem.cs)
    * Added the *BillableQuantity*, *MeterDescription*, *PCToBCExchangeRateDate*, *PCToBCExchangeRate*, *PriceAdjustmentDescription*, and *PricingCurrency* properties
* Product Upgrades
  * Added the [Get-PartnerProductUpgrade](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgrade) command to get information on product upgrades for the specified customer
  * Added the [Get-PartnerProductUpgradeEligibility](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgrade) command to determine if the specified customer has a product eligible for an upgrade
  * Added the [Get-PartnerProductUpgradeStatus](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgradeStatus) command to get the status for product upgrades for the specified customer
  * Added the [New-PartnerProductUpgrade](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerProductUpgrade) command to perform an upgrade for the specified customer
* Security
  * Added the [Get-PartnerUser](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerProductUpgrade) command to get partner user accounts
    * Added the [Get-PartnerUserSignActivity](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignActivity) command to get sign-in activities for the specified user account
* Subscriptions
  * Added the [Get-PartnerCustomerAzurePlanEntitlement](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerAzurePlanEntitlement) command to get entitlement information for an Azure Plan
* Usage
  * Added the [Get-PartnerCustomerUsageRecord](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerUsageRecord) command to get month usage records for all customers
  * Removed the `Get-PartnerCustomerSubscriptionUsage` command due to changes with the Partner Center SDK for .NET. This command will be replaced with the [Get-PartnerCustomerSubscriptionMeterUsage](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionMeterUsage) and [Get-PartnerCustomerSubscriptionResourceUsage](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionResourceUsage) commands

## 2.0.1909.5 - September 2019

* Dependency
  * Corrected an issue that was preventing a dependency from being updated after a successful build

## 2.0.1909.4 - September 2019

* Authentication
  * Log events from the Microsoft Authentication Library (MSAL) will now be written to the console when the debug flag is set

## 2.0.1909.3 - September 2019

* Authentication
  * Address issue [#156](https://github.com/microsoft/Partner-Center-PowerShell/issues/156) where the refresh token was not being returned if it had not been previously used by the module during an interactive authentication attempt
  * After successfully authenticating the module will attempt to get country and locale based on the partner organization profile
* Security
  * Adding the [Test-PartnerSecurityRequirement](https://docs.microsoft.com/powershell/module/partnercenter/Test-PartnerSecurityRequirement) command to help validate that the authenticating account was challenged for multi-factor authentication

## 2.0.1909.2 - September 2019

* Authentication
  * Addressed issue [#153](https://github.com/microsoft/Partner-Center-PowerShell/issues/153) that was preventing the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command from working as expected.

## 2.0.1909.1 - September 2019

* Agreements
  * Added the [Get-PartnerAgreementTemplate](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerAgreementTemplate) command to provide access to the links download or view the Microsoft Customer Agreement
  * Added the ability to request the Microsoft Customer Agreement template metadata
  * The *AgreementType* enumeration has been removed, and where it was used the type has changed to a *string*
* Authentication
  * Added the ability to invoke [Connect-PartnerCenter](https://docs.microsoft.com/powershell/module/partnercenter/Connect-PartnerCenter) without requiring the creation of an Azure Active Directory application
  * Enabled interactive login support for cross-platform by default
  * Device code flow login is now the backup option of interactive login fails, or the user provides the `-UseDeviceAuthentication` switch parameter
  * Token cache is now shared with other products, such as Azure CLI and Visual Studio 2019
* Module
  * The `PartnerCenter` module now supports PowerShell 5.1 and PowerShell, as a result the `PartnerCenter.NetCore` module will be retired
* Subscriptions
  * Added the [New-PartnerCustomerSubscriptionActivation](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionActivation) command to make it where third-party subscriptions can be activated in the integration sandbox

## 1.5.1908.1 - August 2019

* Authentication
  * Transitioned from Active Directory Authentication Library (ADAL) to the Microsoft Authentication Library (MSAL)
* Roles
  * Added the [Get-PartnerRole](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerRole) command to get partner roles
  * Added the [Get-PartnerRoleMember](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerRoleMember) command to get the members for the specified partner role

## 1.5.1907.2 - July 2019

* Devices
  * Modified the output for the [New-PartnerCustomerDeviceBatch](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerAgreement) command.

## 1.5.1907.1 - July 2019

* Agreements
  * Removed the *UserId* parameter from the [New-PartnerCustomerAgreement](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerAgreement) command
* Devices
  * Addressed an issue preventing the successful creation of a device batch

## 1.5.1905.1 - May 2019

* Users
  * Added the following properties to the user model
    * ImmutableId
    * PhoneNumber

## 1.5.1904.3 - April 2019

* Invoices
  * Addressed issue [#117](https://github.com/Microsoft/Partner-Center-PowerShell/issues/117), where the cannot access stream error was being thrown
* Subscriptions
  * Added breaking change warning for the removal the *AutoRenew* flag from the [Set-PartnerCustomerSubscription](https://docs.microsoft.com/powershell/module/partnercenter/set-partnercustomersubscription) command

## 1.5.1904.2 - April 2019

* Authentication
  * Addressed issue [#113](https://github.com/Microsoft/Partner-Center-PowerShell/issues/113), where the access token would expire for long running operations
* Network
  * Any operation that is aborted due to task cancellation exception will now be retired three times
* Utilization
  * Added the page size parameter to the Get-PartnerCustomerSubscriptionUtilization command

## 1.5.1904.1 - April 2019

* Auditing
  * Renamed the CreateInvoice operation type to ReadyInvoice
* Invoices
  * Renamed the reconciliation line item objects
* Users
  * No longer throw an error when searching for a user with UPN that does not exists
* Utilization
  * Modified the default end date value for the Get-PartnerCustomerSubscriptionUtilization command to use UTC time

## 1.5.1903.6 - March 2019

* Products
  * Addressed an issue with requesting products

## 1.5.1903.5 - March 2019

* Auditing
  * Added new operation and resource types
* Authentication
  * Added support for the pre-production environment
* Customers
  * Added the ability to manage customer qualifications
  * Corrected issue #90 that was causing directory role operations to not function as excepted
  * Corrected issue #91 that was causing searching for a customer by domain to not function as expected
* Carts
  * Added the Status property to the Cart model
  * Added the TermDuration property to the CartLineItem model
* Entitlements
  * Added the ability to obtain the expiration date for the entitlement (if applicable)
  * Added the AlternateId property to the reference order object
  * Added the following properties to the Entitlement model
    * FulfillmentState
    * ExpiryDate
* Invoice
  * Added the ability to download the tax receipt
  * Added the following properties to the OneTimeInvoiceLineItem model
    * AlternateId
    * ChargeEndDate
    * ChargeStartDate
    * PublisherId
    * PublisherName
    * SubscriptionDescription
    * SubscriptionId
    * TermAndBillingCycle
    * UnitType
  * Removed Azure Data Market billing provider type and models because this is no longer supported
* Orders
  * Added the ability to get the activation link for an order line item
  * Added the ability to get the provisioning status of an order
  * Added the ability to include pricing details when requesting order information
  * Addressed an issue with requesting an order by the billing cycle
* Products
  * Added the following properties to the Availability model
    * IsPurchasable
    * IsRenewable
    * Terms
  * Added the following properties to the Product model
    * IsMicrosoftProduct
    * PublisherName
  * Corrected an issue with requesting products by country, target view, and target segment
  * Removed the SKU download operations. No commands where impacted by this change
* Subscriptions
  * Added the following properties to the subscription model
    * IsMicrosoftProduct
    * PublisherName
    * RefundOptions
    * TermDuration
* Users
  * Corrected an issue with performing a query for users from a customer
* Utilization
  * Addressed an issue caused by the Partner Center API return a HTTP 204 no content when Azure utilization data is not yet ready in a dependent system.
* Validations
  * Added the ability to request validation codes used to create Government Community Cloud customers

## Version 1.5.1902.5 - February 2019

* Added the New-PartnerCustomerApplicationConsent command
  * This command can be used to create a new application consent for the specified customer
* Update to version 10.0.3 of Newtonsoft.Json
