using System;
using VehichleApi.Models;

namespace VehichleApi.Interfaces
{
	public interface IVehicle
	{
		// get all vehicles
		Task<List<Vehicle>> GetAllVehicles();

		// get vehicle by id
		Task<Vehicle> GetVehicleById(int Id);

		// add vehicle
		Task AddVehicle(Vehicle vehicle);

		// uodate vehicle
		Task UpdateVehicle(int Id, Vehicle vehicle);

		// delete vehicle
		Task DeleteVehicle(int Id);


	}
}

