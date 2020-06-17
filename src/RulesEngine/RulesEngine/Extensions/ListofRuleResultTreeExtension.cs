﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using RulesEngine.Models;
using System.Collections.Generic;
using System.Linq;


namespace RulesEngine.Extensions
{
    public static class ListofRuleResultTreeExtension
    {
        public delegate void OnSuccessFunc(string eventName);
        public delegate void OnFailureFunc();

        public static IEnumerable<RuleResultTree> OnSuccess(this IEnumerable<RuleResultTree> ruleResultTrees, OnSuccessFunc onSuccessFunc)
        {
            var successfulRuleResult = ruleResultTrees.FirstOrDefault(ruleResult => ruleResult.IsSuccess == true);
            if (successfulRuleResult != null)
            {
                var eventName = successfulRuleResult.Rule.SuccessEvent ?? successfulRuleResult.Rule.RuleName;
                onSuccessFunc(eventName);
            }

            return ruleResultTrees;
        }

        public static IEnumerable<RuleResultTree> OnFail(this IEnumerable<RuleResultTree> ruleResultTrees, OnFailureFunc onFailureFunc)
        {
            bool allFailure = ruleResultTrees.All(ruleResult => ruleResult.IsSuccess == false);
            if (allFailure)
                onFailureFunc();
            return ruleResultTrees;
        }
    }
}
