using System;
using System.Collections.Generic;
using blockbuster_api.Models;
using blockbuster_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace blockbuster_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly VideosService _vs;
        // NOTE Dependency Injection
        public VideosController(VideosService vs)
        {
            _vs = vs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> Get()
        {
            try
            {
                return Ok(_vs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Video> Get(int id)
        {
            try
            {
                return Ok(_vs.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<Video> Create([FromBody] Video newVideo)
        {
            try
            {
                return Ok(_vs.Create(newVideo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Video> Edit(int id, [FromBody] Video updatedVideo)
        {
            try
            {
                updatedVideo.Id = id;
                return Ok(_vs.Edit(updatedVideo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_vs.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}