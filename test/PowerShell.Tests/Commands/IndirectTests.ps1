<#
.SYNOPSIS
Tests to be performed using the Get-PartnerIndirectReseller cmdlet.
#>
function Test-GetPartnerIndirectReseller
{
    $resellers = Get-PartnerIndirectReseller

    Assert-NotNull $resellers
    Assert-NotNullOrEmpty $resellers[0].Name
}