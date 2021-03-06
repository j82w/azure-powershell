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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.JobDefinitions.AzureHDInsightStreamingMapReduceJobDefinition),
    OutputType(
        typeof(AzureHDInsightStreamingMapReduceJobDefinition))]
    public class NewAzureHDInsightStreamingMapReduceJobDefinitionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightStreamingMapReduceJobDefinition job;

        #region Input Parameter Definitions
        
        [Parameter(HelpMessage = "The hive arguments for the jobDetails.")]
        public string[] Arguments { get; set; }

        [Parameter(HelpMessage = "The file for the jobDetails.")]
        public string File
        {
            get { return job.File; }
            set { job.File = value; } 
        }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return job.StatusFolder; }
            set { job.StatusFolder = value; }
        }

        [Parameter(HelpMessage = "The command line environment for the mappers or the reducers.")]
        public string[] CommandEnvironment { get; set; }
        
        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public Hashtable Defines { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "The input path to use for the jobDetails.")]
        public string InputPath
        {
            get { return job.Input; }
            set { job.Input = value; }
        }

        [Parameter(HelpMessage = "The Mapper to use for the jobDetails.")]
        public string Mapper
        {
            get { return job.Mapper; }
            set { job.Mapper = value; }
        }

        [Parameter(HelpMessage = "The output path to use for the jobDetails.")]
        public string OutputPath
        {
            get { return job.Output; }
            set { job.Output = value; }
        }

        [Parameter(HelpMessage = "The Reducer to use for the jobDetails.")]
        public string Reducer
        {
            get { return job.Reducer; }
            set { job.Reducer = value; }
        }

        #endregion

        public NewAzureHDInsightStreamingMapReduceJobDefinitionCommand()
        {
            Arguments = new string[] {};
            CommandEnvironment = new string[] {};
            Defines = new Hashtable();
            job = new AzureHDInsightStreamingMapReduceJobDefinition();
        }

        protected override void ProcessRecord()
        {
            foreach (var arg in Arguments)
            {
                job.Arguments.Add(arg);
            }

            foreach (var cmdenv in CommandEnvironment)
            {
                job.CommandEnvironment.Add(cmdenv);
            }

            var defineDic = Defines.ToDictionary(false);
            foreach (var define in defineDic)
            {
                job.Defines.Add(define.Key, define.Value.ToString());
            }

            WriteObject(job);
        }
    }
}
