using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Gallery_App.Models;

namespace Gallery_App.Pages
{
    public partial class PhotoPage : ContentPage
    {
        public static string PhotoName { get; set; }
        public static string PhotoDate { get; set; }
        public static string PhotoImage { get; set; }

        public Photo Photo { get; set; }

        public PhotoPage(Photo photo = null)
        {
            if (photo != null)
            {
                Photo = photo;
                PhotoName = photo.Name;
                PhotoDate = photo.Date;
                PhotoImage = photo.Image;
            }
            else
            {
                Photo = new Photo();
            }

            InitializeComponent();
        }
    }
}
