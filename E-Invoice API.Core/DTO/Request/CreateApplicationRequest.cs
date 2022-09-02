using System;

namespace E_Invoice_API.Core.DTO.Request
{
    public class CreateApplicationRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Question { get; set; }
        public DateTime EndVotingDateTime{ get; set; }
    }
}
