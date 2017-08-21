using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Java.Interop;
using Android.Content;
using Android.Support.V7.App;

namespace CardFormQs
{
    [Activity(Label = "CardFormQs", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.sample_activity_layout);
        }

        [Export("onClick")]
        public void OnClick(View v)
        {
            var destination = v.Id == Resource.Id.material_light_theme_form
                               ? typeof(LightThemeActivity)
                               : typeof(DarkThemeActivity);

            StartActivity(new Intent(this, destination));
        }
    }
}

