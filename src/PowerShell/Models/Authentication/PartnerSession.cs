// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Factories;

    /// <summary>
    /// Contains session information for the execution of the commands.
    /// </summary>
    public class PartnerSession
    {
        /// <summary>
        /// Singleton instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        private static readonly Lazy<PartnerSession> partnerSession = new Lazy<PartnerSession>();

        /// <summary>
        /// Provides a registry for various components.
        /// </summary>
        private readonly IDictionary<string, object> componentRegistry = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        public PartnerSession()
        { }

        /// <summary>
        /// Gets or sets an instance of the authentication factory.
        /// </summary>
        public IAuthenticationFactory AuthenticationFactory { get; set; }

        /// <summary>
        /// Gets or sets an instance of the client factory.
        /// </summary>
        public IClientFactory ClientFactory { get; set; }

        /// <summary>
        /// Gets the operating context information.
        /// </summary>
        public PartnerContext Context { get; set; }

        /// <summary>
        /// Gets an instance of the <see cref="PartnerSession" /> class.
        /// </summary>
        public static PartnerSession Instance => partnerSession.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentName"></param>
        /// <param name="componentInitializer"></param>
        public void RegisterComponent<T>(string componentName, Func<T> componentInitializer) where T : class
        {
            RegisterComponent(componentName, componentInitializer, false); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentName"></param>
        /// <param name="componentInitializer"></param>
        /// <param name="overwrite"></param>
        public void RegisterComponent<T>(string componentName, Func<T> componentInitializer, bool overwrite) where T : class
        {
            ChangeRegistry(
                () =>
                {
                    if (!componentRegistry.ContainsKey(componentName) || overwrite)
                    {
                        componentRegistry[componentName] = componentInitializer();
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentName"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public bool TryGetComponent<T>(string componentName, out T component) where T : class
        {
            component = null;

            if (componentRegistry.ContainsKey(componentName))
            {
                component = componentRegistry[componentName] as T;
            }

            return component != null;
        }

        private void ChangeRegistry(Action changeAction)
        {
            changeAction();
        }
    }
}