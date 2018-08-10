# Purchase Azure reservations

## Applies To

- Partner Center

To purchase an Azure reservation using the Partner Center PowerShell module, you must have one or more deployed Cloud Solution Provider (CSP) Azure subscriptions. If you do not have a CSP Azure subscription, follow these steps to purchase one:

- Get a list of offers for a market.
- Create an order for an CSP Azure subscription.
- Submit the order
- Verify that the order is fulfilled.

> **NOTE**
> Azure Reserved VM Instances are not available in all markets, please check for the latest list of markets where Reserved VM instances are available.  

## How to purchase Microsoft Azure reservations

After you have identified an active CSP Azure subscription for which to add the Azure reservation, use the following steps to complete the RI purchase:

1. [Enablement](#enablement) - Register an active CSP Azure subscription to enable it for purchasing Azure reservations.
2. [Discovery](#discovery) - Find and select the Azure reservation products and SKUs you want to purchase and check their availability.
3. [Order submission](#order_submission) - Create a shopping cart with the items in your order and submit it.

### Enablement

Once you have identified the active subscription for which to add the Azure reservation, you must register the subscription to enable Azure reservations. To register an existing subscription, run the [New-PartnerCustomerSubscriptionRegistration](../help/NewPartnerCustomerSubscriptionRegistration.md) cmdlet

```powershell
New-PartnerCustomerSubscriptionRegistration -CustomerId '<Customer-Id>' -SubscriptionId '<Subscription-Id>'
```

After registering the subscription, confirm that the registration completed successfully by checking the registration status. To do this, run the [Get-PartnerCustomerSubscriptionRegistrationStatus](../help/GetPartnerCustomerSubscriptionRegistrationStatus.md) cmdlet

```powershell
Get-PartnerCustomerSubscriptionRegistrationStatus -CustomerId '<Customer-Id>' -SubscriptionId '<Subscription-Id>'
```

### Discovery

Once the subscription is enabled for purchasing Azure reservations, you need the Product identifiers and SKUs for the Reserved VM Instances. You must also verify that the SKUs are in inventory and available. To retrieve the product identifiers, SKUs, and to verify inventory and availability, complete the following steps:

1. Identify  the Product and SKU information for the Reserved VM Instance that you will purchase. To do this, run the [Get-PartnerProduct](../help/Get-PartnerProduct.md) and [Get-PartnerProductSku](../help/Get-PartnerProductSku.md) cmdlets.

    ```powershell
    Get-PartnerProduct -Catalog 'Azure' -Segment 'commercial'
    ```

    ```powershell
    Get-PartnerProductSku -ProductId '<Product-Id>'
    ```

2. Verify SKU​ inventory for each one that is tagged with a **InventoryCheck** prerequisite​. To do this, run the [Get-PartnerProductInventory](../help/Get-PartnerProductInventory.md) cmdlet.

    ```powershell
    $variables = @{ customerId='<Customer-Id>'; azureSubscriptionId='<Subscription-Id>'; armRegionName='<Azure-region>' }

    Get-PartnerProductInventory -ProductId '<Product-Id>' -Variables $variables
    ```

3. View the SKU availability and make note of the corresponding **CatalogItemId**​. To get this value, run the [Get-PartnerProductAvailability](../help/Get-PartnerProductAvailability.md) cmdlet.

    ```powershell
    Get-PartnerProductAvailability -Product '<Product-Id>' -SkuId '<Sku-Id>'
    ```

### Order submission

To submit your Azure reservation order, do the following:

1. Create a cart to hold the collection of catalog items that you intend to buy. When you create a cart, the cart line items are automatically grouped based on what can be purchased in the same order. To do this, run the [New-PartnerCustomerCart](../help/New-PartnerCustomerCart.md) cmdlet.

    ```powershell
    $lineItems = @()
    $lineItems += New-PartnerCustomerCartLineItem -BillingCycle 'OneTime' -CatalogItemId '<Catalog-Item-Id>' -CustomerId '<Customer-Id>' -FriendlyName '<Friendly-Name>' -ProvisioningContext @{duration='1Year'; scope='shared'; subscriptionId='<Subscription-Id>'} -Quantity 1

    New-PartnerCustomerCart -CustomerId '<Customer-Id>' -LineItems $lineItems
    ```

2. Submit the cart. Checking out (submitting) a cart results in an order. To do this, run the [Submit-PartnerCustomerCart](../help/Submit-PartnerCustomerCart.md) cmdlet.

    ```powershell
    Submit-PartnerCustomerCart -CartId '<Cart-Id>' -CustomerId '<Customer-Id>'
    ```