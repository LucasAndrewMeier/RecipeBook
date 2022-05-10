using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeBook.Domain.Entities;
namespace RecipeBook.WebUI.Models
{
    public class ScheduleIndexViewModel
    {
        public Schedule Schedule { get; set; }
        public string ReturnUrl { get; set; }
    }
}