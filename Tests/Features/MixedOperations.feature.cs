﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Mixed Operations")]
    public partial class MixedOperationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "MixedOperations.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Mixed Operations", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I can track multi operations")]
        public virtual void ICanTrackMultiOperations()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can track multi operations", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
        testRunner.Given("I created the default database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
        testRunner.And("the \'dbo.Users\' has \'10\' rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 6
        testRunner.When("I execute \"INSERT INTO dbo.Users(FullName, CreatedDate) VALUES(\'Name 11\', \'2023-0" +
                        "3-19 03:06:33.227\');\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
        testRunner.And("I execute \"UPDATE dbo.Users SET FullName = \'Name 5555\' WHERE FullName = \'Name 5\';" +
                        "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
        testRunner.And("I execute \"DELETE dbo.Users WHERE FullName = \'Name 3\';\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
        testRunner.Then("the \'dbo.Users\' has \'10\' rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "ObjectName",
                            "Operation",
                            "Type",
                            "RedoSQL",
                            "UndoSQL"});
                table5.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_INSERT_ROWS",
                            "DML",
                            "set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[" +
                                "CreatedDate]) values(1002,N\'Name 11\',\'2023-03-19 03:06:33.227\'); set identity_in" +
                                "sert [dbo].[Users] off;",
                            "delete top(1) from [dbo].[Users] where [Id]=1002 and [FullName]=N\'Name 11\' and [C" +
                                "reatedDate]=\'2023-03-19 03:06:33.227\';"});
                table5.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_MODIFY_ROW",
                            "DML",
                            "update top(1) [dbo].[Users] set [FullName]=N\'Name 5555\' where [Id]=5 and [FullNam" +
                                "e]=N\'Name 5\' and [CreatedDate]=\'2023-03-14 04:08:39.547\';",
                            "update top(1) [dbo].[Users] set [FullName]=N\'Name 5\' where [Id]=5 and [FullName]=" +
                                "N\'Name 5555\' and [CreatedDate]=\'2023-03-14 04:08:39.547\';"});
                table5.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_DELETE_ROWS",
                            "DML",
                            "delete top(1) from [dbo].[Users] where [Id]=3 and [FullName]=N\'Name 3\' and [Creat" +
                                "edDate]=\'2023-03-14 04:08:37.103\';",
                            "set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[" +
                                "CreatedDate]) values(3,N\'Name 3\',\'2023-03-14 04:08:37.103\'); set identity_insert" +
                                " [dbo].[Users] off;"});
#line 10
        testRunner.And("Transaction logs in the last 5 min should be", ((string)(null)), table5, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
