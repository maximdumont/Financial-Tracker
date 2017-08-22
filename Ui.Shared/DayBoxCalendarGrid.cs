using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Shared
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:UI.Shared"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:UI.Shared;assembly=UI.Shared"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:DayBoxCalendarGrid/>
    ///
    /// </summary>
    public class DayBoxCalendarGrid : ItemsControl
    {
        static DayBoxCalendarGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DayBoxCalendarGrid),
                new FrameworkPropertyMetadata(typeof(DayBoxCalendarGrid)));
        }

        public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register(
            "SelectionMode", typeof(string), typeof(DayBoxCalendarGrid), new PropertyMetadata(default(string)));

        public string SelectionMode
        {
            get => (string) GetValue(SelectionModeProperty);
            set => SetValue(SelectionModeProperty, value);
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(DayBoxCalendarGrid), new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get => (object) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }


        public static readonly DependencyProperty FirstColumnProperty = DependencyProperty.Register(
            "FirstColumn", typeof(int), typeof(DayBoxCalendarGrid), new PropertyMetadata(default(int)));

        public int FirstColumn
        {
            get => (int) GetValue(FirstColumnProperty);
            set => SetValue(FirstColumnProperty, value);
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns", typeof(int), typeof(DayBoxCalendarGrid), new PropertyMetadata(default(int)));

        public int Columns
        {
            get => (int) GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
    }
}