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
    ///     <MyNamespace:ConfirmOrCancelGrid/>
    ///
    /// </summary>
    public class ConfirmOrCancelGrid : ItemsControl
    {
        static ConfirmOrCancelGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConfirmOrCancelGrid),
                new FrameworkPropertyMetadata(typeof(ConfirmOrCancelGrid)));
        }

        public static readonly DependencyProperty GridMarginProperty = DependencyProperty.Register(
            "GridMargin", typeof(Thickness), typeof(ConfirmOrCancelGrid), new PropertyMetadata(default(Thickness)));

        public Thickness GridMargin
        {
            get => (Thickness) GetValue(GridMarginProperty);
            set => SetValue(GridMarginProperty, value);
        }

        public static readonly DependencyProperty GridVerticalAlignmentProperty = DependencyProperty.Register(
            "GridVerticalAlignment", typeof(string), typeof(ConfirmOrCancelGrid),
            new PropertyMetadata(default(string)));

        public string GridVerticalAlignment
        {
            get => (string) GetValue(GridVerticalAlignmentProperty);
            set => SetValue(GridVerticalAlignmentProperty, value);
        }
    }
}