using System.ComponentModel.DataAnnotations;

namespace SoftLine.Trebol.Domain;

public class Company
{
    [Key]
    public int Id { get; set; }
    [StringLength(50)]
    public string? NameShortCompany { get; set; }

    [StringLength(30)]
    public string? NIT { get; set; }

    [StringLength(5)]
    public string? CheckDigit { get; set; }

    [StringLength(100)]
    public string? CompanyName { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(50)]
    public string? City { get; set; }

    [StringLength(10)]
    public string? Indicative { get; set; }

    [StringLength(10)]
    public string? DepartmentCode { get; set; }

    [StringLength(10)]
    public string? AdministrationCode { get; set; }

    [StringLength(20)]
    public string? Phone1 { get; set; }

    [StringLength(20)]
    public string? Phone2 { get; set; }

    [StringLength(50)]
    public string? PulledApart { get; set; }

    public DateTime? LastClosingDate { get; set; }

    public decimal TaxYear { get; set; }

    [StringLength(50)]
    public string? Regime { get; set; }

    public int Level1 { get; set; }
    public int Level2 { get; set; }
    public int Level3 { get; set; }
    public int Level4 { get; set; }
    public int Level5 { get; set; }
    public int Level6 { get; set; }

    [StringLength(50)]
    public string? CostCenter { get; set; }

    public int CostCenterLevel1 { get; set; }
    public int CostCenterLevel2 { get; set; }
    public int CostCenterLevel3 { get; set; }

    public bool BankReconciliation { get; set; }
    public bool CashFlow { get; set; }

    public int CompanyType { get; set; }
    public int Economic_Activity { get; set; }
    public int IndustryAndCommerceActivityCode { get; set; }

    [StringLength(50)]
    public string? CompanyClass { get; set; }

    [StringLength(50)]
    public string? DeclaringClass { get; set; }

    [StringLength(50)]
    public string? CommercialRegistration { get; set; }

    public int BranchNumber { get; set; }

    [StringLength(100)]
    public string? LegalRepresentative { get; set; }

    public int LegalRepresentativeID { get; set; }

    [StringLength(50)]
    public string? RepresentativeCard { get; set; }

    [StringLength(50)]
    public string? TaxAudit { get; set; }

    public int TaxAuditorID { get; set; }

    [StringLength(50)]
    public string? ProfessionalCard { get; set; }

    [StringLength(50)]
    public string? Counter { get; set; }

    [StringLength(50)]
    public string? CounterId { get; set; }

    [StringLength(50)]
    public string? AccountantProfessionalCard { get; set; }

    public decimal MinimumSanction { get; set; }

    public bool? LocalMoney { get; set; }

    [StringLength(200)]
    public string? DescriptionOfLocal { get; set; }

    public bool? ParallelMoney { get; set; }
    public bool ParallelMoneycheck { get; set; }
    public bool CostCenterClosure { get; set; }

    [StringLength(20)]
    public string? NitMinorCash { get; set; }

    [StringLength(20)]
    public string? NitMajorCash { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }
}
