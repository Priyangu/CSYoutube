using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace CSYoutube
{
    public partial class frmYoutubeDownloader : Form
    {
        public frmYoutubeDownloader()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {

            //The Google Maps API Either return JSON or XML. We are using XML Here
            //Saving the url of the Google API 
            string url = String.Format("http://maps.googleapis.com/maps/api/geocode/xml?address=" +
            "62 Parau street,Threekings auckland " + "&sensor=false");

            // using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            //{ if (fbd.ShowDialog()==DialogResult.OK)
            // {

            string filepath = Path.Combine(Application.StartupPath + "\\Songs\\");
            string[] listVideos = File.ReadAllLines(Path.Combine(Application.StartupPath + "\\SongstoDownload.txt"));
            string videoUrl = string.Empty;
            int totalDownloaded = 0;

            for (int i = 0; i < listVideos.Length; i++)
            {
                videoUrl = listVideos[i].ToString();


                var youtube = YouTube.Default;
                var video = await youtube.GetVideoAsync(videoUrl);
                lblStatus.Text = "Downloading ....";

                File.WriteAllBytes(filepath + video.FullName, await video.GetBytesAsync());
                totalDownloaded++;
                lblStatus.Text = totalDownloaded.ToString() +" out of "+ listVideos.Length.ToString() +  "  file Download completed...!!!";

            }


            //}
            //}              
            //}
        }
    }
}
