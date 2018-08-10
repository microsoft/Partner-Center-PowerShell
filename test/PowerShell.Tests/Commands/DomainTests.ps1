<#
.SYNOPSIS
Tests to be performed using the Test-PartnerDomainAvailability cmdlet.
#>
function Test-TestPartnerDomainAvailability
{
    $result = Test-PartnerDomainAvailability -Domain 'testdomain.onmicrosoft.com'

    Assert-AreEqual $result $false
}