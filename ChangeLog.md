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

## 2.0.1909.5

* Dependency
  * Corrected an issue that was preventing a dependency from being updated after a successful build

## 2.0.1909.4

* Authentication 
  * Log events from the Microsoft Authentication Library (MSAL) will now be written to the console when the debug flag is set

## 2.0.1909.3

* Authentication
  * Address issue [#156](https://github.com/microsoft/Partner-Center-PowerShell/issues/156) where the refresh token was not being returned if it had not been previously used by the module during an interactive authentication attempt
  * After successfully authenticating the module will attempt to get country and locale based on the partner organization profile
* Security
  * Adding the [Test-PartnerSecurityRequirement](https://docs.microsoft.com/powershell/module/partnercenter/Test-PartnerSecurityRequirement) command to help validate that the authenticating account was challenged for multi-factor authentication

## 2.0.1909.2

* Authentication
  * Addressed issue [#153](https://github.com/microsoft/Partner-Center-PowerShell/issues/153) that was preventing the [New-PartnerAccessToken](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerAccessToken) command from working as expected.

## 2.0.1909.1

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

## 1.5.1908.1

* Authentication
  * Transitioned from Active Directory Authentication Library (ADAL) to the Microsoft Authentication Library (MSAL)
* Roles
  * Added the [Get-PartnerRole](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerRole) command to get partner roles
  * Added the [Get-PartnerRoleMember](https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerRoleMember) command to get the members for the specified partner role

## 1.5.1907.2

* Devices
  * Modified the output for the [New-PartnerCustomerDeviceBatch](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerAgreement) command.

## 1.5.1907.1

* Agreements
  * Removed the *UserId* parameter from the [New-PartnerCustomerAgreement](https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerAgreement) command
* Devices
  * Addressed an issue preventing the successful creation of a device batch

## 1.5.1905.1

* Users
  * Added the following properties to the user model
    * ImmutableId
    * PhoneNumber

## 1.5.1904.3

* Invoices
  * Addressed issue [#117](https://github.com/Microsoft/Partner-Center-PowerShell/issues/117), where the cannot access stream error was being thrown
* Subscriptions
  * Added breaking change warning for the removal the *AutoRenew* flag from the [Set-PartnerCustomerSubscription](https://docs.microsoft.com/powershell/module/partnercenter/set-partnercustomersubscription) command

## 1.5.1904.2

* Authentication
  * Addressed issue [#113](https://github.com/Microsoft/Partner-Center-PowerShell/issues/113), where the access token would expire for long running operations
* Network
  * Any operation that is aborted due to task cancellation exception will now be retired three times
* Utilization
  * Added the page size parameter to the Get-PartnerCustomerSubscriptionUtilization command

## 1.5.1904.1

* Auditing
  * Renamed the CreateInvoice operation type to ReadyInvoice
* Invoices
  * Renamed the reconciliation line item objects
* Users
  * No longer throw an error when searching for a user with UPN that does not exists
* Utilization
  * Modified the default end date value for the Get-PartnerCustomerSubscriptionUtilization command to use UTC time

## 1.5.1903.6

* Products
  * Addressed an issue with requesting products

## 1.5.1903.5

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

## Version 1.5.1902.5

* Added the New-PartnerCustomerApplicationConsent command
  * This command can be used to create a new application consent for the specified customer
* Update to version 10.0.3 of Newtonsoft.Json
