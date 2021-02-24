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
        public void AddUser(SaveUserDto saveUserDto)
        {
            Data.Database.user user = new Data.Database.user
            {
                id = 0,
                name = saveUserDto.name,
                password = saveUserDto.password,
                username = saveUserDto.userName
            };

            unitOfWork.UserRepository.Add(user);
            unitOfWork.Complete();
        }

        public void DelUser(UserDto userDto)
        {
            var result = unitOfWork.UserRepository.Get(userDto.id);
            unitOfWork.UserRepository.Del(result);
        }


        public UserDto GetUser(int id)
        {
            var result = unitOfWork.UserRepository.Get(id);
            Data.DTO.UserDto userDto = new UserDto
            {
                id = result.id,
                name = result.name,
                userName = result.username
            };

            return userDto;
        }

        public void SetUser(int id ,SaveUserDto saveUserDto)
        {
           var result =  unitOfWork.UserRepository.Get(id);
            result.name = saveUserDto.name;
            result.password = saveUserDto.password;
            result.username = saveUserDto.userName;
            unitOfWork.UserRepository.Set(result);
            unitOfWork.Complete();
          
        }
    }
}
