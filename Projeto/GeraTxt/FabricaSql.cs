using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ManipulaTxt
{
    public abstract class FabricaSql
    {
        /// <summary>Retorna a connection string definida no arquivo Web.config</summary>
        private static string StringConexao
        {
            get { return ConfigurationManager.ConnectionStrings["connection"].ConnectionString; }
        }

        /// <summary>Cria um objeto do tipo <see cref="SqlConnection" />.</summary>
        /// <returns>Retorna o objeto criado.</returns>
        public static SqlConnection NovaConexao()
        {
            return new SqlConnection(StringConexao);
        }

        /// <summary>
        ///     Cria um objeto <see cref="SqlCommand" /> do tipo <see cref="CommandType.Text" />, utilizando a conexão recebida por parâmetro, e
        ///     abre essa conexão."/>
        /// </summary>
        /// <param name="conexao">Objeto do tipo <see cref="SqlConnection" /> que é atribuído na property Connection do novo comando.</param>
        /// <returns>Retorna o objeto <see cref="SqlCommand" /> criado.</returns>
        public static SqlCommand NovoComandoTexto(SqlConnection conexao)
        {
            var comando = new SqlCommand { Connection = conexao, CommandType = CommandType.Text };
            conexao.Open();
            return comando;
        }

        /// <summary>
        ///     Cria um objeto <see cref="SqlCommand" /> do tipo <see cref="CommandType.StoredProcedure" />, utilizando a conexão recebida por
        ///     parâmetro, e abre essa conexão."/>
        /// </summary>
        /// <param name="conexao">Objeto do tipo <see cref="SqlConnection" /> que é atribuído na property Connection do novo comando.</param>
        /// <returns>Retorna o objeto <see cref="SqlCommand" /> criado.</returns>
        public static SqlCommand NovoComandoStoredProcedure(SqlConnection conexao)
        {
            var comando = new SqlCommand { Connection = conexao, CommandType = CommandType.StoredProcedure };
            conexao.Open();
            return comando;
        }

        /// <summary>Carrega um <see cref="DataTable" /> a partir de um <see cref="SqlCommand" />.</summary>
        /// <param name="comando">Objeto a partir do qual o <see cref="DataTable" /> é carregado.</param>
        /// <returns>Retorna o novo <see cref="DataTable" />.</returns>
        public static DataTable GeraDataTable(SqlCommand comando)
        {
            var dataTable = new DataTable();
            SqlDataReader reader = comando.ExecuteReader();
            dataTable.Load(reader);
            return dataTable;
        }
    }
}
