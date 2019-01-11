using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using System.Diagnostics;

namespace LocationApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Location : ContentPage
	{
		public Location ()
		{
			InitializeComponent ();
		}

        public async void getLocation()
        {
            var locator = CrossGeolocator.Current;
            try
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (locator.IsGeolocationAvailable)
                    {
                        var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                        Console.WriteLine("Position Status: {0}", position.Timestamp);
                        Console.WriteLine("Position Latitude: {0}", position.Latitude);
                        Console.WriteLine("Position Longitude: {0}", position.Longitude);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnGetLocation_Clicked(object sender, EventArgs e)
        {
            getLocation();
        }
    }
}