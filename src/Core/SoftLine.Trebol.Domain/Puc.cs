using SoftLine.Trebol.Domain.Common;


namespace SoftLine.Trebol.Domain;

    public class Puc : BaseDomainModel
    {
       
        public string NombreCorto { get; set; }
        public int Cuenta { get; set; } 
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CodTributario { get; set; }
        public string Digitable { get; set; }

    }

