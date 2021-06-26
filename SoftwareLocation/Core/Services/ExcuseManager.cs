using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class ExcuseManager : IExcuseService
    {

        IExcuseDal _excuseDal;

        public ExcuseManager(IExcuseDal excuseDal)
        {
            _excuseDal = excuseDal;
        }


        public void Add(Excuse excuse)
        {
            _excuseDal.Add(excuse);
        }

        public void Delete(Excuse excuse)
        {
            _excuseDal.Delete(excuse);

        }

        public List<Excuse> GetAll()
        {
            return _excuseDal.GetAll();

        }

        public Excuse GetById(int excuseId)
        {
            return _excuseDal.Get(e => e.ExcuseId == excuseId);

        }

        public List<ExcuseDetailDto> GetExcuseDetails()
        {
           return _excuseDal.GetExcuseDetails();
        }

        public void Update(Excuse excuse)
        {
            _excuseDal.Update(excuse);
        }
    }
}
