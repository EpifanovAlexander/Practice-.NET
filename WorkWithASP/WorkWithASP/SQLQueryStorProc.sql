CREATE PROCEDURE FillRewardUpdatedUser (@idUser int, @idReward int)
AS
BEGIN
    if (NOT EXISTS(SELECT * FROM RewardsUser WHERE UserId=@idUser AND RewardId=@idReward))
     BEGIN 
      INSERT INTO RewardsUser (UserId,RewardId) VALUES (@idUser, @idReward) 
     END     
END