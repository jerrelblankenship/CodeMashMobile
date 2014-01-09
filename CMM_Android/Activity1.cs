using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CMM_Android
{
    using CMM.DataAccessLayer;
    using CMM.WebServiceLayer;

    [Activity(Label = "CMM_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;
        private TextView cName = null;
        private TextView nation = null;
        private TextView capital = null;
        private TextView population = null;
        private TextView currency = null;
        private TextView region = null;
        private TextView subregion = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button button2 = FindViewById<Button>(Resource.Id.LoadDB);
            cName = FindViewById<TextView>(Resource.Id.countryName);
            nation = FindViewById<TextView>(Resource.Id.nationality);
            capital = FindViewById<TextView>(Resource.Id.capital);
            population = FindViewById<TextView>(Resource.Id.population);
            currency = FindViewById<TextView>(Resource.Id.currency);
            region = FindViewById<TextView>(Resource.Id.region);
            subregion = FindViewById<TextView>(Resource.Id.subregion);

            button.Click += delegate
            {
                var restProcessor = new RestProcessor();
                restProcessor.GetCountry();
            };

            button2.Click += delegate
            {
                var repo = new DataRepository();
                var country = repo.GetCountry("London");

                if (country != null)
                {
                    cName.Text = "Country Name  ->  " + country.Name;
                    nation.Text = nation.Text + country.Nationality;
                    capital.Text = capital.Text + country.Capital;
                    population.Text = population.Text + country.Population;
                    currency.Text = currency.Text + country.Currency;
                    region.Text = region.Text + country.Region;
                    subregion.Text = subregion.Text + country.Subregion;
                }
                else
                {
                    cName.Text = "Country not found.";
                }
            };
        }
    }
}

