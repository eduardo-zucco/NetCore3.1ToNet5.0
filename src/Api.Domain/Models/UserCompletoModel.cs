using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class UserCompletoModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _uf;
        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }

        private string _municipio;
        public string Municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
        }
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }


    }
}