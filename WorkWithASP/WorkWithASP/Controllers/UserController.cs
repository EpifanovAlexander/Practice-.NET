using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkWithASP.Models;

namespace WorkWithASP.Controllers
{
    public class UserController : Controller
    {
		private static List<RewardsModel> geraltRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=1,Title="Кубок Туссента",Description="Получен в Туссенте"},
			new RewardsModel{Id=2,Title="Орден из Боклера",Description="Вы убили бестию. Но какой ценой?.."},
			new RewardsModel{Id=3,Title="Кубок по гвинту",Description="Достойная награда!"},
		};

		private static List<RewardsModel> letoRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=4,Title="Корона Фольтеста",Description="Надеюсь, вы рады этой награде"},
			new RewardsModel{Id=5,Title="Орден школы Змеи",Description="Вы единственный, кто получил эту награду"},
		};

		private static List<RewardsModel> vilgefortzRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=6,Title="Медаль за отвагу",Description="Поздравляем!"},
		};

		private static List<UsersModel> usersList = new List<UsersModel>
		{
			new UsersModel{Id = 1, Name = "Геральт из Ривии", Rewards = geraltRewards, Birthdate = new DateTime(1962, 3, 1, 7, 15, 44)},
			new UsersModel{Id = 2, Name = "Лето из Гулеты", Rewards = letoRewards, Birthdate = new DateTime(1953, 8, 4, 12, 11, 03)},
			new UsersModel{Id = 3, Name = "Вильгефорц из Роггевеена", Rewards = vilgefortzRewards, Birthdate = new DateTime(1978, 12, 11, 16, 17, 54)},
		};

		public IActionResult Index()
		{
			return View(usersList);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(UsersModel user)
		{
			user.Id = usersList.Max(m => m.Id) + 1;
			usersList.Add(user);
			return RedirectToAction(nameof(Index));
        }


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			UsersModel userEdit = usersList.FirstOrDefault(td => td.Id == id.Value);
			return View("AddOrEdit",userEdit);
		}

		[HttpPost]
		public IActionResult Edit(UsersModel user)
		{
			usersList[user.Id - 1] = user;
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			UsersModel userRemove = usersList.FirstOrDefault(td => td.Id == id.Value);

			if (userRemove == null)
				return NotFound();

			return View(userRemove);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			UsersModel userRemove = usersList.FirstOrDefault(td => td.Id == id);

			if (userRemove == null)
				return NotFound();

			usersList.Remove(userRemove);

			return RedirectToAction(nameof(Index));
		}
	}
}
