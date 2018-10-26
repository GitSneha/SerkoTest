using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerkoTest.Interface;

namespace SerkoTest.Services
{
    public class CalculateGSTService: ICalculateGST
    {

        public CalculateGSTService() { }

        public double CalculateGST(double totalamountwithgst)
        {
            return totalamountwithgst * 3 / 23;
        }

        public double CalculateTotalWithoutGST(double totalamountwithgst)
        {
            return totalamountwithgst / 1.15;
        }


    }
}