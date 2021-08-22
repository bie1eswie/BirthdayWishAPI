using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI.APIClient
{
		public interface IApiClient
		{
				//get a list of items from any endpoint
				Task<List<T>> GetTAsync<T>(string requestUrl);
		}
}
