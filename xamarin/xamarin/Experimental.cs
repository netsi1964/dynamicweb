using System;
using WebSupergoo;
using System.Web;
using HtmlAgilityPack;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;

namespace netsi1964
{
	public class Experimental
	{

		public static string getDatalistAsJSON (int datalistID)
		{
			string result = "Could not get datalist id = " + datalistID.ToString ();
			try {
				string xmlInput = getDatalistAsXML(datalistID);

				Assembly assembly = typeof(netsi1964.Experimental).Assembly;
				System.IO.Stream stream = assembly.GetManifestResourceStream("netsi1964.resources.xml2json.xslt");
				if(stream == null)
					throw new Exception("The resource \"netsi1964.resources.xml2json.xslt\" was not loaded properly.");


				System.IO.StreamReader sr = new StreamReader(stream);
				String xslInput = sr.ReadToEnd();
				result = transform(xmlInput, xslInput);

			} catch (Exception ex) {
				result += "\n" + ex.Message;
			}
			return result;
		}

		public static string getDatalistAsXML (int datalistID)
		{
			string result = "Could not get datalist id = " + datalistID.ToString ();
			try {
				Dynamicweb.Modules.DataManagement.Publishing publish = Dynamicweb.Modules.DataManagement.Publishing.GetPublishingById (datalistID);
				result  = publish.GetXMLOutput ();
			} catch (Exception ex) {
				result += "\n" + ex.Message;
			}
			return result;
		}

		public static string transform(string xmlInput, string xslInput) {
			string output = String.Empty;
			try {
				using (StringReader srt = new StringReader (xslInput)) // xslInput is a string that contains xsl
				using (StringReader sri = new StringReader (xmlInput)) { // xmlInput is a string that contains xml
					using (XmlReader xrt = XmlReader.Create (srt))
					using (XmlReader xri = XmlReader.Create (sri)) {
						XslCompiledTransform xslt = new XslCompiledTransform ();
						xslt.Load (xrt);
						using (StringWriter sw = new StringWriter ())
						using (XmlWriter xwo = XmlWriter.Create (sw, xslt.OutputSettings)) { // use OutputSettings of xsl, so it can be output as HTML
							xslt.Transform (xri, xwo);
							output = sw.ToString ();
						}
					}
				}
			} catch (Exception ex) {
				output = "Error: " + ex.Message;
			}
			return output;
		}

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

		public static string base64encode (string Path)
		{
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
				base64String = "Error: " + ex.Message;
			}
			return base64String;
		}

	}
}

