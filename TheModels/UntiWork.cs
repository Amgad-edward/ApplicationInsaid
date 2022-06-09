using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TheModels.Models;
using TheModels.InterfaceUnitWork;
using TheModels.Repository;

namespace TheModels
{
    public class UntiWork<Data> : IUntiWork ,IUntiWorkWebSaite where Data : ContextApplication
    {
        private readonly Data data;

        public UntiWork(Data data)
        {
            this.data = data;
        }

        public IRepository<Customer> Customer => new Repository<Customer>(data);

        public IRepository<Project> Projects => new Repository<Project>(data);

        public IRepository<UnitProject> UnitProjects => new Repository<UnitProject>(data);

        public IRepository<Category>? Categories => new Repository<Category>(data);

        public IRepository<ResertvationAndSale>? ResertvationAndSales => new Repository<ResertvationAndSale>(data);

        public IRepository<PaymentMoney>? PaymentMoneys => new Repository<PaymentMoney>(data);

        public IRepository<Floor>? Floors => new Repository<Floor>(data);

        public IRepository<Company>? Companys => new Repository<Company>(data);

        public IRepository<Weight>? Weights => new Repository<Weight>(data);

        public IRepository<SaleryPayment>? SaleryPayments => new Repository<SaleryPayment>(data);

        public IRepository<ProjectImage>? ProjectImages => new Repository<ProjectImage>(data);

        public IRepository<Materials>? Materials => new Repository<Materials>(data);

        public IRepository<BuildingCost>? BuildingCosts => new Repository<BuildingCost>(data);

        public IRepository<AttendingAndLeaving>? AttendingAndLeavings => new Repository<AttendingAndLeaving>(data);

        public IRepository<Emplyee>? Emplyees => new Repository<Emplyee>(data);

        public IRepository<LogAdmins>? LogAdmins => new Repository<LogAdmins>(data);

        public IRepository<LogCustomers>? LogCustomers => new Repository<LogCustomers>(data);

        public IRepository<LogEmplyee>? logEmplyees => new Repository<LogEmplyee>(data);

        public IRepositoryNet<Contacts>? Contacts => new Repository<Contacts>(data);

        public IRepositoryNet<Gallery>? Gallery => new Repository<Gallery>(data);

        public IRepositoryNet<AllSubjects>? AllSubjects => new Repository<AllSubjects>(data);

        public IRepository<FinishesUnit>? FinishesUnits => new Repository<FinishesUnit>(data);

        public IRepository<FinishCost>? FinishCosts => new Repository<FinishCost>(data);

        public IRepository<Maker>? Makers => new Repository<Maker>(data);

        public IRepository<Report>? Reports =>new Repository<Report>(data);

        public IRepository<TaskCarry>? Tasks => new Repository<TaskCarry>(data);

        public IRepository<OtherCompanies>? OtherCompanies => new Repository<OtherCompanies>(data);

        public IRepository<AccountOtherCompany>? AccountOtherCompanies => new Repository<AccountOtherCompany>(data);

        public IRepository<ThePaymentCost>? ThePaymentCosts => new Repository<ThePaymentCost>(data);

        public IRepository<PaymentFinish>? PaymentFinishing => new Repository<PaymentFinish>(data);

        public IRepository<AllSubjects>? Subjects => new Repository<AllSubjects>(data);

        public IRepository<Contacts>? Contant => new Repository<Contacts>(data);

        public IRepository<Gallery>? Gallerys => new Repository<Gallery>(data);

        public IRepository<Customer> Customers => new Repository<Customer>(data);

      
        public bool CreateDatabase()
        {
            return data.Database.EnsureCreated();
        }

        public async Task<bool> CreateDatabaseAsync()
        {
            return await data.Database.EnsureCreatedAsync();
        }

        public async Task<bool> DataBaseExsist()
        {
            return await data.Database.CanConnectAsync();
        }

        public void Dispose()
        {
            data.Dispose();
        }

        public void SaveChange()
        {
            data.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await data.SaveChangesAsync();
        }
    }
}
