using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Gameplay.Items;

namespace TextGame.Gameplay.Locations
{
    /// <summary>
    /// Локация игры
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Имя локации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Куда можно пройти из локации
        /// </summary>
        public List<string> NextLocations { get; set; }

        /// <summary>
        /// Предметы в локации
        /// </summary>
        public List<ItemFromLocation> Items { get; set; } = new List<ItemFromLocation>();
    }
}
