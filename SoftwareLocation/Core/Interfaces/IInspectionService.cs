using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IInspectionService
    {
        void Add(Inspection inspection);

        void Delete(Inspection inspection);

        void Update(Inspection inspection);

        Inspection GetById(int inspectionId);

        List<Inspection> GetAll();

        List<InspectionDetailDto> GetInspectionDetails();

        bool CheckTheLocation(string parallel, string meridian, int employeeId);
    }
}
