using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public void Add(Manager manager)
        {
            _managerDal.Add(manager);
        }

        public void Delete(Manager manager)
        {
            _managerDal.Delete(manager);
        }

        public List<Manager> GetAll()
        {
            return _managerDal.GetAll();
        }

        public Manager GetById(int managerId)
        {
            return _managerDal.Get(m => m.ManagerID == managerId);
        }

        public void Update(Manager manager)
        {
            _managerDal.Update(manager);
        }
    }
}
