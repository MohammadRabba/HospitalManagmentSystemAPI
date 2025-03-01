using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EntityDTO;
using WebApplication1.EntityManager;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/auth/[action]")]

    public class AccountController:ControllerBase
    {
        public AccountManager accountManager ;
        public AccountController(AccountManager account)
        {
            accountManager = account;
        }


        
        [HttpPost]
        public IActionResult Register([FromBody]UserDTO newuser)
        {
            accountManager.Register(newuser);
            return Created();
        }

       
        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            var token = accountManager.Authenticate(login);
            if (token == null)
                Unauthorized();

            return Ok(token);
        }
       
        [Authorize(Roles = "admin")]

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO newuser)
        {
            accountManager.UpdateUser(id, newuser);
            return Ok();
        }
    }
}
