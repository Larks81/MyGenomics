using AutoMapper;
using MyGenomics.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenomics.Services
{
    public class UserService
    {
        public DomainModel.User CheckLogin(string userName, string password, int? userType = null)
        {
            var userLogged = new DomainModel.User();
            using (var context = new MyGenomicsContext())
            {
                var user = context.Users
                    .FirstOrDefault(p =>
                        p.UserName.ToUpper() == userName.ToUpper() &&
                        p.Password == password);

                if (user != null)
                {
                    return Mapper.Map<DataModel.User, DomainModel.User>(user);
                }
                else
                {
                    return null;
                }
            }            
        }
    }
}
