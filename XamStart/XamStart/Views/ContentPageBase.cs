﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamStart.Views
{
    public class ContentPageBase : ContentPage
    {

        //protected Settings setting;
        public ContentPageBase() : base()
        { 
           
        }

        protected void CustomToastMessage(string title, string message)
        {
            // need to implement
        }
        public async Task DummyTask()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(0)).ConfigureAwait(false);
        }
        protected void Track(string str)
        {
            // if you are using analytics, place your analytics code here
        }        

        protected double GetDevicePaddingWhenToolbarIsUsed()
        {
            double topPadding;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    topPadding = 40;
                    break;
                default:
                    topPadding = 0;
                    break;
            }

            return topPadding;
        }

    }
}
