using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Exceptions;

namespace TextGame.Gameplay.Actions.Handlers
{
    /// <summary>
    /// Обработчик команды Взять
    /// </summary>
    public class TakeHandler : BaseActionHandler
    {
        private string _takeItemName;

        public TakeHandler(GameProcess game) : base(game)
        {
        }

        public override string Execute()
        {
            var currentLocation = GetCurrentLocation();

            var takeItem = currentLocation.Items.FirstOrDefault(item => item.Name.ToLower() == _takeItemName.ToLower());

            if (takeItem == null)
                return $"Нет такого";

            Game.Player.Items.Add(takeItem.Name);
            currentLocation.Items.Remove(takeItem);

            return $"Предмет добавлен в инвентарь: {_takeItemName}";
        }

        public override void SetParams(List<string> parameters)
        {
            if (parameters.Count == 0)
                throw new GameProcessException("Не заданы параметры для команды.");

            _takeItemName = parameters[0];
        }
    }
}
