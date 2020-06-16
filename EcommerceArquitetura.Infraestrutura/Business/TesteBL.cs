using EcommerceArquitetura.Infraestrutura.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceArquitetura.Infraestrutura.Business
{
    public class TesteBL : IDisposable
    {      
        private TesteDAO _dao;

        public TesteBL()
        {
            _dao = new TesteDAO();
        }

        public void Dispose()
        {
            if (_dao != null)
            {
                _dao.Dispose();
                _dao = null;
            }
        }

        public string Teste()
        {
            var teste = "";
            using (var dr = _dao.Teste())
            {
                try
                {
                    while (dr.Read())
                    {
                        teste = dr["nom_usuario"].ToString();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally 
                {
                    dr.Close();
                }
            }

            return teste;
        }
    }
}
