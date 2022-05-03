using System;
using Azure.Messaging.ServiceBus;
using CustomerApi.Data;
using CustomerApi.Interfaces;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomerApi.Services
{
	public class CustomerService : ICustomer
	{
		
        private ApiDbContext dbContext;

        public CustomerService()
        {
            dbContext = new ApiDbContext();
        }

        public async Task AddCustomer(Customer customer)
        {
            var vehicleInDb = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == customer.VehicleId);
            if (vehicleInDb == null)
            {
                await dbContext.Vehicles.AddAsync(customer.Vehicle);
                await dbContext.SaveChangesAsync();
            }
            customer.Vehicle = null;
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            // azure service bus
            string connectionString = "Endpoint=sb://vehicleapi.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HwcqUvEqqCKHRIAr/Kg69vEJ+MQMoTj8ZZ6LtPdwASE=";
            string queueName = "azureorderqueue";
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            var objectAsText = JsonConvert.SerializeObject(customer);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(objectAsText);

            // send the message
            await sender.SendMessageAsync(message);
        }
}
}

