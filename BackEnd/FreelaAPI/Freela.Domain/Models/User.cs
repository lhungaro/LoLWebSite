using System;

namespace Freela.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Whatsapp { get; set; }
        public string PhotoURL { get; set; }
        public string Biography { get; set; }
        public string Area { get; set;}
        public string Price { get; set; }
        public string Curriculum { get; set; }
        public Company Company { get; set; }
        public IEnumerable<UserProject>? UserProjects { get; set; }


    }
}
