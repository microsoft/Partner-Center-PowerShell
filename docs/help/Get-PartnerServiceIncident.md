---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceIncident.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerServiceIncident.md
schema: 2.0.0
---

# Get-PartnerServiceIncident

## SYNOPSIS
Gets a list of service incidents.

## SYNTAX

```powershell
Get-PartnerServiceIncident [-Status <ServiceIncidentStatus>] [-Resolved] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of service incidents.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerServiceIncident -Status Warning -Resolved
```

Gets a list of service incidents that have a status of warning and are marked as resolved.

## PARAMETERS

### -Resolved
If specified resolved incidents are also returned.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Specifies which status types to return.

```yaml
Type: ServiceIncidentStatus
Parameter Sets: (All)
Aliases:
Accepted values: Critical, Information, Normal, Warning

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

### Microsoft.Store.PartnerCenter.Models.ServiceIncidents.ServiceIncidentDetail

## NOTES

## RELATED LINKS
