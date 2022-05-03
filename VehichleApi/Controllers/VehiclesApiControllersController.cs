using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehichleApi.Interfaces;
using VehichleApi.Models;

// NuGet packages
// Microsoft.EntityFrameworkCore
// Microsoft.EntityFrameworkCore.SqlServer
// Microsoft.EntityFrameworkCore.Tools

namespace VehichleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicle _vehicleService;
        // get interface

        // inject interface in this structure
        public VehiclesController(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/VehiclesApiControllers
        // currently returnign a listof strings
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            // get all vehicle methods
            // need to use Task
            return vehicles;
        }

        // GET: api/VehiclesApiControllers/5
        // again string so need to change to a vehicle
        [HttpGet("{id}", Name = "Get")]
        public async Task<Vehicle> Get(int id)
        {
            return await _vehicleService.GetVehicleById(id);
        }

        // POST: api/VehiclesApiControllers
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleService.AddVehicle(vehicle);
        }

        // PUT: api/VehiclesApiControllers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {

            await _vehicleService.UpdateVehicle(id, vehicle);
        }

        // DELETE: api/VehiclesApiControllers/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}
