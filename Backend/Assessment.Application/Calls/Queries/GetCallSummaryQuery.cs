using Assessment.Data;
using Assessment.Data.Entities;
using Assessment.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Application.Calls.Queries
{
    public class GetCallSummaryQuery : IRequest<Result<GetCallSummaryResult>> 
    {
        public Guid UserId { get; set; }
        public DateTimeOffset SelectedDate { get; set; }
    }

    public class GetCallSummaryResult
    {
        public DateTime dateMostCalls { get; set; }
        public int avgCallsPerDay { get; set; }
        public int avgCallsPerUser { get; set; }
    }

    public class GetCallSummaryQueryHandler : IRequestHandler<GetCallSummaryQuery, Result<GetCallSummaryResult>>
    {
        private readonly ApplicationDbContext _context;

        public GetCallSummaryQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetCallSummaryResult>> Handle(
            GetCallSummaryQuery request,
            CancellationToken cancellationToken)
        {
            var callResuls = _context.Calls
                .Where(x => x.CallingUserId == request.UserId && x.DateCallStarted == request.SelectedDate).AsQueryable();

            var result = new GetCallSummaryResult
            {
                //avgCallsPerUser = await callResuls.AverageAsync()
            };


            return Result<GetCallSummaryResult>.Success(result);
        }
    }
}
