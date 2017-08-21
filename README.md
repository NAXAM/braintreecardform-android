# Card Form - Xamarin Android Binding Library

Card Form is a ready made card form layout that can be included in your app making it easy to
accept credit and debit cards.

## Adding It To Your Project

```
Install-Package Naxam.BraintreeCardForm.Droid
```

## Usage

Card Form is a LinearLayout that you can add to your layout:

```xml
<com.braintreepayments.cardform.view.CardForm
    android:id="@+id/card_form"
    android:layout_width="match_parent"
    android:layout_height="match_parent" />
```

To initialize the view and change which fields are required for the user to enter, use the required
field methods and `CardForm#Setup(Activity activity)`.

```c#
CardForm cardForm = (CardForm)FindViewById(Resource.Id.card_form);;
cardForm.CardRequired(true)
        .ExpirationRequired(true)
        .CvvRequired(true)
        .PostalCodeRequired(true)
        .MobileNumberRequired(true)
        .MobileNumberExplanation("Make sure SMS is enabled for this mobile number")
        .ActionLabel(GetString(Resource.String.purchase))
        .Setup(this);
```

To access the values in the form, there are getters for each field:

```c#
var cardNumber = cardForm.CardNumber;
var expirationMonth = cardForm.ExpirationMonth;
var expirationYear = cardForm.ExpirationYear;
var cvv = cardForm.Cvv;
var postcode = cardForm.PostalCode;
var countryCode = cardForm.CountryCode;
var mobileNumber = cardForm.MobileNumber;
```

To check if `CardForm` is valid call `CardForm#IsValid`. To validate each required field
and show the user which fields are incorrect, call `CardForm#Validate()`.

To set custom error messages on a field call `CardForm#setCardNumberError(String)` on the given field.

Additionally `CardForm` has 4 available listeners:

* `CardForm#SetOnCardFormValidListener` called when the form changes state from valid to invalid or invalid to valid.
* `CardForm#SetOnCardFormSubmitListener` called when the form should be submitted.
* `CardForm#SetOnFormFieldFocusedListener` called when a field in the form is focused.
* `CardForm#SetOnCardTypeChangedListener` called when the `CardType` in the form changes.

## card.io

The card form is compatible with [card.io](https://github.com/card-io/card.io-Android-SDK).

To use card.io, add the dependency in your `packages.config`:

```xml
<package id="Xamarin.CardIO.Android" version="5.5.1" targetFramework="monoandroid71" />
```

Check if card.io is available for use:

```c#
cardForm.IsCardScanningAvailable;
```

Scan a card:

```c#
cardForm.ScanCard(activity);
```

## Example

![](https://github.com/braintree/android-card-form/blob/master/Sample/screenshot.png)

## Styling

The card form uses the [Android Design Support Library](http://android-developers.blogspot.com/2015/05/android-design-support-library.html)
for styling and floating labels. All card form inputs use the `colorAccent` theme attribute, when present,
to set their focused color. For more information on the `colorAccent` attribute, see
[Using the Material Theme](https://developer.android.com/training/material/theme.html). Additional
styling, such as the error color (`textErrorColor`) can be set in your theme and will be picked up
by the card form.

The included [sample app](https://github.com/naxam/braintreecardform-android-binding/tree/master/demo) has
examples with a light theme and dark theme.

**Note:** Any `Activity` using the card form must use a style that is a Theme.AppCompat theme or
descendant (defines `android.support.v7.appcompat.R.attr.colorPrimary`). This is a requirement of
the [Android Design Support Library](http://android-developers.blogspot.com/2015/05/android-design-support-library.html).
If this is a problem in your usage of the card form, please [file an issue](https://github.com/braintree/android-card-form/issues)
and we will look further into workarounds for this.

## License

Card Form is open source and available under the MIT license. See the [LICENSE](LICENSE) file for
more info.