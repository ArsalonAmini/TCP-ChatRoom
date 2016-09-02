using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//this is a facade Design pattern 
//devCodeCamp 9/2/2016
//A.Amini-Hajibashi

namespace Server
{
    class Client
    {

        private string _name;
        private double _port;

        public string Name
        {
            get { return _name; }
        }
        public double Port
        {
            get { return _port; }
        }
        public Client(string name)
        {
            this._name = name;
            this._port = 10000;
        }

    
    }
}
