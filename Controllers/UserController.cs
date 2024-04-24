using Microsoft.AspNetCore.Mvc;
using DataLayer.Models.Domain;
using DataLayer.Models.Repository;

namespace Learnsite.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
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
