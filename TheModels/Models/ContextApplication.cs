using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheModels.Models
{
    public class ContextApplication : DbContext
    {
        public ContextApplication(DbContextOptions<ContextApplication> options) : base(options)
        {
            
        }




        public DbSet<Customer>? Customers { get; set; }//1

        public DbSet<Project>? Projects { get; set; }//2

        public DbSet<UnitProject>? UnitProjects { get; set; }//3

        public DbSet<Category>? Categories { get; set; }//4

        public DbSet<ResertvationAndSale>? ResertvationAndSales { get; set; }//5

        public DbSet<PaymentMoney>? PaymentMoneys { get; set; }//6

        public DbSet<Floor>? Floors { get; set; }//7

        public DbSet<Company>? Companys { get; set; }//8

        public DbSet<Weight>? Weights { get; set; }//9

        public DbSet<SaleryPayment>? SaleryPayments { get; set; }//10

        public DbSet<ProjectImage>? ProjectImages { get; set; }//11

        public DbSet<Materials>? Materials { get; set; }//12

        public DbSet<BuildingCost>? BuildingCosts { get; set; }//III

        public DbSet<AttendingAndLeaving>? AttendingAndLeavings { get; set; }//14

        public DbSet<Emplyee>? Emplyees { get; set; }//15

        public DbSet<LogAdmins>? LogAdmins { get; set; }//16

        public DbSet<LogCustomers>? LogCustomers { get; set; }//17

        public DbSet<LogEmplyee>? logEmplyees { get; set; }//18

        public DbSet<Contacts>? Contacts { get; set; }//19

        public DbSet<Gallery>? Gallery { get; set; }//20

        public DbSet<AllSubjects>? AllSubjects { get; set; }//21

        public DbSet<FinishesUnit>? FinishesUnits { get; set; }//22

        public DbSet<FinishCost>? FinishCosts { get; set; }//23

        public DbSet<Maker>? Makers { get; set; }//24

        public DbSet<Report>? Reports { get; set; }//25

        public DbSet<TaskCarry>? Tasks { get; set; }//26

        public DbSet<OtherCompanies>? OtherCompanies { get; set; }//27

        public DbSet<AccountOtherCompany>? AccountOtherCompanies { get; set; }//28

        public DbSet<ThePaymentCost>? ThePaymentCosts { get; set; }//29

        public DbSet<PaymentFinish>? PaymentFinishes { get; set; }//30
    }
}
