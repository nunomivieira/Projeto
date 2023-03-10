using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto.Models;
using MySql.Data.MySqlClient;

namespace Projeto.Pages
{
    public class ProdutosModel : PageModel
    {

    public IEnumerable<Lojaonline> LojaonlineList { get; set; }

        public void OnGet()
        {
            LojaonlineContext context = new LojaonlineContext();
            LojaonlineList = context.getAllSapatilhas();
        }
    }
}
