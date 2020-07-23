using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndRewards.Common;
using UsersAndRewards.Common.Models;
using WorkWithASP.Controllers;
using WorkWithASP.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UsersAndRewards.Tests
{
    public class UserControllerTests
    {
		[Fact]
		public void ShouldBeAbleToReturnIndexViewWithUsersCollection()
		{
			// Arrange
			var mockedStorage = new Mock<IStorage>();
			var usersList = new List<UsersModel>
			{
				new UsersModel {Id = 1, Name = "Лето из Гулеты", Rewards = new List<RewardsModel>(), Birthdate = new DateTime(1953, 8, 4)},
				new UsersModel {Id = 2, Name = "Андрей из Гулеты", Rewards = new List<RewardsModel>(), Birthdate = new DateTime(1954, 8, 4)},
				new UsersModel {Id = 3, Name = "Владислав из Гулеты", Rewards = new List<RewardsModel>(), Birthdate = new DateTime(1955, 8, 4)},
			};

			mockedStorage.Setup(x => x.GetUsersList()).Returns(usersList);
			var controller = new UserController(mockedStorage.Object);

			// Act
			ViewResult result = (ViewResult)controller.Index();
			IEnumerable<UsersViewModel> model = (IEnumerable<UsersViewModel>)result.Model;

			// Assert
			Assert.NotNull(result);
			Assert.NotNull(model);
			Assert.Equal(model.Count(), usersList.Count);
		}

		[Fact]
		public void ShouldBeAbleToAddUserFromViewModel()
		{
			// Arrange
			var mockedStorage = new Mock<IStorage>();
			var user = new UsersViewModel { Id = 5, Name = "Трисс из Марибора", Rewards = new List<RewardsViewModel>(), DateTimeBirthdate = new DateTime(1953, 8, 4) };

			mockedStorage.Setup(x => x.AddUser(It.IsAny<UsersModel>())).Returns(user.Id);
			var controller = new UserController(mockedStorage.Object);

			// Act
			var result = controller.Add(user);
			mockedStorage.Verify(x => x.AddUser(It.IsAny<UsersModel>()), Times.Once());
		}


		[Fact]
		public void ShouldBeAbleToEditUserFromViewModel()
		{
			// Arrange
			var mockedStorage = new Mock<IStorage>();
			var user = new UsersViewModel { Id = 1, Name = "Трисс из Марибора", Rewards = new List<RewardsViewModel>(), DateTimeBirthdate = new DateTime(1953, 8, 4) };

			mockedStorage.Setup(x => x.UpdateUser(It.IsAny<UsersModel>())).Returns(false);
			var controller = new UserController(mockedStorage.Object);

			// Act
			var result = controller.Edit(user);
			mockedStorage.Verify(x => x.UpdateUser(It.IsAny<UsersModel>()), Times.Once());
		}


		[Fact]
		public void ShouldBeAbleToDeleteUserFromViewModel()
		{
			// Arrange
			var mockedStorage = new Mock<IStorage>();
			var user = new UsersViewModel { Id = 1, Name = "Лето из Гулеты", Rewards = new List<RewardsViewModel>(), DateTimeBirthdate = new DateTime(1953, 8, 4) };

			mockedStorage.Setup(x => x.RemoveUserById(It.IsAny<int>())).Returns(false);
			var controller = new UserController(mockedStorage.Object);

			// Act
			var result = controller.Delete(user.Id);
			mockedStorage.Verify(x => x.RemoveUserById(It.IsAny<int>()), Times.Once());
		}
	}
}
