using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndRewards.Common;
using UsersAndRewards.Common.Models;
using WorkWithASP.Models;

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
			return View(usersAndRewardsStorage.GetUsersList().Select(user => user.ConvertUserToViewModel()));
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(UsersViewModel user)
		{
			UsersModel newDomaiUser = user.ConvertUserToDomainModel();
			newDomaiUser.Id = usersAndRewardsStorage.AddUser(newDomaiUser);
			usersAndRewardsStorage.RewardUser(newDomaiUser);
			return RedirectToAction(nameof(Index));
        }


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			UsersViewModel userEdit = usersAndRewardsStorage.GetUsersList().FirstOrDefault(td => td.Id == id.Value).ConvertUserToViewModel();
			userEdit = usersAndRewardsStorage.ExpandUserRewardsList(userEdit.ConvertUserToDomainModel()).ConvertUserToViewModel();
			userEdit.DateTimeBirthdate = Convert.ToDateTime(userEdit.Birthdate);
			return View("AddOrEdit",userEdit);
		}

		[HttpPost]
		public IActionResult Edit(UsersViewModel user)
		{
			user.Birthdate = user.DateTimeBirthdate.ToString("D");
			usersAndRewardsStorage.UpdateUser(user.ConvertUserToDomainModel());
			usersAndRewardsStorage.RewardUser(user.ConvertUserToDomainModel());
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			UsersViewModel userRemove = usersAndRewardsStorage.GetUsersList().FirstOrDefault(td => td.Id == id.Value).ConvertUserToViewModel();
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
