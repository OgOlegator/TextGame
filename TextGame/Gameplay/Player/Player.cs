using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Gameplay.Items;
using TextGame.Gameplay.Locations;

namespace TextGame.Gameplay.Player
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Текущая локация игрока
        /// </summary>
        public string CurrentLocation { get; set; }

        /// <summary>
        /// Предметы в инвентаре
        /// </summary>
        public List<string> Items { get; set; } = new List<string>();
    }
}
