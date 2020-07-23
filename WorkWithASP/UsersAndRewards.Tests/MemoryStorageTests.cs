using System;
using Xunit;
using UsersAndRewards.Common.Models;
using System.Collections.Generic;
using System.Linq;
using Storage = UsersAndRewards.MemoryStorage.MemoryStorage;

namespace UsersAndRewards.Tests
{
    public class MemoryStorageTests
    {
        public Storage storage = new Storage();


        [Fact]
        public void ShouldBeAbleReturnNotNullUsersCollection()
        {
            // Arrange

            // Act
            var usersList = storage.GetUsersList().ToList();

            // Assert
            Assert.NotNull(usersList);
        }


        [Fact]
        public void ShouldBeAbleReturnNotNullRewardsCollection()
        {
            // Arrange

            // Act
            var rewardsList = storage.GetRewardsList().ToList();

            // Assert
            Assert.NotNull(rewardsList);
        }


        #region Tests for AddUser
        [Fact]
        public void VerifiesThatTheAddedUserHasValidId()
        {
            // Arrange
            int expectedId = 3;
            UsersModel user = new UsersModel();

            // Act
            int actualId = storage.AddUser(user);

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void ShouldBeAbleToAddUser()
        {
            // Arrange
            UsersModel user = new UsersModel();

            // Act
            int userId = storage.AddUser(user);
            UsersModel userReturned = storage.ReturnUserById(userId);

            // Assert
            Assert.NotNull(userReturned);
        }
        #endregion


        #region Tests for AddReward
        [Fact]
        public void VerifiesThatTheAddedRewardHasValidId()
        {
            // Arrange
            int expectedId = 6;
            RewardsModel reward = new RewardsModel();

            // Act
            int actualId = storage.AddReward(reward);

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void ShouldBeAbleToAddReward()
        {
            // Arrange
            RewardsModel reward = new RewardsModel();

            // Act
            int rewardId = storage.AddReward(reward);
            RewardsModel rewardReturned = storage.ReturnRewardById(rewardId);

            // Assert
            Assert.NotNull(rewardReturned);
        }
        #endregion


        #region Tests for RemoveReward
        [Fact]
        public void VerifiesDeleteRewardReturnFalse()
        {
            // Arrange
            int invalidId = 60;

            // Act
            bool removalResult = storage.RemoveRewardById(invalidId);

            // Assert
            Assert.False(removalResult);
        }


        [Fact]
        public void VerifiesDeleteRewardReturnTrue()
        {
            // Arrange
            int realId = 2;

            // Act
            bool removalResult = storage.RemoveRewardById(realId);

            // Assert
            Assert.True(removalResult);
        }


        [Fact]
        public void VerifiesRemoteRewardDoesNotExist()
        {
            // Arrange
            int realId = 1;

            // Act
            bool removalResult = storage.RemoveRewardById(realId);

            // Assert
            Assert.Null(storage.ReturnRewardById(realId));
        }
        #endregion


        #region Tests for RemoveUser
        [Fact]
        public void VerifiesDeleteUserReturnFalse()
        {
            // Arrange
            int invalidId = 60;

            // Act
            bool removalResult = storage.RemoveUserById(invalidId);

            // Assert
            Assert.False(removalResult);
        }


        [Fact]
        public void VerifiesDeleteUserReturnTrue()
        {
            // Arrange
            int realId = 1;

            // Act
            bool removalResult = storage.RemoveUserById(realId);

            // Assert
            Assert.True(removalResult);
        }


        [Fact]
        public void VerifiesRemoteUserDoesNotExist()
        {
            // Arrange
            int realId = 1;

            // Act
            bool removalResult = storage.RemoveUserById(realId);

            // Assert
            Assert.Null(storage.ReturnRewardById(realId));
        }
        #endregion


        #region Tests for GetRewardsByUserId
        [Fact]
        public void VerifiesThrowExceptionIfViewRewardsNullUser()
        {
            // Arrange
            int invalidId = 60;

            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => storage.GetRewardsByUserId(invalidId));
        }
        #endregion


        #region Tests for Update User and Update Reward
        [Fact]
        public void VerifiesUpdateUser()
        {
            // Arrange
            UsersModel oldUser = storage.ReturnUserById(0);
            UsersModel newUser = new UsersModel { Id = 0, Name = "Новый пользователь", Rewards = new List<RewardsModel>(), Birthdate = new DateTime(1962, 3, 1) };

            // Act
            storage.UpdateUser(newUser);

            // Assert
            Assert.NotEqual(oldUser.Name, newUser.Name);
        }

        [Fact]
        public void VerifiesUpdateReward()
        {
            // Arrange
            RewardsModel oldReward = storage.ReturnRewardById(0);
            RewardsModel newReward = new RewardsModel { Id = 0, Title = "Новое название", Description = "Получен в Туссенте" };

            // Act
            storage.UpdateReward(newReward);

            // Assert
            Assert.NotEqual(oldReward.Title, newReward.Title);
        }
        #endregion


        #region Tests for RemoveReward
        [Fact]
        public void VerifiesThrowExceptionIfNullUser()
        {
            // Arrange
            int invalidUserId = 60;
            int realRewardId = 0;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => storage.RemoveReward(invalidUserId, realRewardId));
        }


        [Fact]
        public void VerifiesThrowExceptionIfNullReward()
        {
            // Arrange
            int invalidRewardId = 60;
            int realUserId = 0;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => storage.RemoveReward(realUserId, invalidRewardId));
        }


        [Fact]
        public void VerifiesRemoteRewardUserDoesNotExist()
        {
            // Arrange
            int realRewardId = 0;
            int realUserId = 0;

            // Act
            storage.RemoveReward(realUserId, realRewardId);
            var rewardsUserList = storage.GetRewardsByUserId(realUserId);

            // Assert
            Assert.Null(rewardsUserList.FirstOrDefault(reward => reward.Id == realRewardId));
        }
        #endregion


        #region Tests for RewardUser
        [Fact]
        public void VerifiesThrowExceptionIfNullUserForReward()
        {
            // Arrange
            UsersModel user = new UsersModel { Id = 100 };

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => storage.RewardUser(user));
        }
        #endregion

    }
}
