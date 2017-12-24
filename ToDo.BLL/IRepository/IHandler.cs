using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.BLL.IRepository {
    interface IHandler<T> {
        void Add(T m);
        void Update(T m, int id);
        void Delete(T m);

        T GetById(int id);
        ICollection<T> GetAll();

        void Save();
    }
}
