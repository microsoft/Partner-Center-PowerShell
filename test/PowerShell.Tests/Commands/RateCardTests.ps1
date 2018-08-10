<#
.SYNOPSIS
Tests to be performed using the Get-PartnerAzureRateCard cmdlet.
#>
function Test-GetPartnerAzureRateCard
{
    $rateCard = Get-PartnerAzureRateCard 

    Assert-NotNull $rateCard
    Assert-NotNull $rateCard.Meters

    Assert-NotNullOrEmpty $rateCard.Meters[0].Name
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerAzureRateCard cmdlet.
#>
function Test-GetPartnerAzureRateCardSharedServices
{
    $rateCard = Get-PartnerAzureRateCard -SharedServices

    Assert-NotNull $rateCard
    Assert-NotNull $rateCard.Meters

    Assert-NotNullOrEmpty $rateCard.Meters[0].Name
}