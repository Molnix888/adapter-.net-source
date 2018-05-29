﻿using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TMNAdapter.Core.Common.Validation;
using TMNAdapter.Core.Tracking.Attributes;

namespace TMNAdapter.Tracking.Attributes
{
    /// <summary>
    /// Represents an attribute, which marks test method, to be linked with
    /// JIRA issue, using issue key
    /// NUnit implementation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class JiraIssueKeyAttribute : BaseJiraIssueKeyAttribute, ITestAction
    {
        public ActionTargets Targets => ActionTargets.Test;

        private Stopwatch _stopWatch;

        /// <summary>
        /// Initializes a new instance of <see cref="JiraIssueKeyAttribute"/>
        /// </summary>
        /// <param name="key">JIRA issue key</param>
        public JiraIssueKeyAttribute(string key) : base(key)
        {
        }

        public void BeforeTest(ITest test)
        {
            _stopWatch = Stopwatch.StartNew();
        }

        public void AfterTest(ITest test)
        {
            _stopWatch.Stop();
            ExecutionTracker.SendTestResult(Key, _stopWatch.ElapsedMilliseconds);
        }
    }
}
