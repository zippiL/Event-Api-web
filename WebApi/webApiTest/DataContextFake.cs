using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace webApiTest
{
    internal class DataContextFake : IDataContex
    {
        public List<Event> Events { get; set; }

        public DataContextFake()
        {
            Events = new List<Event> { new Event { Id = 1, Title = "start", Start = DateTime.Now } };
        }
    }
}
