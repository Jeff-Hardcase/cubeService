using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cubeService.Models;

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
            var myCube = new Cube();
            myCube.Init();

            //var myCubeJson = Newtonsoft.Json.JsonConvert.SerializeObject(myCube);
            var result = string.Empty;
            var z = 3;

            for (var y = 1; y < 4; y++)
                for (var x = 1; x < 4; x++)
                    result += string.Format("{0}{1}{2} - {3}, ", x, y, z, myCube.cubelets[x, y, z].Z);

            return result;
        }

    }
}