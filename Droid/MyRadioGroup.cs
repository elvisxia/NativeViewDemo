using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace NativeSwitch.Droid
{
    public class MyRadioGroup:RadioGroup
    {
        //Every native control in xaml will be wrapped in NativeViewWrapper, so we want to pass a NativeViewWrapper list here
        IList<NativeViewWrapper> items;
        public IList<NativeViewWrapper> ItemsSource
        {
            get {
                items.Clear();
                for (int i = 0; i < this.ChildCount; i++)
                {
                    items.Add(new NativeViewWrapper(this.GetChildAt(i)));
                }
                return items;
            }
            set {
                //
                if (items != value)
                {
                    items = value;
                    this.RemoveAllViews();
                    foreach (NativeViewWrapper wrapper in items)
                    {
                        this.AddView(wrapper.NativeView);
                    }
                }
            }
        }
        public MyRadioGroup(Context context) : base(context)
        {
            items = new List<NativeViewWrapper>();
        }
    }
}