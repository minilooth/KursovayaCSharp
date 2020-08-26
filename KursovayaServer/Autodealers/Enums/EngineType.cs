using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum EngineType
    {
        [Description("Бензиновый")]
        Petrol = 1,
        [Description("Дизельный")]
        Diesel,
        [Description("Электро")]
        Electric
    }
}
