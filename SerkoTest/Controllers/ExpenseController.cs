using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SerkoTest.Interface;
using SerkoTest.Models;

namespace SerkoTest.Controllers
{
    public class ExpenseController : ApiController
    {

        private ICalculateGST _calculationService;
        private IExtractData _extractDataService;

        public ExpenseController() { }

        public ExpenseController(IExtractData extractDataService, ICalculateGST calculationService) {
            this._calculationService = calculationService;
            this._extractDataService = extractDataService;
        }
   
        [HttpGet]
        [Route("api/calculateexpense")]
        public string CalculateExpense(string textExtractedFromEmail = "")
        {
            try
            {
                if (textExtractedFromEmail != "" && textExtractedFromEmail != null)
                {
                    //RemoveEmailAddress from msg
                    string processedMsg = _extractDataService.RemoveEmailAddress(textExtractedFromEmail);

                    ////Format and Load msg
                    var xmlDoc = new System.Xml.XmlDocument();                    
                    xmlDoc.LoadXml("<EmailContent>" + processedMsg + "</EmailContent>");

                                     
                    //Extract required information from xml msg 
                    ExpenseData ed =  _extractDataService.ExtractXMLIslands(xmlDoc);

                    //calculate GST
                    double total = System.Convert.ToDouble(ed.totalwithgst);
                    ed.gst = _calculationService.CalculateGST(total);
                    ed.totalwithoutgst = _calculationService.CalculateTotalWithoutGST(total);

                    return JsonConvert.SerializeObject(ed);
                }
            }
            catch (Exception e)
            {
                return e.Message + " Cannot extract the required field. Message is rejected.";
            }
            return "Email extracted data is empty.";
        }
    }
}
