
 /* using da namespace da interface na PCL */

using System;
using Xamarin.Forms;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Runtime;
using Android.App;

 /* using namespace do seu projeto */
using Android.Hardware;

[assembly: Dependency(typeof(ShareImplementation))]
namespace /* alterar colocar o namespace */ Share.Forms.Plugin.Droid
{
    public class ShareImplementation : IShare
    {
      
		public static void Init() 
		{ 
		}

		public void ShareStatus (string status)
		{
			ShareOnService(status);
		}

		public void ShareLink (string title, string status, string link)
		{
			ShareOnService(status,title,link);
		}

		private void ShareOnService(string status, string title = "", string link = "")
		{
			var intent = new Intent(global::Android.Content.Intent.ActionSend);
        		intent.PutExtra(global::Android.Content.Intent.ExtraText, String.Format("{0} - {1}", status ?? string.Empty, link ?? string.Empty));
        		intent.PutExtra(global::Android.Content.Intent.ExtraSubject, title ?? string.Empty);
			intent.SetType("text/plain");
			Forms.Context.StartActivity(intent);
		}
	}
}
