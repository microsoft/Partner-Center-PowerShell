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

```powershell
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

Gets the sign activities from the past seven days for the specified user.

### Example 3
```powershell
PS C:\> $users = Get-PartnerUser
PS C:\> $activities = $users.ForEach({Get-PartnerUserSignInActivity -EndDate (Get-Date) -StartDate (Get-Date).AddDays(-7) -UserId $_.Id})
PS C:\> $activities | ? {$_.AuthenticationDetails | ? {$_.Succeeded -eq $true}}
```

Gets the sign-activities from the past seven days that have successfully authenticated.

### Example 4
```powershell
PS C:> $users = Get-PartnerUser
PS C:> $activities = $users.ForEach({Get-PartnerUserSignInActivity -EndDate (Get-Date) -StartDate (Get-Date).AddDays(-7) -UserId $_.Id})
PS C:> $activities | ? {$_.AuthenticationDetails | ? {$_.Succeeded -eq $true}} | ? {$_.ResourceId -eq 'fa3d9a0c-3fb0-42cc-9193-47c7ecd2edbd'}
```

Gets the sign-in activities from the past seven days where the resource being accessed was the Partner Center API.

### Example 5
```powershell
PS C:> $users = Get-PartnerUser
PS C:> $activities = $users.ForEach({Get-PartnerUserSignInActivity -EndDate (Get-Date) -StartDate (Get-Date).AddDays(-7) -UserId $_.Id})
PS C:> $activities | ? {$_.AuthenticationDetails | ? {$_.Succeeded -eq $true}} | ? {$_.MfaDetail | ? {$_.AuthMethod -eq $null}} | ? {$_.ResourceId -eq 'fa3d9a0c-3fb0-42cc-9193-47c7ecd2edbd'}
```

Gets the sign-in activities from the past seven days where the resource being accessed was the Partner Center API and the sign-in activity was not challenged for multi-factor authentication.

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
