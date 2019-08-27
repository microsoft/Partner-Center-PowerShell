<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Upcoming Breaking Changes", and should adhere to the following format:

    # Upcoming Breaking Changes

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

# Upcoming Breaking Changes

## Release 2.0 - September 2019

* Authentication

## Release 1.5.1906.1 - June 2019

* Agreements
  * The *UserId* parameter will be removed from the [New-PartnerCustomerAgreement](https://docs.microsoft.com/powershell/module/partnercenter/new-partnercustomeragreement) command. Enhancements to the API have been to derive this value based on the authenticated user

## Release 1.5.1905.1 - May 2019

* Subscriptions
  * The *AutoRenew* flag will be removed from the [Set-PartnerCustomerSubscription](https://docs.microsoft.com/powershell/module/partnercenter/set-partnercustomersubscription) command
