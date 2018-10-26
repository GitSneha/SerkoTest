using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerkoTest.Interface
{
    public interface ICalculateGST
    {
        double CalculateGST(double totalamountwithgst);

        double CalculateTotalWithoutGST(double totalamountwithgst);       

    }

}