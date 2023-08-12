using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Models.DTOs;

namespace TourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTourController : ControllerBase
    {
        private ICustomerTourService _tourService;

        public CustomerTourController(ICustomerTourService tourService)
        {
            _tourService = tourService;
        }

        [ProducesResponseType(typeof(IEnumerable<Tour>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> Get(string name)
        {
            var data = await _tourService.GetTourByName(name);
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
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours(int min, int max)
        {
            var data = await _tourService.GetTourWithinRange(min, max);
            
            return data!=null?Ok(data):NotFound("No tour with that name");
        }
       
    }
}
