﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemoAPI.DAL;
using DapperDemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private IConfiguration _configuration;
        //private CustomerRepository _ourCustomerRepository;
        private ICustomerRepository _ourCustomerRepository;

        public CustomerController(IConfiguration configuration)
        {
            //_configuration = configuration;
            _ourCustomerRepository = new CustomerRepository(configuration.GetSection("DefaultConnection").Value);
            //_ourCustomerRepository = customerRepository;
        }

        // GET: api/Customer
        [Route("Customers/{amount}/{sort}")]
        [HttpGet]
        public IEnumerable<Customer> Get(int amount, string sort)
        {
            return _ourCustomerRepository.GetCustomers(amount, sort);
        }

        // GET: api/Customer/5
        [HttpGet("Customers/{id}")]
        public Customer Get(int id)
        {
            return _ourCustomerRepository.GetSingleCustomer(id);
        }

        // POST: api/Customer/Customers
        [Route("Customers")]
        [HttpPost]
        public bool Post([FromBody] Customer ourCustomer)
        {
            var result = _ourCustomerRepository.MapCustomer(ourCustomer);
            var student = new Student { Age = 17, StuName = "Yi", Subject = "Wuli" };
            var result_I = _ourCustomerRepository.MapCustomerI(student);
            return _ourCustomerRepository.InsertCustomer(ourCustomer);
        }

        // PUT: api/Customer/5
        [HttpPut("Customers")]
        public bool Put([FromBody] Customer ourCustomer)
        {
            return _ourCustomerRepository.UpdateCustomer(ourCustomer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Customers/{id}")]
        public bool Delete(int id)
        {
            return _ourCustomerRepository.DeleteCustomer(id);
        }
    }
}
