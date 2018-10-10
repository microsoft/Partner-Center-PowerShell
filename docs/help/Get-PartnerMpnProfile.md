---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerMpnProfile

## SYNOPSIS
Gets the partner MPN from Partner Center.

## SYNTAX

```
Get-PartnerMpnProfile [-MpnId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets the partner MPN from Partner Center.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerMpnProfile
```

Gets the partner MPN from Partner Center.

## PARAMETERS

### -MpnId
The partner's MPN identifier.

```yaml
Type: String
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Partners.PSMpnProfile

## NOTES

## RELATED LINKS
