using System;
using System.Collections.Generic;
using UsersAndRewards.Common.Models;
using WorkWithASP.Models;


namespace WorkWithASP
{
    public static class Converter
    {
		public static UsersViewModel ConvertUserToViewModel(this UsersModel domainUserModel)
		{
			return new UsersViewModel()
			{
				Id = domainUserModel.Id,
				Name = domainUserModel.Name,
				Birthdate = domainUserModel.Birthdate.ToString("D"),
				RewardsIsCheck = domainUserModel.RewardsIsCheck,
                Rewards = domainUserModel.Rewards.ConvertListDomainToView()
            };
		}

		public static UsersModel ConvertUserToDomainModel(this UsersViewModel viewUserModel)
		{
			return new UsersModel()
			{
				Id = viewUserModel.Id,
				Name = viewUserModel.Name,
				Birthdate = Convert.ToDateTime(viewUserModel.Birthdate),
				RewardsIsCheck = viewUserModel.RewardsIsCheck,
				Rewards = viewUserModel.Rewards.ConvertListViewToDomain()
			};
		}


		public static RewardsViewModel ConvertRewardToViewModel(this RewardsModel domainRewardModel)
		{
			return new RewardsViewModel()
			{
				Id = domainRewardModel.Id,
				Title = domainRewardModel.Title,
				Description = domainRewardModel.Description,
			};
		}

		public static RewardsModel ConvertRewardToDomainModel(this RewardsViewModel viewRewardModel)
		{
			return new RewardsModel()
			{
				Id = viewRewardModel.Id,
				Title = viewRewardModel.Title,
				Description = viewRewardModel.Description,
			};
		}

		public static List<RewardsViewModel> ConvertListDomainToView(this List<RewardsModel> domainRewards)
        {
			List<RewardsViewModel> viewRewards = new List<RewardsViewModel>();
			foreach (var reward in domainRewards)
            {
				viewRewards.Add(reward.ConvertRewardToViewModel());
            }
			return viewRewards;
		}

		public static List<RewardsModel> ConvertListViewToDomain(this List<RewardsViewModel> viewRewards)
		{
			List<RewardsModel> domainRewards = new List<RewardsModel>();
			foreach (var reward in viewRewards)
			{
				domainRewards.Add(reward.ConvertRewardToDomainModel());
			}
			return domainRewards;
		}
	}
}
