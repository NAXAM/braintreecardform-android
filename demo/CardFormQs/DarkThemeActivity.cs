using System;
using Android.App;

namespace CardFormQs
{
	[Activity(Theme = "@style/DarkTheme")]
    public class DarkThemeActivity : BaseCardFormActivity
    {
        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);

            if (mCardForm.IsCardScanningAvailable)
			{
                MenuInflater.Inflate(Resource.Menu.card_io_dark, menu);
			}

			return true;
        }
    }
}
