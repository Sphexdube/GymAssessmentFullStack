using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebGYM.Interface;

namespace WebGYM
{
    public class Role : IRole
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public Role(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool CheckRoleExits(string roleName)
        {
            var result = (from role in _context.Role
                          where role.RoleName == roleName
                          select role).Count();

            return result > 0 ? true : false;
        }

        public bool DeleteRole(int roleId)
        {
            var roledata = (from role in _context.Role
                            where role.RoleId == roleId
                            select role).FirstOrDefault();

            if (roledata != null)
            {
                _context.Role.Remove(roledata);
                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Models.Role GetRolebyId(int roleId)
        {
            var result = (from role in _context.Role
                          where role.RoleId == roleId
                          select role).FirstOrDefault();

            return result;
        }

        public List<Models.Role> GetAllRole()
        {
            var result = (from role in _context.Role
                select role).ToList();

            return result;
        }

        public void InsertRole(Models.Role role)
        {
            _context.Role.Add(role);
            _context.SaveChanges();
        }

        public bool UpdateRole(Models.Role role)
        {
            _context.Entry(role).Property(x => x.Status).IsModified = true;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
