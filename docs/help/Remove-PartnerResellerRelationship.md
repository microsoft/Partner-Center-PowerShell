---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerResellerRelationship.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Remove-PartnerResellerRelationship
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Remove-PartnerResellerRelationship.md
schema: 2.0.0
---

# Remove-PartnerResellerRelationship

## SYNOPSIS
Removes the reseller relationship between the specified customer and the partner.

## SYNTAX

```powershell
Remove-PartnerResellerRelationship -CustomerId <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes the reseller relationship between the specified customer and the partner. You must first ensure that any active Azure Reserved VM Instances for that customer are cancelled. This command will suspend all active subscriptions.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-PartnerResellerRelationship -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Removes the reseller relationship between the specified customer and the partner.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## NOTES

## RELATED LINKS
