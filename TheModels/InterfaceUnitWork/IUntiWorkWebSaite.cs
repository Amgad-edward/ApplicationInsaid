using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Models;
using TheModels.Repository;

namespace TheModels.InterfaceUnitWork
{
    public interface IUntiWorkWebSaite : IDisposable
    {

        public IRepository<LogCustomers>? LogCustomers { get; }//17

        public IRepository<Customer> Customers { get; }

        public IRepository<LogEmplyee>? logEmplyees { get; }//18

        public IRepository<Project> Projects { get; }//2

        public IRepository<Company>? Companys { get; }//8

        public IRepository<AllSubjects>? Subjects { get; }//8

        public IRepository<Contacts>? Contant { get; }//8

        public IRepository<Gallery>? Gallerys { get; }//8
        void SaveChange();

        Task SaveChangeAsync();
    }
}
