using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFUygulama.Presentation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddUser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddUser(Data.DTO.SaveUserDto saveUserDto);
        [OperationContract]

        
        [WebInvoke(Method = "GET", UriTemplate = "GetUser?id={id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Data.DTO.UserDto GetUser(int id);
        [OperationContract]

        [WebInvoke(Method = "PUT", UriTemplate = "SetUser?id={id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SetUser(int id,Data.DTO.SaveUserDto saveUserDto);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DelUser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        void DelUser(Data.DTO.UserDto userDto);


    }
}
