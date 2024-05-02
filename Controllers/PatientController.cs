
using HealthCareWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace HealthCareWebApi.Controllers
{
    public class PatientController : ApiController
    {
       
       Entities db = new Entities();


        [HttpPost]
        public string Post(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return "Patient is added";
            
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return db.Patients.ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public Patient GetById(int id)
        {
            return db.Patients.Find(id);
        }

        [HttpPut]
        [Route("{id}")]
        public string Put(int id,Patient patient)
        {
            var patient2 = db.Patients.Find(id);
            patient2.Name= patient.Name; 
            patient2.Surname= patient.Surname;
            patient2.DateOfBirth=patient.DateOfBirth;
            patient2.PhoneNumber= patient.PhoneNumber;
            db.Entry(patient2).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Patient is updated";

        }

        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            Patient patient = db.Patients.Find( id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return "Patient is deleted";
        }

       
    }
}
