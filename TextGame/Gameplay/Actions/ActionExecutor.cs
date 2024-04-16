using System.Reflection;
using TextGame.Exceptions;
using TextGame.Gameplay.Actions.Handlers;

namespace TextGame.Gameplay.Actions
{
    /// <summary>
    /// Исполнитель действий в игре
    /// </summary>
    public class ActionExecutor
    {
        /// <summary>
        /// Настроенные действия в игре
        /// </summary>
        private readonly List<GameAction> _actions;

        /// <summary>
        /// Процесс игры
        /// </summary>
        private readonly GameProcess _game;

        public ActionExecutor(List<GameAction> actions, GameProcess game)
        {
            _actions = actions;
            _game = game;
        }

        /// <summary>
        /// Получение инстанции класса реализующего действие в игре
        /// </summary>
        /// <param name="action">Действие (с параметрами)</param>
        /// <returns></returns>
        public string Execute(string command)
        {
            var commandParams = command.Split(' ');
            var commandName = commandParams[0];

            var action = _actions.FirstOrDefault(action => action.Name.ToLower() == commandName.ToLower());

            if (action == null)
                return "Неизвестная команда.";

            try
            {
                var actionType = GetType(action.ClassHandler);

                //Предпологается, что при иницилизации обработчику действия бедет передавать только GameProcess 
                var actionHandler = (BaseActionHandler)Activator.CreateInstance(actionType, new object[] { _game });

                actionHandler.SetParams(commandParams.Skip(1).ToList());

                return actionHandler.Execute();
            }
            catch (ArgumentNullException ex)
            {
                throw new GameProcessException("Не задан обработчик действия.");
            }
            catch (GameProcessException ex)
            {
                throw;
            }
            catch
            {
                throw new GameProcessException("Ошибка при выполнении действия.");
            }
        }

        private Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);

            if (type != null) 
                return type;

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);

                if (type != null)
                    return type;
            }

            return null;
        }
    }
}
