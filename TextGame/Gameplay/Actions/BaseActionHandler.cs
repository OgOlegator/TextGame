using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Exceptions;
using TextGame.Gameplay.Locations;
using TextGame.Gameplay.Player;

namespace TextGame.Gameplay.Actions
{
    /// <summary>
    /// Базовый обработчик действия
    /// </summary>
    public abstract class BaseActionHandler
    {
        /// <summary>
        /// Объект игры
        /// </summary>
        protected readonly GameProcess Game;

        /// <summary>
        /// Выполнить действие
        /// </summary>
        /// <returns></returns>
        public abstract string Execute();

        /// <summary>
        /// Установить параметры действия
        /// </summary>
        /// <param name="parameters">Параметры действия</param>
        public abstract void SetParams(List<string> parameters);

        public BaseActionHandler(GameProcess game)
        {
            Game = game;
        }

        /// <summary>
        /// Получить текущую локацию игрока
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GameProcessException">Локация не найдена</exception>
        protected Location GetCurrentLocation()
        {
            var currentLocation = Game.Locations.FirstOrDefault(location => location.Name == Game.Player.CurrentLocation);

            if (currentLocation == null)
                throw new GameProcessException("Не найдена текущая локация игрока.");

            return currentLocation;
        }
    }
}
