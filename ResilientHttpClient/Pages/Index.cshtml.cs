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

        public async Task OnGetAsync([FromServices]UsersClient client)
        {
            Users = await client.GetUsers();
        }
    }
}
