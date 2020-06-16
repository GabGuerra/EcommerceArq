using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceArquitetura.Framework.Data.Base
{
    public class ConexaoBD

    {
        private static MySqlConnection _conexaoPadrao;
        protected MySqlTransaction transaction;

        public ConexaoBD()
        {
            _conexaoPadrao = CriarConexao();
        }

        private MySqlConnection CriarConexao()
        {
            if (_conexaoPadrao == null)
                return new MySqlConnection("Server=localhost;Database=teste;UserId=root;Password=;");
            else
                return _conexaoPadrao;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    transaction = null;
                }
            }
        }

        /// <summary>
        /// Retorna objeto IDataReader, caso haja necessidade de realizar alguma logica antes de passar os valores para o objeto
        /// </summary>
        /// <param name="sql">Instrução SQL</param>
        /// <returns>IDataReader</returns>
        public IDataReader RetornaDataReader(string sql)
        {
            IDataReader dr = null;

            try
            {
                if (_conexaoPadrao.State != ConnectionState.Open)
                    _conexaoPadrao.Open();
                var comando = _conexaoPadrao.CreateCommand();
                comando.CommandText = sql;
                comando.CommandType = CommandType.Text;

                if (transaction != null)
                    comando.Transaction = transaction;

                dr = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("IDataReader ExecuteReader(string sql) : " + ex.Message);
            }

            return dr;
        }

    }
}
