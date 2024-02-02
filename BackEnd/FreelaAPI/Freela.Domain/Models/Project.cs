using System;

namespace Freela.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int Proposes { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Ranking { get; set; }
        public string Area { get; set; }
        public string ValueToPay{ get; set; }
        public string categories{ get; set; }   
        public string contaxt{ get; set; }
        public Company Company { get; set; }
        public IEnumerable<UserProject>? UserProjects { get; set; }

    }
}
