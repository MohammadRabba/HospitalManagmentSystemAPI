using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DBaccess;
using WebApplication1.EntityDTO;

namespace WebApplication1.EntityManager
{
    public class AccountManager
    {


        private readonly MyDBContext dbcontext ;

        public  AccountManager(MyDBContext context)
        {
            dbcontext=context;
        }

        public void Register(UserDTO user)
        {
            var newUser = new User { password = user.password, userName = user.userName };
            newUser.userRoles = user.RollsIds.Select(x => new UserRoles() { rollID = x, user = newUser }).ToList();
            dbcontext.Users.Add(newUser);
            dbcontext.SaveChanges();
        }

        public string? Authenticate(LoginDTO login)
        {
            var user = dbcontext.Users
     .Include(x => x.userRoles) 
     .ThenInclude(x => x.Roll)  
     .Where(x => x.userName == login.userName && x.password == login.password).FirstOrDefault();
            if (user == null) return null;
            
            
            
            if (user.userRoles.Any(x => x.rollID == 3))
            {
                List<Claim> myClaimed = user.userRoles.Select(x => new Claim(ClaimTypes.Role, x.Roll.name)).ToList();

                myClaimed.Add(new Claim("PatientId", user.Id.ToString()));
                var mySkey = "sdfsdfkasdfajsfkLsdfsdfkasdfajsfkL";
                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySkey));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken mytoken = new JwtSecurityToken(

                    expires: DateTime.Now.AddHours(1), claims: myClaimed, signingCredentials: signingCredentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(mytoken);
            }
            else {
                List<Claim> myClaimed = user.userRoles.Select(x => new Claim(ClaimTypes.Role, x.Roll.name)).ToList();
                var mySkey = "sdfsdfkasdfajsfkLsdfsdfkasdfajsfkL";
                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySkey));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken mytoken = new JwtSecurityToken(

                    expires: DateTime.Now.AddHours(1), claims: myClaimed, signingCredentials: signingCredentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(mytoken);
            }
          
            
        }

        public void UpdateUser(int id, UserDTO newuser)
        {
            var user = dbcontext.Users.FirstOrDefault(x => x.Id == id);
            user.userName = newuser.userName;
            user.password = newuser.password;
            var oldRoles = dbcontext.UserRoles.Where(x => x.userId == id).ToList();
            foreach(var roll in oldRoles)
            {
                dbcontext.UserRoles.Remove(roll);

            }

            foreach (var roleId in newuser.RollsIds)
            {
                var role = dbcontext.Rolls.FirstOrDefault(r => r.Id == roleId);
                if (role != null)
                {


                    user.userRoles.Add(new UserRoles { userId = user.Id, rollID = roleId });
                }
            }
            dbcontext.SaveChanges();
        }
    }
}
