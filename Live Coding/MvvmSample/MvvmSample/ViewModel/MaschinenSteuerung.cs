using MVVMSample;
using MVVMSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.ViewModel
{
    public class MaschinenSteuerung
    {
        public MaschinenSteuerung()
        {
            this.StartCommand = new RelayCommand(p => this.CanStarten(), a => this.Starten());
            this.StoppCommand = new RelayCommand(p => this.CanStoppen(), a => this.Stoppen());
        }

        private bool CanStoppen()
        {
            return this.Maschine.IstAmLaufen;
        }

        private void Stoppen()
        {
            this.Maschine.Stopp();
        }

        private bool CanStarten()
        {
            return !this.Maschine.IstAmLaufen;
        }

        private void Starten()
        {
            this.Maschine.Start();
        }

        public TennisballWurfmaschine Maschine { get; set; } = new TennisballWurfmaschine();

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StoppCommand { get; set; }
    }
}
