using System;
using Dynamicweb.Content.Items;
using Dynamicweb;

// Used for Item related attributes
using Dynamicweb.Content.Items.Annotations;

using Dynamicweb.Content.Items.Activation;

// Used if you want custom editors
using Dynamicweb.Content.Items.Editors;

// Used for item metadata
using Dynamicweb.Content.Items.Metadata;



namespace netsi1964
{
	// Thanks to Morten Bengtsson for sharing his experiences and code
	// http://developer.dynamicweb.com/Default.aspx?ID=2&CategoryID=27&ThreadID=37770
	[Name ("Basic Item")]
	[AreaRule] //  Allow items of this type to be created in any area / website
	[StructureRule (Dynamicweb.Content.Items.Activation.StructureContextType.Pages)] //  Allow items of this type to be created as pages only.
	[ParentRule (ParentRestrictionRule.ParentType.RootOfWebsite, ParentRestrictionRule.ParentType.RegularPage)] // Allow items of this type to be created in the root of the website and under a regular page.
	public class basicItem : ItemEntry  // classname becomes "systemname" used among other in Database Table Name "ItemType_basicItem"
	{


		[Group ("Content")] // This field will be placed in a group named "Content"
		public string Heading { get; set; }

		[Group ("Content")]
		public int Integer { get; set; }

		[Group ("Content")]
		[Field ("HTML Body", typeof(SimpleTextboxEditor))]
		public string Body { get; set; }

		[Group ("Content")]
		[Field ("Content", typeof(Dynamicweb.Content.Items.Editors.DateTimeEditor))]
		[Name ("Born")]
		public DateTime Born { get; set; }

		// Here the set will only allow for 155 chars
		[Group ("SEO")]
		public string MetaDescription { get; set; }


		// http://developer.dynamicweb.com/documentation/for-developers/item-based-structure/working-with-metadata.aspx
		// ItemType t = ItemManager.Metadata.GetItemType ("basicItem");


		public override void Save (ItemContext context)
		{
			this.MetaDescription = "TEST" + this.MetaDescription.Substring (0, 155);
			base.Save (context);
		}


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
				context.Output.WriteLine (string.Format ("<textarea rows=\"10\" cols=\"70\" onclick=\"val=val.toUpperCase()\">{0}</textarea>", System.Web.HttpUtility.HtmlAttributeEncode (v)));
			}
		}

		public override object EndEdit ()
		{
			return base.HttpContext.Request [base.Key];
		}
	}


}
