using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Data.Models.Models;
using Service.Data.Repositories.DayOfWeekRepository;
using Service.Data.Repositories.PaymentRepository;
using Service.Global.Dates;
using Service.Global.Events.Controls;
using Service.Global.Events.Data;
using Service.Global.Events.DateTime;
using Service.Global.Events.Shell;
using UI.CalendarModule.ViewModels.BaseTypes;

namespace UI.CalendarModule.ViewModels
{
    public class CalendarUniformGridViewModel : BindableBase, ICalendarUniformGridViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IPaymentRepository _paymentRepository;
        private DateTime _currentlySelectedDate = DateTime.Now;
        private ObservableCollection<DateCollection> _dayBoxes;
        private ICommand _onGridItemSelectedCommand;
        private int _padding;
        private DateCollection _selectedDateCollection;

        public CalendarUniformGridViewModel(IEventAggregator eventAggregator, IPaymentRepository paymentRepository,
            IDayOfWeekRepository dayOfWeekRepository)
        {
            _paymentRepository = paymentRepository;
            _eventAggregator = eventAggregator;

            eventAggregator.GetEvent<DataCollectionChangedEvent>().Subscribe(OnDateCollectionChangedEventReceived);
            eventAggregator.GetEvent<MonthChangedEvent>().Subscribe(OnMonthChangedEventPublished);
            eventAggregator.GetEvent<SetCurrentMonthEvent>().Subscribe(OnCurrentMonthSetEventPublished);

            OnCurrentMonthSetEventPublished(DateTime.Now);
            DaysInWeekCount = dayOfWeekRepository.GetDaysInWeek();

            OnGridItemSelectedCommand = new DelegateCommand<DateCollection>(OnGridItemSelected);
        }

        public DateCollection SelectedDateCollection
        {
            get => _selectedDateCollection;
            set
            {
                SetProperty(ref _selectedDateCollection, value);
                OnGridItemSelected(value);
            }
        }

        public ObservableCollection<DateCollection> DayBoxes
        {
            get => _dayBoxes;
            set => SetProperty(ref _dayBoxes, value);
        }

        public DateTime CurrentlySelectedDate
        {
            get => _currentlySelectedDate;
            set => SetProperty(ref _currentlySelectedDate, value);
        }

        public int Padding
        {
            get => _padding;
            set => SetProperty(ref _padding, value);
        }

        public ICommand OnGridItemSelectedCommand
        {
            get => _onGridItemSelectedCommand;
            set => SetProperty(ref _onGridItemSelectedCommand, value);
        }

        public int DaysInWeekCount { get; }

        private void OnDateCollectionChangedEventReceived(IEnumerable<DateCollection> obj)
        {
        }

        private void OnGridItemSelected(DateCollection obj)
        {
            _eventAggregator
                .GetEvent<SetTitleForFlyoutAndOpenEvent>().Publish($"{obj.Date.ToString($"MMMM")} {obj.Date.Day}");
            _eventAggregator
                .GetEvent<SetSidePanelOpenAndSendDateCollectionEvent<DateCollection>>().Publish(obj);
            _eventAggregator
                .GetEvent<SetFlyoutControlEvent<string>>().Publish("SelectedDayAccounts");
        }

        private void OnCurrentMonthSetEventPublished(DateTime currentlySelectedDateTime)
        {
            CurrentlySelectedDate = currentlySelectedDateTime;
            SetCalendarToCorrectDayWeekStart(CurrentlySelectedDate);
        }

        private async void SetCalendarToCorrectDayWeekStart(DateTime currentDateTime)
        {
            _eventAggregator.GetEvent<ToggleShellToLoadEvent>().Publish(true);
            DayBoxes = new ObservableCollection<DateCollection>(
                await _paymentRepository.GetPaymentDateCollectionsForMonthAsync(currentDateTime));
            Padding = DataTimeShiftPadding.GetShiftFrom(DayOfWeek.Sunday, DayBoxes.ElementAt(0).Date.DayOfWeek);
            _eventAggregator.GetEvent<ToggleShellToLoadEvent>().Publish(false);
        }

        private void OnMonthChangedEventPublished(int obj)
        {
            CurrentlySelectedDate = CurrentlySelectedDate.AddMonths(obj);
            SetCalendarToCorrectDayWeekStart(CurrentlySelectedDate);
        }
    }
}