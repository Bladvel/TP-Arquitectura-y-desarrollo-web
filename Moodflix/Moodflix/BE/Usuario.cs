﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BE
{
    public class Usuario: IEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Username { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
