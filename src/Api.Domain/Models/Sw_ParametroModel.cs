using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Sw_ParametroModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _chave;
        public string Chave
        {
            get { return _chave; }
            set { _chave = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        private string _valor;
        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        private int _valorInt;
        public int ValorInt
        {
            get { return _valorInt; }
            set { _valorInt = value; }
        }
        
        private string _filial;
        public string Filial
        {
            get { return _filial; }
            set { _filial = value; }
        }
        private int _usuario;
        public int Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        
        
        
    }
}