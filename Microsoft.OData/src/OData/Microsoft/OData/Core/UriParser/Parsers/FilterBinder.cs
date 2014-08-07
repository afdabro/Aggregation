//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

using Microsoft.OData.Core.Aggregation;

namespace Microsoft.OData.Core.UriParser.Parsers
{
    using System;
    using System.Linq;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Core.Metadata;
    using Microsoft.OData.Core.UriParser.Semantic;
    using Microsoft.OData.Core.UriParser.Syntactic;
    using ODataErrorStrings = Microsoft.OData.Core.Strings;

    /// <summary>
    /// Class responsible for binding a syntactic filter expression into a bound tree of semantic nodes.
    /// </summary>
    internal sealed class FilterBinder
    {
        /// <summary>
        /// Method to use to visit the token tree and bind the tokens recursively.
        /// </summary>
        private readonly MetadataBinder.QueryTokenVisitor bindMethod;
        
        /// <summary>
        /// State to use for binding.
        /// </summary>
        private readonly BindingState state;

        /// <summary>
        /// Creates a FilterBinder.
        /// </summary>
        /// <param name="bindMethod">Method to use to visit the token tree and bind the tokens recursively.</param>
        /// <param name="state">State to use for binding.</param>
        internal FilterBinder(MetadataBinder.QueryTokenVisitor bindMethod, BindingState state)
        {
            this.bindMethod = bindMethod;
            this.state = state;
        }

        /// <summary>
        /// Binds the given filter token.
        /// </summary>
        /// <param name="filter">The filter token to bind.</param>
        /// <returns>A FilterNode with the given path linked to it (if provided).</returns>
        internal FilterClause BindFilter(QueryToken filter)
        {
            ExceptionUtils.CheckArgumentNotNull(filter, "filter");

            QueryNode expressionNode = this.bindMethod(filter);

            SingleValueNode expressionResultNode = expressionNode as SingleValueNode;
            if (expressionResultNode == null ||
                (expressionResultNode.TypeReference != null && !expressionResultNode.TypeReference.IsODataPrimitiveTypeKind()))
            {
                throw new ODataException(ODataErrorStrings.MetadataBinder_FilterExpressionNotSingleValue);
            }

            // The type may be null here if the query statically represents the null literal or an open property.
            IEdmTypeReference expressionResultType = expressionResultNode.TypeReference;
            if (expressionResultType != null)
            {
                IEdmPrimitiveTypeReference primitiveExpressionResultType = expressionResultType.AsPrimitiveOrNull();
                if (primitiveExpressionResultType == null ||
                    primitiveExpressionResultType.PrimitiveKind() != EdmPrimitiveTypeKind.Boolean)
                {
                    throw new ODataException(ODataErrorStrings.MetadataBinder_FilterExpressionNotSingleValue);
                }
            }

            FilterClause filterNode = new FilterClause(expressionResultNode, this.state.ImplicitRangeVariable);

            return filterNode;
        }


        /// <summary>
        /// Binds the given filter token.
        /// </summary>
        /// <param name="filter">The filter token to bind.</param>
        /// <returns>A FilterNode with the given path linked to it (if provided).</returns>
        internal ExpressionClause BindExpression(QueryToken filter)
        {
            ExceptionUtils.CheckArgumentNotNull(filter, "filter");

            QueryNode expressionNode = this.bindMethod(filter);

            SingleValueNode expressionResultNode = expressionNode as SingleValueNode;
            if (expressionResultNode == null ||
                (expressionResultNode.TypeReference != null && !expressionResultNode.TypeReference.IsODataPrimitiveTypeKind()))
            {
                throw new ODataException(ODataErrorStrings.MetadataBinder_FilterExpressionNotSingleValue);
            }

            // The type may be null here if the query statically represents the null literal or an open property.
            IEdmTypeReference expressionResultType = expressionResultNode.TypeReference;
            ExpressionClause res = new ExpressionClause(expressionResultNode, this.state.ImplicitRangeVariable);

            return res;
        }
    }
}
