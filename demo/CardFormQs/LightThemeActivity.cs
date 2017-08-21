using System;
using Android.App;

namespace CardFormQs
{
    [Activity(Theme = "@style/LightTheme")]
    public class LightThemeActivity : BaseCardFormActivity
	{
		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			base.OnCreateOptionsMenu(menu);

			if (mCardForm.IsCardScanningAvailable)
			{
				MenuInflater.Inflate(Resource.Menu.card_io, menu);
			}

			return true;
		}
    }
}
