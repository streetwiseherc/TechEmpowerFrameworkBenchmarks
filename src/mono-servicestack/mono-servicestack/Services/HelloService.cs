using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using System;

namespace monoservicestack
{
	[Route("/hello")]
	public class Hello : IReturn<HelloResponse>
	{
	}

	public class HelloResponse
	{
		public string Message { get; set; }
	}

	public class HelloService : Service	
	{
		public object Get(Hello request) 
		{
			return new HelloResponse() { Message = "Hello World!"}; 
		}
	}
}

