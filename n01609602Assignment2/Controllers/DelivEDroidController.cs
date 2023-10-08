using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01609602Assignment2.Controllers
{
    public class DelivEDroidController : ApiController
    {
        /// <summary>
        /// A Simple Get api to calculate the final score of the Deliv-e-Driod game.
        /// </summary>
        /// <param name="numberOfPackagesDelivered">The total number of packages delivered</param>
        /// <param name="numberOfObstacle">the total number of obstacles hit</param>
        /// <returns>
        /// GET api/calculateFinalScore/5/2 --> 730
        /// GET api/calculateFinalScore/0/10 --> -100
        /// GET api/calculateFinalScore/6/5 --> 750
        /// GET api/calculateFinalScore/5/5 --> 200
        /// </returns>
        [Route("api/calculateFinalScore/{numberOfPackagesDelivered}/{numberOfObstacle}")]
        [HttpGet]
        public int calculateFinalScore(int numberOfPackagesDelivered, int numberOfObstacle)
        {
            // declare all variables here
            int bonusPoints = 0;
            int totalPackageDeliveryCost = numberOfPackagesDelivered * 50;
            int totalObstacleCost = numberOfObstacle * 10;

            // check if the number of package is greater than number of obstacle
            if (numberOfPackagesDelivered > numberOfObstacle)
            {
                bonusPoints += 500;
            }

            // calculate final score by subtracting totalPackageDeliveryCost with totalObstacleCost and adding bonus points
            int finalScore = totalPackageDeliveryCost - totalObstacleCost + bonusPoints;
            return finalScore;
        }
    }
}
