using MediatR;
using SoftLine.Trebol.Application.Features.Pucs.Queries.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLine.Trebol.Application.Features.Pucs.Queries.GetPucs
{
    public class GetPucsQueryById : IRequest<PucsVm>
    {
        public int Id { get; set; }
        public GetPucsQueryById(int id)
        {
            Id = id;
        }
    }
}
