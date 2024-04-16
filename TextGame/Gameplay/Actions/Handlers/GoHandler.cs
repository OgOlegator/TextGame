using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Exceptions;

namespace TextGame.Gameplay.Actions.Handlers
{
    /// <summary>
    /// Обработчик команды Идти
    /// </summary>
    public class GoHandler : LookAroundHandler
    {
        /// <summary>
        /// Следующая локация
        /// </summary>
        private string _nextLocation { get; set; }

        public GoHandler(GameProcess game) : base(game)
        {
        }

        public override string Execute()
        {
            var currentLocation = GetCurrentLocation();

            var nameNextLocation = currentLocation.NextLocations.FirstOrDefault(nextLocation => nextLocation.ToLower() == _nextLocation.ToLower());

            if (nameNextLocation == null) 
                return $"Нет пути в {_nextLocation}";

            Game.Player.CurrentLocation = nameNextLocation;

            return base.Execute();
        }

        public override void SetParams(List<string> parameters)
        {
            if (parameters.Count == 0)
                throw new GameProcessException("Не заданы параметры для команды.");

            _nextLocation = parameters[0];
        }
    }
}
