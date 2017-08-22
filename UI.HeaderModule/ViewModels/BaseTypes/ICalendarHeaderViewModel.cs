using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace UI.HeaderModule.ViewModels.BaseTypes
{
    public interface ICalendarHeaderViewModel
    {
        DateTime CurrentlySelectedDate { get; set; }
        decimal PostiveAmountForMonth { get; set; }
        decimal NegativeAmountForMonth { get; set; }
        ICommand IncreaseMonthCommand { get; }
        ICommand DecreaseMonthCommand { get; }
        ICommand ResetToCurrentMonthCommand { get; }
        Thickness IconButtonMargin { get; set; }
        Thickness ArrowBoxMargin { get; set; }
        Brush ThumbsDownColor { get; set; }
        Brush ThumbsUpColor { get; set; }
    }
}