---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerDeviceBatch.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version:
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/New-PartnerCustomerDeviceBatch.md
schema: 2.0.0
---

# New-PartnerCustomerDeviceBatch

## SYNOPSIS
Creates a new device batch for the specified customer.

## SYNTAX

```powershell
New-PartnerCustomerDeviceBatch -BatchId <String> -CustomerId <String> -Devices <PSDevice[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new device batch for the specified customer. The following combinations of populated properties are required at a minimum for identifying each device: HardwareHash + ProductKey, HardwareHash + SerialNumber, HardwareHash + ProductKey + SerialNumber, HardwareHash only, ProductKey only, or SerialNumber + OemManufacturerName + ModelName.

## EXAMPLES

### Example 1
```powershell
PS C:\> $device = New-Object -TypeName Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment.PSDevice
PS C:\> $device.HardwardHash = 'HardwareHas1234'
PS C:\> $device.ProductKey = '00329-00000-0003-AA606'
PS C:\> $device.SerialNumber = '1R9-ZNP67'
PS C:\> 
PS C:\> New-PartnerCustomerDeviceBatch -BatchId 'TestDviceBatch' -CustomerId '46a62ece-10ad-42e5-b3f1-b2ed53e6fc08' -Devices $device
```

Creates a new device batch for the specified customer.

## PARAMETERS

### -BatchId
The identifier for the batch.

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

### -Devices
The devices to be included in the device batch.

```yaml
Type: PSDevice[]
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

### System.String

## NOTES

## RELATED LINKS
