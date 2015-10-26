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

	 public void ShareStatus(string status)
        {
            ShareLink("", status, "");
        }

        public void ShareLink(string title = "", string status = "", string link = "")
        {

            Uri uriResult;
            bool isUriValid = Uri.TryCreate(link, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;

            if (isUriValid)
            {
                ShareLinkTask shareLinkTask = new ShareLinkTask();
                shareLinkTask.Title = title;
                shareLinkTask.Message = status;
                shareLinkTask.LinkUri = new Uri(link, UriKind.Absolute);
                shareLinkTask.Show();

            }
            else
            {
                ShareStatusTask shareStatusTask = new ShareStatusTask();
                shareStatusTask.Status = title + status;
                shareStatusTask.Show();
            }

        }
    }
}
