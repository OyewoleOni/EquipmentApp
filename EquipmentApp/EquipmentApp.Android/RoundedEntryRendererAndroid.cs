﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using EquipmentApp.CustomRenders;
using EquipmentApp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererAndroid))]
namespace EquipmentApp.Droid
{
    [Obsolete]
    public class RoundedEntryRendererAndroid : EntryRenderer
    {
        RoundedEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (RoundedEntry)this.Element;
            var editText = this.Control;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(60f);
            gradientDrawable.SetStroke(2, Android.Graphics.Color.Gray);
            gradientDrawable.SetColor(Android.Graphics.Color.White);
            editText.SetBackground(gradientDrawable);

            editText.SetPadding(15, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            //if(e.OldElement == null)
            //{
            //   var gradientDrawable = new GradientDrawable();
            //    gradientDrawable.SetCornerRadius(60f);
            //    gradientDrawable.SetStroke(2, Android.Graphics.Color.Gray);
            //    gradientDrawable.SetColor(Android.Graphics.Color.White);
            //    Control.SetBackground(gradientDrawable);

            //    Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

            //}
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth , element.ImageHeight , true));
        }
    }
}