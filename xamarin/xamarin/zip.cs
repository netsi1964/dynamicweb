using System;
using System.Web;
using System.IO;
using System.Net;
using Ionic.Zip;

namespace netsi1964
{
	public class zip
	{
		public string doZip (string sourcePath, string targetPath)
		{
			return doZip (sourcePath, targetPath, false);
		}

		public string doZip (string sourcePath, string targetPath, bool files)
		{
			string status = "";
			bool okay = true;
			string _sourcePath = System.Web.HttpContext.Current.Server.MapPath (sourcePath);
			string _targetPath = System.Web.HttpContext.Current.Server.MapPath (targetPath);

			if (!System.IO.Directory.Exists (_sourcePath)) {
				status += "\nThe directory \"" + _sourcePath + "\" does not exist!\n";
				okay = false;
			}


			string ZipFileToCreate = _targetPath;

			if (okay) {
				try {
					using (ZipFile zip = new ZipFile ()) {
						if (files) {
							// note: this does not recurse directories! 
							String[] filenames = System.IO.Directory.GetFiles (_sourcePath);

							// This is just a sample, provided to illustrate the DotNetZip interface.  
							// This logic does not recurse through sub-directories.
							// If you are zipping up a directory, you may want to see the AddDirectory() method, 
							// which operates recursively. 
							foreach (String filename in filenames) {
								status += String.Format ("\nAdding {0}...", filename);
								ZipEntry e = zip.AddFile (filename);
								e.Comment = "Added by Cheeso's CreateZip utility."; 
							}
						} else {
							zip.AddDirectory(_sourcePath, "backup");
						}


						zip.Comment = String.Format ("This zip archive was created by the CreateZip example application on machine '{0}'",
							System.Net.Dns.GetHostName ());

						zip.Save (ZipFileToCreate);
					}

				} catch (System.Exception ex1) {
					status += "\nexception: " + ex1;
				}
			}
			return status;
		}

	}
}

