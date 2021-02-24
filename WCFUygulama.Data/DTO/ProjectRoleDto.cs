using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.Data.DTO
{
    [DataContract]
    public class ProjectRoleDto
    {
        [DataMember]

        public int id { get; set; }
        [DataMember]

        public int projectId { get; set; }
        [DataMember]

        public int userId { get; set; }
        [DataMember]

        public string projectName { get; set; }
        [DataMember]

        public string userName { get; set; }

    }
}
