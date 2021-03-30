

namespace NotificationService.Models
{
    public class Developer
    {
        public string Name { get; }
        public string Phone { get; }

        public Developer(string name , string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }
    }
}
