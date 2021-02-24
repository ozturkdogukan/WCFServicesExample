using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.Data.DTO
{
    [DataContract]
    public class ProjectDto
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]

        public string projectName { get; set; }


    }
}
