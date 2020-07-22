using System.Collections.Generic;
using UsersAndRewards.Common.Models;

namespace UsersAndRewards.Common
{
    public interface IStorage
    {
        IEnumerable<RewardsModel> GetRewardsList();
        IEnumerable<UsersModel> GetUsersList();
        int AddReward(RewardsModel reward);
        int AddUser(UsersModel user);
        bool RemoveRewardById(int id);
        bool RemoveUserById(int id);
        bool UpdateUser(UsersModel user);
        bool UpdateReward(RewardsModel reward);
        IEnumerable<RewardsModel> GetRewardsByUserId(int id);
        bool RewardUser(UsersModel user);
        bool RemoveReward(int userId, int rewardId);
        UsersModel ExpandUserRewardsList(UsersModel user);
    }
}
