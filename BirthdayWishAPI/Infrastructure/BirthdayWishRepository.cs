using BirthdayWishAPI.APIClient;
using BirthdayWishAPI.Infrastructure.Messaging;
using BirthdayWishAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.Infrastructure
{
		public class BirthdayWishRepository : IBirthdayWishRepository
		{
				private readonly IApiClient  _apiClient;

				

				public BirthdayWishRepository(IApiClient apiClient)
				{
						_apiClient = apiClient;
				}
				public async Task<EmployeesModel> GetAllEmployees()
				{

						var employees = await _apiClient.GetTAsync<Employee>("https://interview-assessment-1.realmdigital.co.za/employees");
						return new EmployeesModel(employees);
				}
		}
}