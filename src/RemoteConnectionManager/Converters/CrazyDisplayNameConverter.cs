﻿using RemoteConnectionManager.Core;
using RemoteConnectionManager.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Layout;

namespace RemoteConnectionManager.Converters
{
    public class CrazyDisplayNameConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var textBlock = (TextBlock) value;
            var connectionSettings = ((IConnection)((LayoutDocument)textBlock.DataContext).Content).ConnectionSettings;
            var civm = ViewModelLocator.Locator
                .Settings.Items
                .Single(x => x.CategoryItem.ConnectionSettings == connectionSettings);

            var binding = new Binding("DisplayName");
            binding.Source = civm;

            textBlock.SetBinding(TextBlock.TextProperty, binding);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}