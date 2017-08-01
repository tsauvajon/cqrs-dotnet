using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS
{
    /// <summary>
    /// Generic Interface for a repository
    /// </summary>
    /// <typeparam name="T">Type of the repository items</typeparam>
    public interface IBaseRepository<T>
    {
        T GetByID(int id);
        List<T> GetMultiple(List<int> ids);
        bool Exists(int id);
        void Save(T item);
    }
}
