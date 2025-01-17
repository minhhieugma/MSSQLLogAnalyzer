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
    [NUnit.Framework.DescriptionAttribute("Delete Row")]
    public partial class DeleteRowFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "DeleteRow.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Delete Row", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("I can track deleting a single row")]
        public virtual void ICanTrackDeletingASingleRow()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can track deleting a single row", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.When("I execute \"DELETE dbo.Users WHERE FullName = \'Name 5\';\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 7
 testRunner.Then("the \'dbo.Users\' has \'9\' rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "ObjectName",
                            "Operation",
                            "Type",
                            "RedoSQL",
                            "UndoSQL"});
                table1.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_DELETE_ROWS",
                            "DML",
                            "delete top(1) from [dbo].[Users] where [Id]=5 and [FullName]=N\'Name 5\' and [Creat" +
                                "edDate]=\'2023-03-14 04:08:39.547\';",
                            "set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[" +
                                "CreatedDate]) values(5,N\'Name 5\',\'2023-03-14 04:08:39.547\'); set identity_insert" +
                                " [dbo].[Users] off;"});
#line 8
 testRunner.And("Transaction logs in the last 5 min should be", ((string)(null)), table1, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("I can track deleting two rows")]
        public virtual void ICanTrackDeletingTwoRows()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("I can track deleting two rows", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
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
#line 14
 testRunner.Given("I created the default database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
 testRunner.And("the \'dbo.Users\' has \'10\' rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.When("I execute \"DELETE dbo.Users WHERE FullName = \'Name 5\';\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
 testRunner.When("I execute \"DELETE dbo.Users WHERE FullName = \'Name 6\';\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("the \'dbo.Users\' has \'8\' rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "ObjectName",
                            "Operation",
                            "Type",
                            "RedoSQL",
                            "UndoSQL"});
                table2.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_DELETE_ROWS",
                            "DML",
                            "delete top(1) from [dbo].[Users] where [Id]=5 and [FullName]=N\'Name 5\' and [Creat" +
                                "edDate]=\'2023-03-14 04:08:39.547\';",
                            "set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[" +
                                "CreatedDate]) values(5,N\'Name 5\',\'2023-03-14 04:08:39.547\'); set identity_insert" +
                                " [dbo].[Users] off;"});
                table2.AddRow(new string[] {
                            "[dbo].[Users]",
                            "LOP_DELETE_ROWS",
                            "DML",
                            "delete top(1) from [dbo].[Users] where [Id]=6 and [FullName]=N\'Name 6\' and [Creat" +
                                "edDate]=\'2023-03-14 04:08:40.927\';",
                            "set identity_insert [dbo].[Users] on; insert into [dbo].[Users]([Id],[FullName],[" +
                                "CreatedDate]) values(6,N\'Name 6\',\'2023-03-14 04:08:40.927\'); set identity_insert" +
                                " [dbo].[Users] off;"});
#line 19
 testRunner.And("Transaction logs in the last 5 min should be", ((string)(null)), table2, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
