//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

#if ASTORIA_CLIENT
namespace Microsoft.OData.Client.ALinq.UriParser
#else
namespace Microsoft.OData.Core.UriParser.Syntactic
#endif
{
    #region Namespaces

    using System.Collections.Generic;
    using Microsoft.OData.Core.UriParser.Semantic;
    using Microsoft.OData.Core.UriParser.TreeNodeKinds;
    using Microsoft.OData.Core.UriParser.Visitors;

    #endregion Namespaces

    /// <summary>
    /// Lexical token representing a select operation.
    /// </summary>
    internal sealed class SelectToken : QueryToken
    {
        /// <summary>
        /// The properties according to which to select the results.
        /// </summary>
        private readonly IEnumerable<PathSegmentToken> properties;

        /// <summary>
        /// Create a SelectToken given the property-accesses of the select query.
        /// </summary>
        /// <param name="properties">The properties according to which to select the results.</param>
        public SelectToken(IEnumerable<PathSegmentToken> properties)
        {
            this.properties = properties != null ? new ReadOnlyEnumerableForUriParser<PathSegmentToken>(properties) 
                                                 : new ReadOnlyEnumerableForUriParser<PathSegmentToken>(new List<PathSegmentToken>());
        }

        /// <summary>
        /// The kind of the query token.
        /// </summary>
        public override QueryTokenKind Kind
        {
            get { return QueryTokenKind.Select; }
        }

        /// <summary>
        /// The properties according to which to select the results.
        /// </summary>
        public IEnumerable<PathSegmentToken> Properties
        {
            get { return this.properties; }
        }

        /// <summary>
        /// Accept a <see cref="ISyntacticTreeVisitor{T}"/> to walk a tree of <see cref="QueryToken"/>s.
        /// </summary>
        /// <typeparam name="T">Type that the visitor will return after visiting this token.</typeparam>
        /// <param name="visitor">An implementation of the visitor interface.</param>
        /// <returns>An object whose type is determined by the type parameter of the visitor.</returns>
        public override T Accept<T>(ISyntacticTreeVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
