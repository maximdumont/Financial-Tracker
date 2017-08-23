using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Service.Global.Events;
using Service.Global.Events.Controls;
using UI.WindowCommandsModule.ViewModels.BaseTypes;

namespace UI.WindowCommandsModule.ViewModels
{
    public class LeftWindowCommandsViewModel : BindableBase, ILeftWindowCommandsViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private ICommand _infoButtonClickedCommand;

        public LeftWindowCommandsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InfoButtonClickedCommand = new DelegateCommand(OnInfoButtonClicked);
        }

        private void OnInfoButtonClicked()
        {
            _eventAggregator.GetEvent<SetTitleForFlyoutAndOpenEvent>().Publish("About");
            _eventAggregator.GetEvent<SetFlyoutControlEvent<string>>().Publish("About");
        }

        public ICommand InfoButtonClickedCommand
        {
            get => _infoButtonClickedCommand;
            set => SetProperty(ref _infoButtonClickedCommand, value);
        }
    }
}