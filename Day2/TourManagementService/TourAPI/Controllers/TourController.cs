using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Models.DTOs;

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

        /// <summary>
        /// Gets tours within the given min and max value
        /// </summary>
        /// <param name="min">int that represents minimum price</param>
        /// <param name="max">int that represents maximum price</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<Tour>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetToursInRange")]
        public ActionResult<IEnumerable<Tour>> GetTours(int min, int max)
        {
            var data = _tourService.GetTourWithinRange(min, max);
            
            return data!=null?Ok(data):NotFound("No tour with that name");
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
