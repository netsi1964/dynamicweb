using System;
using Dynamicweb.Content.Items;
using Dynamicweb;
using Dynamicweb.Content.Items.Annotations;

 // Used for Item related attributes

namespace xamarin
{
	[Name ("Basic Item")]
	public class basicItem : ItemEntry
	{
		[Group ("Content")] // This field will be placed in a group named "Content"
		public string Heading { get; set; }

		[Group ("Content")]
		public int Integer { get; set; }

		[Field ("Content", typeof(Dynamicweb.Content.Items.Editors.DateTimeEditor))]
		public DateTime Born { 
			get { return this.Born; }
			set { 
				DateTime oldest = DateTime.Now.AddYears (-120);
				this.Born = (this.Born < oldest) ? this.Born : oldest;
			}
		}

		// Here the set will only allow for 155 chars
		[Group ("SEO")]
		public string MetaDescription { 
			get { return this.MetaDescription; } 
			set { this.Heading = value.Substring (0, 155); } 
		}


	}


}
