using homecoming.api.Abstraction;
using homecoming.api.Model;
using homecoming.api.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace homecoming.api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccomodationController : Controller
    {

        IDataStore<Accomodation> repo;
        IWebHostEnvironment web;
        HomecomingDbContext db;
        public AccomodationController(IWebHostEnvironment host, HomecomingDbContext cx)
        {
            web = host;
            db = cx;
            repo = new AccomodationRepo(web, db);
        }


        [HttpGet]
        public IActionResult GetAllAccomodations()
        {
            return Ok(repo.FindAll());
        }

        [HttpPost]
        public IActionResult AddAccomodation([FromForm] Accomodation accomodation)
        {
            if(accomodation != null)
            {
                repo.Add(accomodation);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + accomodation.AccomodationId, accomodation);
            }

            return BadRequest("Room could not be saved!");
        }
        [HttpGet("{id}")]
        public IActionResult GetAccomodation(int id)
        {
            Accomodation accomodation = repo.GetById(id);
            if(accomodation != null)
            {
                return Ok(accomodation);
            }
            else
            {
                return BadRequest("Accomodation with id: "+ id + " Not Found");
            }
        }

    }
}
