using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.MLModelGenerator.Models
{
    public class ContentType
    {
        List<string> contentTypes;
        public ContentType()
        {
            AddContentTypes();
        }
        public List<string> GetContentTypes()
        {
            return contentTypes;
        }
        private void AddContentTypes()
        {
            contentTypes = new List<string>();
            contentTypes.Add("Text");
            contentTypes.Add("Presentation");
            contentTypes.Add("Multimedia");
        }
    }
}
