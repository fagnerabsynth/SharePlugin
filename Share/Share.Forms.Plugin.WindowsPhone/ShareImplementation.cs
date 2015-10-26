 /* using da namespace da interface na PCL */
 
using System;
using Xamarin.Forms;

 /* using namespace do seu projeto */
 
using Windows.Devices.Sensors;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

[assembly: Dependency(typeof(ShareImplementation))]

namespace /* alterar colocar o namespace */ Share.Forms.Plugin.WindowsPhone
{
    public class ShareImplementation : IShare
    {
        public static void Init() 
        {

        }

		public void ShareStatus (string status)
		{
			var task = new ShareStatusTask {Status = status};
			Device.BeginInvokeOnMainThread(() =>
				{
					try
					{
						task.Show();
					}
					catch (Exception ex)
					{;
					}
				});
		}

		public void ShareLink (string title, string status, string link)
		{
			var task = new ShareLinkTask {Title = title, Message = status, LinkUri = new Uri(link)};
			Device.BeginInvokeOnMainThread(() =>
				{
					try
					{
						task.Show();
					}
					catch (Exception ex)
					{;
					}
				});
		}
    }
}
