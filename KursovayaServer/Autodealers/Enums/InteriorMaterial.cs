using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum InteriorMaterial
    {
        [Description("Натуральная кожа")]
        GenuineLeather = 1,
        [Description("Искусственная кожа")]
        FauxLeather = 2,
        [Description("Ткань")]
        Cloth = 3,
        [Description("Велюр")]
        Velours = 4,
        [Description("Алькантара")]
        Alcantara = 5,
        [Description("Комбинированный")]
        Combined = 6
    }
}
