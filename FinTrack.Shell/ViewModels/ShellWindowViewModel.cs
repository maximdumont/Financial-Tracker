using System.Windows;
using Prism.Events;
using Prism.Mvvm;
using Service.Global.Events.Controls;
using Service.Global.Events.Shell;

namespace FinTrack.Shell.ViewModels
{
    public class ShellWindowViewModel : BindableBase, IShellWindowViewModel
    {
        private bool _doesShellNeedToShowLoadIcon;
        private double _expectedScreenHeight;
        private double _expectedScreenWidth;
        private string _flyoutTitle;
        private double _flyoutWidth;
        private bool _isFlyoutOpen;
        private double _sidePanelOpacity;
        private string _windowTitle;

        public ShellWindowViewModel(IEventAggregator eventAgreggator)
        {
            ExpectedScreenHeight = SystemParameters.PrimaryScreenHeight / 2;
            ExpectedScreenWidth = SystemParameters.PrimaryScreenWidth / 2;

            eventAgreggator.GetEvent<SetWindowTitleEvent>().Subscribe(OnWindowTitleEventPublished);
            eventAgreggator.GetEvent<SetTitleForFlyoutAndOpenEvent>()
                .Subscribe(OnSetTitleForFlyoutAndOpenEventReceived);

            eventAgreggator.GetEvent<ToggleShellToLoadEvent>().Subscribe(OnToggleShellToLoadEventReceived);
            FlyoutWidth = 350;
            SidePanelOpacity = 0.9;
            FlyoutTitle = string.Empty;
            DoesShellNeedToShowLoadIcon = true;
        }

        public double SidePanelOpacity
        {
            get => _sidePanelOpacity;
            set => SetProperty(ref _sidePanelOpacity, value);
        }

        public double ExpectedScreenWidth
        {
            get => _expectedScreenWidth;
            set => SetProperty(ref _expectedScreenWidth, value);
        }

        public double ExpectedScreenHeight
        {
            get => _expectedScreenHeight;
            set => SetProperty(ref _expectedScreenHeight, value);
        }


        public string WindowTitle
        {
            get => _windowTitle;
            set => SetProperty(ref _windowTitle, value);
        }

        public bool IsFlyoutOpen
        {
            get => _isFlyoutOpen;
            set => SetProperty(ref _isFlyoutOpen, value);
        }

        public double FlyoutWidth
        {
            get => _flyoutWidth;
            set => SetProperty(ref _flyoutWidth, value);
        }

        public string FlyoutTitle
        {
            get => _flyoutTitle;
            set => SetProperty(ref _flyoutTitle, value);
        }

        public bool DoesShellNeedToShowLoadIcon
        {
            get => _doesShellNeedToShowLoadIcon;
            set => SetProperty(ref _doesShellNeedToShowLoadIcon, value);
        }

        private void OnToggleShellToLoadEventReceived(bool obj)
        {
            DoesShellNeedToShowLoadIcon = obj;
        }

        private void OnSetTitleForFlyoutAndOpenEventReceived(string flyoutTitle)
        {
            if (!IsFlyoutOpen)
                IsFlyoutOpen = !IsFlyoutOpen;
            if (!FlyoutTitle.Equals(flyoutTitle))
                FlyoutTitle = flyoutTitle;
        }


        private void OnWindowTitleEventPublished(string newTitle)
        {
            WindowTitle = newTitle;
        }
    }
}