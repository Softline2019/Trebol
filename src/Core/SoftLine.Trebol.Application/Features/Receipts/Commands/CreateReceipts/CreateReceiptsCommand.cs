using MediatR;
using SoftLine.Trebol.Application.Features.Receipts.Queries.Vms;
using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Application.Features.Receipts.Commands.CreateReceipts;

public class CreateReceiptsCommand : IRequest<ReceiptsVm>
    {
        [Key]
        public int NR { get; set; }
        public string? CompanyShortName { get; set; }
        public int CompInt { get; set; } // validar segun el nombre eque el usaurio escoja el asigna un numero del 1 al 40
        public int Receipts { get; set; } // validar que no se repita
        public string? Name { get; set; }
        public bool DocRef { get; set; }
        public bool ReceiptClosing { get; set; }
        public bool ConseOblig { get; set; }
        public int Consecutive { get; set; } // validar que no se deje repetir pero el puede poner el que el quiere debe ser auto incrementado

        public class ConsecutiveManager
        {
            public int CurrentConsecutive { get; private set; }

            public ConsecutiveManager(int initialConsecutive)
            {
                CurrentConsecutive = initialConsecutive;
            }

            public void SetConsecutive(int newConsecutive)
            {
                if (newConsecutive < CurrentConsecutive)
                {
                    throw new ArgumentException("El nuevo consecutivo no puede ser menor al actual.");
                }
                CurrentConsecutive = newConsecutive;
            }

            public int GetNextConsecutive()
            {
                return ++CurrentConsecutive;
            }
        }


        public static Dictionary<int, string> GetReceiptInternalList()
        {
            return new Dictionary<int, string>
        {
            { 1, "ingreso" },
            { 2, "egreso" },
            { 3, "facturación" },
            { 4, "compras" },
            { 5, "provisiones" },
            { 6, "depreciación" }
        };
        }
    }
