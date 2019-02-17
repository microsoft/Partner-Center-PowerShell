---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUserLicense.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerUserLicense
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerUserLicense.md
schema: 2.0.0
---

# Get-PartnerCustomerUserLicense

## SYNOPSIS
Gets a list of licenses assigned to a user within a customer account.

## SYNTAX

```powershell
Get-PartnerCustomerUserLicense -CustomerId <String> [-LicenseGroup <LicenseGroupId[]>] -UserId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Gets a list of licenses assigned to a user within a customer account.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerCustomerUserLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -UserId 'd9be87b7-d838-4830-8d45-d18e8e71f3b2'
```

Gets a list of licenses assigned to a user within a customer account.

### Example 2
```powershell
PS C:\> Get-PartnerCustomerUserLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group1 -UserId 'd9be87b7-d838-4830-8d45-d18e8e71f3b2'
```

Gets a list of Azure Active Directory (AAD) licenses assigned to a user within a customer account.

### Example 3
```powershell
PS C:\> Get-PartnerCustomerUserLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group2 -UserId 'd9be87b7-d838-4830-8d45-d18e8e71f3b2'
```

Gets a list of Minecraft licenses assigned to a user within a customer account.

### Example 4
```powershell
PS C:\> Get-PartnerCustomerUserLicense -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -LicenseGroup Group1 -UserId 'd9be87b7-d838-4830-8d45-d18e8e71f3b2'
```

Gets a list of Azure Active Directory (AAD) and Minecraft licenses assigned to a user within a customer account.

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

### -LicenseGroup
The identifier for the license group.

```yaml
Type: LicenseGroupId[]
Parameter Sets: (All)
Aliases:
Accepted values: Group1, Group2

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses.PSLicense

## NOTES

## RELATED LINKS
