using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Models
{
    public abstract class WeightedComboBoxItem
    {
        /// <summary>
        /// Name. Normalized uppercase.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// User Id from user
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Records last time a string was used
        /// </summary>
        public DateTime LastUsed { get; set; }
        /// <summary>
        /// How many times a string has been used
        /// </summary>
        public int Uses { get; set; }
        /// <summary>
        /// User who used the string - there will be a library per-user 
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Defines how high a string will be in the results when searching.
        /// Calculates based on logic around last use and how often used.
        /// </summary>
        /// <param name="httpContextAccessor">HTTP Context Accessor from dependency injection</param>
        /// <param name="userManager">User Manager from dependency injection</param>
        /// <returns>Weight to be used in combobox result sorting</returns>
        public virtual async Task<int> GetWeight(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            int weight = 1000000;
            DateTime today = DateTime.Now.Date;
            var contextUser = httpContextAccessor.HttpContext.User;
            var user = await userManager.GetUserAsync(contextUser);
            SortedList<int, int> dateWeightMap = new SortedList<int, int>()
            {
                { 0, 10000 }, // Weight highest if used today
                { 1, 900 }, // Yesterday
                { 7, 800 }, // A week ago
                { 14, 600 }, // Two weeks ago
                { 31, 500 },  // A month ago
                { 365, 400 }, // A year ago
                { 730, 0 } // Anytime after two years
            };
            // Process date weighting
            int timeSinceUse = today.Subtract(LastUsed.Date).Days;
            weight += dateWeightMap.GetValueOrDefault(dateWeightMap.Keys.BinarySearch(timeSinceUse));

            // Weight higher if used by current user
            if ( User == user)
            {
                weight += 10000;
            }
            // Weight higher if used more often
            weight += Uses;
            return weight;
        }

        public virtual void Update(WeightedComboBoxItem item)
        {
            if (Name != item.Name)
                Name = item.Name;
            if (LastUsed != item.LastUsed)
                LastUsed = item.LastUsed;
            if (Uses != item.Uses)
                Uses = item.Uses;
            if (User != item.User)
                User = item.User;
        }
    }
}
