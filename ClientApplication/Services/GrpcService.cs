using Grpc.Net.Client;

namespace ClientApplication.Services;

public class GrpcService
{
    private readonly GrpcChannel _channel;
    private SubscriptionService.SubscriptionServiceClient _client;

    public GrpcService(string ServerAddress)
    {
        _channel = GrpcChannel.ForAddress(ServerAddress);
        _client = new SubscriptionService.SubscriptionServiceClient(_channel);
    }

    public async Task<SubscribeResponse> SubscribeAsync(SubscribeRequest request) 
    {
        var response = await _client.SubscribeAsync(request);
        return response;
    }

    public async Task<UnsubscribeResponse> UnsubscribeAsync(UnsubscribeRequest request)
    { 
        var response = await _client.UnsubscribeAsync(request); 
        return response;
    }
    
}
