using SoftLine.Trebol.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
// entidad
namespace SoftLine.Trebol.Domain
{
    public class ThirdParty : BaseDomainModel
    {

        public string? CompanyShortName { get; set; } // VARCHAR(6)
        public string? User { get; set; } // VARCHAR(15)
        public char? Class { get; set; } // CHAR(1)
        public char? Regime { get; set; } // CHAR(1)
        public decimal NIT { get; set; } // NUMERIC(12,2)
        public decimal VerificationDigitNIT { get; set; } // NUMERIC(1,2)
        public string? NITCode { get; set; } // VARCHAR(20)
        public string? BusinessName { get; set; } // VARCHAR(450)
        public string? Address { get; set; } // VARCHAR(40)
        public string? City { get; set; } // VARCHAR(25)
        public decimal? Phone1 { get; set; } // NUMERIC(12,2)
        public decimal? Phone2 { get; set; } // NUMERIC(12,2)
        public string? Mobile { get; set; } // VARCHAR(50)
        public decimal? Fax { get; set; } // NUMERIC(12,2)
        public string? Email { get; set; } // VARCHAR(60)
        public string? FirstName { get; set; } // VARCHAR(60)
        public string? MiddleName { get; set; } // VARCHAR(60)
        public string? LastName1 { get; set; } // VARCHAR(60)
        public string? LastName2 { get; set; } // VARCHAR(60)
        public string? CountryCode { get; set; } // CHAR(3)
        public string? DepartmentCode { get; set; } // CHAR(5)
        public string? EconomicActivityCode { get; set; } // VARCHAR(50)
        public bool? HasDocument { get; set; } // CHAR(1)
        public bool? IsMandator { get; set; } // CHAR(1)
        public DateTime? AdmissionDate { get; set; } // DATE
        public string? UserUpdate { get; set; } // VARCHAR(15)
        public DateTime? UpdateDate { get; set; } // DATE
        public string? TaxMailbox { get; set; } // VARCHAR(60)
        public bool IsSupplier { get; set; } // BOOLEAN
        public bool IsClient { get; set; } // BOOLEAN
        public bool IsEmployee { get; set; } // BOOLEAN
        public bool IsBeneficiary { get; set; } // BOOLEAN
    }

}

