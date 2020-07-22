using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkWithASP.Models;
using UsersAndRewards.Common;
using System.Collections.Generic;

namespace WorkWithASP.Controllers
{
    public class RewardsController : Controller
    {
		private IStorage usersAndRewardsStorage;

		public RewardsController(IStorage storage)
		{
			usersAndRewardsStorage = storage;
		}

		public IActionResult Index()
        {
			return View(usersAndRewardsStorage.GetRewardsList().Select(reward => reward.ConvertRewardToViewModel()));
        }

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(RewardsViewModel reward)
		{
			usersAndRewardsStorage.AddReward(reward.ConvertRewardToDomainModel());
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			RewardsViewModel rewardEdit = usersAndRewardsStorage.GetRewardsList().FirstOrDefault(td => td.Id == id.Value).ConvertRewardToViewModel();
			return View("AddOrEdit", rewardEdit);
		}

		[HttpPost]
		public IActionResult Edit(RewardsViewModel reward)
		{
			usersAndRewardsStorage.UpdateReward(reward.ConvertRewardToDomainModel());
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			RewardsViewModel rewardRemove = usersAndRewardsStorage.GetRewardsList().FirstOrDefault(td => td.Id == id.Value).ConvertRewardToViewModel();

			if (rewardRemove == null)
				return NotFound();

			return View(rewardRemove);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			if (!usersAndRewardsStorage.RemoveRewardById(id))
			{
				return NotFound();
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
