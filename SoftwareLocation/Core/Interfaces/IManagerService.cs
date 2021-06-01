using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IManagerService
    {
        void Add(Manager manager);
        void Delete(Manager manager);

        void Update(Manager manager);

        Manager GetById(int managerId);

        List<Manager> GetAll();

    }
}
