using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Autodealers.Enums
{
    public enum BodyType
    {
        [Description("Внедорожник 3 дв.")]
        SUVThreeDoors = 1,
        [Description("Внедорожник 5 дв.")]
        SUVFiveDoors,
        [Description("Кабриолет")]
        Cabriolet,
        [Description("Купе")]
        Coupe,
        [Description("Легковой фургон")]
        PassengerVan,
        [Description("Лимузин")]
        Limousine,
        [Description("Лифтбек")]
        Liftback,
        [Description("Микроавтобус грузопассажирский")]
        CargoMinibus,
        [Description("Микроавтобус пассажирский")]
        PassengerMinibus,
        [Description("Минивэн")]
        Minivan,
        [Description("Пикап")]
        Pickup,
        [Description("Родстер")]
        Roadster,
        [Description("Седан")]
        Sedan,
        [Description("Универсал")]
        StationWagon,
        [Description("Хэтчбек 3 дв.")]
        HatchbackThreeDoors,
        [Description("Хэтчбек 5 дв.")]
        HatchbachFiveDoors,
        [Description("Другой")]
        Other
    }
}
