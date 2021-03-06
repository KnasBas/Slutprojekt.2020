﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Slutprojekt._2020
{
    class JokeAPI //denna klass kommer få en utökad funktion
    {
        public int id;
        public string type; //publika parameterar
        public string setup;
        public string punchline;

        private List<string> ValueList = new List<string>();

        public List<string> Joke
        {
            get
            {
                return ValueList;
            }
            set 
            {
                ValueList.Add(id.ToString());
                ValueList.Add(type);
                ValueList.Add(setup);
                ValueList.Add(punchline);
            }
        }
    }
}
