# Confirm customer acceptance of Microsoft Cloud agreement

## Applies To

- Partner Center

> [!NOTE]  
> The **Agreement** resource is currently supported by Partner Center in the Microsoft public cloud only. It is not applicable to:
> - Partner Center operated by 21Vianet
> - Partner Center for Microsoft Cloud Germany
> - Partner Center for Microsoft Cloud for US Government

How to confirm customer acceptance of the Microsoft Cloud agreement.

## Prerequisites

- A customer identifier (customer-tenant-id).
- Date when customer accepted the Microsoft Cloud Agreement.
- Information about the user from the organization who accepted the Microsoft Cloud Agreement, including:
  - First name
  - Last name
  - Email address
  - Phone number (optional)

## Examples

Follow these steps to confirm or reconfirm a customer has accepted the Microsoft Cloud Agreement:

1. Run the [Get-PartnerAgreementDetail](../help/Get-PartnerAgreementDetail.md) cmdlet to retrieve the **Template Id** for the agreement.

    ```powershell
    Get-PartnerAgreementDetail
    ```

2. Run the [New-PartnerCustomerAgreement](../help/New-PartnerCustomerAgreement.md) cmdlet and supply the **Template Id**, **Customer Id**, and details on the person who accepted the Microsoft Cloud Agreement for the customer.

    ```powershell
    New-PartnerCustomerAgreement -TemplateId '<Template-Id>'-AgreementType MicrosoftCloudAgreement -CustomerId '<Customer-Id>' -ContactEmail '<Email>' -ContactFirstName '<First-Name>' -ContactLastName '<Last-Name>'
    ```