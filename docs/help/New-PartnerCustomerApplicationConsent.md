---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerApplicationConsent.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/New-PartnerCustomerApplicationConsent
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerApplicationConsent.md
schema: 2.0.0
---

# New-PartnerCustomerApplicationConsent

## SYNOPSIS
Creates a new application consent for the specified customer.

## SYNTAX

```powershell
New-PartnerCustomerApplicationConsent -ApplicationGrants <ApplicationGrant[]> -ApplicationId <String>
 -CustomerId <String> -DisplayName <String> [<CommonParameters>]
```

## DESCRIPTION
This cmdlet creates a new application consent for the specified customer.

## EXAMPLES

### Example 1
```powershell
PS C:\> $grant = New-Object -TypeName Microsoft.Store.PartnerCenter.Models.ApplicationConsents.ApplicationGrant
PS C:\> $grant.EnterpriseApplicationId = '00000002-0000-0000-c000-000000000000'
PS C:\> $grant.Scope = "Domain.ReadWrite.All,User.ReadWrite.All,Directory.Read.All"
PS C:\> New-PartnerCustomerApplicationConsent -ApplicationId 'c33c2273-9329-42ec-948d-152ead47cf65' -ApplicationGrants @($grant) -CustomerId 'f1c5e45f-7dea-4863-a55d-b5a5479201df' -DisplayName 'CPV Web App'
```

{{ Add example description here }}

## PARAMETERS

### -ApplicationGrants
The grants for the application.

```yaml
Type: ApplicationGrant[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationId
The identifier for application.

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

### -DisplayName
The display name for the application.

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

### Microsoft.Store.PartnerCenter.Models.ApplicationConsents.ApplicationConsent

## NOTES

## RELATED LINKS
