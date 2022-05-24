using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmUiWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {
            NeuesHuhnCommand = new RelayCommand(p => CanNeuesHuhn(), a => NeuesHuhn());

            FuetternCommand = new RelayCommand(p => CannFuettern(), a => Fuettern());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool CannFuettern()
        {
            return true;
        }

        private void Fuettern()
        {
            ((Gefluegel)this.SelectedTier).Fressen();
        }

        private bool CanNeuesHuhn()
        {
            return true;
        }

        private void NeuesHuhn()
        {
            Huhn huhn = new Huhn();
            this.Tiere.Add(huhn);
            this.SelectedTier = huhn;
        }

        private IEileger _selectedTier;

        public IEileger SelectedTier
        {
            get
            {
                return _selectedTier;
            }
            set
            {
                _selectedTier = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTier"));
            }
        }
        public ObservableCollection<IEileger> Tiere { get; set; } = new ObservableCollection<IEileger>();

        public RelayCommand FuetternCommand { get; set; }
        public RelayCommand EiLegenCommand { get; set; }
        public RelayCommand NeuesHuhnCommand { get; set; }
        public RelayCommand NeueEnteCommand { get; set; }
    }
}
