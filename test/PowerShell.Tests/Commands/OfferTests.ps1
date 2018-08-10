$O365BusinessPremiumOfferId = "031C9E47-4802-4248-838E-778FB1D2CC05"

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerOffer cmdlet.
#>
function Test-GetPartnerOffer
{
    $offers = Get-PartnerOffer -CountryCode US
    
    # This value should be two instead of four because the
    # cmdlet will filter out any add-ons and trials by default. 
    Assert-AreEqual 2 $offers.Count

    $addOns = Get-PartnerOffer -CountryCode US -AddOn
    Assert-AreEqual 1 $addOns.Count

    $trials = Get-PartnerOffer -CountryCode US -Trial 
    Assert-AreEqual 1 $trials.Count

    $offer = Get-PartnerOffer -CountryCode US -OfferId $O365BusinessPremiumOfferId
   
    Assert-NotNullOrEmpty $offer.Description 'Description should not be null'    
    Assert-NotNullOrEmpty $offer.OfferId 'Id should not be null'    
    Assert-NotNullOrEmpty $offer.Name 'Name should not be null'    
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerOfferAddon cmdlet.
#>
function Test-GetPartnerOfferAddon
{
    $addOns = Get-PartnerOfferAddon -OfferId '195416C1-3447-423A-B37B-EE59A99A19C4'

    Assert-NotNull $addOns
    Assert-NotNullOrEmpty $addOns[0].Description
    Assert-NotNullOrEmpty $addOns[0].Name
    Assert-NotNullOrEmpty $addOns[0].OfferId
}