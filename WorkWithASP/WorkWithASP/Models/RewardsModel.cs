﻿using System.ComponentModel.DataAnnotations;

namespace WorkWithASP.Models
{
    public class RewardsModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
