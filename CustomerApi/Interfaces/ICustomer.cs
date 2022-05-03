using System;
using CustomerApi.Models;

namespace CustomerApi.Interfaces
{
	public interface ICustomer
	{
		Task AddCustomer(Customer customer);
	}
}

