using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Global.Events;
using Service.Global.Events.DateTime;
using UI.HeaderModule.ViewModels.BaseTypes;

namespace UI.HeaderModule.ViewModels
{
    public class CalendarHeaderViewModel : BindableBase, ICalendarHeaderViewModel
    {
        private DateTime _currentlySelectedDate = DateTime.Now;
        private decimal _postiveAmountForMonth;
        private decimal _negativeAmountForMonth;

        private readonly IEventAggregator _eventAggregator;

        public CalendarHeaderViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            IncreaseMonthCommand = new DelegateCommand(OnIncreaseMonthCommandClicked);
            DecreaseMonthCommand = new DelegateCommand(OnDecreasedMonthCommandClicked);
            ResetToCurrentMonthCommand = new DelegateCommand(OnResetToCurrentMonthCommandClicked);

            eventAggregator.GetEvent<SetCurrentMonthEvent>().Publish(DateTime.Now);
        }

        private void OnResetToCurrentMonthCommandClicked()
        {
            _eventAggregator?.GetEvent<SetCurrentMonthEvent>().Publish(DateTime.Now);
            CurrentlySelectedDate = DateTime.Now;
        }

        private void OnDecreasedMonthCommandClicked()
        {
            _eventAggregator?.GetEvent<MonthChangedEvent>().Publish(MonthChangedEvent.PreviousMonth);
            CurrentlySelectedDate = CurrentlySelectedDate.AddMonths(MonthChangedEvent.PreviousMonth);
        }

        private void OnIncreaseMonthCommandClicked()
        {
            _eventAggregator?.GetEvent<MonthChangedEvent>().Publish(MonthChangedEvent.NextMonth);
            CurrentlySelectedDate = CurrentlySelectedDate.AddMonths(MonthChangedEvent.NextMonth);
        }

        public ICommand IncreaseMonthCommand { get; }
        public ICommand DecreaseMonthCommand { get; }
        public ICommand ResetToCurrentMonthCommand { get; }

        public DateTime CurrentlySelectedDate
        {
            get => _currentlySelectedDate;
            set => SetProperty(ref _currentlySelectedDate, value);
        }

        public decimal PostiveAmountForMonth
        {
            get => _postiveAmountForMonth;
            set => SetProperty(ref _negativeAmountForMonth, value);
        }

        public decimal NegativeAmountForMonth
        {
            get => _negativeAmountForMonth;
            set => SetProperty(ref _postiveAmountForMonth, value);
        }

        public Thickness IconButtonMargin { get; set; } = new Thickness(1, 0, 0, 1);
        public Thickness ArrowBoxMargin { get; set; } = new Thickness(0, 2, 2, 0);

        public Brush ThumbsDownColor { get; set; } = Brushes.Red;
        public Brush ThumbsUpColor { get; set; } = Brushes.Green;
    }
}