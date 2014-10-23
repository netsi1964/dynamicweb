using System;
using WebSupergoo;
using System.Web;
using HtmlAgilityPack;
using System.Drawing;
using System.IO;

namespace netsi1964
{
	public class Experimental
	{
		public static string saveUrlAsPDFToPath (string Url, string path)
		{
			string mappedPath = "";
			try {
				WebSupergoo.ABCpdf9.Doc theDoc = new WebSupergoo.ABCpdf9.Doc ();
				theDoc.AddImageUrl (Url);
				mappedPath = HttpContext.Current.Server.MapPath (path);
				theDoc.Save (path);
				theDoc.Clear ();
			} catch (Exception ex) {
				mappedPath = ex.Message;
			}
			return mappedPath;
		}

		public static string request (string Url, string xPathSearch)
		{
			string response = "";
			try {
				HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlAgilityPack.HtmlWeb ();
				HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load (Url);
				xPathSearch = String.IsNullOrEmpty (xPathSearch) ? "//body" : xPathSearch;
				HtmlNode node = doc.DocumentNode.SelectSingleNode (xPathSearch);
				response = node.OuterHtml;
			} catch (Exception ex) {
				response = ex.Message;
			}
			return response;
		}

		public static string base64encode(string Path) {
			// http://stackoverflow.com/questions/21325661/convert-image-path-to-base64-string
			string base64String = "";
			try {
				using (System.Drawing.Image image = System.Drawing.Image.FromFile (Path)) {   
					base64String = "ok";
					using (MemoryStream m = new MemoryStream ()) {
						image.Save (m, image.RawFormat);
						byte[] imageBytes = m.ToArray ();
				
						// Convert byte[] to Base64 String
						base64String = Convert.ToBase64String (imageBytes);
					}                  
				}
			} catch (Exception ex) {
				base64String = "Error: "+ex.Message;
			}
			return base64String;
		}

	}
}

