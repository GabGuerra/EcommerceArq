using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceArquitetura.Framework.Data.Base
{
    public class BaseDAO : IDisposable
    {
        private ConexaoBD _conexao;

        public void Dispose()
        {
            Dispose(true);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_conexao != null)
                {
                    _conexao.Dispose();
                    _conexao = null;
                }
            }
        }

        protected ConexaoBD ConexaoBase
        {
            get
            {
                if (_conexao == null)
                    _conexao = new ConexaoBD();
                return _conexao;
            }

        }
    }
}
