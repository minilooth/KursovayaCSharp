using System;

namespace ServerUtilities
{
    [Serializable]
    public enum MessageType
    {
        Action = 1,
        Error,
        Success
    }

    [Serializable]
    public enum ActionType
    {
        Authorize = 1,
        Deauthorize,
        Register,
        GetAutodealers,
        SetCurrentAutodealer,
        GetCars,
        GetCurrentUser,
        GetCurrentAutodealer,
        AddCar,
        DeleteCar,
        EditCar,
        SetCarFilter,
        ResetCarFilter,
        GetUsers,
        AddUser,
        BanUnbanUser,
        DeleteUser,
        SetUserSearchData,
        EditUser,
        GetDeals,
        ConfirmDeal,
        DeleteDeal,
        AddDeal,
        EditDeal,
        SetDealSearchData,
        DeleteAutodealer,
        AddAutodealer,
        EditAutodealer,
        SetAutodealerSearchData,
        GetCurrentAutodealerStatistics,
        GetNotSoldCars,
        EditCurrentUserUsername,
        EditCurrentUserPassword,
        EditCurrentUserFirstname,
        EditCurrentUserSurname,
        EditCurrentUserTelephone,
        BuyCar,
        GetCurrentUserStatistics,
        GetCurrentUserCars,
        GetUsersNotSuperUsers,
        Quit
    }
}
