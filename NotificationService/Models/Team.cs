

namespace NotificationService.Models
{
    using System.Collections.Generic;
    public class Team
    {
        public string Name { get; }
        public List<Developer> Developers { get; }

        public Team(string name)
        {
            this.Name = name;
            this.Developers = new List<Developer>();
        }

        public void AddDeveloper(Developer developer)
        {
            this.Developers.Add(developer);
        }

        public Developer GetSomeDeveloper()
        {
            int size = this.Developers.Count;
            return this.Developers[size / 2]; // we can randomize this
        }
    }
}
