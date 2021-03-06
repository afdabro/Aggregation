//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Core.Atom
{
    /// <summary>
    /// Atom metadata for stream reference values.
    /// </summary>
    public sealed class AtomStreamReferenceMetadata : ODataAnnotatable
    {
        /// <summary>Gets or sets an Atom link metadata for the self link.</summary>
        /// <returns>An Atom link metadata for the self link.</returns>
        public AtomLinkMetadata SelfLink
        {
            get;
            set;
        }

        /// <summary>Gets or sets an Atom link metadata for the edit link.</summary>
        /// <returns>An Atom link metadata for the edit link.</returns>
        public AtomLinkMetadata EditLink
        {
            get;
            set;
        }
    }
}
