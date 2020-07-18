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
			new RewardsModel{Id=0,Title="Кубок Туссента",Description="Получен в Туссенте"},
			new RewardsModel{Id=1,Title="Орден из Боклера",Description="Вы убили бестию. Но какой ценой?.."},
			new RewardsModel{Id=2,Title="Кубок по гвинту",Description="Достойная награда!"},
		};

		private static List<RewardsModel> letoRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=3,Title="Корона Фольтеста",Description="Надеюсь, вы рады этой награде"},
			new RewardsModel{Id=4,Title="Орден школы Змеи",Description="Вы единственный, кто получил эту награду"},
		};

		private static List<RewardsModel> vilgefortzRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=5,Title="Медаль за отвагу",Description="Поздравляем!"},
		};

		private static List<UsersModel> usersList = new List<UsersModel>
		{
			new UsersModel{Id = 0, Name = "Геральт из Ривии", Rewards = geraltRewards, Birthdate = new DateTime(1962, 3, 1)},
			new UsersModel{Id = 1, Name = "Лето из Гулеты", Rewards = letoRewards, Birthdate = new DateTime(1953, 8, 4)},
			new UsersModel{Id = 2, Name = "Вильгефорц из Роггевеена", Rewards = vilgefortzRewards, Birthdate = new DateTime(1978, 12, 11)},
		};

		private static List<RewardsModel> rewardsList = new List<RewardsModel>
		{
			new RewardsModel{Id=0,Title="Кубок Туссента",Description="Получен в Туссенте"},
			new RewardsModel{Id=1,Title="Орден из Боклера",Description="Вы убили бестию. Но какой ценой?.."},
			new RewardsModel{Id=2,Title="Кубок по гвинту",Description="Достойная награда!"},
			new RewardsModel{Id=3,Title="Корона Фольтеста",Description="Надеюсь, вы рады этой награде"},
			new RewardsModel{Id=4,Title="Орден школы Змеи",Description="Вы единственный, кто получил эту награду"},
			new RewardsModel{Id=5,Title="Медаль за отвагу",Description="Поздравляем!"},
		};

		public IActionResult Index()
		{
			foreach (UsersModel user in usersList)
			{
				user.StringBirthdate = user.Birthdate.ToString("d");
			}
			return View(usersList);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(UsersModel user, int[] addedRewards)
		{
			user.Id = usersList.Max(m => m.Id) + 1;
			usersList.Add(PresentRewards(user, addedRewards));
			return RedirectToAction(nameof(Index));
        }


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			UsersModel userEdit = usersList.FirstOrDefault(td => td.Id == id.Value);
			return View("AddOrEdit",userEdit);
		}

		[HttpPost]
		public IActionResult Edit(UsersModel user, int[] editedRewards)
		{
			usersList[user.Id] = PresentRewards(user, editedRewards);
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

		public UsersModel PresentRewards (UsersModel user, int[] indexesRewards)
        {
			user.Rewards = new List<RewardsModel>();
			foreach (int index in indexesRewards)
            {
				user.Rewards.Add(rewardsList[index]);
            }
			return user;
        }
	}
}
