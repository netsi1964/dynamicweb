using System;
using netsi1964;
using System.IO;
using System.Drawing;

namespace test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Base64encode test
			// Console.WriteLine ("Base64encode");
			// Console.WriteLine(File.Exists("/Users/stenhougaard/Dokumenter/Git/dynamicweb/xamarin/test/msdn.png"));
			// Console.WriteLine(System.Drawing.Image.FromFile ("/Users/stenhougaard/Dokumenter/Git/dynamicweb/xamarin/test/msdn.png"));

			// Request Test 
			Console.WriteLine ("request");
			Console.WriteLine (netsi1964.Experimental.request ("http://www.dr.dk", "//head"));


			// TimeAgo test




			Console.WriteLine ("TimeAgo");
			Console.WriteLine (netsi1964.util.TimeAgo (DateTime.Now.AddSeconds (10).ToString()));

			Console.WriteLine (netsi1964.util.TimeAgo ("2014/01/01"));

			Console.WriteLine (netsi1964.util.TimeAgo ("2015/01/01"));

			// Test 90 seconds ago.
			Console.WriteLine ("90 seconds "+netsi1964.util.TimeAgo (DateTime.Now.AddSeconds (-90).ToString ()));
			// Test 25 minutes ago.
			Console.WriteLine ("25 minutes "+netsi1964.util.TimeAgo (DateTime.Now.AddMinutes (-25).ToString ()));
			// Test 45 minutes ago.
			Console.WriteLine ("45 minutes "+netsi1964.util.TimeAgo (DateTime.Now.AddMinutes (-45).ToString ()));
			// Test 4 hours ago.
			Console.WriteLine ("4 hours "+netsi1964.util.TimeAgo (DateTime.Now.AddHours (-4).ToString ()));
			// Test 15 days ago.
			Console.WriteLine ("15 days "+netsi1964.util.TimeAgo (DateTime.Now.AddDays (-15).ToString ()));

			// Taken from my head
			string simpleTime = "2014/01/01";
			DateTime time = DateTime.Parse(simpleTime);
			Console.WriteLine(time);

			// Taken from HTTP header
			string httpTime = "Fri, 27 Feb 2009 03:11:21 GMT";
			time = DateTime.Parse(httpTime);
			Console.WriteLine(time);

			// Taken from w3.org
			string w3Time = "2009/02/26 18:37:58";
			time = DateTime.Parse(w3Time);
			Console.WriteLine(time);

			// Taken from nytimes.com
			string nyTime = "Thursday, February 26, 2009";
			time = DateTime.Parse(nyTime);
			Console.WriteLine(time);

			// Taken from this site
			string perlTime = "February 26, 2009";
			time = DateTime.Parse(perlTime);
			Console.WriteLine(time);

			// Taken from ISO Standard 8601 for Dates
			string isoTime = "2002-02-10";
			time = DateTime.Parse(isoTime);
			Console.WriteLine(time);

			// Taken from Windows file system Created/Modified
			string windowsTime = "2/21/2009 10:35 PM";
			DateTime t;
			bool ok = DateTime.TryParse(windowsTime, out t);
			Console.WriteLine(t);

			// Taken from Windows Date and Time panel
			string windowsPanelTime = "8:04:00 PM";
			time = DateTime.Parse(windowsPanelTime);
			Console.WriteLine(time);
		}



	}
}


