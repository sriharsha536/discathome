using System;
using DVDRentalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVDRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController: Controller
    {
        private readonly ICSCService _cscService;

        public StatesController(ICSCService cscService)
        {
            _cscService = cscService ?? throw new ArgumentNullException(nameof(cscService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStates()
        {
            var states = _cscService.GetStates();
            return Ok(states);
        }

        [HttpGet("{stateId}/cities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCities(int stateId)
        {
            var cities = _cscService.GetCities(stateId);
            return Ok(cities);
        }
    }
}
