using System;
using Dynamicweb;
using Dynamicweb.Rendering;
using Dynamicweb.Extensibility;

namespace netsi1964
{

	public class tagExtension
	{

		// AddInName is the name of the extension method - <!--@tag.getDatalistAsJSON(id)-->
		// will give an TagExtension of 'getDatalistAsJSON(int id)'
		// "page name".getDatalistAsJSON(1) => JSON from the datalist no 1
		[AddInName ("getDatalistAsJSON")]
		public class TagExtension_getDatalistAsJSON : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				int id = -1;
				object fullPassedArgument = this.Argument;
				if (this.Arguments.Count == 1) {
					id = int.Parse(this.Arguments [0].ToString());
				}
				return netsi1964.Experimental.getDatalistAsJSON (id);
			}
		}


		// AddInName is the name of the extension method - <!--@tag.getDatalistAsXML(id)-->
		// will give an TagExtension of 'getDatalistAsXML(int id)'
		// "page name".getDatalistAsXML(1) => XML from the datalist no 1
		[AddInName ("getDatalistAsXML")]
		public class TagExtension_getDatalistAsXML : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				int id = -1;
				object fullPassedArgument = this.Argument;
				if (this.Arguments.Count == 1) {
					id = int.Parse(this.Arguments [0].ToString());
				}
				return netsi1964.Experimental.getDatalistAsXML (id);
			}
		}

		// AddInName is the name of the extension method - <!--@tag.Request(Url, xpath)-->
		// will give an TagExtension of 'request(string Url, string xpath)'
		// "page name".Request("http://www.dr.dk", "") => HTML from <body> of dr.dk
		[AddInName ("Request")]
		public class TagExtension_Request : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				string url = "http://www.dr.dk";
				string xpath = "";
				object fullPassedArgument = this.Argument;
				if (this.Arguments.Count == 2) {
					url = this.Arguments [0].ToString ();
					xpath = this.Arguments [1].ToString ();
				}
				return netsi1964.Experimental.request (url, xpath);
			}
		}

		// AddInName is the name of the extension method - <!--@DwPageName.TimeAgo()-->
		// will give an AddInName of 'TimeAgo'
		// "date".TimeAgo() => "3 days ago"
		// If tag||value is not a date the original value will be returned
		// If a parameter is given, THAT parameter value is used to get TimeAgo, ignoring the tag value.
		[AddInName ("TimeAgo")]
		public class TagExtension_TimeAgo : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				string useValue = value;
				object fullPassedArgument = this.Argument;
				bool wrap = false;
				if (this.Arguments.Count > 0) {
					//First argument is the startIndex of the Substring method
					useValue = this.Arguments [0].ToString ();
					wrap = (this.Arguments.Count == 2) ? bool.Parse (this.Arguments [1].ToString ()) : false;
				} 
				return netsi1964.util.TimeAgo (useValue, wrap);
			}
		}
	}
}
