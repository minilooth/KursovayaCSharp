using Autodealers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursovayaServer.Controllers
{
    interface IController
    {
        public Session Session { get; set; }
        public AutodealersContext AutodealersContext { get; set; }

        public void RefreshContext();
        public void Add();
        public void Edit();
        public void Delete();
    }
}
