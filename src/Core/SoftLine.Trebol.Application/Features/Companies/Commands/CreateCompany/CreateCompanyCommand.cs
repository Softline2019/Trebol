using MediatR;
using SoftLine.Trebol.Application.Features.Companies.Queries.Vms;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.CreateCompanies
{
    public class CreateCompanyCommand : IRequest<CompanyVm>
    {
        public int Id { get; set; }
        public string? NameShortCompany { get; set; }
        public string? NIT { get; set; }
        public string? CheckDigit { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Indicative { get; set; }
        public string? DepartmentCode { get; set; }
        public string? AdministrationCode { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? PulledApart { get; set; }
        public DateTime? LastClosingDate { get; set; }
        public decimal TaxYear { get; set; }
        public string? Regime { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Level4 { get; set; }
        public int Level5 { get; set; }
        public int Level6 { get; set; }
        public string? CostCenter { get; set; }
        public int CostCenterLevel1 { get; set; }
        public int CostCenterLevel2 { get; set; }
        public int CostCenterLevel3 { get; set; }
        public bool BankReconciliation { get; set; }
        public bool CashFlow { get; set; }
        public int CompanyType { get; set; }
        public int Economic_Activity { get; set; }
        public int IndustryAndCommerceActivityCode { get; set; }
        public string? CompanyClass { get; set; }
        public string? DeclaringClass { get; set; }
        public string? CommercialRegistration { get; set; }
        public int BranchNumber { get; set; }
        public string? LegalRepresentative { get; set; }
        public int LegalRepresentativeID { get; set; }
        public string? RepresentativeCard { get; set; }
        public string? TaxAudit { get; set; }
        public int TaxAuditorID { get; set; }
        public string? ProfessionalCard { get; set; }
        public string? Counter { get; set; }
        public string? CounterId { get; set; }
        public string? AccountantProfessionalCard { get; set; }
        public decimal MinimumSanction { get; set; }
        public bool? LocalMoney { get; set; }
        public string? DescriptionOfLocal { get; set; }
        public bool? ParallelMoney { get; set; }
        public bool ParallelMoneycheck { get; set; }
        public bool CostCenterClosure { get; set; }
        public string? NitMinorCash { get; set; }
        public string? NitMajorCash { get; set; }
        public string? Email { get; set; }
    }
}
