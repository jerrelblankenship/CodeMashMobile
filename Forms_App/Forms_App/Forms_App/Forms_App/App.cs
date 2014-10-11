using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Forms_App
{
    public class App
    {
        public static Page GetMainPage()
        {
            var bControl = new Button
            {
                Text = "Click Me Please",
            };

            var lControl = new Label()
            {
                Text = "Hello, Forms !",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            return new ContentPage
            {
                Content = new StackLayout()
                {
                    Spacing = 10,
                    VerticalOptions = LayoutOptions.End,
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Start,
                    Children = { lControl, bControl }
                },
            };
        }
    }
}
