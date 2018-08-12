/*
 * Created by SharpDevelop.
 * User: jeffry
 * Date: 15.10.2013
 * Time: 9:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace scanner.Code
{
	/// <summary>
	/// Description of Downloader.
	/// </summary>
	public class Downloader
	{
		public Downloader()
		{
		}
		
		public static HtmlDocument DownloadPage(string uri)
		{
			WebClient client = new WebClient ();

		    Stream data = client.OpenRead(uri);
		    StreamReader reader = new StreamReader(data);
		    string s = reader.ReadToEnd();
		    data.Close ();
		    reader.Close ();
		    
		    
			HtmlDocument doc = new HtmlDocument();
		    
		    TextReader sr = new StringReader(s);
		    
		    doc.Load(sr);
		    
		    return doc;
			
			//HtmlDocument doc = new HtmlDocument();
			
			//doc.Load("c:\\usercontent\\projects\\test.htm");
			
			//return doc;
		}

        public static string DownloadHtml(string uri)
        {
            WebClient client = new WebClient();

            Stream data = client.OpenRead(uri);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;

        }


        public static HtmlDocument GetUserInfo(string user)
		{
            return DownloadPage(user);
		}
	}
}
