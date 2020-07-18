using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWithASP.Models;

namespace WorkWithASP.Controllers
{
    public class RewardsController : Controller
    {
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
            return View(rewardsList);
        }

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(RewardsModel reward)
		{
			reward.Id = rewardsList.Max(m => m.Id) + 1;
			rewardsList.Add(reward);
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			RewardsModel rewardEdit = rewardsList.FirstOrDefault(td => td.Id == id.Value);
			return View("AddOrEdit", rewardEdit);
		}

		[HttpPost]
		public IActionResult Edit(RewardsModel reward)
		{
			rewardsList[reward.Id - 1] = reward;
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			RewardsModel rewardRemove = rewardsList.FirstOrDefault(td => td.Id == id.Value);

			if (rewardRemove == null)
				return NotFound();

			return View(rewardRemove);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			RewardsModel rewardRemove = rewardsList.FirstOrDefault(td => td.Id == id);

			if (rewardRemove == null)
				return NotFound();

			rewardsList.Remove(rewardRemove);

			return RedirectToAction(nameof(Index));
		}
	}
}
