---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerCart.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerCart.md
schema: 2.0.0
---

# Get-PartnerCustomerCart

## SYNOPSIS
Gets a specific cart for the specified partner.

## SYNTAX

```powershell
Get-PartnerCustomerCart -CartId <String> -CustomerId <String> [<CommonParameters>]
```

## DESCRIPTION
The Get-PartnerCustomerCart cmdlet will get a specific cart for the specified partner.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerCart -CartId 'b4c8fdea-cbe4-4d17-9576-13fcacbf9605' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08'
```

Gets the cart with the identifier of b4c8fdea-cbe4-4d17-9576-13fcacbf9605 that belongs to the customer with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08.

## PARAMETERS

### -CartId
The identifier for the cart.

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

### -CustomerId
The identifier for the customer.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Carts.PSCart

## NOTES

## RELATED LINKS
