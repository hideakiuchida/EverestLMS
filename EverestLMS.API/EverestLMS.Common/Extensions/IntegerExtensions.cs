using EverestLMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Common.Extensions
{
    public static class IntegerExtensions
    {
        public static string ConvertGenderToString(this int input)
        {
            switch (input)
            {
                case (int)GeneroEnum.Masculino: return GeneroEnum.Masculino.ToString();
                case (int)GeneroEnum.Femenino: return GeneroEnum.Femenino.ToString();
                default: return GeneroEnum.Masculino.ToString();
            }
        }

        public static string ConvertSedeToString(this int input)
        {
            switch (input)
            {
                case (int)SedeEnum.Cochabamba: return SedeEnum.Cochabamba.ToString();
                case (int)SedeEnum.Liberia: return SedeEnum.Liberia.ToString();
                case (int)SedeEnum.Lima: return SedeEnum.Lima.ToString();
                case (int)SedeEnum.SanCarlos: return SedeEnum.SanCarlos.ToString();
                case (int)SedeEnum.SanJose: return SedeEnum.SanJose.ToString();
                default: return SedeEnum.SanJose.ToString();
            }
        }

        public static string ConvertLineaCarreraToString(this int input)
        {
            switch (input)
            {
                case (int)LineaCarreraEnum.BusinessAnalyst: return LineaCarreraEnum.BusinessAnalyst.ToString();
                case (int)LineaCarreraEnum.DevOpsEngineer: return LineaCarreraEnum.DevOpsEngineer.ToString();
                case (int)LineaCarreraEnum.MobileEngineer: return LineaCarreraEnum.MobileEngineer.ToString();
                case (int)LineaCarreraEnum.QualityAssurance: return LineaCarreraEnum.QualityAssurance.ToString();
                case (int)LineaCarreraEnum.SoftwareEngineer: return LineaCarreraEnum.SoftwareEngineer.ToString();
                default: return LineaCarreraEnum.SoftwareEngineer.ToString();
            }          
        }

        public static string ConvertNivelToString(this int input)
        {
            switch (input)
            {
                case (int)NivelEnum.Junior: return NivelEnum.Junior.ToString();
                case (int)NivelEnum.NivelUno: return NivelEnum.NivelUno.ToString();
                case (int)NivelEnum.NivelDos: return NivelEnum.NivelDos.ToString();
                case (int)NivelEnum.NivelTres: return NivelEnum.NivelTres.ToString();
                case (int)NivelEnum.Senior: return NivelEnum.Senior.ToString();
                default: return NivelEnum.Junior.ToString();
            }
        }

        public static int ValidateLineaCarrera(this int input)
        {
            switch (input)
            {
                case (int)LineaCarreraEnum.BusinessAnalyst:
                case (int)LineaCarreraEnum.DevOpsEngineer:
                case (int)LineaCarreraEnum.QualityAssurance:
                case (int)LineaCarreraEnum.MobileEngineer:
                case (int)LineaCarreraEnum.SoftwareEngineer:
                    return input;
                default: return (int)LineaCarreraEnum.SoftwareEngineer;
            }
        }

        public static int ValidateNivel(this int input)
        {
            switch (input)
            {
                case (int)NivelEnum.Junior:
                case (int)NivelEnum.NivelUno:
                case (int)NivelEnum.NivelDos:
                case (int)NivelEnum.NivelTres:
                case (int)NivelEnum.Senior:
                    return input;
                default: return (int)NivelEnum.Junior;
            }
        }
    }
}
