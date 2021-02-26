using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFUygulama.Data.DTO;

namespace WCFUygulama.Presentation.Services
{
    public class ProjectService : IProjectService
    {
        DataAccess.UnitOfWork.UnitOfWork unitOfWork = new DataAccess.UnitOfWork.UnitOfWork(new Data.Database.tablolarEntities());

        WebOperationContext ctx = WebOperationContext.Current;
        public void AddProject(ProjectDto projectDto)
        {   


                try
                {

                    if (projectDto.projectName==null)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    }
                    else
                    {
                        Data.Database.project project1 = new Data.Database.project
                        {
                            id = projectDto.id,
                            name = projectDto.projectName
                        };

                        unitOfWork.GetRepository<Data.Database.project>().Add(project1);
                        unitOfWork.Complete();
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                    

                }
                catch (Exception)
                {

                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    throw;
                }

        }


        public void AddProjectRole(ProjectRoleDto projectRoleDto)
        {
            
                try
                {
                    if (projectRoleDto.projectId == 0 || projectRoleDto.userId == 0 || projectRoleDto.projectName == null || projectRoleDto.userName == null)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        Data.Database.projectroles projectroles = new Data.Database.projectroles
                        {
                            id = projectRoleDto.id,
                            projectid = projectRoleDto.projectId,
                            userid = projectRoleDto.userId
                        };
                        unitOfWork.GetRepository<Data.Database.projectroles>().Add(projectroles);
                        unitOfWork.Complete();
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;


                    }
                }
                catch (Exception)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    throw;
                

            }
        
    }

    public void DelProject(ProjectDto projectDto)
    {
            try
            {
                if (projectDto.id == 0)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
                var result = unitOfWork.GetRepository<Data.Database.project>().Get(projectDto.id);

                if (result == null)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
                else
                {
                    unitOfWork.GetRepository<Data.Database.project>().Del(result);
                    unitOfWork.Complete();
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                throw;
            }
        
    }

    public void DelProjectRole(ProjectRoleDto projectRoleDto)
    {
            
                try
                {
                    if (projectRoleDto.id == 0)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    var result = unitOfWork.GetRepository<Data.Database.projectroles>().Get(projectRoleDto.id);
                    if (result == null)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                    else
                    {

                        unitOfWork.GetRepository<Data.Database.projectroles>().Del(result);
                        unitOfWork.Complete();
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                catch (Exception)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    throw;
                }

            
    }

    public ProjectDto GetProject(int id)
    {
           
                
                try
                {
                    
                    if (id == 0)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return new ProjectDto();
                    }
                    var result = unitOfWork.GetRepository<Data.Database.project>().Get(id);
                    if (result == null)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                        return new ProjectDto();
                    }
                    else
                    {
                        Data.DTO.ProjectDto projectDto = new ProjectDto
                        {
                            id = result.id,
                            projectName = result.name

                        };
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                        return projectDto;
                    }
                }
                catch (Exception)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    throw;
                }
    }

    public List<ProjectRoleDto> GetProjectRoles(int id)
    {
        try
        {
            if (id == 0)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return new List<ProjectRoleDto>();
            }
            var result = unitOfWork.GetRepository<Data.Database.projectroles>().GetProjectRoles(id);
            if (result == null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return new List<ProjectRoleDto>();
            }

            else
            {
                List<ProjectRoleDto> projectRoleDtos = new List<ProjectRoleDto>();
                foreach (var item in result)
                {
                    var project = unitOfWork.GetRepository<Data.Database.project>().Get((int)item.projectid);
                    var user = unitOfWork.GetRepository<Data.Database.user>().Get((int)item.userid);
                    Data.DTO.ProjectRoleDto projectRoleDto = new ProjectRoleDto
                    {
                        id = item.id,
                        projectId = (int)item.projectid,
                        userId = (int)item.userid,
                        projectName = project.name,
                        userName = user.username
                    };

                    projectRoleDtos.Add(projectRoleDto);

                }
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return projectRoleDtos;
            }

        }
        catch (Exception)
        {
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            throw;
        }


    }

    public void SetProject(ProjectDto projectDto)
    {
        try
        {
            if (projectDto.id == 0 || projectDto.projectName == null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            var result = unitOfWork.GetRepository<Data.Database.project>().Get(projectDto.id);
            if (result == null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            else
            {
                result.name = projectDto.projectName;
                unitOfWork.GetRepository<Data.Database.project>().Set(result);
                unitOfWork.Complete();
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
        }
        catch (Exception)
        {
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            throw;
        }


    }

    public void SetProjectRole(ProjectRoleDto projectRoleDto)
    {
        try
        {
            if (projectRoleDto.id == 0 || projectRoleDto.projectId == 0 ||
                projectRoleDto.projectName == null || projectRoleDto.userId == 0 || projectRoleDto.userName == null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            var result = unitOfWork.GetRepository<Data.Database.projectroles>().Get(projectRoleDto.id);
            if (result == null)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            else
            {
                result.projectid = projectRoleDto.projectId;
                result.userid = projectRoleDto.userId;
                unitOfWork.GetRepository<Data.Database.projectroles>().Set(result);
                unitOfWork.Complete();
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
        }
        catch (Exception)
        {
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            throw;
        }


    }
}
}