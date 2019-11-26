<#
.SYNOPSIS
    Tests to be performed using the Get-PartnerOfferCategory cmdlet.
#>
function Test-GetPartnerOfferCategory
{
    $categories = Get-PartnerOfferCategory -CountryCode 'US'

    Assert-NotNull $categories
}