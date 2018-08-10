$TestProductId = "DZH318Z0BQ4C"
$TestSkuId = "00FF"
$TestAvailabilityId = "DZH318Z0RFQB"


# Catalogs can be "Azure", "OnlineServices", "Software"
$TestCatalog = "Azure"

$TestCountryCode = "US"

# Segments can be: "commercial", "education", "government", "nonprofit"
$TestTargetSegment = "commercial"


<#
.SYNOPSIS
Tests to be performed using the Get-PartnerProduct cmdlet.
#>
function Test-GetPartnerProduct
{
    $product = Get-PartnerProduct -Catalog $TestCatalog

    Assert-NotNullOrEmpty $product[0].productId 'ProductId should not be null'    
    Assert-NotNullOrEmpty $product[0].Title 'Title should not be null'   
    Assert-NotNullOrEmpty $product[0].Type 'Type should not be null'   
    Assert-NotNullOrEmpty $product[0].ProductType.Id 'ProductType.Id should not be null'
    Assert-NotNullOrEmpty $product[0].ProductType.DisplayName 'ProductType.DisplayName should not be null'
 
    if ($null -eq $product[0].Description)
    {
        Assert-NotNullOrEmpty $product[1].Description 'Description should not be null'
    }
}


<#
.SYNOPSIS
Tests to be performed using the Get-PartnerProductAvailability cmdlet.
#>
function Test-GetPartnerProductAvailability
{
   # Testing by Sku without target segment
   $ProductAvailability = Get-PartnerProductAvailability -ProductId $TestProductId -SkuId $TestSkuId -CountryCode $TestCountryCode

    Assert-NotNullOrEmpty $ProductAvailability.SkuId "SkuId should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Code "DefaultCurrency.Code should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Symbol "DefaultCurrency.Symbol should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencyCode "DefaultCurrencyCode should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencySymbol "DefaultCurrencySymbol should not be null"

   # Testing by Sku with target segment
   $ProductAvailability = Get-PartnerProductAvailability -ProductId $TestProductId -SkuId $TestSkuId -CountryCode $TestCountryCode -segment $TestTargetSegment
   
    Assert-NotNullOrEmpty $ProductAvailability.SkuId "SkuId should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Code "DefaultCurrency.Code should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Symbol "DefaultCurrency.Symbol should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencyCode "DefaultCurrencyCode should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencySymbol "DefaultCurrencySymbol should not be null"

   # Testing by AvailabilityId
    $ProductAvailability = Get-PartnerProductAvailability -ProductId $TestProductId -SkuId $TestSkuId -AvailabilityId $TestAvailabilityId -CountryCode $TestCountryCode
 
    Assert-NotNullOrEmpty $ProductAvailability.SkuId "SkuId should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencyCode "DefaultCurrencyCode should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrencySymbol "DefaultCurrencySymbol should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Code "DefaultCurrency.Code should not be null"
    Assert-NotNullOrEmpty $ProductAvailability.DefaultCurrency.Symbol "DefaultCurrency.Symbol should not be null"
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerProductInventory cmdlet.
#>
function Test-GetPartnerProductInventory
{
    $variables = @{ customerId='46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'; azureSubscriptionId='a38ad5c9-5198-4e80-8064-2599ba6b8833'; armRegionName='uswest2' }

    Get-PartnerProductInventory -ProductId 'DZH318Z0BQ3P' -Variables $variables
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerProductSku cmdlet.
#>
function Test-GetPartnerProductSku
{
    # Testing without specifying segment
    $ProductSku = Get-PartnerProductSku -ProductId  $TestProductId -CountryCode $TestCountryCode
    Assert-NotNullOrEmpty $ProductSku[0].SkuId "SkuId should not be null"
    Assert-NotNullOrEmpty $ProductSku[0].ProductId "ProductId should not be null"
    Assert-NotNullOrEmpty $ProductSku[0].Title "Title should not be null"

    # Testing  specifying segment
    $ProductSku = Get-PartnerProductSku -ProductId  $TestProductId -CountryCode $TestCountryCode -Segment $TestTargetSegment
    Assert-NotNullOrEmpty $ProductSku[0].SkuId "SkuId should not be null"
    Assert-NotNullOrEmpty $ProductSku[0].ProductId "ProductId should not be null"
    Assert-NotNullOrEmpty $ProductSku[0].Title "Title should not be null"
}
