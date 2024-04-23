using Grpc.Core;
using gRPCServer.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace gRPCServer.Services;

public class SubscribeService(DataContext context) : SubscriptionService.SubscriptionServiceBase   
{
    private readonly DataContext _context = context;

    public override async Task<SubscribeResponse> Subscribe(SubscribeRequest request, ServerCallContext context)
    {
        if (! await _context.Subscribers.AnyAsync(x => x.Email == request.Email))
        {
            _context.Subscribers.Add(request);
            await _context.SaveChangesAsync();

            return new SubscribeResponse
            {
                Message = "You have been subscribed "
            }; ;
        }

        return new SubscribeResponse
        {
            Message = "You are already subscribed "
        }; ;

    }

    public override async Task<UnsubscribeResponse> Unsubscribe(UnsubscribeRequest request, ServerCallContext context)
    {
        var subscribeRequest = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (subscribeRequest != null)
        {
            _context.Subscribers.Remove(subscribeRequest);
            await _context.SaveChangesAsync();

            return new UnsubscribeResponse
            {
                Message = "You have been unsubscribed "
            }; ;
        }

        return new UnsubscribeResponse
        {
            Message = "You are not subscribed "
        }; 
    }
}

