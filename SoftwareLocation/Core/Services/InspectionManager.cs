using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class InspectionManager : IInspectionService
    {
        IInspectionDal _inspectionDal;

        public InspectionManager(IInspectionDal inspectionDal)
        {
            _inspectionDal = inspectionDal;
        }

        public void Add(Inspection inspection)
        {
            _inspectionDal.Add(inspection);
        }

        public void Delete(Inspection inspection)
        {
            _inspectionDal.Delete(inspection);
        }

        public List<Inspection> GetAll()
        {
            var result = _inspectionDal.GetAll();
            return result;
        }

        public Inspection GetById(int inspectionId)
        {
            var result = _inspectionDal.Get(i => i.InspectionID == inspectionId);
            return result;
        }

        public List<InspectionDetailDto> GetInspectionDetails()
        {
            var result = _inspectionDal.GetInspectionDetails();
            return result;
        }

        public void Update(Inspection inspection)
        {
            _inspectionDal.Update(inspection);
        }
    }
}
