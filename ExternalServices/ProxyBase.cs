using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices
{
	public class ProxyBase
	{
		/// <summary>
		/// Method for sending get request via HttpClient.
		/// </summary>
		/// <param name="requestUrl">Url for sending request.</param>
		/// <returns>Response as a string</returns>
		internal static async Task<string> GetAsync(string requestUrl)
		{
			using var client = new HttpClient();

			var response = await client.GetAsync(requestUrl);

			return await response.Content.ReadAsStringAsync();
		}
	}
}
