using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndRewards.Common;
using UsersAndRewards.Common.Models;

namespace UsersAndRewards.MemoryStorage
{
	public class MemoryStorage : IStorage
	{
		private static List<RewardsModel> storageRewards = new List<RewardsModel>
		{
			new RewardsModel{Id=0,Title="Кубок Туссента",Description="Получен в Туссенте"},
			new RewardsModel{Id=1,Title="Орден из Боклера",Description="Вы убили бестию. Но какой ценой?.."},
			new RewardsModel{Id=2,Title="Кубок по гвинту",Description="Достойная награда!"},
			new RewardsModel{Id=3,Title="Корона Фольтеста",Description="Надеюсь, вы рады этой награде"},
			new RewardsModel{Id=4,Title="Орден школы Змеи",Description="Вы единственный, кто получил эту награду"},
			new RewardsModel{Id=5,Title="Медаль за отвагу",Description="Поздравляем!"},
		};

		private static List<UsersModel> storageUsers = new List<UsersModel>
		{
			new UsersModel{Id = 0, Name = "Геральт из Ривии", Rewards = new List<RewardsModel>(){ storageRewards[0], storageRewards[1], storageRewards[2]}, Birthdate = new DateTime(1962, 3, 1)},
			new UsersModel{Id = 1, Name = "Лето из Гулеты", Rewards = new List<RewardsModel>(){ storageRewards[3], storageRewards[4]}, Birthdate = new DateTime(1953, 8, 4)},
			new UsersModel{Id = 2, Name = "Вильгефорц из Роггевеена", Rewards = new List<RewardsModel>(){ storageRewards[5]}, Birthdate = new DateTime(1978, 12, 11)},
		};

		public MemoryStorage()
		{
			foreach (UsersModel user in storageUsers)
			{
				for (int i = 0; i < storageRewards.Count; i++)
				{
					user.RewardsIsCheck.Add(false);
				}

				foreach (RewardsModel reward in user.Rewards)
				{
					user.RewardsIsCheck[reward.Id] = true;
				}
			}
		}



		public IEnumerable<RewardsModel> GetRewardsList()
		{
			return storageRewards;
		}


		public IEnumerable<UsersModel> GetUsersList()
		{
			return storageUsers;
		}


		public int AddReward(RewardsModel reward)
		{
			reward.Id = storageRewards.Max(task => task.Id) + 1;
			storageRewards.Add(reward);
			return reward.Id;
		}


		public int AddUser(UsersModel user)
		{
			user.Id = storageUsers.Max(task => task.Id) + 1;
			storageUsers.Add(user);
			return user.Id;
		}


		public bool RemoveRewardById(int id)
		{
			RewardsModel removedReward = ReturnRewardById(id);

			foreach (UsersModel user in storageUsers)
			{
				RemoveReward(user.Id, id);
				user.RewardsIsCheck.Remove(user.RewardsIsCheck[storageRewards.IndexOf(removedReward)-1]);
			}
			return storageRewards.Remove(removedReward);
		}


		public bool RemoveUserById(int id)
		{
			return storageUsers.Remove(ReturnUserById(id));
		}



		public bool UpdateUser(UsersModel user)
		{
			UsersModel userUpdated = ReturnUserById(user.Id);
			if (storageUsers[storageUsers.IndexOf(userUpdated)] is null)
			{
				return false;
			}
			storageUsers[storageUsers.IndexOf(userUpdated)] = user;
			return true;
		}


		public bool UpdateReward(RewardsModel reward)
		{
			RewardsModel rewardUpdated = ReturnRewardById(reward.Id);
			if (storageRewards[storageRewards.IndexOf(rewardUpdated)] is null)
			{
				return false;
			}
			storageRewards[storageRewards.IndexOf(rewardUpdated)] = reward;
			return true;
		}


		public IEnumerable<RewardsModel> GetRewardsByUserId(int id)
		{
			UsersModel user = ReturnUserById(id);
			if (user is null)
			{
				return new List<RewardsModel>();
			}
			return user.Rewards;
		}

		public bool RewardUser(UsersModel user)
		{
			UsersModel userInStorage = ReturnUserById(user.Id);
			if (userInStorage is null)
			{
				return false;
			}

			userInStorage.Rewards.Clear();
			for (int i = 0; i < userInStorage.RewardsIsCheck.Count; i++)
			{
				if (userInStorage.RewardsIsCheck[i]) userInStorage.Rewards.Add(storageRewards[i]);
			}
			return true;
		}


		public bool RemoveReward(int userId, int rewardId)
		{
			RewardsModel rewardRemoved = ReturnRewardById(rewardId);
			UsersModel userRemoved = ReturnUserById(userId);
			return userRemoved.Rewards.Remove(rewardRemoved);
		}


		public UsersModel ExpandUserRewardsList(UsersModel user)
		{
			for (int i = user.RewardsIsCheck.Count; i < storageRewards.Count; i++)
			{
				user.RewardsIsCheck.Add(false);
			}
			return user;
		}

		public UsersModel ReturnUserById(int id)
		{
			return storageUsers.FirstOrDefault(user => user.Id == id);
		}
		public RewardsModel ReturnRewardById(int id)
		{
			return storageRewards.FirstOrDefault(reward => reward.Id == id);
		}

	}
}
