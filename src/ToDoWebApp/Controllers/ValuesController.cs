﻿using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace ToDoWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Bradley", "Rausch" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return id += 1;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}