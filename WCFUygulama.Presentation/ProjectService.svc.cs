using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFUygulama.Data.DTO;

namespace WCFUygulama.Presentation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProjectService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProjectService.svc or ProjectService.svc.cs at the Solution Explorer and start debugging.
    public class ProjectService : IProjectService
    {
        DataAccess.UnitOfWork.UnitOfWork unitOfWork = new DataAccess.UnitOfWork.UnitOfWork(new Data.Database.tablolarEntities());
        public void AddProject(ProjectDto projectDto)
        {
            Data.Database.project project1 = new Data.Database.project {
                id= projectDto.id,
                name = projectDto.projectName
            };

            unitOfWork.ProjectRepository.Add(project1);
            unitOfWork.Complete();
            
        }

        public void AddProjectRole(ProjectRoleDto projectRoleDto)
        {
            Data.Database.projectroles projectroles = new Data.Database.projectroles { 
                id = projectRoleDto.id,
                projectid = projectRoleDto.projectId,
                userid = projectRoleDto.userId
            };
            unitOfWork.ProjectRoleRepository.Add(projectroles);
            unitOfWork.Complete();
        }

        public void DelProject(ProjectDto projectDto)
        {
           var result = unitOfWork.ProjectRepository.Get(projectDto.id);
            unitOfWork.ProjectRepository.Del(result);
            unitOfWork.Complete();
        }

        public void DelProjectRole(ProjectRoleDto projectRoleDto)
        {
           var result = unitOfWork.ProjectRoleRepository.Get(projectRoleDto.id);
            unitOfWork.ProjectRoleRepository.Del(result);
            unitOfWork.Complete();
        }

        public ProjectDto GetProject(int id)
        {
            var result = unitOfWork.ProjectRepository.Get(id);
            Data.DTO.ProjectDto projectDto = new ProjectDto { 
                id = result.id,
                projectName = result.name
            
            };
            return projectDto;
        }

        public List<ProjectRoleDto> GetProjectRoles(int id)
        {
            var result = unitOfWork.ProjectRoleRepository.GetProjectRoles(id);
            List<ProjectRoleDto> projectRoleDtos = new List<ProjectRoleDto>();
            foreach (var item in result)
            {
                var project = unitOfWork.ProjectRepository.Get((int)item.projectid);
                var user = unitOfWork.UserRepository.Get((int)item.userid);
                Data.DTO.ProjectRoleDto projectRoleDto = new ProjectRoleDto { 
                    id = item.id,
                    projectId = (int)item.projectid,
                    userId = (int)item.userid,
                    projectName = project.name,
                    userName = user.username
                };

                projectRoleDtos.Add(projectRoleDto);

            }
            return projectRoleDtos;
        }

        public void SetProject(ProjectDto projectDto)
        {
            var result = unitOfWork.ProjectRepository.Get(projectDto.id);
            result.name = projectDto.projectName;
            unitOfWork.ProjectRepository.Set(result);
            unitOfWork.Complete();
            
        }

        public void SetProjectRole(ProjectRoleDto projectRoleDto)
        {
            var result = unitOfWork.ProjectRoleRepository.Get(projectRoleDto.id);
            result.projectid = projectRoleDto.projectId;
            result.userid = projectRoleDto.userId;
            unitOfWork.ProjectRoleRepository.Set(result);
            unitOfWork.Complete();
        }
    }
}
