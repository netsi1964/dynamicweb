using System;
using Dynamicweb;
using Dynamicweb.Rendering;
using Dynamicweb.Extensibility;

namespace netsi1964
{

	public class tagExtension
	{


		//AddInName is the name of the extension method - <!--@DwPageName.sho(12)-->
		// will give an AddInName of 'sho'
		// "page name".sho() => "page_name"
		[AddInName ("sho")]
		public class TagExtension_sho : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				object fullPassedArgument = this.Argument;
				return netsi1964.util.sho (value);
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
