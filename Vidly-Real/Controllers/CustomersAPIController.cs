using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly_Real.Data_Transfer_Objects;
using Vidly_Real.Models;

namespace Vidly_Real.Controllers
{
    public class CustomersAPIController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersAPIController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET /api/customersAPI
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }
        //GET /api/customersAPI/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int? Id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id ==Id);
            if (customer == null) return NotFound();
            return Ok(Mapper.Map < Customer,CustomerDTO >(customer));
        }

        //POST /api/customersAPI
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDTO);
        }
        //PUT /api/customersAPI/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDTO customerDTO)
        { 
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if(customerInDb == null ) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDb);
            customerInDb.Name = customerDTO.Name;
            customerInDb.BirthDate = customerDTO.BirthDate;
            customerInDb.IsSubscirbedToNewsLetter = customerDTO.IsSubscirbedToNewsLetter;
            customerInDb.MembershipTypeId = customerDTO.MembershipTypeId;
            _context.SaveChanges();
        }
        //delete /api/customersAPI
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
