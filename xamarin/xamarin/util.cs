using System;
using Dynamicweb.Rendering;
using Dynamicweb.Templatev2;


namespace netsi1964
{
	public class util
	{
		public static string sho (string value)
		{
			return value.Replace (" ", "_");
		}

		#region TimeAgo

		public static String TimeAgo (string date)
		{
			return TimeAgo (date, false);
		}

		public static String TimeAgo (string date, bool wrap)
		{
			String prettyDate = date;
			DateTime parsedDate;
			bool dataIsOkay = DateTime.TryParse (date, out parsedDate);
			prettyDate = (dataIsOkay) ? GetPrettyDate (parsedDate, wrap) : prettyDate;
			return prettyDate;
		}


		#endregion

		private static string substitute (bool isTrue, string txt, Double number)
		{
			return (isTrue) ? txt.Replace ("%d", number.ToString ()) : "";
		}

		#region GetPrettyDate

		private static string GetPrettyDate (DateTime d)
		{
			return GetPrettyDate (d, false);
		}

		private static string GetPrettyDate (DateTime date, bool bWrap)
		{
			bWrap = true;
			string future = "in about %txt";
			string past = "about %txt ago";

			string txtNow = "just now";
			string txtSec = "%n sekunder";
			string txtMin = "%n minutes";
			string txtHou = "%n hours";
			string txtDay = "%n days";
			string txtWee = "%n weeks";
			string txtMon = "%n months";
			string txtYea = "%n years";

			DateTime oNow = DateTime.Now;

			// Difference between date and now
			// Negative: Future
			TimeSpan ts = oNow - date;


			bool bFuture = (ts.Milliseconds < 0);

			double sec = Math.Abs (ts.Seconds);
			double min = Math.Abs (ts.Minutes);
			double hou = Math.Abs (ts.Hours);
			double day = Math.Abs (ts.Days);
			double wee = Math.Abs (Math.Round (day / 7));
			double mon = Math.Abs (Math.Round (day / 30));
			double yea = Math.Abs (Math.Round (day / 365));

			string sTimeAgo = "";

			if (sec == 0) {
				sTimeAgo = txtNow;
			} else if (sec < 60) {
				sTimeAgo = txtSec.Replace ("%n", sec.ToString ());
			} else if (min < 60) {
				sTimeAgo = txtMin.Replace ("%n", min.ToString ());
			} else if (hou < 24) {
				sTimeAgo = txtHou.Replace ("%n", hou.ToString ());
			} else if (day < 7) {
				sTimeAgo = txtDay.Replace ("%n", day.ToString ());
			} else if (wee < 4) {
				sTimeAgo = txtWee.Replace ("%n", wee.ToString ());
			} else if (mon < 12) {
				sTimeAgo = txtMon.Replace ("%n", mon.ToString ());
			} else {
				sTimeAgo = txtYea.Replace ("%n", yea.ToString ());
			}

			if (yea > 0) {
				sTimeAgo = txtYea.Replace ("%n", yea.ToString ());
			} else if (mon > 0) {
				sTimeAgo = txtMon.Replace ("%n", mon.ToString ());
			} else if (wee > 0) {
				sTimeAgo = txtWee.Replace ("%n", wee.ToString ());
			} else if (day > 0) {
				sTimeAgo = txtDay.Replace ("%n", day.ToString ());
			} else if (hou > 0) {
				sTimeAgo = txtHou.Replace ("%n", hou.ToString ());
			} else if (min > 0) {
				sTimeAgo = txtMin.Replace ("%n", min.ToString ());
			} else if (sec > 0) {
				sTimeAgo = txtSec.Replace ("%n", sec.ToString ());
			}


			if (sec > 0) {
				sTimeAgo = ((bFuture) ? future : past).Replace ("%txt", sTimeAgo);
			}
			if (bWrap) {
				var sDatetime = String.Format ("{0:yyyy-MM-dd hh:mm:sszzz}", date);
				sTimeAgo = "<time datetime=\"" + sDatetime + "\">" + sTimeAgo + "</time>";
			}


			return sTimeAgo;
		}

		#endregion


	}
}

