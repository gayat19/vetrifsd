using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Models.DTOs;
using TourAPI.Services;

namespace TourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentTourController : ControllerBase
    {
        private readonly IAgentTourService _tourService;

        public AgentTourController(IAgentTourService tourService)
        {
            _tourService = tourService;
        }
        [ProducesResponseType(typeof(Tour), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Tour>> AddTour(Tour tour)
        {
            var result = await _tourService.AddNewTour(tour);
            if (result == null)
            {
                return BadRequest("Unable to add tour at this moment");
            }
            return Created("", tour);
        }
        [ProducesResponseType(typeof(Tour), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<Tour>> EditTour(TourPriceUpdateDTO tour)
        {
            var result = await _tourService.UpdatePrice(tour);
            if (result == null)
            {
                return BadRequest("Unable to add tour at this moment");
            }
            return Created("", tour);
        }
    }
}
