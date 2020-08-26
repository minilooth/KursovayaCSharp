using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum WheelDriveType
    {
        [Description("Передний")]
        Front = 1,
        [Description("Задний")]
        Rear,
        [Description("Подключаемый полный")]
        PluggableFull,
        [Description("Постоянный полный")]
        PermanentFull
    }
}
