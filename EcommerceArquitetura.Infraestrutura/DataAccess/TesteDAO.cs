using EcommerceArquitetura.Framework.Data.Base;
using EcommerceArquitetura.Framework.Data.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceArquitetura.Infraestrutura.DataAccess
{
    public class TesteDAO: BaseDAO
    {
        public IDataReader Teste() 
        {
            ListaParametros lp = new ListaParametros();
            lp.Sql = "SELECT * FROM USUARIO";

            return ConexaoBase.RetornaDataReader(lp.Sql);
        }
    }
}
