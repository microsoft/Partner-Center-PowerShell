---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Register-PartnerTokenCache.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Register-PartnerTokenCache
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Register-PartnerTokenCache.md
schema: 2.0.0
---

# Register-PartnerTokenCache

## SYNOPSIS
Registers the specified token cache for the module.

## SYNTAX

### ByPersistent (Default)
```powershell
Register-PartnerTokenCache [-Persistent] [<CommonParameters>]
```

### ByInMemory
```powershell
Register-PartnerTokenCache [-InMemory] [<CommonParameters>]
```

## DESCRIPTION
Registers the specified token cache for the module.

## EXAMPLES

### Example 1
```powershell
PS C:\> Register-PartnerTokenCache -InMemory
```

Registers the in-memory token cache for the module.

### Example 2
```powershell
PS C:\> Register-PartnerTokenCache -Persistent
```

Registers the persistent token cache for the module.

## PARAMETERS

### -InMemory
A flag indicating that the in-memory token cache should be registered.

```yaml
Type: SwitchParameter
Parameter Sets: ByInMemory
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Persistent
A flag indicating that the persistent token cache should be registered.

```yaml
Type: SwitchParameter
Parameter Sets: ByPersistent
Aliases:

Required: True
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

### System.Object
## NOTES

## RELATED LINKS
