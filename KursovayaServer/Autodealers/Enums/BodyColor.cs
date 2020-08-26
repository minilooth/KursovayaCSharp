using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum BodyColor
    {
        [Description("Белый")]
        White = 1,
        [Description("Бордовый")]
        Burgundy,
        [Description("Желтый")]
        Yellow,
        [Description("Зеленый")]
        Green,
        [Description("Коричневый")]
        Brown,
        [Description("Красный")]
        Red,
        [Description("Оранжевый")]
        Orange,
        [Description("Серебристый")]
        Silver,
        [Description("Серый")]
        Gray,
        [Description("Синий")]
        Blue,
        [Description("Фиолетовый")]
        Purple,
        [Description("Черный")]
        Black,
        [Description("Другой")]
        Other
    }
}
