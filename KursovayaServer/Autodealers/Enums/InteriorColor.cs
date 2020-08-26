using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum InteriorColor
    {
        [Description("Светлый")]
        Light = 1,
        [Description("Темный")]
        Dark,
        [Description("Комбинированный")]
        Combined
    }
}
