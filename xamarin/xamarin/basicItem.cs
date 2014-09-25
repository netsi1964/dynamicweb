using System;
using Dynamicweb.Content.Items;
using Dynamicweb;

// Used for Item related attributes
using Dynamicweb.Content.Items.Annotations;

// Used if you want custom editors
using Dynamicweb.Content.Items.Editors;

// Used for item metadata
using Dynamicweb.Content.Items.Metadata;



namespace xamarin
{
	[Name ("Basic Item")]
	public class basicItem : ItemEntry  // classname becomes "systemname" used among other in Database Table Name "ItemType_basicItem"
	{


		[Group ("Content")] // This field will be placed in a group named "Content"
		public string Heading { get; set; }

		[Group ("Content")]
		public int Integer { get; set; }

		[Group ("Content")]
		[Field ("HTML Body", typeof(SimpleTextboxEditor))]
		public string Body { get; set; }

		/*
		[Group ("Content")]
		[Field ("Content", typeof(Dynamicweb.Content.Items.Editors.DateTimeEditor))]
		[Name ("Born")]
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
		*/

		[Group ("Content")]
		[Field ("Content", typeof(Dynamicweb.Content.Items.Editors.DateTimeEditor))]
		[Name ("Born")]
		public DateTime Born { get; set; }

		// Here the set will only allow for 155 chars
		[Group ("SEO")]
		public string MetaDescription { get; set; }


		// http://developer.dynamicweb.com/documentation/for-developers/item-based-structure/working-with-metadata.aspx
		// ItemType t = ItemManager.Metadata.GetItemType ("basicItem");



		// Returns the current metadata
		public static MetadataContainer GetMeta ()
		{
			return ItemManager.Metadata.GetMetadata ();
		}

	}

	// http://developer.dynamicweb.com/documentation/for-developers/item-based-structure/using-field-editors.aspx
	[Editor ("My custom editor")]
	public class SimpleTextboxEditor : Editor
	{
		public override Type DataType {
			get { return typeof(string); }
		}

		public override void BeginEdit (EditorContext context)
		{
			if (context != null && context.Output != null) {
				var v = context.Value != null ?
					context.Value.ToString () : string.Empty;

				// context.Output.WriteLine (string.Format ("<input type=\"text\" value=\"{0}\" />", System.Web.HttpUtility.HtmlAttributeEncode (v)));
				context.Output.WriteLine (string.Format ("<textarea rows=\"10\" cols=\"70\">{0}</textarea>", System.Web.HttpUtility.HtmlAttributeEncode (v)));
			}
		}

		public override object EndEdit ()
		{
			return base.HttpContext.Request [base.Key];
		}
	}


}
