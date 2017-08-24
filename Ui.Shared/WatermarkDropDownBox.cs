using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
    ///     <MyNamespace:WatermarkDropDownBox />
    /// </summary>
    public class WatermarkDropDownBox : Control
    {
        public static readonly DependencyProperty BorderMarginProperty =
            DependencyProperty.Register("BorderMargin", typeof(Thickness), typeof(WatermarkDropDownBox),
                new PropertyMetadata(new Thickness(5, 0, 5, 0)));

        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable<object>),
                typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(IEnumerable<object>)));

        public static readonly DependencyProperty SelectedComboBoxItemProperty =
            DependencyProperty.Register("SelectedComboBoxItem", typeof(object), typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(object)));

        public static readonly DependencyProperty OnComboBoxItemSelectedCommandProperty =
            DependencyProperty.Register("OnComboBoxItemSelectedCommand", typeof(ICommand), typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(ICommand)));

        static WatermarkDropDownBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkDropDownBox),
                new FrameworkPropertyMetadata(typeof(WatermarkDropDownBox)));
        }

        public Thickness BorderMargin
        {
            get => (Thickness) GetValue(BorderMarginProperty);
            set => SetValue(BorderMarginProperty, value);
        }

        public string WatermarkText
        {
            get => (string) GetValue(WatermarkTextProperty);
            set => SetValue(WatermarkTextProperty, value);
        }

        public IEnumerable<object> ComboBoxItemsSource
        {
            get => (IEnumerable<object>) GetValue(ComboBoxItemsSourceProperty);
            set => SetValue(ComboBoxItemsSourceProperty, value);
        }

        public object SelectedComboBoxItem
        {
            get => GetValue(SelectedComboBoxItemProperty);
            set => SetValue(SelectedComboBoxItemProperty, value);
        }

        public ICommand OnComboBoxItemSelectedCommand
        {
            get => (ICommand) GetValue(OnComboBoxItemSelectedCommandProperty);
            set => SetValue(OnComboBoxItemSelectedCommandProperty, value);
        }
    }
}