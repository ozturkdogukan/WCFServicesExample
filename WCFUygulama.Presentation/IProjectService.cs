using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFUygulama.Presentation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProjectService" in both code and config file together.
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddProject", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddProject(Data.DTO.ProjectDto projectDto);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddProjectRole", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddProjectRole(Data.DTO.ProjectRoleDto projectRoleDto);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetProject?id={id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Data.DTO.ProjectDto GetProject(int id);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetProjectRoles?id={id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Data.DTO.ProjectRoleDto> GetProjectRoles(int id);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "SetProject", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SetProject(Data.DTO.ProjectDto projectDto);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "SetProjectRole", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SetProjectRole(Data.DTO.ProjectRoleDto projectRoleDto);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DelProject", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DelProject(Data.DTO.ProjectDto projectDto);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DelProjectRole", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DelProjectRole(Data.DTO.ProjectRoleDto projectRoleDto);
    }
}
