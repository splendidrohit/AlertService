using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService.Storage
{
    public class InMemoryCache : IStorage
    {
        private readonly Dictionary<string, Team> Cache;
        private static IStorage CacheInstace = null;

        private InMemoryCache()
        {
            Cache = new Dictionary<string, Team>();
        }

        public static IStorage GetInstance()
        {
            if (CacheInstace == null)
            {
                CacheInstace = new InMemoryCache();
            }
            return CacheInstace;
        }

        public Team GetTeam(string name)
        {
            if (!this.Cache.ContainsKey(name))
            {
                throw new Exception("Team name not found");
            }

            return this.Cache[name];
        }

        public void SaveTeam(Team team)
        {
            if (this.Cache.ContainsKey(team.Name))
            {
                throw new Exception("team already exist");
            }

            this.Cache.Add(team.Name, team);
        }
    }
}
