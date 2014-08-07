//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

using System.Collections.Generic;

namespace Microsoft.OData.Edm.Csdl.Parsing.Ast
{
    /// <summary>
    /// Represents a CSDL Operation.
    /// </summary>
    internal class CsdlOperation : CsdlFunctionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsdlAction"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="isBound">if set to <c>true</c> [is bound].</param>
        /// <param name="entitySetPath">The entity set path.</param>
        /// <param name="documentation">The documentation.</param>
        /// <param name="location">The location.</param>
        public CsdlOperation(
            string name, 
            IEnumerable<CsdlOperationParameter> parameters, 
            CsdlTypeReference returnType, 
            bool isBound, 
            string entitySetPath, 
            CsdlDocumentation documentation, 
            CsdlLocation location)
            : base(name, parameters, returnType, documentation, location)
        {
            this.IsBound = isBound;
            this.EntitySetPath = entitySetPath;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is bound.
        /// </summary>
        public bool IsBound { get; private set; }

        /// <summary>
        /// Gets the entity set path.
        /// </summary>
        public string EntitySetPath { get; private set; }
    }
}
