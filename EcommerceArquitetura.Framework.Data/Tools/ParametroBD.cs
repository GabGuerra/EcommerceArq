using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceArquitetura.Framework.Data.Tools
{
    public sealed class ParametroBD
    {
        /// <summary>
        /// nome do parametro
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Valor do parametro que está sendo passado
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Tipo do parametro, imput, output, value...
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// Tipo do parametro, caso seja de output por padrão as procedures criadas estão retornando Cursor
        /// </summary>
        public Types Type { get; set; }

        public ParametroBD() { }

        public ParametroBD(string parametroName, object value, Types type)
        {
            ParameterName = parametroName;
            Value = value;
            Type = type;
            Direction = ParameterDirection.Input;
        }

        public ParametroBD(string parametroName, Types type, ParameterDirection direction)
        {
            ParameterName = parametroName;
            Type = type;
            Direction = direction;
        }

        public ParametroBD(string parametroName, object value, Types type, ParameterDirection direction)
        {
            ParameterName = parametroName;
            Value = value;
            Type = type;
            Direction = direction;
        }

    }

    public sealed class ListaParametros
    {
        /// <summary>
        /// Comando Sql ou o Nome da Procedure a ser executada
        /// </summary>
        public string Sql { get; set; }
        public List<ParametroBD> Param { get; set; }
        public CommandType CommandType { get; set; }

        public ListaParametros()
        {
            if (Param == null) Param = new List<ParametroBD>();
            CommandType = CommandType.Text;
        }
    }

    public enum Types : int
    {
        Number = 1,
        Date = 4,
        Decimal = 6,
        Varchar = 9,
        RefCursor = 121,
        Blob = 102,
        Array = 128
    }
}
