using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace app_gymManager
{
    public static class conexaoBanco
    {
        private static string connectionString;

        public static SqlConnection OpenConnection()
        {
            string server = "";
            string database = "";
            connectionString = $"Data Source={server};Initial Catalog={database};Integrated Security=True";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return null;
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static string GetRowAsString(string query, string item)
        {
            using (SqlConnection connection = OpenConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        int posicao = query.IndexOf("FROM");
                        if (posicao >= 0)
                        {
                            string parteDepoisDaPalavra = query.Substring(posicao + "FROM".Length);
                            query = "SELECT " + item + " FROM" + parteDepoisDaPalavra;
                        }

                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string result = "";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result += $"{reader.GetValue(i)}";
                            }
                            return result;
                        }
                        else
                        {
                            return "Nenhuma linha encontrada para a consulta fornecida.";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao executar a consulta: {ex.Message}");
                        return null;
                    }
                }
                else
                {
                    return "Não foi possível conectar ao banco de dados.";
                }
            }
        }

        public static DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = OpenConnection())
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar a consulta: {ex.Message}");
            }

            return dataTable;
        }

        public static void Executar(string query)
        {
            using (SqlConnection connection = OpenConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"Consulta executada com sucesso. Linhas afetadas: {rowsAffected}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao executar a consulta: {ex.Message}");
                }
            }
        }
    }
}

