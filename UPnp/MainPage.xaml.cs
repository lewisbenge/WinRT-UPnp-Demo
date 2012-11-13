using System;
using UPnp.Sevices;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UPnp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DeviceList.Text = String.Empty;
        }

        private void ClientOnDeviceFound(object sender, DeviceFoundEventArgs deviceFoundEventArgs)
        {
          Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
                                                                 {
                                                                     DeviceList.Text += deviceFoundEventArgs.Device.DeviceType.friendlyName + Environment.NewLine;
                                                                 });

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var client = new SSDPClient();
            client.SearchForDevices();
            client.DeviceFound += ClientOnDeviceFound;
        }
    }
}
