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
* Customers
  * Added the ability to manage customer qualifications
  * Corrected issue #90 that was causing directory role operations to not function as excepted
* Entitlements
  * Added the AlternateId property to the reference order object
* Invoice
  * Added the ability to download the Taiwan tax receipt
* Orders
  * Addressed an issue with requesting an order by the billing cycle
* Products
  * Corrected an issue with requesting products by country, target view, and target segment

## Version 1.5.1902.5

* Added the New-PartnerCustomerApplicationConsent command
  * This command can be used to create a new application consent for the specified customer
* Update to version 10.0.3 of Newtonsoft.Json