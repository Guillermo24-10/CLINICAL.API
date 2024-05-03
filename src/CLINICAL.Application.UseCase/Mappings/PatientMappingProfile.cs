using AutoMapper;
using CLINICAL.Application.DTOS.Patient.Response;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();
        }
    }
}
