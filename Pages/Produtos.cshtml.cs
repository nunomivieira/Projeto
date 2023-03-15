using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;




namespace Projeto.Pages
{
    public class ProdutosModel : PageModel
    {

    public IEnumerable<Lojaonline>? LojaonlineList { get; set; }

        public void OnGet()
        {
            LojaonlineContext context = new LojaonlineContext();
            LojaonlineList = context.getAllSapatilhas();
        }

        private readonly string _connectionString = "server=localhost;port=3306;database=lojaonline;user=root;password=root";

        public IActionResult OnPost()
        {
            int id = int.Parse(Request.Form["id"]);

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "UPDATE sapatilhas SET stock = stock - 1 WHERE id_sapatilhas = @idsapatilhas AND stock > 0";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idsapatilhas", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    TempData["SuccessMessage"] = "Compra efetuada com sucesso!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Este produto está esgotado.";
                }
            }

            return RedirectToPage("Produtos");
        }



    }
}
