using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheModels;
using TheModels.Models;
using TheModels.InterfaceUnitWork;




namespace ApplicationInsaid.Models
{
    public class ModelViewIndex
    {
        private readonly IUntiWorkWebSaite db;

        private readonly HttpContext httpContext1;

        public IEnumerable<AllSubjects>? AllSubjects { get; private set; }

        public IEnumerable<Contacts>? Contacts { get; private set; }

        public IEnumerable<Gallery>? Galleries { get; private set; }

        public string? GuidCustomer { get; private set; }

        public bool Login { get; private set; }
        public ModelViewIndex(IUntiWorkWebSaite DB, HttpContext httpContext1)
        {
            db = DB;
            this.httpContext1 = httpContext1;
            GetData();
        }

        private void GetData()
        {
            if(httpContext1 is not null)
            {
                if (httpContext1.Session.IsAvailable)
                {
                    if(httpContext1.Session.Keys.Count() > 0)
                    {
                        GuidCustomer = httpContext1.Session.GetString("LL");
                        Login = true;
                        //var GetCustomer = await db.Customers.Include(unit => unit.Units).ThenInclude(p => p.Unit)
                        //                        .ThenInclude(u => u.Project)
                        //                        .Include(c => c.Units).ThenInclude(p => p.PaymentMoney)
                        //                        .Include(unit => unit.Units).ThenInclude(p => p.Unit).ThenInclude(c=>c.Category)
                        //                        .Include(unit => unit.Units).ThenInclude(p => p.Unit).ThenInclude(Floor => Floor.Floor)
                        //                        .Include(unit => unit.Units).ThenInclude(p => p.FinishUnit).ThenInclude(pay=>pay.PaymentMoney)
                        //                        .Include(f => f.FinishesUnits).ThenInclude(f => f.PaymentMoney)
                        //                        .AsNoTracking().FirstOrDefaultAsync(x => x.GideID == Guid);
                        
                    }
                }
            }

            AllSubjects =  db.Subjects.Include(x => x.Images).AsNoTracking().ToList();
            Contacts =  db.Contant.GetAllNoTracking();
            Galleries =  db.Gallerys.GetAllNoTracking();
        }
    }
}
