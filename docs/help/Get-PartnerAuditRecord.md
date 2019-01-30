---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAuditRecord.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerAuditRecord.md
schema: 2.0.0
---

# Get-PartnerAuditRecord

## SYNOPSIS
Gets audit records from Partner Center.

## SYNTAX

```powershell
Get-PartnerAuditRecord [-EndDate <DateTime>] [-StartDate <DateTime>] [<CommonParameters>]
```

## DESCRIPTION
Gets audit records for the previous 30 days from the current date, or for a date range specified by including the start date and/or the end date. Note, however, that for performance reasons activity log data availability is limited to the previous 90 days.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerAuditRecord -Start (Get-Date).AddDays(-89)
```

Gets the audit records from Partner Center for the past 89 days.

## PARAMETERS

### -EndDate
The end date of the audit record logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
The start date of the audit record logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Auditing.PSAuditRecord

## NOTES

## RELATED LINKS
