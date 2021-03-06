﻿using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BadListener.Runtime
{
	public class JsonControllerAttribute : BaseControllerAttribute
	{
        public JsonControllerAttribute(ControllerMethod method = ControllerMethod.Get)
            : base(method)
        {
        }

		public override void Render(string name, object model, HttpListenerContext context, HttpServer server)
		{
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
			string json = JsonConvert.SerializeObject(model, settings);
			context.Response.SetStringResponse(json, MimeType.ApplicationJson);
		}
	}
}
