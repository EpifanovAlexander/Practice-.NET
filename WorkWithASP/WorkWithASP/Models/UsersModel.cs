using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
