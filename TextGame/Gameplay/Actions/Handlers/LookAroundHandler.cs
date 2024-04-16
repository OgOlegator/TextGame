using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Exceptions;

namespace TextGame.Gameplay.Actions.Handlers
{
    /// <summary>
    /// Обработчик команды Осмотреться
    /// </summary>
    public class LookAroundHandler : BaseActionHandler
    {
        public LookAroundHandler(GameProcess game) : base(game)
        {
        }

        public override string Execute()
        {
            var currentLocation = GetCurrentLocation();

            return $"Текущее местоположение: {Game.Player.CurrentLocation}. { GetItems() }. Можно пройти: {GetNextLocations()}";

            string GetNextLocations()
                => string.Join(", ", currentLocation.NextLocations);

            string GetItems()
            {
                if (currentLocation.Items.Count == 0)
                    return "Ничего интересного";
                else
                    return "Предметы в комнате: " + string.Join("; ", currentLocation.Items.Select(item => $"{item.AdditionalDesc} - {item.Name}"));
            }
        }

        public override void SetParams(List<string> parameters)
        {
            return;
        }
    }
}
