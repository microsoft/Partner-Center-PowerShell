---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerManagedService.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerManagedService.md
schema: 2.0.0
---

# Get-PartnerCustomerManagedService

## SYNOPSIS
Gets the managed services for a customer.

## SYNTAX

```powershell
Get-PartnerCustomerManagedService [-CustomerId] <String> [-ManagedServiceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets the managed services for a customer. In other words, get links to all of the customer's subscriptions for which you have delegated admin privileges. You can use these links to provide support and file service requests with Microsoft.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerManagedService 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08
```

Gets the managed services for the customer with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerManagedService -CustomerId 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08 -ManagedServiceId Exchange
```

Gets the Exchange managed services for the customer with the identifier of 46a62ece-10ad-42e5-b3f1-b2ed53e6fc08.

## PARAMETERS

### -CustomerId
Identifier for the customer.

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

### -ManagedServiceId
A string that identifies the managed service.

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

### Microsoft.Store.PartnerCenter.PowerShell.Models.ManagedServices.PSManagedService

## NOTES

## RELATED LINKS
