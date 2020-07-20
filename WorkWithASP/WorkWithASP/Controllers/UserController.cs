using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkWithASP.Models;
using WorkWithASP.Services;

namespace WorkWithASP.Controllers
{
    public class UserController : Controller
    {
		private IStorage usersAndRewardsStorage;

		public UserController(IStorage storage)
		{
			usersAndRewardsStorage = storage;
		}

		public IActionResult Index()
		{
			return View(usersAndRewardsStorage.GetUsersList());
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(UsersModel user)
		{
			usersAndRewardsStorage.AddUser(user);
			usersAndRewardsStorage.RewardUser(user.Id);
			return RedirectToAction(nameof(Index));
        }


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			UsersModel userEdit = usersAndRewardsStorage.GetUsersList().FirstOrDefault(td => td.Id == id.Value);
			userEdit = usersAndRewardsStorage.ExpandUserRewardsList(userEdit);
			return View("AddOrEdit",userEdit);
		}

		[HttpPost]
		public IActionResult Edit(UsersModel user)
		{
			usersAndRewardsStorage.UpdateUser(user);
			usersAndRewardsStorage.RewardUser(user.Id);
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			UsersModel userRemove = usersAndRewardsStorage.GetUsersList().FirstOrDefault(td => td.Id == id.Value);
			if (userRemove is null)
            {
				return NotFound();
			}
			return View(userRemove);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			if (!usersAndRewardsStorage.RemoveUserById(id))
			{
				return NotFound();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
