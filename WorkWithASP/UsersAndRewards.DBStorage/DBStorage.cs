using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UsersAndRewards.Common;
using UsersAndRewards.Common.Models;

namespace UsersAndRewards.DBStorage
{
    public class DBStorage : IStorage
	{
		private string _connectionString;
		public DBStorage(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IEnumerable<RewardsModel> GetRewardsList()
		{
			List<RewardsModel> rewardsList = new List<RewardsModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT * FROM Rewards";

					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							RewardsModel reward = new RewardsModel()
							{
								Id = reader.GetInt32(0),
								Title = reader.GetString(1),
								Description = reader.GetString(2)
							};

							rewardsList.Add(reward);
						}
					}
				}
			}
			return rewardsList;
		}


		public IEnumerable<UsersModel> GetUsersList()
		{
			List<UsersModel> usersList = new List<UsersModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SELECT * FROM Users";

					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							UsersModel user = new UsersModel()
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								Birthdate = reader.GetDateTime(2)
							};

							user.Rewards = (List<RewardsModel>)GetRewardsByUserId(user.Id);

							for (int i = 0; i < GetRewardsList().LongCount(); i++)
							{
								user.RewardsIsCheck.Add(false);
							}

							foreach (RewardsModel reward in user.Rewards)
							{
								user.RewardsIsCheck[user.Rewards.IndexOf(reward)] = true;
							}

							usersList.Add(user);
						}
					}
				}
			}
			return usersList;
		}


		public IEnumerable<RewardsModel> GetRewardsByUserId(int id)
        {
			List<RewardsModel> rewardsList = new List<RewardsModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter userId = new SqlParameter();
					userId.ParameterName = "userId";
					userId.Value = id;
					command.Parameters.Add(userId);

					command.CommandText = "SELECT Id,Title,Description FROM Rewards JOIN RewardsUser on Rewards.Id=RewardsUser.RewardId" +
										  " WHERE UserId=@userId";

					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							RewardsModel reward = new RewardsModel()
							{
								Id = reader.GetInt32(0),
								Title = reader.GetString(1),
								Description = reader.GetString(2)
							};

							rewardsList.Add(reward);
						}
					}
				}
			}
			return rewardsList;
		}



		public int AddReward(RewardsModel reward)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter titleParameter = new SqlParameter();
					titleParameter.ParameterName = "Title";
					titleParameter.Value = reward.Title;
					command.Parameters.Add(titleParameter);

					SqlParameter descriptionParameter = new SqlParameter();
					descriptionParameter.ParameterName = "Description";
					descriptionParameter.Value = reward.Description;
					command.Parameters.Add(descriptionParameter);

					command.CommandText = "INSERT INTO Rewards (Title, Description) output INSERTED.Id VALUES (@Title, @Description)";

					try
					{
						connection.Open();
						return (int)command.ExecuteScalar();
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return -1;
		}

		public int AddUser(UsersModel user)
		{
			int result=-1;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter nameParameter = new SqlParameter();
					nameParameter.ParameterName = "Name";
					nameParameter.Value = user.Name;
					command.Parameters.Add(nameParameter);

					SqlParameter birthdateParameter = new SqlParameter();
					birthdateParameter.ParameterName = "Birthdate";
					birthdateParameter.Value = user.Birthdate;
					command.Parameters.Add(birthdateParameter);

					command.CommandText = "INSERT INTO Users (Name, Birthdate) output INSERTED.Id VALUES (@Name, @Birthdate)";

					try
					{
						connection.Open();
						result=(int)command.ExecuteScalar();
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return result;
		}


		public bool RemoveRewardById(int id)
        {
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter rewardId = new SqlParameter();
					rewardId.ParameterName = "rewardId";
					rewardId.Value = id;
					command.Parameters.Add(rewardId);

					command.CommandText = "DELETE RewardsUser WHERE RewardId=@rewardId" +
										  " DELETE Rewards WHERE Id=@rewardId";

					try
					{
						connection.Open();
						if (command.ExecuteNonQuery() != 0)
							return true;
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return false;
		}


		public bool RemoveUserById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter userId = new SqlParameter();
					userId.ParameterName = "userId";
					userId.Value = id;
					command.Parameters.Add(userId);

					command.CommandText = "DELETE RewardsUser WHERE UserId=@userId" +
						                  " DELETE Users WHERE Id=@userId";

					try
					{
						connection.Open();
						if (command.ExecuteNonQuery() != 0)
							return true;
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return false;
		}


		public bool RemoveReward(int userId, int rewardId)
        {
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter idUser = new SqlParameter();
					idUser.ParameterName = "idUser";
					idUser.Value = userId;
					command.Parameters.Add(idUser);

					SqlParameter idReward = new SqlParameter();
					idReward.ParameterName = "idReward";
					idReward.Value = rewardId;
					command.Parameters.Add(idReward);

					command.CommandText = "DELETE RewardsUser WHERE UserId=@idUser AND RewardId=@idReward";

					try
					{
						connection.Open();
						if (command.ExecuteNonQuery() != 0)
							return true;
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return false;
		}

		public UsersModel ExpandUserRewardsList(UsersModel user)
        {
			for (int i = user.RewardsIsCheck.Count; i < GetRewardsList().LongCount(); i++)
			{
				user.RewardsIsCheck.Add(false);
			}
			return user;
		}



		public bool RewardUser(UsersModel user)
		{
			if (user is null)
			{
				return false;
			}

			List<RewardsModel> rewardsList = (List<RewardsModel>)GetRewardsList();
			user.Rewards.Clear();
			for (int i = 0; i < user.RewardsIsCheck.Count; i++)
			{
				if (user.RewardsIsCheck[i])
				{
					user.Rewards.Add(rewardsList[i]);
				}
                else
                {
					RemoveReward(user.Id, rewardsList[i].Id);
				}
			}


			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				foreach (var reward in user.Rewards)
				{
					connection.Open();
					SqlCommand commandForStorProc = new SqlCommand("FillRewardUpdatedUser", connection);
					commandForStorProc.CommandType = System.Data.CommandType.StoredProcedure;

					SqlParameter idUser = new SqlParameter
					{
						ParameterName = "@idUser",
						Value = user.Id
					};
					commandForStorProc.Parameters.Add(idUser);

					SqlParameter idReward = new SqlParameter
					{
						ParameterName = "@idReward",
						Value = reward.Id
					};
					commandForStorProc.Parameters.Add(idReward);
					commandForStorProc.ExecuteNonQuery();
					connection.Close();
				}
			}
			return true;
		}


		public bool UpdateUser(UsersModel user)
        {
			bool result = false;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter idParameter = new SqlParameter();
					idParameter.ParameterName = "Id";
					idParameter.Value = user.Id;
					command.Parameters.Add(idParameter);

					SqlParameter nameParameter = new SqlParameter();
					nameParameter.ParameterName = "Name";
					nameParameter.Value = user.Name;
					command.Parameters.Add(nameParameter);

					SqlParameter birthdateParameter = new SqlParameter();
					birthdateParameter.ParameterName = "Birthdate";
					birthdateParameter.Value = user.Birthdate;
					command.Parameters.Add(birthdateParameter);

					command.CommandText = "UPDATE Users SET Name=@Name, Birthdate=@Birthdate WHERE Id=@Id";

					try
					{
						connection.Open();
						if (command.ExecuteNonQuery() != 0)
						result = true;
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return result;
		}


		public bool UpdateReward(RewardsModel reward)
        {
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					SqlParameter idParameter = new SqlParameter();
					idParameter.ParameterName = "Id";
					idParameter.Value = reward.Id;
					command.Parameters.Add(idParameter);

					SqlParameter titleParameter = new SqlParameter();
					titleParameter.ParameterName = "Title";
					titleParameter.Value = reward.Title;
					command.Parameters.Add(titleParameter);

					SqlParameter descriptionParameter = new SqlParameter();
					descriptionParameter.ParameterName = "Description";
					descriptionParameter.Value = reward.Description;
					command.Parameters.Add(descriptionParameter);

					command.CommandText = "UPDATE Rewards SET Title=@Title, Description=@Description WHERE Id=@Id";

					try
					{
						connection.Open();
						if (command.ExecuteNonQuery() != 0)
							return true;
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}
			return false;
		}

	}
}

