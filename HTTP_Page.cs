using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectHTTP5101
{
    public class HTTP_Page
    {

        private string Ptitle;
        private string Pbody;



        public string GetPtitle()
        {
            return Ptitle;
        }
        public string GetPbody()
        {
            return Pbody;
        }


        public void SetPtitle(string value)
        {
            Ptitle = value;
        }
        public void SetPbody(string value)
        {
            Pbody = value;
        }

    }
}