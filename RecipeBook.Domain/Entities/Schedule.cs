using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Entities
{
    public class ScheduleLine
    {
        public Recipe Recipe { get; set; }
        public int Day { get; set; }
    }

    //Schedule Operations
    public class Schedule
    {
        private List<ScheduleLine> lineCollection = new List<ScheduleLine>();
    
        public IEnumerable<ScheduleLine> Lines
        {
            get { return lineCollection; }
        }
        //Add a Recipe (Recipe and which Day
        public void AddRecipe(Recipe recipe, int whichDay)
        {
            ScheduleLine line = lineCollection.Where(r => r.Recipe.RecipeID == recipe.RecipeID).FirstOrDefault();

            // Adding a new recipe to the schedule
            if(line == null)
            {
                lineCollection.Add(new ScheduleLine
                {
                    Recipe = recipe,
                    Day = whichDay
                });
            }
            // for recipe that is already on the schedule, add to more than one day
        }
        // Remove a product
        public void RemoveLine(Recipe recipe)
        {
            lineCollection.RemoveAll(l => l.Recipe.RecipeID == recipe.RecipeID);
        }

        // Clear the schedule
        public void Clear()
        {
            lineCollection.Clear();
        }
    }


}
