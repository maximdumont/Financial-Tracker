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

        public static readonly DependencyProperty WatermarkTextHorizontalAlignmentProperty =
            DependencyProperty.Register("WatermarkTextHorizontalAlignment", typeof(HorizontalAlignment),
                typeof(WatermarkDropDownBox), new PropertyMetadata(HorizontalAlignment.Center));

        public static readonly DependencyProperty WatermarkTextFontSizeProperty =
            DependencyProperty.Register("WatermarkTextFontSize", typeof(double), typeof(WatermarkDropDownBox),
                new PropertyMetadata(15.0));

        public static readonly DependencyProperty WatermarkTextVerticalAlignmentProperty =
            DependencyProperty.Register("WatermarkTextVerticalAlignment", typeof(VerticalAlignment),
                typeof(WatermarkDropDownBox), new PropertyMetadata(VerticalAlignment.Center));

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable<object>),
                typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(IEnumerable<object>)));

        public static readonly DependencyProperty SelectedComboBoxItemProperty =
            DependencyProperty.Register("SelectedComboBoxItem", typeof(object), typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(object)));

        public static readonly DependencyProperty ComboBoxOuterMarginProperty =
            DependencyProperty.Register("ComboBoxOuterMargin", typeof(Thickness), typeof(WatermarkDropDownBox),
                new PropertyMetadata(new Thickness(2)));

        public static readonly DependencyProperty ComboBoxHorizontalContentAlignmentProperty =
            DependencyProperty.Register("ComboBoxHorizontalContentAlignment", typeof(HorizontalAlignment),
                typeof(WatermarkDropDownBox), new PropertyMetadata(HorizontalAlignment.Center));

        public static readonly DependencyProperty OnComboBoxItemSelectedCommandProperty =
            DependencyProperty.Register("OnComboBoxItemSelectedCommand", typeof(ICommand), typeof(WatermarkDropDownBox),
                new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty LeftSideColumnWidthProperty =
            DependencyProperty.Register("LeftSideColumnWidth", typeof(string), typeof(WatermarkDropDownBox),
                new PropertyMetadata(".25*"));

        public static readonly DependencyProperty RightSideColumnWidthProperty =
            DependencyProperty.Register("RightSideColumnWidth", typeof(string), typeof(WatermarkDropDownBox),
                new PropertyMetadata("*"));

        public static readonly DependencyProperty ComboBoxFontSizeProperty =
            DependencyProperty.Register("ComboBoxFontSize", typeof(double), typeof(WatermarkDropDownBox),
                new PropertyMetadata(20.0));

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

        public HorizontalAlignment WatermarkTextHorizontalAlignment
        {
            get => (HorizontalAlignment) GetValue(WatermarkTextHorizontalAlignmentProperty);
            set => SetValue(WatermarkTextHorizontalAlignmentProperty, value);
        }

        public double WatermarkTextFontSize
        {
            get => (double) GetValue(WatermarkTextFontSizeProperty);
            set => SetValue(WatermarkTextFontSizeProperty, value);
        }

        public VerticalAlignment WatermarkTextVerticalAlignment
        {
            get => (VerticalAlignment) GetValue(WatermarkTextVerticalAlignmentProperty);
            set => SetValue(WatermarkTextVerticalAlignmentProperty, value);
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

        public Thickness ComboBoxOuterMargin
        {
            get => (Thickness) GetValue(ComboBoxOuterMarginProperty);
            set => SetValue(ComboBoxOuterMarginProperty, value);
        }

        public HorizontalAlignment ComboBoxHorizontalContentAlignment
        {
            get => (HorizontalAlignment) GetValue(ComboBoxHorizontalContentAlignmentProperty);
            set => SetValue(ComboBoxHorizontalContentAlignmentProperty, value);
        }

        public ICommand OnComboBoxItemSelectedCommand
        {
            get => (ICommand) GetValue(OnComboBoxItemSelectedCommandProperty);
            set => SetValue(OnComboBoxItemSelectedCommandProperty, value);
        }

        public string LeftSideColumnWidth
        {
            get => (string) GetValue(LeftSideColumnWidthProperty);
            set => SetValue(LeftSideColumnWidthProperty, value);
        }

        public string RightSideColumnWidth
        {
            get => (string) GetValue(RightSideColumnWidthProperty);
            set => SetValue(RightSideColumnWidthProperty, value);
        }

        public double ComboBoxFontSize
        {
            get => (double) GetValue(ComboBoxFontSizeProperty);
            set => SetValue(ComboBoxFontSizeProperty, value);
        }
    }
}