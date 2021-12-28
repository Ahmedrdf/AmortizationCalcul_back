using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class FirstResults
    {
        [Key]
        public int Id { get; set; }
        public double MontantDachat { get; set; }
        public double FraisDachat { get; set; }
        public double FondPropre { get; set; }
        public double FraisDhypotheque { get; set; }
        public double Mensualite { get; set; }
        public double MentantEmpBrut { get; set; }
        public double MentantEmpNet { get; set; } 
        public double InteretAnnuel { get; set; }
        public double InteretMensuel { get; set; }
        public double Capital { get; set; }

        public int duree { get; set; }

        //[ForeignKey("AmortissementId")]
        public List <Amortissement> Amortissements { get; set; }

    }
}