using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Gameplay.Items;

namespace TextGame.Progress
{
    /// <summary>
    /// Прогресс игры
    /// </summary>
    public class GameProgressModel
    {
        /// <summary>
        /// Состояние игрока
        /// </summary>
        public PlayerState PlayerState { get; set; } = new PlayerState();

        /// <summary>
        /// Состояние локаций
        /// </summary>
        public List<LocationState> LocationsState { get; set; } = new List<LocationState>();
    }

    /// <summary>
    /// Состояние игрока
    /// </summary>
    public class PlayerState
    {
        /// <summary>
        /// Текущая локация игрока
        /// </summary>
        public string CurrentLocation { get; set; }

        /// <summary>
        /// Состояние инвентаря игрока
        /// </summary>
        public List<string> Items {  get; set; }
    }

    /// <summary>
    /// Состояние локации
    /// </summary>
    public class LocationState
    {
        public string Name { get; set; }

        /// <summary>
        /// Какие предметы остались в локации
        /// </summary>
        public List<string> Items {  get; set; }
    }
}
