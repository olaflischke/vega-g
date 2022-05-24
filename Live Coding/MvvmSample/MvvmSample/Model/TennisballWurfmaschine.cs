using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MVVMSample
{
    public class TennisballWurfmaschine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Lokale Variablen
        private DispatcherTimer timTimer;
        #endregion

        public TennisballWurfmaschine()
        {
            timTimer = new DispatcherTimer();
            timTimer.Tick += TimTimer_Tick;
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            this.Stueckzahl++;
        }


        #region Eigenschaften der Maschine
        private int _intSpeed;

        /// <summary>
        /// Geschwindigkeit, mit der die Bälle geworfen werden.
        /// </summary>
        public int Geschwindigkeit
        {
            get { return _intSpeed; }
            set
            {
                if (value > 0)
                {
                    _intSpeed = value;
                    timTimer.Interval = TimeSpan.FromMilliseconds(1000 / this.Geschwindigkeit);
                    OnPropertyChanged("Geschwindigkeit");
                }
            }
        }

        private int _intStueck;


        /// <summary>
        /// Anzahl der geworfenen Bälle.
        /// </summary>
        public int Stueckzahl
        {
            get { return _intStueck; }
            set
            {
                _intStueck = value;
                OnPropertyChanged("Stueckzahl");
            }
        }

        public bool IstAmLaufen { get; set; } = false;

        #endregion

        #region Methoden
        public void Start()
        {
            timTimer.Interval = TimeSpan.FromMilliseconds(1000);
            timTimer.Start();
            this.Geschwindigkeit = 1;
            this.IstAmLaufen = true;
        }

        public void Stopp()
        {
            timTimer.Stop();
            this.IstAmLaufen = false;
        }
        #endregion

    }
}
