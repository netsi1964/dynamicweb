using System;
using Dynamicweb.Content.Items;
using Dynamicweb;

namespace xamarin
{
	[Dynamicweb.Content.Items.Annotations.Name ("Basic Item")]
	public class basicItem
	{
		public string Heading { get; set; }

		public int Integer { get; set; }
	}
}
