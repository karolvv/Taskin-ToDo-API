/*******************************************************************************
* Copyright 2009-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
*
* http://aws.amazon.com/apache2.0/
*
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace Taskin.Models
{
    [DynamoDBTable("Tasks")]
    public class Task
    {
        [DynamoDBHashKey]
        [Required]
        public string Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Updated { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,3)]
        public int Priority {get; set; }

        public override string ToString()
        {
            return string.Format(@"Id: {0} Name: {1} Priority: {2} Created: {3} Updated: {4}",
                Id, Name, Priority, Created, Updated);
        }
    }
}