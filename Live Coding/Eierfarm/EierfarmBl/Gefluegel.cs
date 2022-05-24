using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel : IEileger, INotifyPropertyChanged
    {

        public Gefluegel(string? name)
        {
            this.Name = name;
        }

        public List<Ei> Eier { get; set; } = new List<Ei>();
        public Guid Id { get; init; } = Guid.NewGuid();

        private double _gewicht;

        public double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                _gewicht = value;
                OnPropertyChanged();
            }
        }

        private string? _name;
        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public abstract void EiLegen();
        public abstract void Fressen();

        /// <summary>
        /// Dekonstruiert ein Geflügel zur Syntaxvereinfachung
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gewicht"></param>
        /// <param name="eier"></param>
        /// <remarks>
        /// Methode muss Deconstruct heißen, damit eine Syntax wie 
        ///  var (name, gewicht, eier) = huhn; funktioniert
        /// </remarks>
        public void Deconstruct(out string name, out double gewicht, out List<Ei> eier)
        {
            name = this.Name;
            gewicht = this.Gewicht;
            eier = this.Eier;
        }
    }
}
