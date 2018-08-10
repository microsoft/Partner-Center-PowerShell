<#
.SYNOPSIS
Tests to be performed using the Test-PartnerAddress cmdlet.
#>
function Test-TestPartnerAddress
{
    $isValid = Test-PartnerAddress -AddressLine1 '700 Bellevue Way NE' -City 'Bellevue' -Country 'US' -PostalCode '98004' -State 'WA'

    Assert-AreEqual $isValid $true
}