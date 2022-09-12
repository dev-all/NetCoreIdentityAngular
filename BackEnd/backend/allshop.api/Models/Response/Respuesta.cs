using System;

namespace allshop.Models.Response
{
    public class Respuesta
    {
        public string Status { get; set; }
        public string Timestamp { get; set; } 
        public string Resultado { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

        public Respuesta()
        {
            this.Status = "200";
            this.Timestamp = DateTime.Now.ToString();
        }
    }
}
