<#
.SYNOPSIS
Tests to be performed using the Get-PartnerAuditRecord cmdlet.
#>
function Test-GetPartnerAuditRecord
{
    Get-PartnerAuditRecord -StartDate (Get-Date).AddDays(-7)
}

<#
.SYNOPSIS
Tests to be performed using the Get-PartnerAuditRecord cmdlet.
#>
function Test-GetPartnerAuditRecordInvalidDateTest
{
    Get-PartnerAuditRecord -StartDate (Get-Date).AddDays(-100)
}