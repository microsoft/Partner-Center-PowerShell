---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerEntitlements.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerEntitlements.md
schema: 2.0.0
---

# Get-PartnerCustomerEntitlement

## SYNOPSIS
Gets a collection of entitlements.

## SYNTAX

```powershell
Get-PartnerCustomerEntitlement -CustomerId <String> [-OrderId <String>] [<CommonParameters>]
```

## DESCRIPTION
An entitlement represents the customer's right to use a product (service). It should be consumed by service providers as the source of truth regarding the customer's right to a service. The entitlement state changes based on information received from a variety of sources, for example, subscription events. A customer may stop paying, upgrade, etc, which results in changes to the entitlement fraud. The Commerce platform may rescind an entitlement due to fraud.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerEntitlements -CustomerId c4f6bf3c-60de-432e-a3ec-20bcc5b26ec2
```

Return customer entitlements based on customer identifier.

## PARAMETERS

### -CustomerId
Identifier for the customer.

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

### -OrderId
Identifier for the order.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Entitlements.PSEntitlement

## NOTES

## RELATED LINKS
