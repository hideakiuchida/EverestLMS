using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EverestLMS.Common.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string SeparateTextByUpperCase(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return ReturnTextByUpperCase(Regex.Split(input, @"(?<!^)(?=[A-Z])")); 
            }
        }

        private static string ReturnTextByUpperCase(string[] split)
        {
            string cadena = String.Empty;
            for (int i = 0; i < split.Length; i++)
            {
                if ((split.Length - i) > 1)
                    cadena += split[i] + " ";
                else
                    cadena += split[i];
            }
            return cadena;
        }
    }
}
