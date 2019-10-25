---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUserSignInActivity.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUserSignInActivity
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUserSignInActivity.md
schema: 2.0.0
---

# Get-PartnerUserSignInActivity

## SYNOPSIS
Gets the sign activities for the specified user.

## SYNTAX

```
Get-PartnerUserSignInActivity [-EndDate <DateTime>] [-StartDate <DateTime>] [-UserId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the sign activities for the specified user.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerUserSignInActivity -UserId '3dd89389-b34c-4f5a-975d-516df5694d7e'
```

Gets the sign activities for the specified user.

### Example 2
```powershell
PS C:\> Get-PartnerUserSignInActivity -EndDate (Get-Date) -StartDate (Get-Date).AddDays(-7) -UserId '3dd89389-b34c-4f5a-975d-516df5694d7e'
```

Gets the sign activties from the past sever days for the specified user.

## PARAMETERS

### -EndDate
The end date of the activity logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
The start date of the activity logs.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

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

### Microsoft.Graph.SignIn

## NOTES

## RELATED LINKS
