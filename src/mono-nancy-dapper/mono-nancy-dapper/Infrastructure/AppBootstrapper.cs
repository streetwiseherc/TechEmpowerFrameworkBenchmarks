using Nancy;
using Nancy.Bootstrapper;
using System;

namespace mononancydapper
{
	public class AppBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup (Nancy.TinyIoc.TinyIoCContainer container, IPipelines pipelines)
		{
			// Setup the JSON formatting options
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
		}
	}
}

