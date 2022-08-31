using Microsoft.AspNetCore.Mvc;
using ProjetoBase1.Data;
using ProjetoBase1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoBase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProjectsController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<Projects> Get()
        {
            return _context.Projects;
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        /*public string Get(int id)
        {
            return _context.Projects.FirstOrDefault()
        }*/

        // POST api/<ValuesController1>
        [HttpPost]
        public ActionResult Post(Projects project)
        {
            try
            {
                _context.Projects.Add(project); 
                _context.SaveChanges();
                return Ok(project);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
