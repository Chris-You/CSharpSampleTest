using System;

namespace WebApplicationMVC.Models
{
    public class LogModel
    {
        public LogModel()
        {
        }

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
    }
}