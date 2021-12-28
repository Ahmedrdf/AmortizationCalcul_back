using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Amortissement
    {
        public int AmortissementId { get; set; }
        public int Periode { get; set; }
        public double SoldeDebut  { get; set; }
        public double Mensualite { get; set; }
        public double  Interet { get; set; }
        public double  CapitaleRembourse { get; set; }
        public double  SoldeFin { get; set; }

    }
}
