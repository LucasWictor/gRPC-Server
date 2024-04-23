using ClientApplication;
using ClientApplication.Services;

var grpc = new GrpcService("https://localhost:7030");




Console.Clear();
Console.WriteLine("Email to subscribe: ");
var SubscribeRequest = new SubscribeRequest { Email = Console.ReadLine() };

var Subscriberesponse = await grpc.SubscribeAsync(SubscribeRequest);
Console.WriteLine($"{Subscriberesponse.Message}");
Console.ReadKey();





Console.Clear();
Console.WriteLine("Email to unsubscribe: ");
var Unsubscriberequest = new UnsubscribeRequest { Email = Console.ReadLine() };

var Unsubscriberesponse = await grpc.UnsubscribeAsync(Unsubscriberequest);
Console.WriteLine($"{Unsubscriberesponse.Message}");
Console.ReadKey();