---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerUserLicense.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Set-PartnerCustomerUserLicense.md
schema: 2.0.0
---

# Set-PartnerCustomerUserLicense

## SYNOPSIS
Adds or removes licenses for a Microsoft online service to the list of assigned licenses for a user. 

## SYNTAX

```powershell
Set-PartnerCustomerUserLicense -CustomerId <String> -LicenseUpdate <PSLicenseUpdate> -UserId <String> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Adds or removes licenses for a Microsoft online service to the list of assigned licenses for a user.

## EXAMPLES

### Example 1
```powershell
PS C:\> # Create the objects that will be needed
PS C:\> $license = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses.PSLicenseAssignment
PS C:\> $licenses = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses.PSLicenseUpdate
PS C:\>
PS C:\> # Find the SkuId of the license we want to add - in this example we will use the O365_BUSINESS_PREMIUM license
PS C:\> $license.SkuId = (Get-PartnerCustomerLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' | Where-Object -Property SkuPartNumber -Value "O365_BUSINESS_PREMIUM" -EQ).SkuId
PS C:\> 
PS C:\> # Add the license to the update statement. 
PS C:\> $licenses.LicensesToAssign.Add($license)
PS C:\> 
PS C:\> # Call the command to update the license assignment. 
PS C:\> Set-PartnerCustomerUserLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseUpdate $licenses -UserId '67e57a6a-6f26-4d6c-af64-533bb7f6a99e'
```

Adds or removes licenses for a Microsoft online service to the list of assigned licenses for a user. 

## PARAMETERS

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

### -LicenseUpdate
The information used to update the license assignments.

```yaml
Type: PSLicenseUpdate
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The identifier for the user.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses.PSLicenseUpdate

## NOTES

## RELATED LINKS
