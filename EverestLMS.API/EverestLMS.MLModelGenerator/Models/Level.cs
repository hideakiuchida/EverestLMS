using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.MLModelGenerator.Models
{
    public class Level
    {
        List<string> levels;
        public Level()
        {
            AddLevels();
        }

        public List<string> GetLevels()
        {
            return levels;
        }

        private void AddLevels()
        {
            levels = new List<string>();
            levels.Add("0");
            levels.Add("1");
            levels.Add("2");
            levels.Add("3");
        }
    }
}
