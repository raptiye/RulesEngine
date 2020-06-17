// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using RulesEngine.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace RulesEngine.UnitTest
{
    [Trait("Category", "Unit")]
    public class LambdaExpressionBuilderTest
    {
        [Fact]
        public void BuildExpressionForRuleTest()
        {
            var objBuilderFactory = new RuleExpressionBuilderFactory(new ReSettings());
            var builder = objBuilderFactory.RuleGetExpressionBuilder(RuleExpressionType.LambdaExpression);

            var parameterExpressions = new List<ParameterExpression>
            {
                Expression.Parameter(typeof(string), "RequestType"),
                Expression.Parameter(typeof(string), "RequestStatus"),
                Expression.Parameter(typeof(string), "RegistrationStatus")
            };

            Rule mainRule = new Rule
            {
                RuleName = "rule1",
                Operator = "And",
                Rules = new List<Rule>()
            };

            Rule dummyRule = new Rule
            {
                RuleName = "testRule1",
                RuleExpressionType = RuleExpressionType.LambdaExpression,
                Expression = "RequestType == \"vod\""
            };

            mainRule.Rules.Add(dummyRule);

            ParameterExpression ruleInputExp = Expression.Parameter(typeof(RuleInput), nameof(RuleInput));

            var expression = builder.BuildExpressionForRule(dummyRule, parameterExpressions, ruleInputExp);

            Assert.NotNull(expression);
            Assert.Equal(typeof(RuleResultTree), expression.ReturnType);
        }
    }
}
