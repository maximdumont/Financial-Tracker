using System;
using System.Collections.Generic;
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

namespace Ui.Shared
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Ui.Shared"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Ui.Shared;assembly=Ui.Shared"
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
    ///     <MyNamespace:IconButton/>
    ///
    /// </summary>
    public class IconButton : Control
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton),
                new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public static readonly DependencyProperty TextBlockValueProperty = DependencyProperty.Register(
            "TextBlockValue", typeof(string), typeof(IconButton), new PropertyMetadata(default(string)));

        public string TextBlockValue
        {
            get => (string) GetValue(TextBlockValueProperty);
            set => SetValue(TextBlockValueProperty, value);
        }

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            "IconKind", typeof(string), typeof(IconButton), new PropertyMetadata(default(string)));

        public string IconKind
        {
            get => (string) GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }

        public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(
            "StringFormat", typeof(string), typeof(IconButton), new PropertyMetadata(default(string)));

        public string StringFormat
        {
            get => (string) GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }
    }
}