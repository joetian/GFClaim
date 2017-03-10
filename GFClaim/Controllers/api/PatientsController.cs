using AutoMapper;
using GFClaim.DTO;
using GFClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GFClaim.Controllers.api
{
    public class PatientsController : ApiController
    {
        ApplicationDbContext context;
        public PatientsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        //GET api/patients
        public IHttpActionResult GetPatients()
        {
            /*
            IEnumerable<Patient> patients = context.Patients.ToList();
            IEnumerable<PatientDto> patientDtos = new List<PatientDto>();
            Mapper.Map(patients, patientDtos);
            return Ok(patientDtos); */
            return Ok(context.Patients.ToList().Select(Mapper.Map<Patient, PatientDto>));
        }

        public IHttpActionResult GetPatient(int id)
        {
            var patientInDb = context.Patients.SingleOrDefault(p => p.Id == id);
            if (patientInDb == null)
                return NotFound();
            PatientDto patientDto = Mapper.Map<Patient, PatientDto>(patientInDb);
            return Ok(patientDto);
        }

        // 在postMon里，http://localhost:50993/api/patients/whatever 也会忽略whatever做参数，而是用BODY的JSON给patientDto赋值
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Patient patient = Mapper.Map<Patient>(patientDto);
            context.Patients.Add(patient);
            context.SaveChanges();
            patientDto.Id = patient.Id;
            Uri uri = new Uri(Request.RequestUri + "/" + patient.Id);
            return Created(uri, patientDto);
        }

        // POSTMON : http://localhost:50993/api/patients/6  body里贴JSON数据, 模式选择PUT
        [HttpPut]
        public IHttpActionResult UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var patient = context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();

            Mapper.Map<PatientDto, Patient>(patientDto, patient);
            context.SaveChanges();

            return Ok(patientDto);
        }

        //POSTMON : http://localhost:50993/api/patients/9 模式选择DELETE
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            var patient = context.Patients.SingleOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();
            context.Patients.Remove(patient);
            context.SaveChanges();
            return Ok(patient);
        }
    }
}
