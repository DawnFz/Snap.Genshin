﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DGP.Genshin.Controls.Converters
{
    /// <summary>
    /// 数据可见性转换器，当不存在数据时可见
    /// </summary>
    public class DataVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
