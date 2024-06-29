﻿using SoftLine.Trebol.Domain;

namespace SoftLine.Trebol.Application.Features.Pucs.Queries.Vms
{
    public class PucsVm
    {
        public string? NombreCorto { get; set; }
        public int Cuenta { get; set; }
        public string? Nombre { get; set; }
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }
        public int CodTributario { get; set; }
        public bool Digitable { get; set; }
    }
}
