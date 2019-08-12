using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.MLModelGenerator.Models
{
    public class Stage
    {
        private Dictionary<string, Dictionary<string, List<string>>> stages;
        private List<string> allStages;
        public Stage()
        {
            AddStages();
            AddAllStages();
        }

        public Dictionary<string, Dictionary<string, List<string>>> GetStages()
        {
            return stages;
        }

        public List<string> GetAllStages()
        {
            return allStages;
        }

        private void AddAllStages()
        {
            allStages = new List<string>();
            allStages.Add("BusinessAnalysisMethodology");
            allStages.Add("Requirements");
            allStages.Add("ElicitationAndColaboration");
            allStages.Add("RequirementsMatriz");
            allStages.Add("BasicUML");
            allStages.Add("AdvancedUML");
            allStages.Add("Agile");
            allStages.Add("RequirementLifecycleManagement");
            allStages.Add("ChangesRequest");

            allStages.Add("Needs");
            allStages.Add("PlanningAndSupervision");
            allStages.Add("AnalisysPlan");
            allStages.Add("StrategicAnalisys");
            allStages.Add("RiskAnalisys");
            allStages.Add("SolutionEvaluation");

            allStages.Add("QualityAssuranceConcepts");
            allStages.Add("DevelopmentMethodologies");
            allStages.Add("SoftwareEngineeringBestPractices");
            allStages.Add("SoftwareDesignBasics");
            allStages.Add("DatabaseBasics");
            allStages.Add("WebDevelopmentBasics");
            allStages.Add("SecurityBasics");
            allStages.Add("UXBasics");
            allStages.Add("LanguageAndPlatformFundamentals");

            allStages.Add("EstimationTechniques");
            allStages.Add("PlatformBestPractices");
            allStages.Add("AlgorithmsDesignAndAnalysis");
            allStages.Add("DesignPatterns");
            allStages.Add("DatabaseAdvanced");
            allStages.Add("WebDevelopmentAdvanced");
            allStages.Add("TestingAdvanced");
            allStages.Add("ConcurrentProgramming");

            allStages.Add("RequirementsEngineering");
            allStages.Add("SecurityAdvanced");
            allStages.Add("DatabaseDesign");
            allStages.Add("TechnologyAndPlatformSpecifics");
            allStages.Add("WebServicesAndMicroservices");
            allStages.Add("ArtificialIntelligence");
            allStages.Add("CloudBasics");

            allStages.Add("DevelopmentMethodologies");
            allStages.Add("QualityAssuranceConcepts");
            allStages.Add("SourceCodeManagement");
            allStages.Add("ScriptingForProcessAutomation");
            allStages.Add("DevOpsGeneralConcepts");
            allStages.Add("ContinuousIntegration");
            allStages.Add("TestAutomation");
            allStages.Add("DeliveryPipelines");
            allStages.Add("DatabaseBasics");
            allStages.Add("AgileAndDevOps");

            allStages.Add("AppContainerization");
            allStages.Add("ConfigurationManagement");
            allStages.Add("ContinuousDeliveryAndDeployment");
            allStages.Add("SystemAdministration");
            allStages.Add("EstimationTechniques");
            allStages.Add("ChatOps");
            allStages.Add("SecurityBasics");
            allStages.Add("PerformanceBasics");
            allStages.Add("CloudComputingBasics");

            allStages.Add("AdvancedCloudComputing");
            allStages.Add("InfrastructureAsCode");
            allStages.Add("Monitoring");
            allStages.Add("ProjectManagementInAvantica");
            allStages.Add("Metrics");
            allStages.Add("MicroservicesArchitecture");
            allStages.Add("ServerlessConcepts");
            allStages.Add("DevOpsCulture");
            allStages.Add("ContinuousDeliveryStrategies");

            allStages.Add("QualityAssuranceConcepts");
            allStages.Add("DevelopmentMethodologies");
            allStages.Add("SoftwareDesignBasics");
            allStages.Add("DatabaseBasics");
            allStages.Add("UXBasics");
            allStages.Add("SoftwareEngineeringBestPractices");
            allStages.Add("WebServices");
            allStages.Add("SecurityBasics");
            allStages.Add("LanguagesAndPlatformsFundamentals");

            allStages.Add("AlgorithmDesignAndAnalysis");
            allStages.Add("UserInfoAndAppPublishing");
            allStages.Add("EstimationTechniques");
            allStages.Add("DesignPatterns");
            allStages.Add("TestingAdvance");
            allStages.Add("ConcurrentProgramming");
            allStages.Add("PlatformBestPractices");
            allStages.Add("ConnectivityAndPushNotifications");
            allStages.Add("SensorBasicsLocationAndMaps");
            allStages.Add("CloudMobileServices");

            allStages.Add("SecurityAdvanced");
            allStages.Add("SensorsAdvanced");
            allStages.Add("InAppPurchaseAndPayments");
            allStages.Add("Wearables");
            allStages.Add("TechnologyAndPlatformSpecifics");
            allStages.Add("RequirementsEngineering");
            allStages.Add("WebServicesAndMicroservices");

            allStages.Add("QualityAssuranceConcepts");
            allStages.Add("TestingTypes");
            allStages.Add("AvanticaQualityAssuranceMethodology");
            allStages.Add("TestCasesDesignAndEstimationTechniques");
            allStages.Add("BugManagement");
            allStages.Add("DevelopmentMethodologies");
            allStages.Add("QATools");
            allStages.Add("AvanticaTestingServicesWorkspace");

            allStages.Add("QualityAssuranceInSoftwareDevelopmentLifeCycle");
            allStages.Add("SQLForQualityAssurance");
            allStages.Add("TestCaseAutomationConcepts");
            allStages.Add("TestCasesAutomation");
            allStages.Add("MobileTesting");
            allStages.Add("PerformanceTesting");
            allStages.Add("SoftwareEvaluationMetrics");

            allStages.Add("TestCaseManagement");
            allStages.Add("AdvancedBugManagement");
            allStages.Add("RequirementsManagement");
            allStages.Add("TestStrategyDesign");
            allStages.Add("AdvancedPerformanceTesting");
            allStages.Add("SecurityTestingConcepts");
            allStages.Add("AdvancedSecurityTesting");
            allStages.Add("ProjectManagementInAvantica");

            allStages.Add("ArchitectureForQA");
            allStages.Add("AdvancedSoftwareEvaluationMetrics");
            allStages.Add("ProjectManagementI");
            allStages.Add("ProjectManagementII");
            allStages.Add("SoftSkillsI");
            allStages.Add("SoftSkillsII");
            allStages.Add("SoftSkillsFromHHRR");
        }

        private void AddStages()
        {
            stages = new Dictionary<string, Dictionary<string, List<string>>>();

            var stagesBA = new Dictionary<string, List<string>>();
            var list1BA = new List<string>();
            list1BA.Add("BusinessAnalysisMethodology");
            list1BA.Add("Requirements");
            list1BA.Add("ElicitationAndColaboration");
            list1BA.Add("RequirementsMatriz");
            list1BA.Add("BasicUML");
            list1BA.Add("AdvancedUML");
            list1BA.Add("Agile");
            list1BA.Add("RequirementLifecycleManagement");
            list1BA.Add("ChangesRequest");
            stagesBA.Add("1", list1BA);

            var list2BA = new List<string>();
            list2BA.Add("Needs");
            list2BA.Add("PlanningAndSupervision");
            list2BA.Add("AnalisysPlan");
            list2BA.Add("StrategicAnalisys");
            list2BA.Add("RiskAnalisys");
            list2BA.Add("SolutionEvaluation");
            stagesBA.Add("2", list2BA);

            stages.Add("BA", stagesBA);

            var stagesSE = new Dictionary<string, List<string>>();
            var list1SE = new List<string>();
            list1SE.Add("QualityAssuranceConcepts");
            list1SE.Add("DevelopmentMethodologies");
            list1SE.Add("SoftwareEngineeringBestPractices");
            list1SE.Add("SoftwareDesignBasics");
            list1SE.Add("DatabaseBasics");
            list1SE.Add("WebDevelopmentBasics");
            list1SE.Add("SecurityBasics");
            list1SE.Add("UXBasics");
            list1SE.Add("LanguageAndPlatformFundamentals");
            stagesSE.Add("1", list1SE);

            var list2SE = new List<string>();
            list2SE.Add("EstimationTechniques");
            list2SE.Add("PlatformBestPractices");
            list2SE.Add("AlgorithmsDesignAndAnalysis");
            list2SE.Add("DesignPatterns");
            list2SE.Add("DatabaseAdvanced");
            list2SE.Add("WebDevelopmentAdvanced");
            list2SE.Add("TestingAdvanced");
            list2SE.Add("ConcurrentProgramming");
            stagesSE.Add("2", list2SE);

            var list3SE = new List<string>();
            list3SE.Add("RequirementsEngineering");
            list3SE.Add("SecurityAdvanced");
            list3SE.Add("DatabaseDesign");
            list3SE.Add("TechnologyAndPlatformSpecifics");
            list3SE.Add("WebServicesAndMicroservices");
            list3SE.Add("ArtificialIntelligence");
            list3SE.Add("CloudBasics");
            stagesSE.Add("3", list3SE);

            stages.Add("SE", stagesSE);

            var stagesDevOps = new Dictionary<string, List<string>>();

            var list1DevOps = new List<string>();
            list1DevOps.Add("DevelopmentMethodologies");
            list1DevOps.Add("QualityAssuranceConcepts");
            list1DevOps.Add("SourceCodeManagement");
            list1DevOps.Add("ScriptingForProcessAutomation");
            list1DevOps.Add("DevOpsGeneralConcepts");
            list1DevOps.Add("ContinuousIntegration");
            list1DevOps.Add("TestAutomation");
            list1DevOps.Add("DeliveryPipelines");
            list1DevOps.Add("DatabaseBasics");
            list1DevOps.Add("AgileAndDevOps");
            stagesDevOps.Add("1", list1DevOps);

            var list2DevOps = new List<string>();
            list2DevOps.Add("AppContainerization");
            list2DevOps.Add("ConfigurationManagement");
            list2DevOps.Add("ContinuousDeliveryAndDeployment");
            list2DevOps.Add("SystemAdministration");
            list2DevOps.Add("EstimationTechniques");
            list2DevOps.Add("ChatOps");
            list2DevOps.Add("SecurityBasics");
            list2DevOps.Add("PerformanceBasics");
            list2DevOps.Add("CloudComputingBasics");
            stagesDevOps.Add("2", list2DevOps);

            var list3DevOps = new List<string>();
            list3DevOps.Add("AdvancedCloudComputing");
            list3DevOps.Add("InfrastructureAsCode");
            list3DevOps.Add("Monitoring");
            list3DevOps.Add("ProjectManagementInAvantica");
            list3DevOps.Add("Metrics");
            list3DevOps.Add("MicroservicesArchitecture");
            list3DevOps.Add("ServerlessConcepts");
            list3DevOps.Add("DevOpsCulture");
            list3DevOps.Add("ContinuousDeliveryStrategies");
            stagesDevOps.Add("3", list3DevOps);

            stages.Add("DEVOPS", stagesDevOps);

            var stagesME = new Dictionary<string, List<string>>();

            var list1ME = new List<string>();
            list1ME.Add("QualityAssuranceConcepts");
            list1ME.Add("DevelopmentMethodologies");
            list1ME.Add("SoftwareDesignBasics");
            list1ME.Add("DatabaseBasics");
            list1ME.Add("UXBasics");
            list1ME.Add("SoftwareEngineeringBestPractices");
            list1ME.Add("WebServices");
            list1ME.Add("SecurityBasics");
            list1ME.Add("LanguagesAndPlatformsFundamentals");
            stagesME.Add("1", list1ME);

            var list2ME = new List<string>();
            list2ME.Add("AlgorithmDesignAndAnalysis");
            list2ME.Add("UserInfoAndAppPublishing");
            list2ME.Add("EstimationTechniques");
            list2ME.Add("DesignPatterns");
            list2ME.Add("TestingAdvance");
            list2ME.Add("ConcurrentProgramming");
            list2ME.Add("PlatformBestPractices");
            list2ME.Add("ConnectivityAndPushNotifications");
            list2ME.Add("SensorBasicsLocationAndMaps");
            list2ME.Add("CloudMobileServices");
            stagesME.Add("2", list2ME);

            var list3ME = new List<string>();
            list3ME.Add("SecurityAdvanced");
            list3ME.Add("SensorsAdvanced");
            list3ME.Add("InAppPurchaseAndPayments");
            list3ME.Add("Wearables");
            list3ME.Add("TechnologyAndPlatformSpecifics");
            list3ME.Add("RequirementsEngineering");
            list3ME.Add("WebServicesAndMicroservices");
            stagesME.Add("3", list3ME);

            stages.Add("ME", stagesME);

            var stagesQA = new Dictionary<string, List<string>>();

            var list0QA = new List<string>();
            list0QA.Add("QualityAssuranceConcepts");
            list0QA.Add("TestingTypes");
            list0QA.Add("AvanticaQualityAssuranceMethodology");
            list0QA.Add("TestCasesDesignAndEstimationTechniques");
            list0QA.Add("BugManagement");
            list0QA.Add("DevelopmentMethodologies");
            list0QA.Add("QATools");
            list0QA.Add("AvanticaTestingServicesWorkspace");
            stagesQA.Add("0", list0QA);

            var list1QA = new List<string>();
            list1QA.Add("QualityAssuranceInSoftwareDevelopmentLifeCycle");
            list1QA.Add("SQLForQualityAssurance");
            list1QA.Add("TestCaseAutomationConcepts");
            list1QA.Add("TestCasesAutomation");
            list1QA.Add("MobileTesting");
            list1QA.Add("PerformanceTesting");
            list1QA.Add("SoftwareEvaluationMetrics");
            stagesQA.Add("1", list1QA);

            var list2QA = new List<string>();
            list2QA.Add("TestCaseManagement");
            list2QA.Add("AdvancedBugManagement");
            list2QA.Add("RequirementsManagement");
            list2QA.Add("TestStrategyDesign");
            list2QA.Add("AdvancedPerformanceTesting");
            list2QA.Add("SecurityTestingConcepts");
            list2QA.Add("AdvancedSecurityTesting");
            list2QA.Add("ProjectManagementInAvantica");
            stagesQA.Add("2", list2QA);

            var list3QA = new List<string>();
            list3QA.Add("ArchitectureForQA");
            list3QA.Add("AdvancedSoftwareEvaluationMetrics");
            list3QA.Add("ProjectManagementI");
            list3QA.Add("ProjectManagementII");
            list3QA.Add("SoftSkillsI");
            list3QA.Add("SoftSkillsII");
            list3QA.Add("SoftSkillsFromHHRR");
            stagesQA.Add("3", list3QA);

            stages.Add("QA", stagesQA);
        }
    }
}
