using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cubeService.Controllers
{
    public class SolutionController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Not supported. You need to pass in the current puzzle state.", "Use a comma delimited string with U,D,F,B,L,R as the face colors" };
        //}


        // GET api/<controller>/5
        public string Get(string cubeState)
        {
            return "This will be the solution. The cube state was given as " + cubeState;
        }

    }
}