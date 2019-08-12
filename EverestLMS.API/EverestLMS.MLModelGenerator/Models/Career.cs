using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.MLModelGenerator.Models
{
    public class Career
    {
        List<string> careers;
        public Career()
        {
            AddCareers();
        }
        public List<string> GetCareers()
        {
            return careers;
        }
        private void AddCareers()
        {
            careers = new List<string>();
            careers.Add("BA");
            careers.Add("SE");
            careers.Add("QA");
            careers.Add("DEVOPS");
            careers.Add("ME");
        }
    }
}
