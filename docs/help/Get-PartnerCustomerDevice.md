---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerDevice.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerDevice
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerDevice.md
schema: 2.0.0
---

# Get-PartnerCustomerDevice

## SYNOPSIS
Gets a list of devices in the specified device batch for the specified customer.

## SYNTAX

```powershell
Get-PartnerCustomerDevice [-CustomerId] <String> -BatchId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a list of devices in the specified device batch for the specified customer. Each device resource contains details about the device.

## EXAMPLES

### Example 1

```powershell
PS C:\> Get-PartnerCustomerDevice -CustomerId <Customer ID> -BatchId <Batch ID>
```

This example returns a list of devices in the specified device batch for the specified customer.

## PARAMETERS

### -BatchId
Identifier for the device batch.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment.PSDevice

## NOTES

## RELATED LINKS
