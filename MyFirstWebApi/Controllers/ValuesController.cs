using System;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
       // GET: api/<controller>
        [HttpGet]
        [Produces(("application/dan+json"))]
        public IEnumerable<Value> Get()
        {
            return new Value[] { new Value{ Id = 1, Text ="value1"},  new Value {Id = 2, Text = "value2" }};
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, string query)
        {
            return Ok(new Value { Id = id, Text = "value" + id });
        }

        // POST api/<controller>
        [HttpPost]
        [Produces("application/json",Type = typeof(Value))]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //save the value to the DB
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        public class Value
        {
            public int Id { get; set; }
            [Required]
            [MinLength(3)]
            public string Text { get; set; }
        }
    }
}
