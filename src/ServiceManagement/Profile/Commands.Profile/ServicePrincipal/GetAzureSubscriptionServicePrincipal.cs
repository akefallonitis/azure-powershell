﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, AzureSubscriptionServicePrincipalNounName, DefaultParameterSetName = ListAllServicePrincipalObjectIdsParameterSet)]
    [OutputType(typeof(SubscriptionServicePrincipalGetResponse), typeof(SubscriptionServicePrincipalListResponse))]
    public class GetAzureSubscriptionServicePrincipal : ServiceManagementBaseCmdlet
    {
        protected const string ServicePrincipalObjectIdParameterSet = "ServicePrincipalObjectIdParameterSet";
        protected const string ListAllServicePrincipalObjectIdsParameterSet = "ListAllServicePrincipalObjectIdsParameterSet";
        public GetAzureSubscriptionServicePrincipal()
            : base()
        {

        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ServicePrincipal Object Id", ParameterSetName = ServicePrincipalObjectIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("ObjectId")]
        public string ServicePrincipalObjectId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(this.ServicePrincipalObjectId))
            {
                var response = ManagementClient.SubscriptionServicePrincipals.List();
                WriteObject(response);
            }
            else
            {
                var response = ManagementClient.SubscriptionServicePrincipals.Get(ServicePrincipalObjectId);
                WriteObject(response);
            }
        }
    }
}