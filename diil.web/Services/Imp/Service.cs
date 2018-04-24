using diil.web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diil.web.Services.Imp
{
    public class Service : IService
    {
        public string Say(string p)
        {
            return "你输入的是：" + p;
        }
    }
}