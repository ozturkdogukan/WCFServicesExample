using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFUygulama.Data.DTO;

namespace WCFUygulama.Presentation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        DataAccess.UnitOfWork.UnitOfWork unitOfWork = new DataAccess.UnitOfWork.UnitOfWork(new Data.Database.tablolarEntities());
        WebOperationContext ctx = WebOperationContext.Current;
        public void AddUser(SaveUserDto saveUserDto)
        {
            
            
                Data.Database.user user = new Data.Database.user
                {
                    id = 0,
                    name = saveUserDto.name,
                    password = saveUserDto.password,
                    username = saveUserDto.userName
                };

            try
            {
                if (!(user.name==null||user.password==null||user.username==null))
                {
                    unitOfWork.UserRepository.Add(user);
                    unitOfWork.Complete();
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;

                }
                else
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
              
            }
            catch (Exception)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
               
            }
            

           
        }

        public void DelUser(UserDto userDto)
        {
            try
            {
                if (!(userDto.id==null||userDto.id==0))
                {
                    
                    if ((unitOfWork.UserRepository.Get(userDto.id)== null))
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Gone;
                    }
                    else
                    {
                        unitOfWork.UserRepository.Del(unitOfWork.UserRepository.Get(userDto.id));
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                     
                    
                }
                else
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
                
            }
            catch (Exception)
            {

                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            

        }


        public UserDto GetUser(int id)
        {
            try
            {
                if (id==0||id==null)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return new UserDto();
                }
                var result = unitOfWork.UserRepository.Get(id);
                if (result==null)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Gone;
                    return new UserDto();
                }
                Data.DTO.UserDto userDto = new UserDto
                {
                    id = result.id,
                    name = result.name,
                    userName = result.username
                };

                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                
                return userDto;

            }
            catch (Exception)
            {
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                throw;
            }
            
        }

        public void SetUser(int id ,SaveUserDto saveUserDto)
        {
            try
            {
                if (id == 0 || id == null || saveUserDto.name == null || saveUserDto.password == null || saveUserDto.userName == null)
                {
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
                else
                {

                    var result = unitOfWork.UserRepository.Get(id);
                    if (result == null)
                    {
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Gone;
                    }
                    else
                    {
                        result.name = saveUserDto.name;
                        result.password = saveUserDto.password;
                        result.username = saveUserDto.userName;
                        unitOfWork.UserRepository.Set(result);
                        unitOfWork.Complete();
                        ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    }
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
