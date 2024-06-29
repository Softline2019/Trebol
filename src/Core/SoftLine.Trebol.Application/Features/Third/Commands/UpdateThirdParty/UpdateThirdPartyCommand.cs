using MediatR;

namespace SoftLine.Trebol.Application.Features.Third.Commands.UpdateThirdParty
{
    public class UpdateThirdPartyCommand : IRequest
    {
        public int Id { get; set; }
        public decimal NIT { get; set; }
        public string? Class { get; set; }
        public string? Regime { get; set; }
        public decimal? VerificationDigitNIT { get; set; }
        public string? NITCode { get; set; }
        public string? BusinessName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string? CountryCode { get; set; }
        public string? DepartmentCode { get; set; }
        public string? EconomicActivityCode { get; set; }
        public string? HasDocument { get; set; }
        public string? IsMandator { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? UserUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? TaxMailbox { get; set; }
        public bool? IsSupplier { get; set; }
        public bool? IsClient { get; set; }
        public bool? IsEmployee { get; set; }
        public bool? IsBeneficiary { get; set; }
        public string? CompanyShortName { get; set; }
        public string? User { get; set; }
    }
}
