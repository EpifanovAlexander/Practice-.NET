using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkWithASP.Models
{
    public class UsersModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public List<RewardsModel> Rewards { get; set; }

        public List<bool> RewardsIsCheck { get; set; }

        public UsersModel()
        {
            Rewards = new List<RewardsModel>();
            RewardsIsCheck = new List<bool>();
        }

    }
}
