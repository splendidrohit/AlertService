

namespace NotificationService.Storage
{
    using NotificationService.Models;
    using System;

    public interface IStorage
    {

        Team GetTeam(String name);

        void SaveTeam(Team team);

    }
}
