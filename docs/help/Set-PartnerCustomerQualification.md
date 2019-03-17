---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerQualification.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Set-PartnerCustomerQualification
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerQualification.md
schema: 2.0.0
---

# Set-PartnerCustomerQualification

## SYNOPSIS
Updates the specified customer's qualification to be Education or GovernmentCommunityCloud.

## SYNTAX

### Customer (Default)
```powershell
Set-PartnerCustomerQualification -CustomerId <String> -Qualification <CustomerQualification>
 [-ValidationCode <ValidationCode>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CustomerObject
```powershell
Set-PartnerCustomerQualification -InputObject <PSCustomer> -Qualification <CustomerQualification>
 [-ValidationCode <ValidationCode>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified customer's qualification to be "Education" or "GovernmentCommunityCloud."

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerQualification -CustomerId 'c4f6bf3c-60de-432e-a3ec-20bcc5b26ec2' -Qualification GovernmentCommunityCloud
```

Updates the specified customer's qualification to be GovernmentCommunityCloud.

## PARAMETERS

### -CustomerId
The identifier of the customer.

```yaml
Type: String
Parameter Sets: Customer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The customer object to be modified.

```yaml
Type: PSCustomer
Parameter Sets: CustomerObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Qualification
The qualification assigned to the customer.

```yaml
Type: CustomerQualification
Parameter Sets: (All)
Aliases:
Accepted values: Education, GovernmentCommunityCloud

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationCode
The validation code used when assigning the Government Community Cloud qualification.

```yaml
Type: ValidationCode
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Store.PartnerCenter.PowerShell.Models.Customers.PSCustomer

## OUTPUTS

### Microsoft.Store.PartnerCenter.Models.Customers.CustomerQualification

## NOTES

## RELATED LINKS
