using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Braintreepayments.Cardform;
using Com.Braintreepayments.Cardform.Utils;
using Com.Braintreepayments.Cardform.View;

namespace CardFormQs
{
    public class BaseCardFormActivity : AppCompatActivity, IOnCardFormSubmitListener, CardEditText.IOnCardTypeChangedListener
    {
        static readonly CardType[] SUPPORTED_CARD_TYPES = {
            CardType.Visa, CardType.Mastercard, CardType.Discover,
            CardType.Amex, CardType.DinersClub, CardType.Jcb,
            CardType.Maestro, CardType.Unionpay
        };

        SupportedCardTypesView mSupportedCardTypesView;

        protected CardForm mCardForm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.card_form);

            mSupportedCardTypesView = (SupportedCardTypesView)FindViewById(Resource.Id.supported_card_types);
            mSupportedCardTypesView.SetSupportedCardTypes(SUPPORTED_CARD_TYPES);

            mCardForm = (CardForm)FindViewById(Resource.Id.card_form);
            mCardForm.CardRequired(true)
                    .ExpirationRequired(true)
                    .CvvRequired(true)
                    .PostalCodeRequired(true)
                    .MobileNumberRequired(true)
                    .MobileNumberExplanation("Make sure SMS is enabled for this mobile number")
                    .ActionLabel(GetString(Resource.String.purchase))
                    .Setup(this);
            mCardForm.SetOnCardFormSubmitListener(this);
            mCardForm.SetOnCardTypeChangedListener(this);

            // Warning: this is for development purposes only and should never be done outside of this example app.
            // Failure to set FLAG_SECURE exposes your app to screenshots allowing other apps to steal card information.
            Window.ClearFlags(Android.Views.WindowManagerFlags.Secure);
        }

        public void OnCardTypeChanged(CardType cardType)
        {
            if (cardType == CardType.Empty)
            {
                mSupportedCardTypesView.SetSupportedCardTypes(SUPPORTED_CARD_TYPES);
            }
            else
            {
                mSupportedCardTypesView.SetSelected(cardType);
            }
        }

        public void OnCardFormSubmit()
        {
            if (mCardForm.IsValid)
            {
                Toast.MakeText(this, Resource.String.valid, ToastLength.Short).Show();
            }
            else
            {
                mCardForm.Validate();
                Toast.MakeText(this, Resource.String.invalid, ToastLength.Short).Show();
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnOptionsItemSelected(item);

            if (item.ItemId == Resource.Id.card_io_item)
            {
                mCardForm.ScanCard(this);
                return true;
            }

            return false;
        }
    }
}
