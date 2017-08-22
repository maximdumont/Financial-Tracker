using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Global.Events;
using UI.WindowCommandsModule.ViewModels.BaseTypes;

namespace UI.WindowCommandsModule.ViewModels
{
    public class RightWindowCommandsViewModel : BindableBase, IRightWindowCommandsViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private ICommand _gearIconClickedCommand;

        private ICommand _personIconClickedCommand;

        public RightWindowCommandsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            PersonIconClickedCommand = new DelegateCommand(OnPersonIconClickedPressed);
            GearIconClickedCommand = new DelegateCommand(OnGearIconClickedPressed);
        }

        public ICommand PersonIconClickedCommand
        {
            get => _personIconClickedCommand;
            set => SetProperty(ref _personIconClickedCommand, value);
        }

        public ICommand GearIconClickedCommand
        {
            get => _gearIconClickedCommand;
            set => SetProperty(ref _gearIconClickedCommand, value);
        }

        private void OnGearIconClickedPressed()
        {
            _eventAggregator.GetEvent<SetTitleForFlyoutAndOpenEvent>().Publish("Settings");
            _eventAggregator.GetEvent<SetFlyoutControlEvent<string>>().Publish("Settings");
        }

        private void OnPersonIconClickedPressed()
        {
            _eventAggregator.GetEvent<SetTitleForFlyoutAndOpenEvent>().Publish("Personal");
            _eventAggregator.GetEvent<SetFlyoutControlEvent<string>>().Publish("Personal");
        }
    }
}