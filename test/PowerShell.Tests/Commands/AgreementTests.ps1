<#
.SYNOPSIS
    Tests to be performed using the Test-GetPartnerAgreementDetail cmdlet.
#>
function Test-GetPartnerAgreementDetail
{
    $agreementDetails = Get-PartnerAgreementDetail

    Assert-NotNull $agreementDetails
}