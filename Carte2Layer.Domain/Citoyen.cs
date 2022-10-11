using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carte2Layer.Domain
{
    public class Citoyen
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public int CIN { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
