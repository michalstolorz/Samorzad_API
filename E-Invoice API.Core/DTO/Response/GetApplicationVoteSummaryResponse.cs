using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.DTO.Response
{
    public class GetApplicationVoteSummaryResponse
    {
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
        public int VotesCount { get; set; }
    }
}
