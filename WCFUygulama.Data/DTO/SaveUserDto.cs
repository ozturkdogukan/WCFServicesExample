using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFUygulama.Data.DTO
{
    [DataContract]
    public class SaveUserDto
    {
        
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
