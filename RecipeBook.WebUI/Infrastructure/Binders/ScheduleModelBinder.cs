using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeBook.Domain.Entities;
using System.Web.Mvc;

namespace RecipeBook.WebUI.Infrastructure.Binders
{
    public class ScheduleModelBinder : IModelBinder
    {
        private const string SESSIONKEY = "Schedule";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get schedule from session
            Schedule schedule = null;
            if (controllerContext.HttpContext.Session != null)
            {
                schedule = (Schedule)controllerContext.HttpContext.Session[SESSIONKEY];
            }
            //create schedule iuf there wasn't one in session data
            if (schedule == null)
            {
                schedule = new Schedule();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SESSIONKEY] = schedule;
                }
            }
            //return schedule
            return schedule;
        }
    }
}