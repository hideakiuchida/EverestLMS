using Microsoft.ML.Runtime.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.UnitTests.Resources
{
    public class PerfilPersonalizadoData
    {
        public float LineaCarrera;
        public float Nivel;
        public float TemaMasSeleccionado;

        public float BA1_BusinessAnalysisMethodology_RRC;
        public float BA1_Requirements_RRC;
        public float BA1_ElicitationAndColaboration_RRC;
        public float BA1_RequirementsMatriz_RRC;
        public float BA1_BasicUML_RRC;
        public float BA1_AdvancedUML_RRC;
        public float BA1_Agile_RRC;
        public float BA1_RequirementLifecycleManagement_RRC;
        public float BA1_ChangesRequest_RRC;

        public float BA2_Needs_RRC;
        public float BA2_PlanningAndSupervision_RRC;
        public float BA2_AnalisysPlan_RRC;
        public float BA2_StrategicAnalisys_RRC;
        public float BA2_RiskAnalisys_RRC;
        public float BA2_SolutionEvaluation_RRC;

        public float SE1_QualityAssuranceConcepts_RRC;
        public float SE1_DevelopmentMethodologies_RRC;
        public float SE1_SoftwareEngineeringBestPractices_RRC;
        public float SE1_SoftwareDesignBasics_RRC;
        public float SE1_DatabaseBasics_RRC;
        public float SE1_WebDevelopmentBasics_RRC;
        public float SE1_SecurityBasics_RRC;
        public float SE1_UXBasics_RRC;
        public float SE1_LanguageAndPlatformFundamentals_RRC;

        public float SE2_EstimationTechniques_RRC;
        public float SE2_PlatformBestPractices_RRC;
        public float SE2_AlgorithmsDesignAndAnalysis_RRC;
        public float SE2_DesignPatterns_RRC;
        public float SE2_DatabaseAdvanced_RRC;
        public float SE2_WebDevelopmentAdvanced_RRC;
        public float SE2_TestingAdvanced_RRC;
        public float SE2_ConcurrentProgramming_RRC;

        public float SE3_RequirementsEngineering_RRC;
        public float SE3_SecurityAdvanced_RRC;
        public float SE3_DatabaseDesign_RRC;
        public float SE3_TechnologyAndPlatformSpecifics_RRC;
        public float SE3_WebServicesAndMicroservices_RRC;
        public float SE3_ArtificialIntelligence_RRC;
        public float SE3_CloudBasics_RRC;

        public float DEVOPS1_DevelopmentMethodologies_RRC;
        public float DEVOPS1_QualityAssuranceConcepts_RRC;
        public float DEVOPS1_SourceCodeManagement_RRC;
        public float DEVOPS1_ScriptingForProcessAutomation_RRC;
        public float DEVOPS1_DevOpsGeneralConcepts_RRC;
        public float DEVOPS1_ContinuousIntegration_RRC;
        public float DEVOPS1_TestAutomation_RRC;
        public float DEVOPS1_DeliveryPipelines_RRC;
        public float DEVOPS1_DatabaseBasics_RRC;
        public float DEVOPS1_AgileAndDevOps_RRC;

        public float DEVOPS2_AppContainerization_RRC;
        public float DEVOPS2_ConfigurationManagement_RRC;
        public float DEVOPS2_ContinuousDeliveryAndDeployment_RRC;
        public float DEVOPS2_SystemAdministration_RRC;
        public float DEVOPS2_EstimationTechniques_RRC;
        public float DEVOPS2_ChatOps_RRC;
        public float DEVOPS2_SecurityBasics_RRC;
        public float DEVOPS2_PerformanceBasics_RRC;
        public float DEVOPS2_CloudComputingBasics_RRC;

        public float DEVOPS3_AdvancedCloudComputing_RRC;
        public float DEVOPS3_InfrastructureAsCode_RRC;
        public float DEVOPS3_Monitoring_RRC;
        public float DEVOPS3_ProjectManagementInAvantica_RRC;
        public float DEVOPS3_Metrics_RRC;
        public float DEVOPS3_MicroservicesArchitecture_RRC;
        public float DEVOPS3_ServerlessConcepts_RRC;
        public float DEVOPS3_DevOpsCulture_RRC;
        public float DEVOPS3_ContinuousDeliveryStrategies_RRC;

        public float ME1_QualityAssuranceConcepts_RRC;
        public float ME1_DevelopmentMethodologies_RRC;
        public float ME1_SoftwareDesignBasics_RRC;
        public float ME1_DatabaseBasics_RRC;
        public float ME1_UXBasics_RRC;
        public float ME1_SoftwareEngineeringBestPractices_RRC;
        public float ME1_WebServices_RRC;
        public float ME1_SecurityBasics_RRC;
        public float ME1_LanguagesAndPlatformsFundamentals_RRC;

        public float ME2_AlgorithmDesignAndAnalysis_RRC;
        public float ME2_UserInfoAndAppPublishing_RRC;
        public float ME2_EstimationTechniques_RRC;
        public float ME2_DesignPatterns_RRC;
        public float ME2_TestingAdvance_RRC;
        public float ME2_ConcurrentProgramming_RRC;
        public float ME2_PlatformBestPractices_RRC;
        public float ME2_ConnectivityAndPushNotifications_RRC;
        public float ME2_SensorBasicsLocationAndMaps_RRC;
        public float ME2_CloudMobileServices_RRC;

        public float ME3_SecurityAdvanced_RRC;
        public float ME3_SensorsAdvanced_RRC;
        public float ME3_InAppPurchaseAndPayments_RRC;
        public float ME3_Wearables_RRC;
        public float ME3_TechnologyAndPlatformSpecifics_RRC;
        public float ME3_RequirementsEngineering_RRC;
        public float ME3_WebServicesAndMicroservices_RRC;

        public float QA0_QualityAssuranceConcepts_RRC;
        public float QA0_TestingTypes_RRC;
        public float QA0_AvanticaQualityAssuranceMethodology_RRC;
        public float QA0_TestCasesDesignAndEstimationTechniques_RRC;
        public float QA0_BugManagement_RRC;
        public float QA0_DevelopmentMethodologies_RRC;
        public float QA0_QATools_RRC;
        public float QA0_AvanticaTestingServicesWorkspace_RRC;

        public float QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_RRC;
        public float QA1_SQLForQualityAssurance_RRC;
        public float QA1_TestCaseAutomationConcepts_RRC;
        public float QA1_TestCasesAutomation_RRC;
        public float QA1_MobileTesting_RRC;
        public float QA1_PerformanceTesting_RRC;
        public float QA1_SoftwareEvaluationMetrics_RRC;

        public float QA2_TestCaseManagement_RRC;
        public float QA2_AdvancedBugManagement_RRC;
        public float QA2_RequirementsManagement_RRC;
        public float QA2_TestStrategyDesign_RRC;
        public float QA2_AdvancedPerformanceTesting_RRC;
        public float QA2_SecurityTestingConcepts_RRC;
        public float QA2_AdvancedSecurityTesting_RRC;
        public float QA2_ProjectManagementInAvantica_RRC;

        public float QA3_ArchitectureForQA_RRC;
        public float QA3_AdvancedSoftwareEvaluationMetrics_RRC;
        public float QA3_ProjectManagementI_RRC;
        public float QA3_ProjectManagementII_RRC;
        public float QA3_SoftSkillsI_RRC;
        public float QA3_SoftSkillsII_RRC;
        public float QA3_SoftSkillsFromHHRR_RRC;

        /*public float BA1_BusinessAnalysisMethodology_PCR;
        public float BA1_Requirements_PCR;
        public float BA1_ElicitationAndColaboration_PCR;
        public float BA1_RequirementsMatriz_PCR;
        public float BA1_BasicUML_PCR;
        public float BA1_AdvancedUML_PCR;
        public float BA1_Agile_PCR;
        public float BA1_RequirementLifecycleManagement_PCR;
        public float BA1_ChangesRequest_PCR;

        public float BA2_Needs_PCR;
        public float BA2_PlanningAndSupervision_PCR;
        public float BA2_AnalisysPlan_PCR;
        public float BA2_StrategicAnalisys_PCR;
        public float BA2_RiskAnalisys_PCR;
        public float BA2_SolutionEvaluation_PCR;

        public float SE1_QualityAssuranceConcepts_PCR;
        public float SE1_DevelopmentMethodologies_PCR;
        public float SE1_SoftwareEngineeringBestPractices_PCR;
        public float SE1_SoftwareDesignBasics_PCR;
        public float SE1_DatabaseBasics_PCR;
        public float SE1_WebDevelopmentBasics_PCR;
        public float SE1_SecurityBasics_PCR;
        public float SE1_UXBasics_PCR;
        public float SE1_LanguageAndPlatformFundamentals_PCR;

        public float SE2_EstimationTechniques_PCR;
        public float SE2_PlatformBestPractices_PCR;
        public float SE2_AlgorithmsDesignAndAnalysis_PCR;
        public float SE2_DesignPatterns_PCR;
        public float SE2_DatabaseAdvanced_PCR;
        public float SE2_WebDevelopmentAdvanced_PCR;
        public float SE2_TestingAdvanced_PCR;
        public float SE2_ConcurrentProgramming_PCR;

        public float SE3_RequirementsEngineering_PCR;
        public float SE3_SecurityAdvanced_PCR;
        public float SE3_DatabaseDesign_PCR;
        public float SE3_TechnologyAndPlatformSpecifics_PCR;
        public float SE3_WebServicesAndMicroservices_PCR;
        public float SE3_ArtificialIntelligence_PCR;
        public float SE3_CloudBasics_PCR;

        public float DEVOPS1_DevelopmentMethodologies_PCR;
        public float DEVOPS1_QualityAssuranceConcepts_PCR;
        public float DEVOPS1_SourceCodeManagement_PCR;
        public float DEVOPS1_ScriptingForProcessAutomation_PCR;
        public float DEVOPS1_DevOpsGeneralConcepts_PCR;
        public float DEVOPS1_ContinuousIntegration_PCR;
        public float DEVOPS1_TestAutomation_PCR;
        public float DEVOPS1_DeliveryPipelines_PCR;
        public float DEVOPS1_DatabaseBasics_PCR;
        public float DEVOPS1_AgileAndDevOps_PCR;

        public float DEVOPS2_AppContainerization_PCR;
        public float DEVOPS2_ConfigurationManagement_PCR;
        public float DEVOPS2_ContinuousDeliveryAndDeployment_PCR;
        public float DEVOPS2_SystemAdministration_PCR;
        public float DEVOPS2_EstimationTechniques_PCR;
        public float DEVOPS2_ChatOps_PCR;
        public float DEVOPS2_SecurityBasics_PCR;
        public float DEVOPS2_PerformanceBasics_PCR;
        public float DEVOPS2_CloudComputingBasics_PCR;

        public float DEVOPS3_AdvancedCloudComputing_PCR;
        public float DEVOPS3_InfrastructureAsCode_PCR;
        public float DEVOPS3_Monitoring_PCR;
        public float DEVOPS3_ProjectManagementInAvantica_PCR;
        public float DEVOPS3_Metrics_PCR;
        public float DEVOPS3_MicroservicesArchitecture_PCR;
        public float DEVOPS3_ServerlessConcepts_PCR;
        public float DEVOPS3_DevOpsCulture_PCR;
        public float DEVOPS3_ContinuousDeliveryStrategies_PCR;

        public float ME1_QualityAssuranceConcepts_PCR;
        public float ME1_DevelopmentMethodologies_PCR;
        public float ME1_SoftwareDesignBasics_PCR;
        public float ME1_DatabaseBasics_PCR;
        public float ME1_UXBasics_PCR;
        public float ME1_SoftwareEngineeringBestPractices_PCR;
        public float ME1_WebServices_PCR;
        public float ME1_SecurityBasics_PCR;
        public float ME1_LanguagesAndPlatformsFundamentals_PCR;

        public float ME2_AlgorithmDesignAndAnalysis_PCR;
        public float ME2_UserInfoAndAppPublishing_PCR;
        public float ME2_EstimationTechniques_PCR;
        public float ME2_DesignPatterns_PCR;
        public float ME2_TestingAdvance_PCR;
        public float ME2_ConcurrentProgramming_PCR;
        public float ME2_PlatformBestPractices_PCR;
        public float ME2_ConnectivityAndPushNotifications_PCR;
        public float ME2_SensorBasicsLocationAndMaps_PCR;
        public float ME2_CloudMobileServices_PCR;

        public float ME3_SecurityAdvanced_PCR;
        public float ME3_SensorsAdvanced_PCR;
        public float ME3_InAppPurchaseAndPayments_PCR;
        public float ME3_Wearables_PCR;
        public float ME3_TechnologyAndPlatformSpecifics_PCR;
        public float ME3_RequirementsEngineering_PCR;
        public float ME3_WebServicesAndMicroservices_PCR;

        public float QA0_QualityAssuranceConcepts_PCR;
        public float QA0_TestingTypes_PCR;
        public float QA0_AvanticaQualityAssuranceMethodology_PCR;
        public float QA0_TestCasesDesignAndEstimationTechniques_PCR;
        public float QA0_BugManagement_PCR;
        public float QA0_DevelopmentMethodologies_PCR;
        public float QA0_QATools_PCR;
        public float QA0_AvanticaTestingServicesWorkspace_PCR;

        public float QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_PCR;
        public float QA1_SQLForQualityAssurance_PCR;
        public float QA1_TestCaseAutomationConcepts_PCR;
        public float QA1_TestCasesAutomation_PCR;
        public float QA1_MobileTesting_PCR;
        public float QA1_PerformanceTesting_PCR;
        public float QA1_SoftwareEvaluationMetrics_PCR;

        public float QA2_TestCaseManagement_PCR;
        public float QA2_AdvancedBugManagement_PCR;
        public float QA2_RequirementsManagement_PCR;
        public float QA2_TestStrategyDesign_PCR;
        public float QA2_AdvancedPerformanceTesting_PCR;
        public float QA2_SecurityTestingConcepts_PCR;
        public float QA2_AdvancedSecurityTesting_PCR;
        public float QA2_ProjectManagementInAvantica_PCR;

        public float QA3_ArchitectureForQA_PCR;
        public float QA3_AdvancedSoftwareEvaluationMetrics_PCR;
        public float QA3_ProjectManagementI_PCR;
        public float QA3_ProjectManagementII_PCR;
        public float QA3_SoftSkillsI_PCR;
        public float QA3_SoftSkillsII_PCR;
        public float QA3_SoftSkillsFromHHRR_PCR;*/

        public string Label;
    }

    public class PerfilPersonalizadoPrediction
    {
        [ColumnName("PredictedLabel")]
        public string PerfilPersonalizadoLabels;
    }
}
