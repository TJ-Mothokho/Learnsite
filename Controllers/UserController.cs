using Microsoft.AspNetCore.Mvc;
using DataLayer.Models.Domain;
using DataLayer.Models.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Learnsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<User> userList = await _user.GetAllUsersAsync();
            return View(userList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                user.Status = "Active";

                //if (!ModelState.IsValid)
                //    return View(user);

                bool addUser = await _user.InsertUserAsync(user);

                if(addUser)
                {
                    TempData["msg"] = "Added Sucessfully!";
                }
                else
                {
                    TempData["msg"] = "Failed!";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = $"{ex.Message} \n Something is wrong. Contact Administrator.";
            }
            return RedirectToAction("Index");
        }

       public IActionResult Edit()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id, User user)
        {
            try
            {
                bool addUser = await _user.UpdateUserAsync(user);

                if (addUser)
                {
                    TempData["msg"] = "Updated Sucessfully!";
                }
                else
                {
                    TempData["msg"] = "Failed!";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = $"{ex.Message} \n Something is wrong. Contact Administrator.";
            }
            return RedirectToAction("Index");

        }
    }
}
