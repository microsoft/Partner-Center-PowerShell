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

* Auditing
  * Added new operation and resource types
* Authentication
  * Added support for the pre-production environment
* Customers
  * Added the ability to manage customer qualifications
  * Corrected issue #90 that was causing directory role operations to not function as excepted
  * Corrected issue #91 that was causing searching for a customer by domain to not function as expected
* Entitlements
  * Added the AlternateId property to the reference order object
* Invoice
  * Added the ability to download the tax receipt
* Orders
  * Addressed an issue with requesting an order by the billing cycle
* Products
  * Corrected an issue with requesting products by country, target view, and target segment
* Users
  * Corrected an issue with performing a query for users from a customer

## Version 1.5.1902.5

* Added the New-PartnerCustomerApplicationConsent command
  * This command can be used to create a new application consent for the specified customer
* Update to version 10.0.3 of Newtonsoft.Json