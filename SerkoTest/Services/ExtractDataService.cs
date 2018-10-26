using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using SerkoTest.Interface;
using SerkoTest.Models;
using Newtonsoft.Json;

namespace SerkoTest.Services
{
    public class ExtractDataService : IExtractData
    {

        public ExtractDataService() { }

        public string RemoveEmailAddress(string msg) {

            //extract email address in the message if any
            string emailAddressPattern = @"[A-Za-z0-9]+\.+[A-Za-z0-9]+[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            string textWithoutEmailAddress = Regex.Replace(msg, emailAddressPattern, "");

            string bracketPattern = @"(<>)";
            string textWithoutEmptyBrackets = Regex.Replace(textWithoutEmailAddress, bracketPattern, "");

            return textWithoutEmptyBrackets;
        }

        public ExpenseData ExtractXMLIslands(XmlDocument xmlDoc) {

            //Check for Total node
            if (xmlDoc.SelectSingleNode("//total") == null)
            {
                throw new InvalidOperationException("xmlnode total is missing.");
            }
            
            //Assign model properties
            ExpenseData ed = new ExpenseData();
            if (xmlDoc.SelectSingleNode("//cost_centre") != null) { ed.costcenter = xmlDoc.SelectSingleNode("//cost_centre").InnerText; }
            
            ed.paymentmenthod = xmlDoc.SelectSingleNode("//payment_method").InnerText; ;
            ed.description = xmlDoc.SelectSingleNode("//description").InnerText; ;
            ed.vendor = xmlDoc.SelectSingleNode("//vendor").InnerText; ;
            ed.date = xmlDoc.SelectSingleNode("//date").InnerText;
            ed.totalwithgst = xmlDoc.SelectSingleNode("//total").InnerText;               

            return ed; 
        }
    }
}