﻿using AutoMapper;
using BusinessLogic.DTOs.User;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class UserRepository
    {
        private readonly Agencia_8Context _context;
        private readonly IMapper _mapper;

        public UserRepository(Agencia_8Context context)
        {
            this._context = context;
            this._mapper = new Mapper(new MapperConfiguration(x => x.CreateMap<User, UserDTO>()));
        }

        public bool ValidateCredentials(UserCredentials credentials)
        {
            return _context.Users.Any(x => x.UserName == credentials.User && x.Password == credentials.Password);
        }

        public UserDTO GetUserByUserName(string userName)
        {
            return _mapper.Map<UserDTO>(_context.Users.FirstOrDefault(x => x.UserName == userName));
        }

        public UserDTO GetUserWhitResourcesByUserName(string userName)
        {
            UserDTO user = _mapper.Map<UserDTO>(_context.Users.FirstOrDefault(x => x.UserName == userName));

            if (user != null && user.IdRole != null)
            {
                user.RoleName = _context.Role.FirstOrDefault(x => x.Id == user.IdRole)?.Name;
                user.Resources = GetResourcesByRole(user.IdRole ?? -1);
            }

            return user;
        }

        public List<string> GetResourcesByRole(decimal roleId)
        {
            List<string> resources = new List<string>();

            resources = (from role in _context.Role
                         where role.Id == roleId
                         join rolePerm in _context.PermissionRole on role.Id equals rolePerm.IdRole
                         join perm in _context.Permission on rolePerm.IdPermission equals perm.Id
                         select new { resource = perm.Feature })
                         .Select(s => s.resource).ToList();

            return resources;
        }
    }
}
