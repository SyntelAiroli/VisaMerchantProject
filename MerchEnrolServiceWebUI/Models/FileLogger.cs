using MerchEnrolServiceWebUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchEnrolServiceWebUI.Models
{
    public  class FileLogger : ILogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText( AppDomain.CurrentDomain.BaseDirectory + "\\Error.txt", error);
        }
    }
}