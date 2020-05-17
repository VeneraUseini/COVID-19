using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace covid_19.Models
{
    public class PeopleWithCovid
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Total Cases")]
        public int TotalCases { get; set; }
        [Required]
        [DisplayName("New Cases")]
        public int NewCases { get; set; }
        [Required]
        [DisplayName("Total Deaths")]
        public int TotalDeaths { get; set; }
        [Required]
        [DisplayName("Total Recovered")]
        public int TotalRecovered { get; set; }
        [Required]
        [DisplayName("Active Cases")]
        public int ActiveCases { get; set; }
        [Required]
        [DisplayName("Serious Critical")]
        public int SeriousCritical { get; set; }
    }
}
