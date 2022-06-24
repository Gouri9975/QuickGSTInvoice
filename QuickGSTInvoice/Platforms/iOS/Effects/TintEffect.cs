using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using QuickGSTInvoice.Effects;
using QuickGSTInvoice.Platforms.iOS.Effects;
using System.ComponentModel;
/*using UIKit*/

[assembly: ResolutionGroupName("QuickGSTInvoice")]
[assembly: ExportEffect(typeof(TintColorEffect), nameof(TintEffect))]

namespace QuickGSTInvoice.Platforms.iOS.Effects
{
    public class TintColorEffect : PlatformEffect
    {
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            string propertyName = args.PropertyName;
            if (propertyName == TintEffect.TintColorProperty.PropertyName || propertyName == nameof(UIWindow.Window))
            {
                UpdateColor();
            }
        }

        protected override void OnAttached()
        {
            UpdateColor();
        }

        protected override void OnDetached()
        {
        }

        void OnImageViewWindowChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        void UpdateColor()
        {
            try
            {
                if (Control is UIImageView imageView && imageView.Image is UIImage image)
                {
                    var color = TintEffect.GetTintColor(Element);
                    imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                    imageView.TintColor = color.ToUIColor();
                }
            }
            catch
            {
                //do nothing
            }
        }
    }
}