using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SerkoTest.Models;

namespace SerkoTest.Interface
{
    public interface IExtractData
    {
        string RemoveEmailAddress(string msg);

        ExpenseData ExtractXMLIslands(XmlDocument xmlDoc);        
    }
}
