using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Repository;
using TheModels.Models;

namespace TheModels.InterfaceUnitWork
{
    public interface IUntiWork : IDisposable
    {
        public IRepository<Customer> Customer { get; }//1

        public IRepository<Project> Projects { get; }//2

        public IRepository<UnitProject> UnitProjects { get; }//3

        public IRepository<Category>? Categories { get; }//4

        public IRepository<ResertvationAndSale>? ResertvationAndSales { get;  }//5

        public IRepository<PaymentMoney>? PaymentMoneys { get;  }//6

        public IRepository<Floor>? Floors { get;  }//7

        public IRepository<Company>? Companys { get;  }//8

        public IRepository<Weight>? Weights { get;  }//9

        public IRepository<SaleryPayment>? SaleryPayments { get;  }//10

        public IRepository<ProjectImage>? ProjectImages { get;  }//11

        public IRepository<Materials>? Materials { get;  }//12

        public IRepository<BuildingCost>? BuildingCosts { get;  }//III

        public IRepository<AttendingAndLeaving>? AttendingAndLeavings { get; }//14

        public IRepository<Emplyee>? Emplyees { get;  }//15

        public IRepository<LogAdmins>? LogAdmins { get; }//16

        public IRepository<LogCustomers>? LogCustomers { get;  }//17

        public IRepository<LogEmplyee>? logEmplyees { get;  }//18

        public IRepository<FinishesUnit>? FinishesUnits { get;  }//19

        public IRepository<FinishCost>? FinishCosts { get; }//20

        public IRepository<Maker>? Makers { get;  }//21

        public IRepository<Report>? Reports { get; }//22

        public IRepository<TaskCarry>? Tasks { get;  }//23

        public IRepository<OtherCompanies>? OtherCompanies { get; }//24

        public IRepository<AccountOtherCompany>? AccountOtherCompanies { get;  }//25

        public IRepository<ThePaymentCost>? ThePaymentCosts { get; }//26

        public IRepository<PaymentFinish>? PaymentFinishing { get; }//27
        void SaveChange();

        Task SaveChangeAsync();

        bool CreateDatabase();

        Task<bool>CreateDatabaseAsync();

        Task<bool> DataBaseExsist();

    }
}
