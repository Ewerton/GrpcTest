# Grpc Service (http) being called by a console App (with docker and compose)

This Solution has two projects:
- A Grpc Service (the GreeterService, created from the Visual Studio Template)
- A Console App (the client to call the Service)

I'am trying to run this soution with docker-compose but I'am getting the following excletion:
```
Grpc.Core.RpcException: 'Status(StatusCode="Unavailable", Detail="Error connecting to subchannel.", DebugException="System.Net.Sockets.SocketException (111): Connection refused
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
   at System.Net.Sockets.Socket.<ConnectAsync>g__WaitForConnectWithCancellation|281_0(AwaitableSocketAsyncEventArgs saea, ValueTask connectTask, CancellationToken cancellationToken)
   at Grpc.Net.Client.Balancer.Internal.SocketConnectivitySubchannelTransport.TryConnectAsync(ConnectContext context)")'
```

I'am still trying to make this work.
