using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace Projeto.Pages
{
    public class FormularioContext : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(Formulario formulario)
        {
            string connectionString = "server=localhost;port=3306;database=lojaonline;user=root;password=root";
            string query = "INSERT INTO formulario (nome, apelido, tamanho, marca, modelo, email) VALUES (@Nome, @Apelido, @Tamanho, @Marca, @Modelo, @Email)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Nome", formulario.Nome);
                cmd.Parameters.AddWithValue("@Apelido", formulario.Apelido);
                cmd.Parameters.AddWithValue("@Tamanho", formulario.Tamanho);
                cmd.Parameters.AddWithValue("@Marca", formulario.Marca);
                cmd.Parameters.AddWithValue("@Modelo", formulario.Modelo);
                cmd.Parameters.AddWithValue("@Email", formulario.Email);

                cmd.ExecuteNonQuery();
            }

            return RedirectToPage("/Index");
        }
    }
}

