﻿using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace EverestLMS.ViewModels.CloudinaryFile
{
    public class CloudinaryFileToUpdateVM : CloudinaryFileToCreateVM
    {
        public int Id { get; set; }
    }
}
