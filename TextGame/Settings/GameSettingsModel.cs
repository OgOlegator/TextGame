using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Gameplay.Actions;
using TextGame.Gameplay.Items;
using TextGame.Gameplay.Locations;

namespace TextGame.Settings
{
    /// <summary>
    /// Настройки игры
    /// </summary>
    public class GameSettingsModel
    {
        /// <summary>
        /// Локации
        /// </summary>
        public List<Location> Locations {  get; set; }

        /// <summary>
        /// Действия
        /// </summary>
        public List<GameAction> Actions { get; set; }

        /// <summary>
        /// Предметы
        /// </summary>
        public List<Item> Items { get; set; }
    }

}
