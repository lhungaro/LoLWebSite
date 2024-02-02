using System;

namespace Freela.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyStatus { get; set; }
        public int CompanyRanking { get; set; }
        public string CPNJ { get; set; }
        public DateTime CadastreDate { get; set; }

    }
}
