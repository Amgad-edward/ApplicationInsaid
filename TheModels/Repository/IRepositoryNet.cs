using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheModels.Models;

namespace TheModels.Repository
{
    public interface IRepositoryNet<T> 
    {
       
        Task AddImage<Timage>(Timage entity, byte[] FileImage,string Apiurl) where Timage : Gallery;

        Task AddSubject(T entity);

    }
}
