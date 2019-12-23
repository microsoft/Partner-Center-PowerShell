---
content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUtilization.md
external help file: Microsoft.Store.PartnerCenter.PowerShell.dll-Help.xml
Module Name: PartnerCenter
online version: https://docs.microsoft.com/powershell/module/partnercenter/Get-PartnerCustomerSubscriptionUtilization
original_content_git_url: https://github.com/Microsoft/Partner-Center-PowerShell/blob/master/docs/help/Get-PartnerCustomerSubscriptionUtilization.md
schema: 2.0.0
---

# Get-PartnerCustomerSubscriptionUtilization

## SYNOPSIS
Gets the utilization of a customer's Azure subscription.

## SYNTAX

```powershell
Get-PartnerCustomerSubscriptionUtilization -CustomerId <String> [-EndDate <DateTimeOffset>]
 [-Granularity <AzureUtilizationGranularity>] [-PageSize <Int32>] [-ShowDetails] -StartDate <DateTimeOffset>
 -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets the utilization of a customer's Azure subscription with a daily or hourly granularity.

## EXAMPLES

### Example 1

```powershell
PS C:\> Get-PartnerCustomerSubscriptionUtilization -CustomerId <Customer ID> -SubscriptionId <Subscription ID> -StartDate [System.DateTimeOffset]::Now.AddDays(-1) -Granularity Hourly -ShowDetails
```

Gets a customer's Azure utilization for a specific subscription from a start date (specified in UTC) with a hourly granularity.

### Example 2

```powershell
PS C:\> Get-PartnerCustomerSubscriptionUtilization -CustomerId <Customer ID> -SubscriptionId <Subscription ID> -StartDate [System.DateTimeOffset]::Now.AddDays(-1) -EndDate [System.DateTimeOffset]::Now -Granularity Daily -ShowDetails
```

Gets a customer's Azure utilization for a specific subscription from a start date (specified in UTC) with a daily granularity.

## PARAMETERS

### -CustomerId
The identifier of the customer.

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

### -EndDate
The end date (in UTC) of the usages to filter.

```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Granularity

The resource usage time granularity.
Can either be daily or hourly.
The default value is daily

```yaml
Type: AzureUtilizationGranularity
Parameter Sets: (All)
Aliases:
Accepted values: Daily, Hourly

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
The number of records returned with a single request to the partner service.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowDetails
Flag indicating whether or not utilization records will be aggregated on the resource level

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDate
The start date (in UTC) of the usages to filter.

```yaml
Type: DateTimeOffset
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The identifier of subscription.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Store.PartnerCenter.PowerShell.Models.Utilizations.PSAzureUtilizationRecord

## NOTES

## RELATED LINKS
