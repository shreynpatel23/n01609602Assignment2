using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace n01609602Assignment2.Controllers
{
    public class SpecialEventController : ApiController
    {
        /// <summary>
        /// We have to write to an API to organise a special event. It consist of two
        /// parameteres .
        ///     1. total number of people
        ///     2. list of availabilty of each person (1 means available, and 0 means not available)
        /// we have to return the list of days on which maximum number of people are available.
        /// </summary>
        /// <param name="totalNumberOfPeople">total number of people interested for the special event </param>
        /// <param name="availabilityList">list of availability of each person</param>
        /// <returns>
        /// GET api/specialEvent/3?availabilityList=11010&availabilityList=00010&availabilityList=01110 --> [4]
        /// GET api/specialEvent/5?availabilityList=11001&availabilityList=01101&availabilityList=01010&availabilityList=01101&availabilityList=10001 --> [2,5]
        /// GET api/specialEvent/2?availabilityList=11001&availabilityList=01101&availabilityList=01010&availabilityList=01101&availabilityList=10001 --> [0]
        /// </returns>
        [Route("api/specialEvent/{totalNumberOfPeople}")]
        [HttpGet]
        public List<int> OrganiseSpecialEvent(int totalNumberOfPeople, [FromUri] string[] availabilityList)
        {
            // declare all the variables here
            List<int> availabilityCountArray = new List<int>();
            List<int> maxPeopleAvailableDays = new List<int>();

            // check if the total number of people added is not equal to availabilityList length
            // retun 0 because of invalid input.
            if (totalNumberOfPeople != availabilityList.Length)
            {
                List<int> ints = new List<int>() { 0 };   
                return ints;
            }

            // loop 5 times for each availability of a person 
            // count the number of the person available for each day
            // store the count of person in a new list called availabilityCountArray
            for (int i = 0; i < 5; i++)
            {
                int count = 0;
                for (int j = 0; j <= availabilityList.Length - 1; j++)
                {
                    string str = availabilityList[j];
                    if (str[i].CompareTo('1') == 0)
                    {
                        count++;
                    }
                }
                availabilityCountArray.Add(count);
            }

            // find the largest number from the availabilityCountArray list.
            int largestNumberOfAvailablePeople = availabilityCountArray.Max();

            // loop through the avaibilityCountArray
            // compare each element with the largestNumberOfAvailablePeople
            // store the index of the array + 1 (because we are starting the index from 0) in a new list called maxPeopleAvailableDays
            for(int i = 0; i < availabilityCountArray.Count; i++)
            {
                if (availabilityCountArray[i] == largestNumberOfAvailablePeople)
                {
                    maxPeopleAvailableDays.Add(i + 1);
                }
            }

            // return the maximum days on which most people are available
            return maxPeopleAvailableDays;
        }
    }
}
