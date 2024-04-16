using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Gameplay.Actions
{
    /// <summary>
    /// Действие в игре
    /// </summary>
    public class GameAction
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Класс обработчик
        /// </summary>
        public string ClassHandler { get; set; }
    }
}
