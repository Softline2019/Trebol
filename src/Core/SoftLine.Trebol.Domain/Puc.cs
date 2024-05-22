using SoftLine.Trebol.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Domain
{
    public class Puc : BaseDomainModel
    {
        public int NR { get; set; }
        public int IdCompany { get; set; }
        public string FNCShort { get; set; }
        public int FCAccount { get; set; } 
        public string FCName { get; set; }
        public string FCType { get; set; }
        public int FCCodSub { get; set; }
        public string FCDigit { get; set; }

    }
}
