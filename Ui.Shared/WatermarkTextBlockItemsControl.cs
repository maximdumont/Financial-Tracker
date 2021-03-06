﻿using System.Windows;
using System.Windows.Controls;

namespace UI.Shared
{
    /// <summary>
    ///     Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///     Step 1a) Using this custom control in a XAML file that exists in the current project.
    ///     Add this XmlNamespace attribute to the root element of the markup file where it is
    ///     to be used:
    ///     xmlns:MyNamespace="clr-namespace:UI.Shared"
    ///     Step 1b) Using this custom control in a XAML file that exists in a different project.
    ///     Add this XmlNamespace attribute to the root element of the markup file where it is
    ///     to be used:
    ///     xmlns:MyNamespace="clr-namespace:UI.Shared;assembly=UI.Shared"
    ///     You will also need to add a project reference from the project where the XAML file lives
    ///     to this project and Rebuild to avoid compilation errors:
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///     Step 2)
    ///     Go ahead and use your control in the XAML file.
    ///     <MyNamespace:WatermarkTextBlockItemsControl />
    /// </summary>
    public class WatermarkTextBlockItemsControl : ItemsControl
    {
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkTextBlockItemsControl),
                new PropertyMetadata(default(string)));

        static WatermarkTextBlockItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBlockItemsControl),
                new FrameworkPropertyMetadata(typeof(WatermarkTextBlockItemsControl)));
        }

        public string WatermarkText
        {
            get => (string) GetValue(WatermarkTextProperty);
            set => SetValue(WatermarkTextProperty, value);
        }
    }
}