using System;
using WebSupergoo;
using System.Web;
using HtmlAgilityPack;

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

	}
}

