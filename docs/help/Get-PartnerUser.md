---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUser.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerUser
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerUser.md
schema: 2.0.0
---

# Get-PartnerUser

## SYNOPSIS
Gets a list of users from the partner tenant

## SYNTAX

```powershell
Get-PartnerUser [-UserId <String>] [-UserPrincipalName <String>] [<CommonParameters>]
```

## DESCRIPTION
Gets a list of users from the partner tenant

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-PartnerUser
```

Gets a list of users from the partner tenant

## PARAMETERS

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

### -UserPrincipalName
The user principal name for the user.

```yaml
Type: String
Parameter Sets: (All)
Aliases: UPN

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

### Microsoft.Graph.User

## NOTES

## RELATED LINKS
