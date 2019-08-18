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