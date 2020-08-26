using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum TransmissionType
    {
        [Description("Автоматическая")]
        Automatic = 1,
        [Description("Механическая")]
        Manual
    }
}
