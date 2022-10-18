using System;

namespace allshop.Models.Response
{
    public class Response
    {
        public int Status { get; set; }
        public string Timestamp { get; set; } 
        public string? Aux { get; set; }
        public string? Message { get; set; }
        public string? TypeMessage { get; set; }
        public object? Data { get; set; }
       
        public Response()
        {
            this.Status = 200;
            this.Message = "ok";
            this.TypeMessage = "success";
            this.Timestamp = DateTime.Now.ToString();
        }
    }
}
