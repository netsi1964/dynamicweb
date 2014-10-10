using System;
using Dynamicweb;
using Dynamicweb.Rendering;
using Dynamicweb.Extensibility;

namespace netsi1964
{
	public class util
	{
		public static string sho (string value)
		{
			return value.Replace (" ", "_");
		}
	}

	public class tagExtension
	{


		//AddInName is the name of the extension method - <!--@DwPageName.sho(12)-->
		// will give an AddInName of 'sho'
		// "page name".sho() => "page_name"
		[AddInName ("sho")]
		public class TagExtensionMethodSample : TagExtensionMethod
		{
			public override string ExecuteMethod (string value)
			{
				object fullPassedArgument = this.Argument;
				return netsi1964.util.sho (value);
			}
		}
	}
}
