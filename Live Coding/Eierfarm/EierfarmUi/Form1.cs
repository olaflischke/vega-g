using EierfarmBl;

namespace EierfarmUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnNeuesHuhn_Click(object sender, EventArgs e)
        {
            Huhn huhn = new();

            huhn.PropertyChanged += this.Tier_PropertyChanged;

            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void Tier_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            pgdTier.SelectedObject = (IEileger)sender;
        }

        private void btnNeueEnte_Click(object sender, EventArgs e)
        {
            Ente ente = new();

            ente.PropertyChanged += Tier_PropertyChanged;

            cbxTiere.Items.Add(ente);
            cbxTiere.SelectedItem = ente;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            switch (cbxTiere.SelectedItem)
            {
                case Gefluegel tier:
                    tier.Fressen();
                    break;
                case Schabeltier tier:
                    tier.Fressen();
                    break;
                default:
                    break;
            }
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEileger tier)
            {
                tier.EiLegen();
            }
        }
    }
}