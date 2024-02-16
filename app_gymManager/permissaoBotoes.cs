using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public static class permissaoBotoes
    {

        public static bool permissao(int idButton)
        {
            string sql = $"SELECT BP.ID, DB.ID AS IDBOTAO, DB.DESCRICAO FROM BOTOESPERMISSOES BP INNER JOIN DINAMICABOTOES DB ON BP.IDBOTAO = DB.ID WHERE BP.IDUSUARIO = '{conexaoBanco.idUser}' AND BP.IDBOTAO = '{idButton}' ORDER BY DB.ID";

                string ID = conexaoBanco.GetRowAsString(sql, "BP.ID");
                if (!string.IsNullOrEmpty(ID))
                {
                    // Se retornar algum valor, significa que há permissão
                    return true;
                }
                else
                {
                MessageBox.Show($"Você não tem permissão para entrar nessa aba:", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                }
        }
    }
}
