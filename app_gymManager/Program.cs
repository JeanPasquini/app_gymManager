using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            using (SqlConnection connection = conexaoBanco.OpenConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Conexão estabelecida com sucesso!");
                    // Execute as operações no banco de dados aqui
                }
                else
                {
                    Console.WriteLine("Falha ao conectar ao banco de dados.");
                }
            }
        }
    }
}
