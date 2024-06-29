using MediatR;
using System;

namespace SoftLine.Trebol.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest
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

        public UpdateCompanyCommand(
            int id,
            string? nameShortCompany,
            string? nIT,
            string? checkDigit,
            string? companyName,
            string? address,
            string? city,
            string? indicative,
            string? departmentCode,
            string? administrationCode,
            string? phone1,
            string? phone2,
            string? pulledApart,
            DateTime? lastClosingDate,
            decimal taxYear,
            string? regime,
            int level1,
            int level2,
            int level3,
            int level4,
            int level5,
            int level6,
            string? costCenter,
            int costCenterLevel1,
            int costCenterLevel2,
            int costCenterLevel3,
            bool bankReconciliation,
            bool cashFlow,
            int companyType,
            int economic_Activity,
            int industryAndCommerceActivityCode,
            string? companyClass,
            string? declaringClass,
            string? commercialRegistration,
            int branchNumber,
            string? legalRepresentative,
            int legalRepresentativeID,
            string? representativeCard,
            string? taxAudit,
            int taxAuditorID,
            string? professionalCard,
            string? counter,
            string? counterId,
            string? accountantProfessionalCard,
            decimal minimumSanction,
            bool? localMoney,
            string? descriptionOfLocal,
            bool? parallelMoney,
            bool parallelMoneycheck,
            bool costCenterClosure,
            string? nitMinorCash,
            string? nitMajorCash,
            string? email)
        {
            Id = id;
            NameShortCompany = nameShortCompany;
            NIT = nIT;
            CheckDigit = checkDigit;
            CompanyName = companyName;
            Address = address;
            City = city;
            Indicative = indicative;
            DepartmentCode = departmentCode;
            AdministrationCode = administrationCode;
            Phone1 = phone1;
            Phone2 = phone2;
            PulledApart = pulledApart;
            LastClosingDate = lastClosingDate;
            TaxYear = taxYear;
            Regime = regime;
            Level1 = level1;
            Level2 = level2;
            Level3 = level3;
            Level4 = level4;
            Level5 = level5;
            Level6 = level6;
            CostCenter = costCenter;
            CostCenterLevel1 = costCenterLevel1;
            CostCenterLevel2 = costCenterLevel2;
            CostCenterLevel3 = costCenterLevel3;
            BankReconciliation = bankReconciliation;
            CashFlow = cashFlow;
            CompanyType = companyType;
            Economic_Activity = economic_Activity;
            IndustryAndCommerceActivityCode = industryAndCommerceActivityCode;
            CompanyClass = companyClass;
            DeclaringClass = declaringClass;
            CommercialRegistration = commercialRegistration;
            BranchNumber = branchNumber;
            LegalRepresentative = legalRepresentative;
            LegalRepresentativeID = legalRepresentativeID;
            RepresentativeCard = representativeCard;
            TaxAudit = taxAudit;
            TaxAuditorID = taxAuditorID;
            ProfessionalCard = professionalCard;
            Counter = counter;
            CounterId = counterId;
            AccountantProfessionalCard = accountantProfessionalCard;
            MinimumSanction = minimumSanction;
            LocalMoney = localMoney;
            DescriptionOfLocal = descriptionOfLocal;
            ParallelMoney = parallelMoney;
            ParallelMoneycheck = parallelMoneycheck;
            CostCenterClosure = costCenterClosure;
            NitMinorCash = nitMinorCash;
            NitMajorCash = nitMajorCash;
            Email = email;
        }
    }
}
