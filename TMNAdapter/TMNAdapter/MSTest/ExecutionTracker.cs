﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TMNAdapter.Entities;

namespace TMNAdapter.MSTest
{
    public class ExecutionTracker
    {
        private static List<Issue> issues = new List<Issue>();

        //must be invoked explicitly after each test completion
        public static void SendTestResult(TestContext testContext)
        {
            switch (testContext.CurrentTestOutcome)
            {
                case UnitTestOutcome.Failed:
                    FailedTest();
                    break;
                case UnitTestOutcome.Passed:
                    PassedTest(testContext);
                    break;
                default:
                    SkippedTest();
                    break;
            }
        }

        static void FailedTest()
        {

        }

        static void PassedTest(TestContext testContext)
        {
			string key = testContext.TestName;
			if (key != null)
			{
				Issue issue = new Issue(key, Status.Passed);
				issues.Add(issue);
			}
		}

        static void SkippedTest()
        {

        }

        //some other methods

        //must be invoked explicitly after test run completion
        static void GenerateTestResultXml()
        {

        }
    }
}
