﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EquipmentApp.CustomRenders
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty BorderColorProperty =
     BindableProperty.Create(nameof(BorderColor),
         typeof(Color), typeof(CustomEntry), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        [Obsolete]
        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(int),
            typeof(CustomEntry), Device.OnPlatform(1, 2, 2));

        // Gets or sets BorderWidth value  
        [Obsolete]
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        [Obsolete]
        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(double), typeof(CustomEntry), Device.OnPlatform<double>(6, 7, 7));

        // Gets or sets CornerRadius value  
        [Obsolete]
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
        BindableProperty.Create(nameof(IsCurvedCornersEnabled),
            typeof(bool), typeof(CustomEntry), true);
        // Gets or sets IsCurvedCornersEnabled value  
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
    }
}
