---
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
schema: 2.0.0
---

# New-PartnerCustomerOrder

## SYNOPSIS
Create a new order for the specified services on behalf of the customer.

## SYNTAX

```
New-PartnerCustomerOrder -CustomerId <String> -LineItems <PSOrderLineItem[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new order for the specified services on behalf of the customer.

## EXAMPLES

### Example 1

```powershell
PS C:\> $lineItem = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrderLineItem
PS C:\>
PS C:\> $lineItem.LineItemNumber = 0
PS C:\> $lineItem.OfferId = '031C9E47-4802-4248-838E-778FB1D2CC05'
PS C:\> $lineItem.Quantity = 1
PS C:\>
PS C:\> New-PartnerCustomerOrder -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LineItems $lineItem
```

Create a new order for the specified services on behalf of the customer.

## PARAMETERS

### -CustomerId
The identifier of the customer making the purchase.

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

### -LineItems
The order line items.
Each order line item refers to one offer's purchase data.

```yaml
Type: PSOrderLineItem[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Orders.PSOrder

## NOTES

## RELATED LINKS
