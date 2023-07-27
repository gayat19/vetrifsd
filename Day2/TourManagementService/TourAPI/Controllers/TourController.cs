using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourAPI.Interfaces;
using TourAPI.Models;

namespace TourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [ProducesResponseType(typeof(IEnumerable<Tour>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Tour>> Get(string name)
        {
            var data = _tourService.GetTourByName(name);
            if(data == null)
            {
                return NotFound("No tour with that name");
            }
            return Ok(data);
        }

        [ProducesResponseType(typeof(Tour), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Tour> AddTour(Tour tour)
        {
            var result = _tourService.AddNewTour(tour);
            if(result == null)
            {
                return BadRequest("Unable to add tour at this moment");
            }
            return Created("", tour);
        }
    }
}
