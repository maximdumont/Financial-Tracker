using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Data.Models.Models;
using Service.Data.Repositories.PaymentRepository;
using Service.Global.Events.Controls;
using UI.SidePanelModule.ViewModels.BaseTypes;

namespace UI.SidePanelModule.ViewModels
{
    public class SelectedDayAccountsSidePaneViewModel : BindableBase, ISelectedDayAccountsSidePaneViewModel
    {
        private readonly IPaymentRepository _paymentRepository;
        private ICommand _addButtonClickedCommand;
        private ICommand _addNewPaymentItemCancelledCommand;
        private ICommand _addNewPaymentItemCommand;
        private double _computedBalance;
        private ICommand _deleteCurrentItemCommand;
        private IEnumerable<Payment> _negativePayments;
        private double _newPaymentAmount;
        private string _newPaymentName;
        private IEnumerable<Payment> _positivePayments;
        private DateCollection _receivedDateCollection;
        private bool _setAddPaymentGridVisible;
        private bool _setLoadIconToActive;

        public SelectedDayAccountsSidePaneViewModel(IEventAggregator eventAggregator,
            IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
            eventAggregator
                .GetEvent<SetSidePanelOpenAndSendDateCollectionEvent<DateCollection>>()
                .Subscribe(OnSetSidePanelOpenAndSendDateCollectionEventReceivedOrUpdated);

            AddButtonClickedCommand = new DelegateCommand(OnAddButtonClickedCommandClicked);
            AddNewPaymentItemCommand = new DelegateCommand(OnAddNewPaymentItemCommandClicked);
            DeleteCurrentItemCommand = new DelegateCommand<Payment>(OnDeletePaymentButtonClicked);
            AddNewPaymentItemCancelledCommand =
                new DelegateCommand<Payment>(OnAddNewPaymentItemCancelledOrPaymentScreenResetCommandClicked);
        }

        public DateCollection ReceivedDateCollection
        {
            get => _receivedDateCollection;
            set => SetProperty(ref _receivedDateCollection, value);
        }

        public IEnumerable<Payment> OrderedPayments
        {
            get => _negativePayments;
            set => SetProperty(ref _negativePayments, value);
        }

        public double ComputedBalance
        {
            get => _computedBalance;
            set => SetProperty(ref _computedBalance, value);
        }

        public ICommand AddButtonClickedCommand
        {
            get => _addButtonClickedCommand;
            set => SetProperty(ref _addButtonClickedCommand, value);
        }

        public ICommand AddNewPaymentItemCommand
        {
            get => _addNewPaymentItemCommand;
            set => SetProperty(ref _addNewPaymentItemCommand, value);
        }

        public ICommand DeleteCurrentItemCommand
        {
            get => _deleteCurrentItemCommand;
            set => SetProperty(ref _deleteCurrentItemCommand, value);
        }

        public bool SetAddPaymentGridVisible
        {
            get => _setAddPaymentGridVisible;
            set => SetProperty(ref _setAddPaymentGridVisible, value);
        }

        public string NewPaymentName
        {
            get => _newPaymentName;
            set => SetProperty(ref _newPaymentName, value);
        }

        public double NewPaymentAmount
        {
            get => _newPaymentAmount;
            set => SetProperty(ref _newPaymentAmount, value);
        }

        public ICommand AddNewPaymentItemCancelledCommand
        {
            get => _addNewPaymentItemCancelledCommand;
            set => SetProperty(ref _addNewPaymentItemCancelledCommand, value);
        }

        public bool SetLoadIconToActive
        {
            get => _setLoadIconToActive;
            set => SetProperty(ref _setLoadIconToActive, value);
        }

        private void OnAddNewPaymentItemCancelledOrPaymentScreenResetCommandClicked(Payment obj)
        {
            NewPaymentName = string.Empty;
            NewPaymentAmount = 0.00;
            SetAddPaymentGridVisible = !SetAddPaymentGridVisible;
        }

        private async void OnDeletePaymentButtonClicked(Payment obj)
        {
            await _paymentRepository.RemovePaymentAsync(ReceivedDateCollection.Date, obj);
            OnSetSidePanelOpenAndSendDateCollectionEventReceivedOrUpdated(ReceivedDateCollection);
        }

        private async void OnAddNewPaymentItemCommandClicked()
        {
            await _paymentRepository.AddPaymentAsync(ReceivedDateCollection.Date,
                new Payment(NewPaymentName, NewPaymentAmount));
            OnSetSidePanelOpenAndSendDateCollectionEventReceivedOrUpdated(ReceivedDateCollection);
            SetAddPaymentGridVisible = !SetAddPaymentGridVisible;
        }

        private void OnAddButtonClickedCommandClicked()
        {
            SetAddPaymentGridVisible = !SetAddPaymentGridVisible;
        }

        private async void OnSetSidePanelOpenAndSendDateCollectionEventReceivedOrUpdated(
            DateCollection receivedDateCollection)
        {
            SetLoadIconToActive = true;
            ReceivedDateCollection = receivedDateCollection;

            var paymentsForCalendarDay =
                await _paymentRepository.GetPaymentsForDateTimeCollectionAsync(ReceivedDateCollection);
            SetLoadIconToActive = false;
            if (paymentsForCalendarDay == null)
                return;
            OrderedPayments = paymentsForCalendarDay.OrderBy(m => m.PaymentAmount);
            ComputedBalance = paymentsForCalendarDay.Sum(m => m.PaymentAmount);
        }
    }
}