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
        /// We have to write to an API to calculate the final score scored in a Delivery app. It consist of two
        /// parameteres .
        ///     1. Number of packages delivered
        ///     2. Number of Obstacles occured.
        /// we have to return the final score based on the number of packages delivered and number of obstacles
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
        public int CalculateFinalScore(int numberOfPackagesDelivered, int numberOfObstacle)
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

            // return the final score
            return finalScore;
        }
    }
}
