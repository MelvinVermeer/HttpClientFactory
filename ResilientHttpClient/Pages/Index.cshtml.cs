using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

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
