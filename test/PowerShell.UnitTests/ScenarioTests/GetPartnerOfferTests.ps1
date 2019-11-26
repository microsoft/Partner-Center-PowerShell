<#
.SYNOPSIS
    Tests to be performed using the Get-PartnerOffer cmdlet.
#>
function Test-GetPartnerOffer
{
    $offers = Get-PartnerOffer -CountryCode 'US'

    Assert-NotNull $offers
}

<#
.SYNOPSIS
    Tests to be performed using the Get-PartnerOfferCategory cmdlet.
#>
function Test-GetPartnerOfferCategory
{
    $categories = Get-PartnerOfferCategory -CountryCode 'US'

    Assert-NotNull $categories
}

<#
.SYNOPSIS
    Tests to be performed using the Get-PartnerOffer cmdlet.
#>
function Test-GetPartnerOfferWithAddOnFlag
{
    $offers = Get-PartnerOffer -CountryCode 'US' -AddOn

    Assert-NotNull $offers
}

<#
.SYNOPSIS
    Tests to be performed using the Get-PartnerOffer cmdlet.
#>
function Test-GetPartnerOfferWithOfferId
{
    $offer = Get-PartnerOffer -CountryCode 'US' -OfferId '8BDBB60B-E526-43E9-92EF-AB760C8E0B72'

    Assert-NotNull $offer
}