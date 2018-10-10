---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Test-PartnerDomainAvailability

## SYNOPSIS
Tests if the specified domain name is available for creating a new tenant.

## SYNTAX

```
Test-PartnerDomainAvailability [-Domain] <String> [<CommonParameters>]
```

## DESCRIPTION

The Test-PartnerDomainAvailability cmdlet tests to see if the specified domain name is available for creating a new tenant.

## EXAMPLES

### Example 1
```powershell
PS C:\> Test-PartnerDomainAvailability -Domain 'contoso.onmicrosoft.com'
```

Tests if the domain contoso.onmicrosoft.com is available. Returns true if yes, false otherwise.

## PARAMETERS

### -Domain
A string that identifies the domain to check, e.g. "contoso.onmicrosoft.com". The domain prefix cannot be longer than 27 characters.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
