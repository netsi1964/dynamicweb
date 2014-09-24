using System;
using Dynamicweb.Content.Items;
using Dynamicweb;

namespace xamarin
{
	[Dynamicweb.Content.Items.Annotations.Name ("Basic Item")]
	public class basicItem : ItemEntry
	{
		public string Heading { get; set; }

		// Here the set will only allow for 155 chars
		public string MetaDescription { 
			get { return this.MetaDescription; } 
			set { this.Heading = value.Substring (0, 155); } 
		}

		public int Integer { get; set; }
	}


}
