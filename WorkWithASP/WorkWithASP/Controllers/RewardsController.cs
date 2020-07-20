using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkWithASP.Models;
using WorkWithASP.Services;

namespace WorkWithASP.Controllers
{
    public class RewardsController : Controller
    {
		private 
			IStorage usersAndRewardsStorage;
		public RewardsController(IStorage storage)
		{
			usersAndRewardsStorage = storage;
		}

		public IActionResult Index()
        {
            return View(usersAndRewardsStorage.GetRewardsList());
        }

		[HttpGet]
		public IActionResult Add()
		{
			return View("AddOrEdit");
		}

		[HttpPost]
		public IActionResult Add(RewardsModel reward)
		{
			usersAndRewardsStorage.AddReward(reward);
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Edit(int? id)
		{
			RewardsModel rewardEdit = usersAndRewardsStorage.GetRewardsList().FirstOrDefault(td => td.Id == id.Value);
			return View("AddOrEdit", rewardEdit);
		}

		[HttpPost]
		public IActionResult Edit(RewardsModel reward)
		{
			usersAndRewardsStorage.UpdateReward(reward);
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return RedirectToAction(nameof(Index));

			RewardsModel rewardRemove = usersAndRewardsStorage.GetRewardsList().FirstOrDefault(td => td.Id == id.Value);

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
