﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övningsuppgift_Lektion_3_OOADLib.Services
{
    interface IPasswordService
    {
        string HashPassword(string password);

        bool ValidatePassword(string password, string correctHash);

        bool SlowEquals(byte[] a, byte[] b);

        byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes);

    }
}
