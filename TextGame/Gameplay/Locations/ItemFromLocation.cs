using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Gameplay.Items;

namespace TextGame.Gameplay.Locations
{
    /// <summary>
    /// Предмет в локации
    /// </summary>
    public class ItemFromLocation
    {
        /// <summary>
        /// Предмет
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дополнительное поисание
        /// </summary>
        public string AdditionalDesc { get; set; }
    }
}
