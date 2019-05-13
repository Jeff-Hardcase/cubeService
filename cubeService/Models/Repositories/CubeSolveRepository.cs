using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cubeService.Models.Repositories
{
    public class CubeSolveRepository
    {
        //private Cube cube = new Cube();

        public string GetSolution(string cubeState)
        {
            //"utl,F1,utc,F4,utr,F7,ucl,F2,ucc,F5,ucr,F8,ubl,F3,ubc,F6,ubr,F9,ftl,D1,ftc,D4,ftr,D7,fcl,D2,fcc,D5,fcr,D8,fbl,D3,fbc,D6,fbr,D9,ltl,L7,ltc,L8,ltr,L9,lcl,L4,lcc,L5,lcr,L6,lbl,L1,lbc,L2,lbr,L3,rtl,R3,rtc,R2,rtr,R1,rcl,R6,rcc,R5,rcr,R4,rbl,R9,rbc,R8,rbr,R7,btl,U1,btc,U4,btr,U7,bcl,U2,bcc,U5,bcr,U8,bbl,U3,bbc,U6,bbr,U9,dtl,B1,dtc,B4,dtr,B7,dcl,B2,dcc,B5,dcr,B8,dbl,B3,dbc,B6,dbr,B9,"
            //"utl,U7,utc,F6,utr,L1,ucl,L6,ucc,B5,ucr,R4,ubl,U9,ubc,R6,ubr,R3,ftl,R1,ftc,D8,ftr,F9,fcl,R8,fcc,R5,fcr,D6,fbl,B1,fbc,B6,fbr,R9,ltl,B9,ltc,D2,ltr,F7,lcl,U6,lcc,U5,lcr,B8,lbl,F3,lbc,F8,lbr,D3,rtl,D7,rtc,U8,rtr,U1,rcl,B4,rcc,D5,rcr,F2,rbl,B7,rbc,B2,rbr,L7,btl,L9,btc,U2,btr,U3,bcl,F4,bcc,L5,bcr,L8,bbl,R7,bbc,D4,bbr,B3,dtl,L3,dtc,U4,dtr,D9,dcl,R2,dcc,F5,dcr,L2,dbl,D1,dbc,L4,dbr,F1,"

            return "nothing";
        }

        private void SetCubeState(string cubeState)
        {
            string[] cubeArray = cubeState.Split(',');

            for(int x = 0; x < cubeArray.Length; x++)
            {

            }


        }
    }
}