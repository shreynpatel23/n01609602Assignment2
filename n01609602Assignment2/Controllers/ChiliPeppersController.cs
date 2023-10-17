using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01609602Assignment2.Controllers
{
    public class ChiliPeppersController : ApiController
    {
        /// <summary>
        /// We have to write to an API to calculate the total spiceness count based on the spices on it's SHU Value. 
        /// It consist of two parameteres .
        ///     1. Total Number of spices added by Ron
        ///     2. Spices list.
        /// we have to return the total spice count added by Ron
        /// </summary>
        /// <param name="totalNumberOfSpices">total number of spices added by Ron</param>
        /// <param name="spicesList">spices list added by Ron</param>
        /// <returns>
        /// GET --> /api/chiliPeppers/4?spicesList=Poblano&spicesList=Cayenne&spicesList=Thai&spicesList=Poblano --> 118000
        /// GET --> /api/chiliPeppers/2?spicesList=Poblano&spicesList=Poblano --> 3000
        /// GET --> /api/chiliPeppers/3?spicesList=cayenne&spicesList=cayenne&spicesList=cayenne --> 120000
        /// GET --> /api/chiliPeppers/1?spicesList=habanero --> 125000
        /// GET --> /api/chiliPeppers/0?spicesList=habanero --> 0 (This is an edge case)
        /// </returns>
        [Route("api/chiliPeppers/{totalNumberOfSpices}")]
        [HttpGet]
        public int CalculateTotalSpiceCount(int totalNumberOfSpices, [FromUri] string[] spicesList)
        {
            // declare all the variables here
            int totalSpicinessCount = 0;

            // check if the total number of spices added is not equal to spices list array length
            // retun 0 because of invalid input.
            if (totalNumberOfSpices != spicesList.Length)
            {
                return 0;
            }

            // loop through the spices list and use a switch case to calculate the totalSpicinessCount.
            for (int i = 0; i < spicesList.Length; i++)
            {
                // switch case to identify the right spice type
                switch (spicesList[i].ToLower())
                {
                    case "poblano":
                        totalSpicinessCount += 1500;
                        break;
                    case "mirasol":
                        totalSpicinessCount += 6000;
                        break;
                    case "serrano":
                        totalSpicinessCount += 15500;
                        break;
                    case "cayenne":
                        totalSpicinessCount += 40000;
                        break;
                    case "thai":
                        totalSpicinessCount += 75000;
                        break;
                    case "habanero":
                        totalSpicinessCount += 125000;
                        break;
                    default:
                        totalSpicinessCount += 0;
                        break;
                }
            }

            // return the totalSpicinessCount
            return totalSpicinessCount;
        }
    }
}
