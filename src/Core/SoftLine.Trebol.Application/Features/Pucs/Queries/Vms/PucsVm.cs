using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Pucs.Queries.Vms
{
    public class PucsVm
    {   public int Id {get; set;}
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
