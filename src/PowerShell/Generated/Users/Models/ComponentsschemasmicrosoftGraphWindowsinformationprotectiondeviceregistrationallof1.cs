// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// windowsInformationProtectionDeviceRegistration
    /// </summary>
    /// <remarks>
    /// Represents device registration records for Bring-Your-Own-Device(BYOD)
    /// Windows devices.
    /// </remarks>
    public partial class ComponentsschemasmicrosoftGraphWindowsinformationprotectiondeviceregistrationallof1
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphWindowsinformationprotectiondeviceregistrationallof1
        /// class.
        /// </summary>
        public ComponentsschemasmicrosoftGraphWindowsinformationprotectiondeviceregistrationallof1()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComponentsschemasmicrosoftGraphWindowsinformationprotectiondeviceregistrationallof1
        /// class.
        /// </summary>
        /// <param name="userId">UserId associated with this device
        /// registration record.</param>
        /// <param name="deviceRegistrationId">Device identifier for this
        /// device registration record.</param>
        /// <param name="deviceName">Device name.</param>
        /// <param name="deviceType">Device type, for example, Windows laptop
        /// VS Windows phone.</param>
        /// <param name="deviceMacAddress">Device Mac address.</param>
        /// <param name="lastCheckInDateTime">Last checkin time of the
        /// device.</param>
        public ComponentsschemasmicrosoftGraphWindowsinformationprotectiondeviceregistrationallof1(string userId = default(string), string deviceRegistrationId = default(string), string deviceName = default(string), string deviceType = default(string), string deviceMacAddress = default(string), System.DateTime? lastCheckInDateTime = default(System.DateTime?))
        {
            UserId = userId;
            DeviceRegistrationId = deviceRegistrationId;
            DeviceName = deviceName;
            DeviceType = deviceType;
            DeviceMacAddress = deviceMacAddress;
            LastCheckInDateTime = lastCheckInDateTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets userId associated with this device registration
        /// record.
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets device identifier for this device registration record.
        /// </summary>
        [JsonProperty(PropertyName = "deviceRegistrationId")]
        public string DeviceRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets device name.
        /// </summary>
        [JsonProperty(PropertyName = "deviceName")]
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets device type, for example, Windows laptop VS Windows
        /// phone.
        /// </summary>
        [JsonProperty(PropertyName = "deviceType")]
        public string DeviceType { get; set; }

        /// <summary>
        /// Gets or sets device Mac address.
        /// </summary>
        [JsonProperty(PropertyName = "deviceMacAddress")]
        public string DeviceMacAddress { get; set; }

        /// <summary>
        /// Gets or sets last checkin time of the device.
        /// </summary>
        [JsonProperty(PropertyName = "lastCheckInDateTime")]
        public System.DateTime? LastCheckInDateTime { get; set; }

    }
}
