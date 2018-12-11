using EverestLMS.UnitTests.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EverestLMS.UnitTests
{
    public class GenerarModelPerfilesPersonalizadosUnitTest
    {
        #region Setup
        List<string> carreras;
        List<string> niveles;

        List<string> temasBA1;
        List<string> temasBA2;

        List<string> temasSE1;
        List<string> temasSE2;
        List<string> temasSE3;

        List<string> temasDEVOPS1;
        List<string> temasDEVOPS2;
        List<string> temasDEVOPS3;

        List<string> temasMobile1;
        List<string> temasMobile2;
        List<string> temasMobile3;

        List<string> temasQA0;
        List<string> temasQA1;
        List<string> temasQA2;
        List<string> temasQA3;

        Dictionary<string, int> dictionaryTemas;

        private const float percentageLimitPCR = 0.3f;
        private const float percentageFavoritesPCR = percentageNoFavoritesPCR;
        private const float percentageNoFavoritesPCR = 0.1f;

        [SetUp]
        public void Setup()
        {
            AddCarreras();
            AddNiveles();
            AddTemas();
            AddIdTemasMasSeleccionados();
        }

        private void AddCarreras()
        {
            carreras = new List<string>();
            carreras.Add("BA");
            carreras.Add("SE");
            carreras.Add("QA");
            carreras.Add("DEVOPS");
            carreras.Add("ME");
        }

        private void AddNiveles()
        {
            niveles = new List<string>();
            niveles.Add("0");
            niveles.Add("1");
            niveles.Add("2");
            niveles.Add("3");
        }

        private void AddIdTemasMasSeleccionados()
        {
            dictionaryTemas = new Dictionary<string, int>();
            int countId = 1;
            dictionaryTemas.Add("BusinessAnalysisMethodology", countId++);
            dictionaryTemas.Add("Requirements", countId++);
            dictionaryTemas.Add("ElicitationAndColaboration", countId++);
            dictionaryTemas.Add("RequirementsMatriz", countId++);
            dictionaryTemas.Add("BasicUML", countId++);
            dictionaryTemas.Add("AdvancedUML", countId++);
            dictionaryTemas.Add("Agile", countId++);
            dictionaryTemas.Add("RequirementLifecycleManagement", countId++);
            dictionaryTemas.Add("ChangesRequest", countId++);

            dictionaryTemas.Add("Needs", countId++);
            dictionaryTemas.Add("PlanningAndSupervision", countId++);
            dictionaryTemas.Add("AnalisysPlan", countId++);
            dictionaryTemas.Add("StrategicAnalisys", countId++);
            dictionaryTemas.Add("RiskAnalisys", countId++);
            dictionaryTemas.Add("SolutionEvaluation", countId++);

            dictionaryTemas.Add("QualityAssuranceConcepts", countId++);
            dictionaryTemas.Add("DevelopmentMethodologies", countId++);
            dictionaryTemas.Add("SoftwareEngineeringBestPractices", countId++);
            dictionaryTemas.Add("SoftwareDesignBasics", countId++);
            dictionaryTemas.Add("DatabaseBasics", countId++);
            dictionaryTemas.Add("WebDevelopmentBasics", countId++);
            dictionaryTemas.Add("SecurityBasics", countId++);
            dictionaryTemas.Add("UXBasics", countId++);
            dictionaryTemas.Add("LanguageAndPlatformFundamentals", countId++);

            dictionaryTemas.Add("EstimationTechniques", countId++);
            dictionaryTemas.Add("PlatformBestPractices", countId++);
            dictionaryTemas.Add("AlgorithmsDesignAndAnalysis", countId++);
            dictionaryTemas.Add("DesignPatterns", countId++);
            dictionaryTemas.Add("DatabaseAdvanced", countId++);
            dictionaryTemas.Add("WebDevelopmentAdvanced", countId++);
            dictionaryTemas.Add("TestingAdvanced", countId++);
            dictionaryTemas.Add("ConcurrentProgramming", countId++);

            dictionaryTemas.Add("RequirementsEngineering", countId++);
            dictionaryTemas.Add("SecurityAdvanced", countId++);
            dictionaryTemas.Add("DatabaseDesign", countId++);
            dictionaryTemas.Add("TechnologyAndPlatformSpecifics", countId++);
            dictionaryTemas.Add("WebServicesAndMicroservices", countId++);
            dictionaryTemas.Add("ArtificialIntelligence", countId++);
            dictionaryTemas.Add("CloudBasics", countId++);

            dictionaryTemas.Add("SourceCodeManagement", countId++);
            dictionaryTemas.Add("ScriptingForProcessAutomation", countId++);
            dictionaryTemas.Add("DevOpsGeneralConcepts", countId++);
            dictionaryTemas.Add("ContinuousIntegration", countId++);
            dictionaryTemas.Add("TestAutomation", countId++);
            dictionaryTemas.Add("DeliveryPipelines", countId++);
            dictionaryTemas.Add("AgileAndDevOps", countId++);

            dictionaryTemas.Add("AppContainerization", countId++);
            dictionaryTemas.Add("ConfigurationManagement", countId++);
            dictionaryTemas.Add("ContinuousDeliveryAndDeployment", countId++);
            dictionaryTemas.Add("SystemAdministration", countId++);
            dictionaryTemas.Add("ChatOps", countId++);
            dictionaryTemas.Add("PerformanceBasics", countId++);
            dictionaryTemas.Add("CloudComputingBasics", countId++);

            dictionaryTemas.Add("AdvancedCloudComputing", countId++);
            dictionaryTemas.Add("InfrastructureAsCode", countId++);
            dictionaryTemas.Add("Monitoring", countId++);
            dictionaryTemas.Add("ProjectManagementInAvantica", countId++);
            dictionaryTemas.Add("Metrics", countId++);
            dictionaryTemas.Add("MicroservicesArchitecture", countId++);
            dictionaryTemas.Add("ServerlessConcepts", countId++);
            dictionaryTemas.Add("DevOpsCulture", countId++);
            dictionaryTemas.Add("ContinuousDeliveryStrategies", countId++);

            dictionaryTemas.Add("WebServices", countId++);
            dictionaryTemas.Add("LanguagesAndPlatformsFundamentals", countId++);

            dictionaryTemas.Add("AlgorithmDesignAndAnalysis", countId++);
            dictionaryTemas.Add("UserInfoAndAppPublishing", countId++);
            dictionaryTemas.Add("TestingAdvance", countId++);
            dictionaryTemas.Add("ConnectivityAndPushNotifications", countId++);
            dictionaryTemas.Add("SensorBasicsLocationAndMaps", countId++);
            dictionaryTemas.Add("CloudMobileServices", countId++);

            dictionaryTemas.Add("SensorsAdvanced", countId++);
            dictionaryTemas.Add("InAppPurchaseAndPayments", countId++);
            dictionaryTemas.Add("Wearables", countId++);

            dictionaryTemas.Add("TestingTypes", countId++);
            dictionaryTemas.Add("AvanticaQualityAssuranceMethodology", countId++);
            dictionaryTemas.Add("TestCasesDesignAndEstimationTechniques", countId++);
            dictionaryTemas.Add("BugManagement", countId++);
            dictionaryTemas.Add("QATools", countId++);
            dictionaryTemas.Add("AvanticaTestingServicesWorkspace", countId++);

            dictionaryTemas.Add("QualityAssuranceInSoftwareDevelopmentLifeCycle", countId++);
            dictionaryTemas.Add("SQLForQualityAssurance", countId++);
            dictionaryTemas.Add("TestCaseAutomationConcepts", countId++);
            dictionaryTemas.Add("TestCasesAutomation", countId++);
            dictionaryTemas.Add("MobileTesting", countId++);
            dictionaryTemas.Add("PerformanceTesting", countId++);
            dictionaryTemas.Add("SoftwareEvaluationMetrics", countId++);

            dictionaryTemas.Add("TestCaseManagement", countId++);
            dictionaryTemas.Add("AdvancedBugManagement", countId++);
            dictionaryTemas.Add("RequirementsManagement", countId++);
            dictionaryTemas.Add("TestStrategyDesign", countId++);
            dictionaryTemas.Add("AdvancedPerformanceTesting", countId++);
            dictionaryTemas.Add("SecurityTestingConcepts", countId++);
            dictionaryTemas.Add("AdvancedSecurityTesting", countId++);

            dictionaryTemas.Add("ArchitectureForQA", countId++);
            dictionaryTemas.Add("AdvancedSoftwareEvaluationMetrics", countId++);
            dictionaryTemas.Add("ProjectManagementI", countId++);
            dictionaryTemas.Add("ProjectManagementII", countId++);
            dictionaryTemas.Add("SoftSkillsI", countId++);
            dictionaryTemas.Add("SoftSkillsII", countId++);
            dictionaryTemas.Add("SoftSkillsFromHHRR", countId++);
        }

        private void AddTemas()
        {
            temasBA1 = new List<string>();
            temasBA2 = new List<string>();

            temasSE1 = new List<string>();
            temasSE2 = new List<string>();
            temasSE3 = new List<string>();

            temasDEVOPS1 = new List<string>();
            temasDEVOPS2 = new List<string>();
            temasDEVOPS3 = new List<string>();

            temasMobile1 = new List<string>();
            temasMobile2 = new List<string>();
            temasMobile3 = new List<string>();

            temasQA0 = new List<string>();
            temasQA1 = new List<string>();
            temasQA2 = new List<string>();
            temasQA3 = new List<string>();

            temasBA1.Add("BusinessAnalysisMethodology");
            temasBA1.Add("Requirements");
            temasBA1.Add("ElicitationAndColaboration");
            temasBA1.Add("RequirementsMatriz");
            temasBA1.Add("BasicUML");
            temasBA1.Add("AdvancedUML");
            temasBA1.Add("Agile");
            temasBA1.Add("RequirementLifecycleManagement");
            temasBA1.Add("ChangesRequest");

            temasBA2.Add("Needs");
            temasBA2.Add("PlanningAndSupervision");
            temasBA2.Add("AnalisysPlan");
            temasBA2.Add("StrategicAnalisys");
            temasBA2.Add("RiskAnalisys");
            temasBA2.Add("SolutionEvaluation");

            temasSE1.Add("QualityAssuranceConcepts");
            temasSE1.Add("DevelopmentMethodologies");
            temasSE1.Add("SoftwareEngineeringBestPractices");
            temasSE1.Add("SoftwareDesignBasics");
            temasSE1.Add("DatabaseBasics");
            temasSE1.Add("WebDevelopmentBasics");
            temasSE1.Add("SecurityBasics");
            temasSE1.Add("UXBasics");
            temasSE1.Add("LanguageAndPlatformFundamentals");

            temasSE2.Add("EstimationTechniques");
            temasSE2.Add("PlatformBestPractices");
            temasSE2.Add("AlgorithmsDesignAndAnalysis");
            temasSE2.Add("DesignPatterns");
            temasSE2.Add("DatabaseAdvanced");
            temasSE2.Add("WebDevelopmentAdvanced");
            temasSE2.Add("TestingAdvanced");
            temasSE2.Add("ConcurrentProgramming");

            temasSE3.Add("RequirementsEngineering");
            temasSE3.Add("SecurityAdvanced");
            temasSE3.Add("DatabaseDesign");
            temasSE3.Add("TechnologyAndPlatformSpecifics");
            temasSE3.Add("WebServicesAndMicroservices");
            temasSE3.Add("ArtificialIntelligence");
            temasSE3.Add("CloudBasics");

            temasDEVOPS1.Add("DevelopmentMethodologies");
            temasDEVOPS1.Add("QualityAssuranceConcepts");
            temasDEVOPS1.Add("SourceCodeManagement");
            temasDEVOPS1.Add("ScriptingForProcessAutomation");
            temasDEVOPS1.Add("DevOpsGeneralConcepts");
            temasDEVOPS1.Add("ContinuousIntegration");
            temasDEVOPS1.Add("TestAutomation");
            temasDEVOPS1.Add("DeliveryPipelines");
            temasDEVOPS1.Add("DatabaseBasics");
            temasDEVOPS1.Add("AgileAndDevOps");

            temasDEVOPS2.Add("AppContainerization");
            temasDEVOPS2.Add("ConfigurationManagement");
            temasDEVOPS2.Add("ContinuousDeliveryAndDeployment");
            temasDEVOPS2.Add("SystemAdministration");
            temasDEVOPS2.Add("EstimationTechniques");
            temasDEVOPS2.Add("ChatOps");
            temasDEVOPS2.Add("SecurityBasics");
            temasDEVOPS2.Add("PerformanceBasics");
            temasDEVOPS2.Add("CloudComputingBasics");

            temasDEVOPS3.Add("AdvancedCloudComputing");
            temasDEVOPS3.Add("InfrastructureAsCode");
            temasDEVOPS3.Add("Monitoring");
            temasDEVOPS3.Add("ProjectManagementInAvantica");
            temasDEVOPS3.Add("Metrics");
            temasDEVOPS3.Add("MicroservicesArchitecture");
            temasDEVOPS3.Add("ServerlessConcepts");
            temasDEVOPS3.Add("DevOpsCulture");
            temasDEVOPS3.Add("ContinuousDeliveryStrategies");

            temasMobile1.Add("QualityAssuranceConcepts");
            temasMobile1.Add("DevelopmentMethodologies");
            temasMobile1.Add("SoftwareDesignBasics");
            temasMobile1.Add("DatabaseBasics");
            temasMobile1.Add("UXBasics");
            temasMobile1.Add("SoftwareEngineeringBestPractices");
            temasMobile1.Add("WebServices");
            temasMobile1.Add("SecurityBasics");
            temasMobile1.Add("LanguagesAndPlatformsFundamentals");

            temasMobile2.Add("AlgorithmDesignAndAnalysis");
            temasMobile2.Add("UserInfoAndAppPublishing");
            temasMobile2.Add("EstimationTechniques");
            temasMobile2.Add("DesignPatterns");
            temasMobile2.Add("TestingAdvance");
            temasMobile2.Add("ConcurrentProgramming");
            temasMobile2.Add("PlatformBestPractices");
            temasMobile2.Add("ConnectivityAndPushNotifications");
            temasMobile2.Add("SensorBasicsLocationAndMaps");
            temasMobile2.Add("CloudMobileServices");

            temasMobile3.Add("SecurityAdvanced");
            temasMobile3.Add("SensorsAdvanced");
            temasMobile3.Add("InAppPurchaseAndPayments");
            temasMobile3.Add("Wearables");
            temasMobile3.Add("TechnologyAndPlatformSpecifics");
            temasMobile3.Add("RequirementsEngineering");
            temasMobile3.Add("WebServicesAndMicroservices");

            temasQA0.Add("QualityAssuranceConcepts");
            temasQA0.Add("TestingTypes");
            temasQA0.Add("AvanticaQualityAssuranceMethodology");
            temasQA0.Add("TestCasesDesignAndEstimationTechniques");
            temasQA0.Add("BugManagement");
            temasQA0.Add("DevelopmentMethodologies");
            temasQA0.Add("QATools");
            temasQA0.Add("AvanticaTestingServicesWorkspace");

            temasQA1.Add("QualityAssuranceInSoftwareDevelopmentLifeCycle");
            temasQA1.Add("SQLForQualityAssurance");
            temasQA1.Add("TestCaseAutomationConcepts");
            temasQA1.Add("TestCasesAutomation");
            temasQA1.Add("MobileTesting");
            temasQA1.Add("PerformanceTesting");
            temasQA1.Add("SoftwareEvaluationMetrics");

            temasQA2.Add("TestCaseManagement");
            temasQA2.Add("AdvancedBugManagement");
            temasQA2.Add("RequirementsManagement");
            temasQA2.Add("TestStrategyDesign");
            temasQA2.Add("AdvancedPerformanceTesting");
            temasQA2.Add("SecurityTestingConcepts");
            temasQA2.Add("AdvancedSecurityTesting");
            temasQA2.Add("ProjectManagementInAvantica");

            temasQA3.Add("ArchitectureForQA");
            temasQA3.Add("AdvancedSoftwareEvaluationMetrics");
            temasQA3.Add("ProjectManagementI");
            temasQA3.Add("ProjectManagementII");
            temasQA3.Add("SoftSkillsI");
            temasQA3.Add("SoftSkillsII");
            temasQA3.Add("SoftSkillsFromHHRR");
        }
        #endregion

        [Test]
        public void GenerarLabelPerfilesPersonalizados()
        {
            List<PerfilPersonalizadoData> perfilesPersonalizados = new List<PerfilPersonalizadoData>();
            for (int i = 0; i < 1; i++)
            {
                perfilesPersonalizados.AddRange(GeneratePerfiles());
            }
            bool succeded = CreateFile(perfilesPersonalizados);
            Assert.IsTrue(succeded);
        }

        private List<PerfilPersonalizadoData> GeneratePerfiles()
        {
            List<PerfilPersonalizadoData> perfilesPersonalizados = new List<PerfilPersonalizadoData>();
            foreach (var carrera in carreras)
            {
                foreach (var nivel in niveles)
                {
                    List<PerfilPersonalizadoData> temasTop3Combinaciones = new List<PerfilPersonalizadoData>();
                    if (nivel == "0")
                    {
                        if (carrera == "QA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasQA0);
                    }
                    if (nivel == "1")
                    {
                        if (carrera == "BA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasBA1);
                        if (carrera == "SE")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasSE1);
                        if (carrera == "QA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasQA1);
                        if (carrera == "DEVOPS")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasDEVOPS1);
                        if (carrera == "ME")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasMobile1);
                    }
                    if (nivel == "2")
                    {
                        if (carrera == "BA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasBA2);
                        if (carrera == "SE")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasSE2);
                        if (carrera == "QA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasQA2);
                        if (carrera == "DEVOPS")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasDEVOPS2);
                        if (carrera == "ME")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasMobile2);
                    }
                    if (nivel == "3")
                    {
                        if (carrera == "SE")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasSE3);
                        if (carrera == "QA")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasQA3);
                        if (carrera == "DEVOPS")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasDEVOPS3);
                        if (carrera == "ME")
                            temasTop3Combinaciones = GetTemasTop3Combinaciones(carrera, nivel, temasMobile3);
                    }
                    perfilesPersonalizados.AddRange(temasTop3Combinaciones);
                }
            }
            return perfilesPersonalizados;
        }
        /*
         * Xm a Xn = Ratio de respuestas correctas entre respuestas incorrectas por tema Z1 a Zn. 
            Para recomendar los cursos relacionados a los temas que mas debilidades tiene. (1.0 < X)
            Xm a Xn = Porcentaje de tiempo realizado por tema Z1 a Zn entre el tiempo total realizado.
            Para recomendar los cursos relacionados a los temas que más interés tiene. (percentageLimitPCR > X)

         */
        private List<PerfilPersonalizadoData> GetTemasTop3Combinaciones(string carrera, string nivel, List<string> temas)
        {
            List<PerfilPersonalizadoData> perfilPersonalizados = new List<PerfilPersonalizadoData>();
            for (int i = 0; i < temas.Count; i++)
            {
                string top3combinacion = String.Empty;
                for (int j = i + 1; j < temas.Count; j++)
                {
                    for (int k = j + 1; k < temas.Count; k++)
                    {
                        PerfilPersonalizadoData perfilPersonalizadoData = new PerfilPersonalizadoData();
                        if (carrera == "BA")
                            perfilPersonalizadoData.LineaCarrera = 1.0f;
                        if (carrera == "SE")
                            perfilPersonalizadoData.LineaCarrera = 2.0f;
                        if (carrera == "QA")
                            perfilPersonalizadoData.LineaCarrera = 3.0f;
                        if (carrera == "DEVOPS")
                            perfilPersonalizadoData.LineaCarrera = 4.0f;
                        if (carrera == "ME")
                            perfilPersonalizadoData.LineaCarrera = 5.0f;

                        perfilPersonalizadoData.Nivel = (float)Convert.ToInt32(nivel);

                        if (temas[i] == "BusinessAnalysisMethodology" || temas[j] == "BusinessAnalysisMethodology" || temas[k] == "BusinessAnalysisMethodology")
                        {
                            perfilPersonalizadoData.BA1_BusinessAnalysisMethodology_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["BusinessAnalysisMethodology"]; perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["BusinessAnalysisMethodology"];
                            //perfilPersonalizadoData.TemaMasSeleccionado = 1;// "BusinessAnalysisMethodology";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                            /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                             perfilPersonalizadoData.BA1_BusinessAnalysisMethodology_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_BusinessAnalysisMethodology_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_BusinessAnalysisMethodology_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "Requirements" || temas[j] == "Requirements" || temas[k] == "Requirements")
                        {
                            perfilPersonalizadoData.BA1_Requirements_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Requirements"];//perfilPersonalizadoData.TemaMasSeleccionado = 2;// "Requirements";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_Requirements_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_Requirements_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_Requirements_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ElicitationAndColaboration" || temas[j] == "ElicitationAndColaboration" || temas[k] == "ElicitationAndColaboration")
                        {
                            perfilPersonalizadoData.BA1_ElicitationAndColaboration_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ElicitationAndColaboration"];//perfilPersonalizadoData.TemaMasSeleccionado = 3;// "ElicitationAndColaboration";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_ElicitationAndColaboration_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_ElicitationAndColaboration_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_ElicitationAndColaboration_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "RequirementsMatriz" || temas[j] == "RequirementsMatriz" || temas[k] == "RequirementsMatriz")
                        {
                            perfilPersonalizadoData.BA1_RequirementsMatriz_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RequirementsMatriz"];//perfilPersonalizadoData.TemaMasSeleccionado = 4;// "RequirementsMatriz";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_RequirementsMatriz_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_RequirementsMatriz_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_RequirementsMatriz_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "BasicUML" || temas[j] == "BasicUML" || temas[k] == "BasicUML")
                        {
                            perfilPersonalizadoData.BA1_BasicUML_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["BasicUML"];//perfilPersonalizadoData.TemaMasSeleccionado = 5;// "BasicUML";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_BasicUML_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_BasicUML_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_BasicUML_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AdvancedUML" || temas[j] == "AdvancedUML" || temas[k] == "AdvancedUML")
                        {
                            perfilPersonalizadoData.BA1_AdvancedUML_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedUML"];//perfilPersonalizadoData.TemaMasSeleccionado = 6;// "AdvancedUML";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_AdvancedUML_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_AdvancedUML_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_AdvancedUML_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "Agile" || temas[j] == "Agile" || temas[k] == "Agile")
                        {
                            perfilPersonalizadoData.BA1_Agile_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Agile"];//perfilPersonalizadoData.TemaMasSeleccionado = 7;// "Agile";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_Agile_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_Agile_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_Agile_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "RequirementLifecycleManagement" || temas[j] == "RequirementLifecycleManagement" || temas[k] == "RequirementLifecycleManagement")
                        {
                            perfilPersonalizadoData.BA1_RequirementLifecycleManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RequirementLifecycleManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = 8;// "RequirementLifecycleManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_RequirementLifecycleManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_RequirementLifecycleManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_RequirementLifecycleManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ChangesRequest" || temas[j] == "ChangesRequest" || temas[k] == "ChangesRequest")
                        {
                            perfilPersonalizadoData.BA1_ChangesRequest_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ChangesRequest"];//perfilPersonalizadoData.TemaMasSeleccionado = 9;// "ChangesRequest";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA1_ChangesRequest_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA1_ChangesRequest_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA1_ChangesRequest_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "Needs" || temas[j] == "Needs" || temas[k] == "Needs")
                        {
                            perfilPersonalizadoData.BA2_Needs_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Needs"];//perfilPersonalizadoData.TemaMasSeleccionado = 10;// "Needs";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_Needs_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_Needs_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_Needs_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "PlanningAndSupervision" || temas[j] == "PlanningAndSupervision" || temas[k] == "PlanningAndSupervision")
                        {
                            perfilPersonalizadoData.BA2_PlanningAndSupervision_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["PlanningAndSupervision"];//perfilPersonalizadoData.TemaMasSeleccionado = 11;// "PlanningAndSupervision";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_PlanningAndSupervision_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_PlanningAndSupervision_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_PlanningAndSupervision_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AnalisysPlan" || temas[j] == "AnalisysPlan" || temas[k] == "AnalisysPlan")
                        {
                            perfilPersonalizadoData.BA2_AnalisysPlan_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AnalisysPlan"];//perfilPersonalizadoData.TemaMasSeleccionado = 12;// "AnalisysPlan";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_AnalisysPlan_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_AnalisysPlan_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_AnalisysPlan_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "StrategicAnalisys" || temas[j] == "StrategicAnalisys" || temas[k] == "StrategicAnalisys")
                        {
                            perfilPersonalizadoData.BA2_StrategicAnalisys_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["StrategicAnalisys"];//perfilPersonalizadoData.TemaMasSeleccionado = 13;// "StrategicAnalisys";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_StrategicAnalisys_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_StrategicAnalisys_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_StrategicAnalisys_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "RiskAnalisys" || temas[j] == "RiskAnalisys" || temas[k] == "RiskAnalisys")
                        {
                            perfilPersonalizadoData.BA2_RiskAnalisys_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RiskAnalisys"];//perfilPersonalizadoData.TemaMasSeleccionado = 14;// "RiskAnalisys";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_RiskAnalisys_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_RiskAnalisys_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_RiskAnalisys_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SolutionEvaluation" || temas[j] == "SolutionEvaluation" || temas[k] == "SolutionEvaluation")
                        {
                            perfilPersonalizadoData.BA2_SolutionEvaluation_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SolutionEvaluation"];//perfilPersonalizadoData.TemaMasSeleccionado = 15;// "SolutionEvaluation";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.BA2_SolutionEvaluation_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.BA2_SolutionEvaluation_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.BA2_SolutionEvaluation_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "QualityAssuranceConcepts" || temas[j] == "QualityAssuranceConcepts" || temas[k] == "QualityAssuranceConcepts")
                        {
                            perfilPersonalizadoData.SE1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QualityAssuranceConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = 16;// "QualityAssuranceConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DevelopmentMethodologies" || temas[j] == "DevelopmentMethodologies" || temas[k] == "DevelopmentMethodologies")
                        {
                            perfilPersonalizadoData.SE1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevelopmentMethodologies"];//perfilPersonalizadoData.TemaMasSeleccionado = 17;// "DevelopmentMethodologies";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftwareEngineeringBestPractices" || temas[j] == "SoftwareEngineeringBestPractices" || temas[k] == "SoftwareEngineeringBestPractices")
                        {
                            perfilPersonalizadoData.SE1_SoftwareEngineeringBestPractices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftwareEngineeringBestPractices"];//perfilPersonalizadoData.TemaMasSeleccionado = 18;// "SoftwareEngineeringBestPractices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_SoftwareEngineeringBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_SoftwareEngineeringBestPractices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_SoftwareEngineeringBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftwareDesignBasics" || temas[j] == "SoftwareDesignBasics" || temas[k] == "SoftwareDesignBasics")
                        {
                            perfilPersonalizadoData.SE1_SoftwareDesignBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftwareDesignBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 19;// "SoftwareDesignBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_SoftwareDesignBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_SoftwareDesignBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_SoftwareDesignBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DatabaseBasics" || temas[j] == "DatabaseBasics" || temas[k] == "DatabaseBasics")
                        {
                            perfilPersonalizadoData.SE1_DatabaseBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DatabaseBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 20;// "DatabaseBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_DatabaseBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "WebDevelopmentBasics" || temas[j] == "WebDevelopmentBasics" || temas[k] == "WebDevelopmentBasics")
                        {
                            perfilPersonalizadoData.SE1_WebDevelopmentBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["WebDevelopmentBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 21;// "WebDevelopmentBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_WebDevelopmentBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_WebDevelopmentBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_WebDevelopmentBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SecurityBasics" || temas[j] == "SecurityBasics" || temas[k] == "SecurityBasics")
                        {
                            perfilPersonalizadoData.SE1_SecurityBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 22;// "SecurityBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_SecurityBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "UXBasics" || temas[j] == "UXBasics" || temas[k] == "UXBasics")
                        {
                            perfilPersonalizadoData.SE1_UXBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["UXBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 23;// "UXBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_UXBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_UXBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_UXBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "LanguageAndPlatformFundamentals" || temas[j] == "LanguageAndPlatformFundamentals" || temas[k] == "LanguageAndPlatformFundamentals")
                        {
                            perfilPersonalizadoData.SE1_LanguageAndPlatformFundamentals_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["LanguageAndPlatformFundamentals"];//perfilPersonalizadoData.TemaMasSeleccionado = 24;// "LanguageAndPlatformFundamentals";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE1_LanguageAndPlatformFundamentals_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE1_LanguageAndPlatformFundamentals_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE1_LanguageAndPlatformFundamentals_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "EstimationTechniques" || temas[j] == "EstimationTechniques" || temas[k] == "EstimationTechniques")
                        {
                            perfilPersonalizadoData.SE2_EstimationTechniques_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["EstimationTechniques"];//perfilPersonalizadoData.TemaMasSeleccionado = 25;// "EstimationTechniques";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_EstimationTechniques_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "PlatformBestPractices" || temas[j] == "PlatformBestPractices" || temas[k] == "PlatformBestPractices")
                        {
                            perfilPersonalizadoData.SE2_PlatformBestPractices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["PlatformBestPractices"];//perfilPersonalizadoData.TemaMasSeleccionado = 26;// "PlatformBestPractices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_PlatformBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_PlatformBestPractices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_PlatformBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AlgorithmsDesignAndAnalysis" || temas[j] == "AlgorithmsDesignAndAnalysis" || temas[k] == "AlgorithmsDesignAndAnalysis")
                        {
                            perfilPersonalizadoData.SE2_AlgorithmsDesignAndAnalysis_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AlgorithmsDesignAndAnalysis"];//perfilPersonalizadoData.TemaMasSeleccionado = 27;// "AlgorithmsDesignAndAnalysis";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_AlgorithmsDesignAndAnalysis_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_AlgorithmsDesignAndAnalysis_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_AlgorithmsDesignAndAnalysis_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DesignPatterns" || temas[j] == "DesignPatterns" || temas[k] == "DesignPatterns")
                        {
                            perfilPersonalizadoData.SE2_DesignPatterns_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DesignPatterns"];//perfilPersonalizadoData.TemaMasSeleccionado = 28;// "DesignPatterns";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_DesignPatterns_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_DesignPatterns_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_DesignPatterns_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DatabaseAdvanced" || temas[j] == "DatabaseAdvanced" || temas[k] == "DatabaseAdvanced")
                        {
                            perfilPersonalizadoData.SE2_DatabaseAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DatabaseAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = 29;// "DatabaseAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_DatabaseAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_DatabaseAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_DatabaseAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "WebDevelopmentAdvanced" || temas[j] == "WebDevelopmentAdvanced" || temas[k] == "WebDevelopmentAdvanced")
                        {
                            perfilPersonalizadoData.SE2_WebDevelopmentAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["WebDevelopmentAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = 30;// "WebDevelopmentAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_WebDevelopmentAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_WebDevelopmentAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_WebDevelopmentAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestingAdvanced" || temas[j] == "TestingAdvanced" || temas[k] == "TestingAdvanced")
                        {
                            perfilPersonalizadoData.SE2_TestingAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestingAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = 31;// "TestingAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_TestingAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_TestingAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_TestingAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ConcurrentProgramming" || temas[j] == "ConcurrentProgramming" || temas[k] == "ConcurrentProgramming")
                        {
                            perfilPersonalizadoData.SE2_ConcurrentProgramming_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ConcurrentProgramming"];//perfilPersonalizadoData.TemaMasSeleccionado = 32;// "ConcurrentProgramming";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE2_ConcurrentProgramming_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE2_ConcurrentProgramming_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE2_ConcurrentProgramming_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "RequirementsEngineering" || temas[j] == "RequirementsEngineering" || temas[k] == "RequirementsEngineering")
                        {
                            perfilPersonalizadoData.SE3_RequirementsEngineering_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RequirementsEngineering"];//perfilPersonalizadoData.TemaMasSeleccionado = 33;// "RequirementsEngineering";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_RequirementsEngineering_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_RequirementsEngineering_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_RequirementsEngineering_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SecurityAdvanced" || temas[j] == "SecurityAdvanced" || temas[k] == "SecurityAdvanced")
                        {
                            perfilPersonalizadoData.SE3_SecurityAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = 34;// "SecurityAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_SecurityAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_SecurityAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_SecurityAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DatabaseDesign" || temas[j] == "DatabaseDesign" || temas[k] == "DatabaseDesign")
                        {
                            perfilPersonalizadoData.SE3_DatabaseDesign_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DatabaseDesign"];//perfilPersonalizadoData.TemaMasSeleccionado = 35;// "DatabaseDesign";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_DatabaseDesign_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_DatabaseDesign_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_DatabaseDesign_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TechnologyAndPlatformSpecifics" || temas[j] == "TechnologyAndPlatformSpecifics" || temas[k] == "TechnologyAndPlatformSpecifics")
                        {
                            perfilPersonalizadoData.SE3_TechnologyAndPlatformSpecifics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TechnologyAndPlatformSpecifics"];//perfilPersonalizadoData.TemaMasSeleccionado = 36;// "TechnologyAndPlatformSpecifics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_TechnologyAndPlatformSpecifics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_TechnologyAndPlatformSpecifics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_TechnologyAndPlatformSpecifics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "WebServicesAndMicroservices" || temas[j] == "WebServicesAndMicroservices" || temas[k] == "WebServicesAndMicroservices")
                        {
                            perfilPersonalizadoData.SE3_WebServicesAndMicroservices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["WebServicesAndMicroservices"];//perfilPersonalizadoData.TemaMasSeleccionado = 37;// "WebServicesAndMicroservices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_WebServicesAndMicroservices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_WebServicesAndMicroservices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_WebServicesAndMicroservices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ArtificialIntelligence" || temas[j] == "ArtificialIntelligence" || temas[k] == "ArtificialIntelligence")
                        {
                            perfilPersonalizadoData.SE3_ArtificialIntelligence_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ArtificialIntelligence"];//perfilPersonalizadoData.TemaMasSeleccionado = 38;// "ArtificialIntelligence";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_ArtificialIntelligence_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_ArtificialIntelligence_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_ArtificialIntelligence_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "CloudBasics" || temas[j] == "CloudBasics" || temas[k] == "CloudBasics")
                        {
                            perfilPersonalizadoData.SE3_CloudBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["CloudBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = 39;// "CloudBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.SE3_CloudBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.SE3_CloudBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.SE3_CloudBasics_PCR = percetange; contarCampos++;*/
                        }
                        /*********************************************************/
                        /************************DEVOPS***************************/
                        /*********************************************************/
                        if (temas[i] == "DevelopmentMethodologies" || temas[j] == "DevelopmentMethodologies" || temas[k] == "DevelopmentMethodologies")
                        {
                            perfilPersonalizadoData.DEVOPS1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevelopmentMethodologies"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DevelopmentMethodologies";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "QualityAssuranceConcepts" || temas[j] == "QualityAssuranceConcepts" || temas[k] == "QualityAssuranceConcepts")
                        {
                            perfilPersonalizadoData.DEVOPS1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QualityAssuranceConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "QualityAssuranceConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SourceCodeManagement" || temas[j] == "SourceCodeManagement" || temas[k] == "SourceCodeManagement")
                        {
                            perfilPersonalizadoData.DEVOPS1_SourceCodeManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SourceCodeManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SourceCodeManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_SourceCodeManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_SourceCodeManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_SourceCodeManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ScriptingForProcessAutomation" || temas[j] == "ScriptingForProcessAutomation" || temas[k] == "ScriptingForProcessAutomation")
                        {
                            perfilPersonalizadoData.DEVOPS1_ScriptingForProcessAutomation_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ScriptingForProcessAutomation"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ScriptingForProcessAutomation";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_ScriptingForProcessAutomation_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_ScriptingForProcessAutomation_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_ScriptingForProcessAutomation_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DevOpsGeneralConcepts" || temas[j] == "DevOpsGeneralConcepts" || temas[k] == "DevOpsGeneralConcepts")
                        {
                            perfilPersonalizadoData.DEVOPS1_DevOpsGeneralConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevOpsGeneralConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DevOpsGeneralConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DevOpsGeneralConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_DevOpsGeneralConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DevOpsGeneralConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ContinuousIntegration" || temas[j] == "ContinuousIntegration" || temas[k] == "ContinuousIntegration")
                        {
                            perfilPersonalizadoData.DEVOPS1_ContinuousIntegration_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ContinuousIntegration"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ContinuousIntegration";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_ContinuousIntegration_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_ContinuousIntegration_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_ContinuousIntegration_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestAutomation" || temas[j] == "TestAutomation" || temas[k] == "TestAutomation")
                        {
                            perfilPersonalizadoData.DEVOPS1_TestAutomation_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestAutomation"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestAutomation";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_TestAutomation_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_TestAutomation_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_TestAutomation_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DeliveryPipelines" || temas[j] == "DeliveryPipelines" || temas[k] == "DeliveryPipelines")
                        {
                            perfilPersonalizadoData.DEVOPS1_DeliveryPipelines_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DeliveryPipelines"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DeliveryPipelines";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DeliveryPipelines_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_DeliveryPipelines_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DeliveryPipelines_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DatabaseBasics" || temas[j] == "DatabaseBasics" || temas[k] == "DatabaseBasics")
                        {
                            perfilPersonalizadoData.DEVOPS1_DatabaseBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DatabaseBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DatabaseBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_DatabaseBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AgileAndDevOps" || temas[j] == "AgileAndDevOps" || temas[k] == "AgileAndDevOps")
                        {
                            perfilPersonalizadoData.DEVOPS1_AgileAndDevOps_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AgileAndDevOps"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AgileAndDevOps";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_AgileAndDevOps_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS1_AgileAndDevOps_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS1_AgileAndDevOps_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "AppContainerization" || temas[j] == "AppContainerization" || temas[k] == "AppContainerization")
                        {
                            perfilPersonalizadoData.DEVOPS2_AppContainerization_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AppContainerization"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AppContainerization";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_AppContainerization_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_AppContainerization_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_AppContainerization_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ConfigurationManagement" || temas[j] == "ConfigurationManagement" || temas[k] == "ConfigurationManagement")
                        {
                            perfilPersonalizadoData.DEVOPS2_ConfigurationManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ConfigurationManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ConfigurationManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ConfigurationManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_ConfigurationManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ConfigurationManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ContinuousDeliveryAndDeployment" || temas[j] == "ContinuousDeliveryAndDeployment" || temas[k] == "ContinuousDeliveryAndDeployment")
                        {
                            perfilPersonalizadoData.DEVOPS2_ContinuousDeliveryAndDeployment_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ContinuousDeliveryAndDeployment"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ContinuousDeliveryAndDeployment";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ContinuousDeliveryAndDeployment_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_ContinuousDeliveryAndDeployment_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ContinuousDeliveryAndDeployment_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SystemAdministration" || temas[j] == "SystemAdministration" || temas[k] == "SystemAdministration")
                        {
                            perfilPersonalizadoData.DEVOPS2_SystemAdministration_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SystemAdministration"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SystemAdministration";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_SystemAdministration_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_SystemAdministration_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_SystemAdministration_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "EstimationTechniques" || temas[j] == "EstimationTechniques" || temas[k] == "EstimationTechniques")
                        {
                            perfilPersonalizadoData.DEVOPS2_EstimationTechniques_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["EstimationTechniques"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "EstimationTechniques";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_EstimationTechniques_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ChatOps" || temas[j] == "ChatOps" || temas[k] == "ChatOps")
                        {
                            perfilPersonalizadoData.DEVOPS2_ChatOps_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ChatOps"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ChatOps";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ChatOps_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_ChatOps_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_ChatOps_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SecurityBasics" || temas[j] == "SecurityBasics" || temas[k] == "SecurityBasics")
                        {
                            perfilPersonalizadoData.DEVOPS2_SecurityBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SecurityBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_SecurityBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "PerformanceBasics" || temas[j] == "PerformanceBasics" || temas[k] == "PerformanceBasics")
                        {
                            perfilPersonalizadoData.DEVOPS2_PerformanceBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["PerformanceBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "PerformanceBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_PerformanceBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_PerformanceBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_PerformanceBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "CloudComputingBasics" || temas[j] == "CloudComputingBasics" || temas[k] == "CloudComputingBasics")
                        {
                            perfilPersonalizadoData.DEVOPS2_CloudComputingBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["CloudComputingBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "CloudComputingBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_CloudComputingBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS2_CloudComputingBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS2_CloudComputingBasics_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "AdvancedCloudComputing" || temas[j] == "AdvancedCloudComputing" || temas[k] == "AdvancedCloudComputing")
                        {
                            perfilPersonalizadoData.DEVOPS3_AdvancedCloudComputing_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedCloudComputing"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AdvancedCloudComputing";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_AdvancedCloudComputing_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_AdvancedCloudComputing_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_AdvancedCloudComputing_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "InfrastructureAsCode" || temas[j] == "InfrastructureAsCode" || temas[k] == "InfrastructureAsCode")
                        {
                            perfilPersonalizadoData.DEVOPS3_InfrastructureAsCode_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["InfrastructureAsCode"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "InfrastructureAsCode";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_InfrastructureAsCode_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_InfrastructureAsCode_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_InfrastructureAsCode_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "Monitoring" || temas[j] == "Monitoring" || temas[k] == "Monitoring")
                        {
                            perfilPersonalizadoData.DEVOPS3_Monitoring_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Monitoring"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "Monitoring";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_Monitoring_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_Monitoring_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_Monitoring_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ProjectManagementInAvantica" || temas[j] == "ProjectManagementInAvantica" || temas[k] == "ProjectManagementInAvantica")
                        {
                            perfilPersonalizadoData.DEVOPS3_ProjectManagementInAvantica_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ProjectManagementInAvantica"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ProjectManagementInAvantica";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ProjectManagementInAvantica_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_ProjectManagementInAvantica_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ProjectManagementInAvantica_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "Metrics" || temas[j] == "Metrics" || temas[k] == "Metrics")
                        {
                            perfilPersonalizadoData.DEVOPS3_Metrics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Metrics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "Metrics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_Metrics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_Metrics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_Metrics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "MicroservicesArchitecture" || temas[j] == "MicroservicesArchitecture" || temas[k] == "MicroservicesArchitecture")
                        {
                            perfilPersonalizadoData.DEVOPS3_MicroservicesArchitecture_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["MicroservicesArchitecture"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "MicroservicesArchitecture";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_MicroservicesArchitecture_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_MicroservicesArchitecture_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_MicroservicesArchitecture_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ServerlessConcepts" || temas[j] == "ServerlessConcepts" || temas[k] == "ServerlessConcepts")
                        {
                            perfilPersonalizadoData.DEVOPS3_ServerlessConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ServerlessConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ServerlessConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ServerlessConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_ServerlessConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ServerlessConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DevOpsCulture" || temas[j] == "DevOpsCulture" || temas[k] == "DevOpsCulture")
                        {
                            perfilPersonalizadoData.DEVOPS3_DevOpsCulture_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevOpsCulture"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DevOpsCulture";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_DevOpsCulture_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_DevOpsCulture_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_DevOpsCulture_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ContinuousDeliveryStrategies" || temas[j] == "ContinuousDeliveryStrategies" || temas[k] == "ContinuousDeliveryStrategies")
                        {
                            perfilPersonalizadoData.DEVOPS3_ContinuousDeliveryStrategies_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ContinuousDeliveryStrategies"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ContinuousDeliveryStrategies";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ContinuousDeliveryStrategies_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.DEVOPS3_ContinuousDeliveryStrategies_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.DEVOPS3_ContinuousDeliveryStrategies_PCR = percetange; contarCampos++;*/
                        }
                        /*********************************************************/
                        /************************MOBILE***************************/
                        /*********************************************************/
                        if (temas[i] == "QualityAssuranceConcepts" || temas[j] == "QualityAssuranceConcepts" || temas[k] == "QualityAssuranceConcepts")
                        {
                            perfilPersonalizadoData.ME1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QualityAssuranceConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "QualityAssuranceConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DevelopmentMethodologies" || temas[j] == "DevelopmentMethodologies" || temas[k] == "DevelopmentMethodologies")
                        {
                            perfilPersonalizadoData.ME1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevelopmentMethodologies"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DevelopmentMethodologies";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_DevelopmentMethodologies_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftwareDesignBasics" || temas[j] == "SoftwareDesignBasics" || temas[k] == "SoftwareDesignBasics")
                        {
                            perfilPersonalizadoData.ME1_SoftwareDesignBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftwareDesignBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftwareDesignBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_SoftwareDesignBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_SoftwareDesignBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_SoftwareDesignBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DatabaseBasics" || temas[j] == "DatabaseBasics" || temas[k] == "DatabaseBasics")
                        {
                            perfilPersonalizadoData.ME1_DatabaseBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DatabaseBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DatabaseBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_DatabaseBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_DatabaseBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "UXBasics" || temas[j] == "UXBasics" || temas[k] == "UXBasics")
                        {
                            perfilPersonalizadoData.ME1_UXBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["UXBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "UXBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_UXBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_UXBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_UXBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftwareEngineeringBestPractices" || temas[j] == "SoftwareEngineeringBestPractices" || temas[k] == "SoftwareEngineeringBestPractices")
                        {
                            perfilPersonalizadoData.ME1_SoftwareEngineeringBestPractices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftwareEngineeringBestPractices"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftwareEngineeringBestPractices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_SoftwareEngineeringBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_SoftwareEngineeringBestPractices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_SoftwareEngineeringBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "WebServices" || temas[j] == "WebServices" || temas[k] == "WebServices")
                        {
                            perfilPersonalizadoData.ME1_WebServices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["WebServices"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "WebServices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_WebServices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_WebServices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_WebServices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SecurityBasics" || temas[j] == "SecurityBasics" || temas[k] == "SecurityBasics")
                        {
                            perfilPersonalizadoData.ME1_SecurityBasics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityBasics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SecurityBasics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_SecurityBasics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_SecurityBasics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "LanguagesAndPlatformsFundamentals" || temas[j] == "LanguagesAndPlatformsFundamentals" || temas[k] == "LanguagesAndPlatformsFundamentals")
                        {
                            perfilPersonalizadoData.ME1_LanguagesAndPlatformsFundamentals_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["LanguagesAndPlatformsFundamentals"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "LanguagesAndPlatformsFundamentals";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME1_LanguagesAndPlatformsFundamentals_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME1_LanguagesAndPlatformsFundamentals_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME1_LanguagesAndPlatformsFundamentals_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "AlgorithmDesignAndAnalysis" || temas[j] == "AlgorithmDesignAndAnalysis" || temas[k] == "AlgorithmDesignAndAnalysis")
                        {
                            perfilPersonalizadoData.ME2_AlgorithmDesignAndAnalysis_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AlgorithmDesignAndAnalysis"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AlgorithmDesignAndAnalysis";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_AlgorithmDesignAndAnalysis_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_AlgorithmDesignAndAnalysis_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_AlgorithmDesignAndAnalysis_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "UserInfoAndAppPublishing" || temas[j] == "UserInfoAndAppPublishing" || temas[k] == "UserInfoAndAppPublishing")
                        {
                            perfilPersonalizadoData.ME2_UserInfoAndAppPublishing_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["UserInfoAndAppPublishing"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "UserInfoAndAppPublishing";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_UserInfoAndAppPublishing_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_UserInfoAndAppPublishing_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_UserInfoAndAppPublishing_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "EstimationTechniques" || temas[j] == "EstimationTechniques" || temas[k] == "EstimationTechniques")
                        {
                            perfilPersonalizadoData.ME2_EstimationTechniques_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["EstimationTechniques"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "EstimationTechniques";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_EstimationTechniques_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_EstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DesignPatterns" || temas[j] == "DesignPatterns" || temas[k] == "DesignPatterns")
                        {
                            perfilPersonalizadoData.ME2_DesignPatterns_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DesignPatterns"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DesignPatterns";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_DesignPatterns_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_DesignPatterns_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_DesignPatterns_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestingAdvance" || temas[j] == "TestingAdvance" || temas[k] == "TestingAdvance")
                        {
                            perfilPersonalizadoData.ME2_TestingAdvance_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestingAdvance"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestingAdvance";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_TestingAdvance_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_TestingAdvance_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_TestingAdvance_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ConcurrentProgramming" || temas[j] == "ConcurrentProgramming" || temas[k] == "ConcurrentProgramming")
                        {
                            perfilPersonalizadoData.ME2_ConcurrentProgramming_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ConcurrentProgramming"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ConcurrentProgramming";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_ConcurrentProgramming_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_ConcurrentProgramming_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_ConcurrentProgramming_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "PlatformBestPractices" || temas[j] == "PlatformBestPractices" || temas[k] == "PlatformBestPractices")
                        {
                            perfilPersonalizadoData.ME2_PlatformBestPractices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["PlatformBestPractices"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "PlatformBestPractices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_PlatformBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_PlatformBestPractices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_PlatformBestPractices_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ConnectivityAndPushNotifications" || temas[j] == "ConnectivityAndPushNotifications" || temas[k] == "ConnectivityAndPushNotifications")
                        {
                            perfilPersonalizadoData.ME2_ConnectivityAndPushNotifications_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ConnectivityAndPushNotifications"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ConnectivityAndPushNotifications";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_ConnectivityAndPushNotifications_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_ConnectivityAndPushNotifications_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_ConnectivityAndPushNotifications_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SensorBasicsLocationAndMaps" || temas[j] == "SensorBasicsLocationAndMaps" || temas[k] == "SensorBasicsLocationAndMaps")
                        {
                            perfilPersonalizadoData.ME2_SensorBasicsLocationAndMaps_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SensorBasicsLocationAndMaps"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SensorBasicsLocationAndMaps";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_SensorBasicsLocationAndMaps_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_SensorBasicsLocationAndMaps_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_SensorBasicsLocationAndMaps_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "CloudMobileServices" || temas[j] == "CloudMobileServices" || temas[k] == "CloudMobileServices")
                        {
                            perfilPersonalizadoData.ME2_CloudMobileServices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["CloudMobileServices"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "CloudMobileServices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME2_CloudMobileServices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME2_CloudMobileServices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME2_CloudMobileServices_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "SecurityAdvanced" || temas[j] == "SecurityAdvanced" || temas[k] == "SecurityAdvanced")
                        {
                            perfilPersonalizadoData.ME3_SecurityAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SecurityAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_SecurityAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_SecurityAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_SecurityAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SensorsAdvanced" || temas[j] == "SensorsAdvanced" || temas[k] == "SensorsAdvanced")
                        {
                            perfilPersonalizadoData.ME3_SensorsAdvanced_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SensorsAdvanced"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SensorsAdvanced";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_SensorsAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_SensorsAdvanced_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_SensorsAdvanced_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "InAppPurchaseAndPayments" || temas[j] == "InAppPurchaseAndPayments" || temas[k] == "InAppPurchaseAndPayments")
                        {
                            perfilPersonalizadoData.ME3_InAppPurchaseAndPayments_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["InAppPurchaseAndPayments"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "InAppPurchaseAndPayments";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_InAppPurchaseAndPayments_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_InAppPurchaseAndPayments_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_InAppPurchaseAndPayments_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "Wearables" || temas[j] == "Wearables" || temas[k] == "Wearables")
                        {
                            perfilPersonalizadoData.ME3_Wearables_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["Wearables"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "Wearables";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_Wearables_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_Wearables_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_Wearables_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TechnologyAndPlatformSpecifics" || temas[j] == "TechnologyAndPlatformSpecifics" || temas[k] == "TechnologyAndPlatformSpecifics")
                        {
                            perfilPersonalizadoData.ME3_TechnologyAndPlatformSpecifics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TechnologyAndPlatformSpecifics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TechnologyAndPlatformSpecifics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_TechnologyAndPlatformSpecifics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_TechnologyAndPlatformSpecifics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_TechnologyAndPlatformSpecifics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "RequirementsEngineering" || temas[j] == "RequirementsEngineering" || temas[k] == "RequirementsEngineering")
                        {
                            perfilPersonalizadoData.ME3_RequirementsEngineering_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RequirementsEngineering"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "RequirementsEngineering";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_RequirementsEngineering_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_RequirementsEngineering_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_RequirementsEngineering_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "WebServicesAndMicroservices" || temas[j] == "WebServicesAndMicroservices" || temas[k] == "WebServicesAndMicroservices")
                        {
                            perfilPersonalizadoData.ME3_WebServicesAndMicroservices_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["WebServicesAndMicroservices"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "WebServicesAndMicroservices";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.ME3_WebServicesAndMicroservices_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.ME3_WebServicesAndMicroservices_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.ME3_WebServicesAndMicroservices_PCR = percetange; contarCampos++;*/
                        }
                        /*********************************************************/
                        /************************QA***************************/
                        /*********************************************************/
                        if (temas[i] == "QualityAssuranceConcepts" || temas[j] == "QualityAssuranceConcepts" || temas[k] == "QualityAssuranceConcepts")
                        {
                            perfilPersonalizadoData.QA0_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QualityAssuranceConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "QualityAssuranceConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_QualityAssuranceConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_QualityAssuranceConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestingTypes" || temas[j] == "TestingTypes" || temas[k] == "TestingTypes")
                        {
                            perfilPersonalizadoData.QA0_TestingTypes_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestingTypes"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestingTypes";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_TestingTypes_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_TestingTypes_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_TestingTypes_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AvanticaQualityAssuranceMethodology" || temas[j] == "AvanticaQualityAssuranceMethodology" || temas[k] == "AvanticaQualityAssuranceMethodology")
                        {
                            perfilPersonalizadoData.QA0_AvanticaQualityAssuranceMethodology_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AvanticaQualityAssuranceMethodology"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AvanticaQualityAssuranceMethodology";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_AvanticaQualityAssuranceMethodology_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_AvanticaQualityAssuranceMethodology_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_AvanticaQualityAssuranceMethodology_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestCasesDesignAndEstimationTechniques" || temas[j] == "TestCasesDesignAndEstimationTechniques" || temas[k] == "TestCasesDesignAndEstimationTechniques")
                        {
                            perfilPersonalizadoData.QA0_TestCasesDesignAndEstimationTechniques_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestCasesDesignAndEstimationTechniques"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestCasesDesignAndEstimationTechniques";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_TestCasesDesignAndEstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_TestCasesDesignAndEstimationTechniques_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_TestCasesDesignAndEstimationTechniques_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "BugManagement" || temas[j] == "BugManagement" || temas[k] == "BugManagement")
                        {
                            perfilPersonalizadoData.QA0_BugManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["BugManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "BugManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_BugManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_BugManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_BugManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "DevelopmentMethodologies" || temas[j] == "DevelopmentMethodologies" || temas[k] == "DevelopmentMethodologies")
                        {
                            perfilPersonalizadoData.QA0_DevelopmentMethodologies_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["DevelopmentMethodologies"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "DevelopmentMethodologies";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_DevelopmentMethodologies_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_DevelopmentMethodologies_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "QATools" || temas[j] == "QATools" || temas[k] == "QATools")
                        {
                            perfilPersonalizadoData.QA0_QATools_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QATools"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "QATools";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_QATools_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_QATools_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_QATools_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AvanticaTestingServicesWorkspace" || temas[j] == "AvanticaTestingServicesWorkspace" || temas[k] == "AvanticaTestingServicesWorkspace")
                        {
                            perfilPersonalizadoData.QA0_AvanticaTestingServicesWorkspace_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AvanticaTestingServicesWorkspace"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AvanticaTestingServicesWorkspace";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA0_AvanticaTestingServicesWorkspace_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA0_AvanticaTestingServicesWorkspace_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA0_AvanticaTestingServicesWorkspace_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "QualityAssuranceInSoftwareDevelopmentLifeCycle" || temas[j] == "QualityAssuranceInSoftwareDevelopmentLifeCycle" || temas[k] == "QualityAssuranceInSoftwareDevelopmentLifeCycle")
                        {
                            perfilPersonalizadoData.QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["QualityAssuranceInSoftwareDevelopmentLifeCycle"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "QualityAssuranceInSoftwareDevelopmentLifeCycle";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SQLForQualityAssurance" || temas[j] == "SQLForQualityAssurance" || temas[k] == "SQLForQualityAssurance")
                        {
                            perfilPersonalizadoData.QA1_SQLForQualityAssurance_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SQLForQualityAssurance"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SQLForQualityAssurance";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_SQLForQualityAssurance_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_SQLForQualityAssurance_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_SQLForQualityAssurance_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestCaseAutomationConcepts" || temas[j] == "TestCaseAutomationConcepts" || temas[k] == "TestCaseAutomationConcepts")
                        {
                            perfilPersonalizadoData.QA1_TestCaseAutomationConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestCaseAutomationConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestCaseAutomationConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_TestCaseAutomationConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_TestCaseAutomationConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_TestCaseAutomationConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestCasesAutomation" || temas[j] == "TestCasesAutomation" || temas[k] == "TestCasesAutomation")
                        {
                            perfilPersonalizadoData.QA1_TestCasesAutomation_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestCasesAutomation"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestCasesAutomation";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_TestCasesAutomation_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_TestCasesAutomation_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_TestCasesAutomation_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "MobileTesting" || temas[j] == "MobileTesting" || temas[k] == "MobileTesting")
                        {
                            perfilPersonalizadoData.QA1_MobileTesting_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["MobileTesting"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "MobileTesting";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_MobileTesting_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_MobileTesting_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_MobileTesting_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "PerformanceTesting" || temas[j] == "PerformanceTesting" || temas[k] == "PerformanceTesting")
                        {
                            perfilPersonalizadoData.QA1_PerformanceTesting_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["PerformanceTesting"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "PerformanceTesting";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_PerformanceTesting_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_PerformanceTesting_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_PerformanceTesting_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftwareEvaluationMetrics" || temas[j] == "SoftwareEvaluationMetrics" || temas[k] == "SoftwareEvaluationMetrics")
                        {
                            perfilPersonalizadoData.QA1_SoftwareEvaluationMetrics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftwareEvaluationMetrics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftwareEvaluationMetrics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA1_SoftwareEvaluationMetrics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA1_SoftwareEvaluationMetrics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA1_SoftwareEvaluationMetrics_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "TestCaseManagement" || temas[j] == "TestCaseManagement" || temas[k] == "TestCaseManagement")
                        {
                            perfilPersonalizadoData.QA2_TestCaseManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestCaseManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestCaseManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_TestCaseManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_TestCaseManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_TestCaseManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AdvancedBugManagement" || temas[j] == "AdvancedBugManagement" || temas[k] == "AdvancedBugManagement")
                        {
                            perfilPersonalizadoData.QA2_AdvancedBugManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedBugManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AdvancedBugManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedBugManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_AdvancedBugManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedBugManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "RequirementsManagement" || temas[j] == "RequirementsManagement" || temas[k] == "RequirementsManagement")
                        {
                            perfilPersonalizadoData.QA2_RequirementsManagement_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["RequirementsManagement"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "RequirementsManagement";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_RequirementsManagement_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_RequirementsManagement_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_RequirementsManagement_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "TestStrategyDesign" || temas[j] == "TestStrategyDesign" || temas[k] == "TestStrategyDesign")
                        {
                            perfilPersonalizadoData.QA2_TestStrategyDesign_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["TestStrategyDesign"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "TestStrategyDesign";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_TestStrategyDesign_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_TestStrategyDesign_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_TestStrategyDesign_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AdvancedPerformanceTesting" || temas[j] == "AdvancedPerformanceTesting" || temas[k] == "AdvancedPerformanceTesting")
                        {
                            perfilPersonalizadoData.QA2_AdvancedPerformanceTesting_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedPerformanceTesting"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AdvancedPerformanceTesting";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedPerformanceTesting_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_AdvancedPerformanceTesting_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedPerformanceTesting_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SecurityTestingConcepts" || temas[j] == "SecurityTestingConcepts" || temas[k] == "SecurityTestingConcepts")
                        {
                            perfilPersonalizadoData.QA2_SecurityTestingConcepts_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SecurityTestingConcepts"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SecurityTestingConcepts";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_SecurityTestingConcepts_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_SecurityTestingConcepts_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_SecurityTestingConcepts_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AdvancedSecurityTesting" || temas[j] == "AdvancedSecurityTesting" || temas[k] == "AdvancedSecurityTesting")
                        {
                            perfilPersonalizadoData.QA2_AdvancedSecurityTesting_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedSecurityTesting"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AdvancedSecurityTesting";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedSecurityTesting_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_AdvancedSecurityTesting_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_AdvancedSecurityTesting_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ProjectManagementInAvantica" || temas[j] == "ProjectManagementInAvantica" || temas[k] == "ProjectManagementInAvantica")
                        {
                            perfilPersonalizadoData.QA2_ProjectManagementInAvantica_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ProjectManagementInAvantica"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ProjectManagementInAvantica";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA2_ProjectManagementInAvantica_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA2_ProjectManagementInAvantica_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA2_ProjectManagementInAvantica_PCR = percetange; contarCampos++;*/
                        }

                        if (temas[i] == "ArchitectureForQA" || temas[j] == "ArchitectureForQA" || temas[k] == "ArchitectureForQA")
                        {
                            perfilPersonalizadoData.QA3_ArchitectureForQA_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ArchitectureForQA"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ArchitectureForQA";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_ArchitectureForQA_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_ArchitectureForQA_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_ArchitectureForQA_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "AdvancedSoftwareEvaluationMetrics" || temas[j] == "AdvancedSoftwareEvaluationMetrics" || temas[k] == "AdvancedSoftwareEvaluationMetrics")
                        {
                            perfilPersonalizadoData.QA3_AdvancedSoftwareEvaluationMetrics_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["AdvancedSoftwareEvaluationMetrics"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "AdvancedSoftwareEvaluationMetrics";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_AdvancedSoftwareEvaluationMetrics_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_AdvancedSoftwareEvaluationMetrics_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_AdvancedSoftwareEvaluationMetrics_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ProjectManagementI" || temas[j] == "ProjectManagementI" || temas[k] == "ProjectManagementI")
                        {
                            perfilPersonalizadoData.QA3_ProjectManagementI_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ProjectManagementI"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ProjectManagementI";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_ProjectManagementI_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_ProjectManagementI_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_ProjectManagementI_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "ProjectManagementII" || temas[j] == "ProjectManagementII" || temas[k] == "ProjectManagementII")
                        {
                            perfilPersonalizadoData.QA3_ProjectManagementII_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["ProjectManagementII"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "ProjectManagementII";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_ProjectManagementII_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_ProjectManagementII_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_ProjectManagementII_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftSkillsI" || temas[j] == "SoftSkillsI" || temas[k] == "SoftSkillsI")
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsI_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftSkillsI"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftSkillsI";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsI_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsI_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsI_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftSkillsII" || temas[j] == "SoftSkillsII" || temas[k] == "SoftSkillsII")
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsII_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftSkillsII"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftSkillsII";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsII_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsII_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsII_PCR = percetange; contarCampos++;*/
                        }
                        if (temas[i] == "SoftSkillsFromHHRR" || temas[j] == "SoftSkillsFromHHRR" || temas[k] == "SoftSkillsFromHHRR")
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsFromHHRR_RRC = (float)new Random().NextDouble();perfilPersonalizadoData.TemaMasSeleccionado = dictionaryTemas["SoftSkillsFromHHRR"];//perfilPersonalizadoData.TemaMasSeleccionado = temaId++;// "SoftSkillsFromHHRR";
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange < percentageLimitPCR) percetange = percentageFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsFromHHRR_PCR = percetange; contarCampos++;*/
                        }
                        else
                        {
                            perfilPersonalizadoData.QA3_SoftSkillsFromHHRR_RRC = (float)new Random().NextDouble() + 1.0f;
                            /*var percetange = (float)new Random().NextDouble()-;*/
                           /*if (percetange > percentageLimitPCR) percetange = percentageNoFavoritesPCR;
                            perfilPersonalizadoData.QA3_SoftSkillsFromHHRR_PCR = percetange; contarCampos++;*/
                        }

                        perfilPersonalizadoData.Label = $"{carrera}{nivel}-({temas[i]}-{temas[j]}-{ temas[k]})";
                        perfilPersonalizados.Add(perfilPersonalizadoData);
                    }
                }
            }
            return perfilPersonalizados;
        }

        private bool CreateFile(List<PerfilPersonalizadoData> perfilesPersonalizados)
        {
            string dataPath = "perfiles-personalizados.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Resources\", dataPath);

            List<string> lines = new List<string>();
            foreach (var x in perfilesPersonalizados)
            {
                lines.Add($"{x.LineaCarrera},{x.Nivel}," +
                   $"{x.BA1_BusinessAnalysisMethodology_RRC},{x.BA1_Requirements_RRC},{x.BA1_ElicitationAndColaboration_RRC},{x.BA1_RequirementsMatriz_RRC},{x.BA1_BasicUML_RRC},{x.BA1_AdvancedUML_RRC},{x.BA1_Agile_RRC}, {x.BA1_RequirementLifecycleManagement_RRC}, {x.BA1_ChangesRequest_RRC}," +
                   $"{x.BA2_Needs_RRC}, {x.BA2_PlanningAndSupervision_RRC},{x.BA2_AnalisysPlan_RRC},{x.BA2_StrategicAnalisys_RRC},{x.BA2_RiskAnalisys_RRC},{x.BA2_SolutionEvaluation_RRC}," +
                   $"{x.SE1_QualityAssuranceConcepts_RRC},{x.SE1_DevelopmentMethodologies_RRC},{x.SE1_SoftwareEngineeringBestPractices_RRC},{x.SE1_SoftwareDesignBasics_RRC},{x.SE1_DatabaseBasics_RRC},{x.SE1_WebDevelopmentBasics_RRC},{x.SE1_SecurityBasics_RRC},{x.SE1_UXBasics_RRC},{x.SE1_LanguageAndPlatformFundamentals_RRC}," +
                   $"{x.SE2_EstimationTechniques_RRC},{x.SE2_PlatformBestPractices_RRC},{x.SE2_AlgorithmsDesignAndAnalysis_RRC},{x.SE2_DesignPatterns_RRC},{x.SE2_DatabaseAdvanced_RRC},{x.SE2_WebDevelopmentAdvanced_RRC},{x.SE2_TestingAdvanced_RRC},{x.SE2_ConcurrentProgramming_RRC}," +
                   $"{x.SE3_RequirementsEngineering_RRC},{x.SE3_SecurityAdvanced_RRC},{x.SE3_DatabaseDesign_RRC},{x.SE3_TechnologyAndPlatformSpecifics_RRC},{x.SE3_WebServicesAndMicroservices_RRC},{x.SE3_ArtificialIntelligence_RRC},{x.SE3_CloudBasics_RRC}," +
                   $"{x.DEVOPS1_DevelopmentMethodologies_RRC},{x.DEVOPS1_QualityAssuranceConcepts_RRC},{x.DEVOPS1_SourceCodeManagement_RRC},{x.DEVOPS1_ScriptingForProcessAutomation_RRC},{x.DEVOPS1_DevOpsGeneralConcepts_RRC},{x.DEVOPS1_ContinuousIntegration_RRC},{x.DEVOPS1_TestAutomation_RRC},{x.DEVOPS1_DeliveryPipelines_RRC},{x.DEVOPS1_DatabaseBasics_RRC},{x.DEVOPS1_AgileAndDevOps_RRC}," +
                   $"{x.DEVOPS2_AppContainerization_RRC},{x.DEVOPS2_ConfigurationManagement_RRC},{x.DEVOPS2_ContinuousDeliveryAndDeployment_RRC},{x.DEVOPS2_SystemAdministration_RRC},{x.DEVOPS2_EstimationTechniques_RRC},{x.DEVOPS2_ChatOps_RRC},{x.DEVOPS2_SecurityBasics_RRC},{x.DEVOPS2_PerformanceBasics_RRC},{x.DEVOPS2_CloudComputingBasics_RRC}," +
                   $"{x.DEVOPS3_AdvancedCloudComputing_RRC},{x.DEVOPS3_InfrastructureAsCode_RRC},{x.DEVOPS3_Monitoring_RRC},{x.DEVOPS3_ProjectManagementInAvantica_RRC},{x.DEVOPS3_Metrics_RRC},{x.DEVOPS3_MicroservicesArchitecture_RRC},{x.DEVOPS3_ServerlessConcepts_RRC},{x.DEVOPS3_DevOpsCulture_RRC},{x.DEVOPS3_ContinuousDeliveryStrategies_RRC}," +
                   $"{x.ME1_QualityAssuranceConcepts_RRC},{x.ME1_DevelopmentMethodologies_RRC},{x.ME1_SoftwareDesignBasics_RRC},{x.ME1_DatabaseBasics_RRC},{x.ME1_UXBasics_RRC},{x.ME1_SoftwareEngineeringBestPractices_RRC},{x.ME1_WebServices_RRC},{x.ME1_SecurityBasics_RRC},{x.ME1_LanguagesAndPlatformsFundamentals_RRC}," +
                   $"{x.ME2_AlgorithmDesignAndAnalysis_RRC},{x.ME2_UserInfoAndAppPublishing_RRC},{x.ME2_EstimationTechniques_RRC},{x.ME2_DesignPatterns_RRC},{x.ME2_TestingAdvance_RRC},{x.ME2_ConcurrentProgramming_RRC},{x.ME2_PlatformBestPractices_RRC},{x.ME2_ConnectivityAndPushNotifications_RRC},{x.ME2_SensorBasicsLocationAndMaps_RRC},{x.ME2_CloudMobileServices_RRC}," +
                   $"{x.ME3_SecurityAdvanced_RRC},{x.ME3_SensorsAdvanced_RRC},{x.ME3_InAppPurchaseAndPayments_RRC},{x.ME3_Wearables_RRC},{x.ME3_TechnologyAndPlatformSpecifics_RRC},{x.ME3_RequirementsEngineering_RRC},{x.ME3_WebServicesAndMicroservices_RRC}," +
                   $"{x.QA0_QualityAssuranceConcepts_RRC},{x.QA0_TestingTypes_RRC},{x.QA0_AvanticaQualityAssuranceMethodology_RRC},{x.QA0_TestCasesDesignAndEstimationTechniques_RRC},{x.QA0_BugManagement_RRC},{x.QA0_DevelopmentMethodologies_RRC},{x.QA0_QATools_RRC},{x.QA0_AvanticaTestingServicesWorkspace_RRC}," +
                   $"{x.QA1_QualityAssuranceInSoftwareDevelopmentLifeCycle_RRC},{x.QA1_SQLForQualityAssurance_RRC},{x.QA1_TestCaseAutomationConcepts_RRC},{x.QA1_TestCasesAutomation_RRC},{x.QA1_MobileTesting_RRC},{x.QA1_PerformanceTesting_RRC},{x.QA1_SoftwareEvaluationMetrics_RRC}," +
                   $"{x.QA2_TestCaseManagement_RRC},{x.QA2_AdvancedBugManagement_RRC},{x.QA2_RequirementsManagement_RRC},{x.QA2_TestStrategyDesign_RRC},{x.QA2_AdvancedPerformanceTesting_RRC},{x.QA2_SecurityTestingConcepts_RRC},{x.QA2_AdvancedSecurityTesting_RRC},{x.QA2_ProjectManagementInAvantica_RRC}," +
                   $"{x.QA3_ArchitectureForQA_RRC},{x.QA3_AdvancedSoftwareEvaluationMetrics_RRC},{x.QA3_ProjectManagementI_RRC},{x.QA3_ProjectManagementII_RRC},{x.QA3_SoftSkillsI_RRC},{x.QA3_SoftSkillsII_RRC},{x.QA3_SoftSkillsFromHHRR_RRC}," +
                   $"{x.TemaMasSeleccionado},{x.Label}");
            }
            System.IO.File.WriteAllLines(path, lines);
            return true;
        }
    }
}
