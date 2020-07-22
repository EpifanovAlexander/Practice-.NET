using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkWithASP.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Birthdate { get; set; }

        public DateTime DateTimeBirthdate { get; set; }

        public List<RewardsViewModel> Rewards { get; set; }

        public List<bool> RewardsIsCheck { get; set; }

        public UsersViewModel()
        {
            Rewards = new List<RewardsViewModel>();
            RewardsIsCheck = new List<bool>();
        }

    }
}
