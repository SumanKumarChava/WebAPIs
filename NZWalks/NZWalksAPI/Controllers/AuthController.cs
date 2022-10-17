using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories.Interfaces;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly iTokenHandler _tokenHandler;
        public AuthController(IUserRepository userRepository, iTokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            // validate the incoming request
            if(loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                ModelState.AddModelError("Invalid Request object", "Please verify if the username and password provided are not empty");
                return BadRequest(ModelState);
            }

            // Check if user is authenticated
            var user = await _userRepository.AuthenticateUser(loginRequest.UserName, loginRequest.Password);
            if(user == null)
            {
                return BadRequest("Username or Password is incorrect");
            }


            // Generate JWT token and send it to client if it is a valid user
            var token = await _tokenHandler.GetTokenAsync(user);
            return Ok(token);

        }
    }
}
