using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResilientHttpClient.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            var apiUrl = "https://jsonplaceholder.typicode.com/users";
            var client = new HttpClient();
            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            
            Users = await response.Content.ReadAsAsync<IEnumerable<User>>();
        }
    }
}
