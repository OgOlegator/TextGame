using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using TextGame.Exceptions;
using TextGame.Gameplay.Actions;
using TextGame.Gameplay.Items;
using TextGame.Gameplay.Locations;
using TextGame.Gameplay.Player;
using TextGame.Progress;
using TextGame.Settings;

namespace TextGame
{
    /// <summary>
    /// Ход игры
    /// </summary>
    public class GameProcess
    {
        private const string SolutionAndAppSubPath = "TextGame\\TextGame";

        public Player Player { get; private set; }

        public List<Location> Locations { get; private set; }

        public List<Item> Items { get; private set; }

        public ActionExecutor ActionExecutor { get; private set; }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public string ExecuteAction(string action)
            => ActionExecutor.Execute(action);

        /// <summary>
        /// Запуск игры. Загрузка прогресса
        /// </summary>
        public void StartGame()
        {
            SetGameSettings();
            SetGameProgress();

            //Установка настроек игры
            void SetGameSettings()
            {
                var gameSettings = ReadFile<GameSettingsModel>(
                Path.Combine(GetAppPath(), "Settings\\GameSettings.json"));

                Items = gameSettings.Items;
                Locations = gameSettings.Locations;
                ActionExecutor = new ActionExecutor(gameSettings.Actions, this);
            }

            //Восстановление прогресса игры
            void SetGameProgress()
            {
                var gameProgress = ReadFile<GameProgressModel>(
                Path.Combine(GetAppPath(), "Progress\\GameProgress.json"));

                foreach (var locationState in gameProgress.LocationsState)
                {
                    var location = Locations.FirstOrDefault(location => location.Name == locationState.Name);

                    if (location == null)
                        throw new GameProcessException("Ошибка при загрузке прогресса. Перезапустите игру. Команда: initGame");

                    //Удаляем предметы, которых в локации уже нет
                    location.Items = location.Items.Where(item => locationState.Items.Contains(item.Name)).ToList();
                }

                Player = new Player
                {
                    CurrentLocation = gameProgress.PlayerState.CurrentLocation,
                    Items = gameProgress.PlayerState.Items
                };
            }
        }

        /// <summary>
        /// Начать игру сначала. Удалить прогресс
        /// </summary>
        public void RestartGame()
        {
            var startGameSettings = ReadFile<GameProgressModel>(
                Path.Combine(GetAppPath(), "Progress\\StartProgress.json"));

            WriteFile<GameProgressModel>(
                Path.Combine(GetAppPath(), "Progress\\GameProgress.json"),
                startGameSettings);

            StartGame();
        }

        /// <summary>
        /// Завершение игры. Сохранение прогресса
        /// </summary>
        public void EndGame()
        {
            var gameProgress = new GameProgressModel();

            gameProgress.PlayerState.CurrentLocation = Player.CurrentLocation;
            gameProgress.PlayerState.Items = Player.Items.Select(item => item).ToList();

            foreach(var location in Locations)
                gameProgress.LocationsState.Add(new LocationState
                {
                    Name = location.Name,
                    Items = location.Items.Select(item => item.Name).ToList(),
                });

            WriteFile<GameProgressModel>(
                Path.Combine(GetAppPath(), "Progress\\GameProgress.json"),
                gameProgress);
        }

        /// <summary>
        /// Чтение файлов игры
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        private T ReadFile<T>(string path)
        {
            using (var file = new StreamReader(path))
            {
                var textFile = file.ReadToEnd();

                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                }; 

                return JsonSerializer.Deserialize<T>(textFile, options);
            }
        }

        /// <summary>
        /// Запись в файлы игры
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="model">Данные файла</param>
        private void WriteFile<T>(string path, T model)
        {
            using (var file = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                var newTextFile = JsonSerializer.Serialize(model, options);
             
                file.Write(newTextFile);
            }
        }

        /// <summary>
        /// Получить путь к папке с Приложением 
        /// </summary>
        /// <returns></returns>
        private string GetAppPath()
            => Path.Combine(
                Assembly.GetExecutingAssembly().Location
                    .Split(SolutionAndAppSubPath)
                    .First(), 
                SolutionAndAppSubPath);
    }
}
