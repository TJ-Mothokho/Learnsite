using Microsoft.AspNetCore.Mvc;
using DataLayer.Models.Domain;
using DataLayer.Models.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Learnsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<User> userList = await _userRepository.GetAllUsersAsync();
            return View(userList);
        }
    }
}
