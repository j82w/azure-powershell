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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Set, ProfileNouns.VirtualMachine, DefaultParameterSetName = ResourceGroupNameParameterSet)]
    [OutputType(typeof(AzureOperationResponse))]
    public class SetAzureVMCommand : VirtualMachineActionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "To generalize virtual machine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Generalized { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            ExecuteClientAction(() =>
            {
                var op = this.VirtualMachineClient.Generalize(this.ResourceGroupName, this.Name);
                WriteObject(op);
            });
        }
    }
}
