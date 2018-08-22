---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# Get-PartnerCustomerRelationship

## SYNOPSIS
Gets all the partner relationships associated to the customer based on the logged in partner.

## SYNTAX

```
Get-PartnerCustomerRelationship -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets all the partner relationships associated to the customer based on the logged in partner.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerRelationship -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets all the partner relationships associated to the customer based on the logged in partner.

## PARAMETERS

### -CustomerId
The identifier of the customer.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Relationships.PSPartnerRelationship

## NOTES

## RELATED LINKS
