using Xamarin.Forms;

namespace ValidationCallback
{
    public class HomePageCS : ContentPage
    {
        public static readonly BindableProperty AngleProperty = BindableProperty.Create("Angle", typeof(double), typeof(HomePage), 0.0, validateValue: IsValidValue);

        public double Angle
        {
            get
            {
                return (double)GetValue(AngleProperty);
            }
            set
            {
                if (IsValidValue(null, value))
                {
                    SetValue(AngleProperty, value);
                }
            }
        }

        public HomePageCS()
        {
            BindingContext = this;

            var angleEntry = new Entry { WidthRequest = 50 };
            angleEntry.SetBinding(Entry.TextProperty, "Angle");

            var image = new Image { VerticalOptions = LayoutOptions.CenterAndExpand };
            image.Source = ImageSource.FromFile("waterfront.jpg");
            image.SetBinding(VisualElement.RotationProperty, "Angle");

            Content = new StackLayout
            {
                Margin = new Thickness(0, 35, 0, 0),
                Children =
                {
                    new Label
                    {
                        Text = "Bindable Property Validation Callback Demo",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Label { Text = "Rotation angle:" },
                            angleEntry
                        }
                    },
                    image
                }
            };
        }

        static bool IsValidValue(BindableObject view, object value)
        {
            double result;
            double.TryParse(value.ToString(), out result);
            return (result >= 0 && result <= 360);
        }
    }
}
