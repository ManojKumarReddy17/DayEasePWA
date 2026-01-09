using DayEaseServices.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DayEaseUserApp.Layout
{
    public partial class MainLayout : IDisposable
    {
        [Inject] NavigationManager Nav { get; set; }
        [Inject] CartService Cart { get; set; }

        protected override void OnInitialized()
        {
            Nav.LocationChanged += OnLocationChanged;
        }

        private async void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            try
            {
                await InvokeAsync(async () =>
                {
                    await Cart.SyncCartToBackendAsync();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            Nav.LocationChanged -= OnLocationChanged;
        }
    }
}
