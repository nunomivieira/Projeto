using MySql.Data.MySqlClient;
using System.Data;

namespace Projeto.Models
{
    public class LojaonlineContext
    {
        private string ConnectionString { get; set; }
        public LojaonlineContext()
        {
            ConnectionString = "server=localhost;port=3306;database=lojaonline;user=root;password=root";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Lojaonline> getAllSapatilhas()
        {
            //Lista para guardar todas a loja existentes na base de dados
            List<Lojaonline> lista = new List<Lojaonline>();
            using (MySqlConnection conn = GetConnection())
            {
                //Abrimos uma coneção com a base de dados
                conn.Open();
                // Criamos uma query onde vamos pedir todas as sapatilhas
                MySqlCommand query = new MySqlCommand("SELECT * FROM sapatilhas", conn);
                //Percorrer um a um resultado da query (pesquisa).
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Mapear os dados que vêm da base de dados com os da classe
                        //Atenção que os nomes têm que ser iguais aos da tabela na base de dados
                        lista.Add(new Lojaonline()
                        {
                            idsapatilhas = reader.GetInt32("id_sapatilhas"),
                            marca = reader.GetString("marca"),
                            tamanho = reader.GetInt32("tamanho"),
                            genero = reader.GetString("genero"),
                            preco = reader.GetDouble("preco"),
                            stock = reader.GetInt32("stock"),
                            descricao = reader.GetString("descricao"),
                            foto = reader["foto"] == DBNull.Value ? null : (Byte[])reader["foto"]
                        });
                        Console.WriteLine(reader.GetInt32("id_sapatilhas"));
                    }
                }
                return lista;
            }
        }

    }
}
