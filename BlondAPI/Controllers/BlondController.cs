using BlondAPI.Models;
using BlondAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlondAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlondController : ControllerBase
    {
        private readonly BlondService _service;

        public BlondController(BlondService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ViewModelBlond>> Get() => _service.Get();

        [HttpGet("{id}")]
        public ActionResult<ViewModelBlond> GetById(string id) => _service.GetById(id);

        [HttpPost]
        public ActionResult Create(ViewModelBlond blond)
        {
            _service.Create(blond);
            return CreatedAtRoute("", new
            {
                id = blond.Id
            }, blond);
        }
        [HttpPut("{id}")]
        public ActionResult Update(string id, ViewModelBlond blond)
        {
            var entities = _service.GetById(id);
            if (entities == null)
                NotFound();
            _service.Update(id, blond);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteById(string id)
        {
            var entities = _service.GetById(id);
            if (entities == null)
                NotFound();
            _service.DeleteById(id);
            return Ok();
        }

    }
}
