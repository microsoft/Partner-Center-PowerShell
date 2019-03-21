// -----------------------------------------------------------------------
// <copyright file="PartnerService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter
{
    using System;
    using System.Dynamic;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using Factories;
    using Newtonsoft.Json;
    using RequestContext;

    /// <summary>
    /// This class contains the Partner Center SDK properties and acts as the main entry point to create partners.
    /// </summary>
    public class PartnerService
    {
        /// <summary>
        /// Path to the SDK configuration embedded resource.
        /// </summary>
        private const string SdkConfiguration = "Microsoft.Store.PartnerCenter.Configuration.PartnerService.json";

        /// <summary>
        /// A singleton instance of the partner service.
        /// </summary>
        private static readonly Lazy<PartnerService> instance = new Lazy<PartnerService>(() => new PartnerService());

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerService" /> class.
        /// </summary>
        private PartnerService()
        {
            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(SdkConfiguration)))
            {
                Configuration = JsonConvert.DeserializeObject<ExpandoObject>(reader.ReadToEnd());
            }

            ApiRootUrl = new Uri(Configuration.PartnerServiceApiRoot);
            ApiVersion = Configuration.PartnerServiceApiVersion;
            AssemblyVersion = typeof(PartnerService).Assembly.GetName().Version.ToString();
            Factory = new StandardPartnerFactory();
        }

        /// <summary>
        /// Gets or sets the partner service API root URL.
        /// </summary>
        public Uri ApiRootUrl { get; set; }

        /// <summary>
        /// Gets the partner service API version.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets an application name used to identify the calling application.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets the current Partner Center SDK version.
        /// </summary>
        internal string AssemblyVersion { get; private set; }

        /// <summary>
        /// Gets the Partner Center SDK configuration.
        /// </summary>
        internal dynamic Configuration { get; private set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not multi-factor authentication should be enforced.
        /// </summary>
        /// <remarks>
        /// This flag is only configurable while the requirement for multi-factor authentication is not required.
        /// Once the Partner Center API requires multi-factor authentication this flag will be removed.
        /// </remarks>
        public bool EnforceMfa { get; set; }

        /// <summary>
        /// Gets the partner factory used to create partner objects.
        /// </summary>
        internal IPartnerFactory Factory { get; set; }

        /// <summary>
        /// Gets an instance of the partner service.
        /// </summary>
        public static PartnerService Instance => instance.Value;

        /// <summary>
        /// This callback is invoked when the partner SDK needs to refresh a partner credentials.
        /// </summary>
        internal RefreshCredentialsHandler RefreshCredentials { get; set; }

        /// <summary>
        /// Defines a delegate which is called to refresh stale partner credentials.
        /// </summary>
        /// <param name="credentials">The outdated partner credentials.</param>
        /// <param name="context">The partner context.</param>
        /// <returns>A task that completes when the refresh is complete.</returns>
        internal delegate Task RefreshCredentialsHandler(IPartnerCredentials credentials, IRequestContext context);

        /// <summary>
        /// Creates a <see cref="IPartner" /> instance and configures it using the provided partner credentials. The partner instance can be used to
        /// access all the Partner Center APIs.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the <see cref="IPartnerCredentials" /> class to obtain these.</param>
        /// <returns>A configured partner operations object.</returns>
        public IPartner CreatePartnerOperations(IPartnerCredentials credentials)
        {
            return Factory.Build(credentials);
        }

        /// <summary>
        /// Creates a <see cref="IPartner" /> instance and configures it using the provided partner credentials. The partner instance can be used to
        /// access all the Partner Center APIs.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the <see cref="IPartnerCredentials" /> class to obtain these.</param>
        /// <param name="httpClient">The client used to perform HTTP operations.</param>
        /// <returns>A configured partner operations object.</returns>
        public IPartner CreatePartnerOperations(IPartnerCredentials credentials, HttpClient httpClient)
        {
            return Factory.Build(credentials, httpClient);
        }

        /// <summary>
        /// Creates a <see cref="IPartner" /> instance and configures it using the provided partner credentials. The partner instance can be used to
        /// access all the Partner Center APIs.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the <see cref="IPartnerCredentials" /> class to obtain these.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        /// <returns>A configured partner operations object.</returns>
        public IPartner CreatePartnerOperations(IPartnerCredentials credentials, params DelegatingHandler[] handlers)
        {
            return Factory.Build(credentials, handlers);
        }
    }
}