using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IExcuseService
    {

        void Add(Excuse excuse);

        void Delete(Excuse excuse);

        void Update(Excuse excuse);

        Excuse GetById(int excuseId);

        List<ExcuseDetailDto> GetExcuseDetails();

        ExcuseDetailDto GetExcuseDetailsById(int excuseId);

        List<Excuse> GetAll();

    }
}
