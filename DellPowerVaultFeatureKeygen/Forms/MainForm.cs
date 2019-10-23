using System;
using System.Windows.Forms;

namespace DellPowerVaultFeatureKeygen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmbModel.SelectedIndex = 0;
            txtFeatureEnableIdentifier.MaxLength = 32;
        }

        private void Generate(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.ValidateNames = true;
                sfd.FileName = txtFeatureEnableIdentifier.Text;
                sfd.DefaultExt = "key";
                sfd.Filter = "Feature key file (.key)|*.key";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    byte[] featureEnableId = Utility.HexStringToByteArray(txtFeatureEnableIdentifier.Text);

                    License license = new License();

                    license.Features.Add(new Feature(featureEnableId, Capability.HighPerformanceTier));
                    license.Features.Add(new Feature(featureEnableId, Capability.SsdCache));
                    license.Features.Add(new Feature(featureEnableId, Capability.VirtualDiskCopy));
                    license.Features.Add(new Feature(featureEnableId, Capability.SnapshotVirtualDisks));
                    license.Features.Add(new Feature(featureEnableId, Capability.PhysicalDiskSlots192));
                    license.Features.Add(new Feature(featureEnableId, Capability.Snapshot, 256));

                    license.Save(sfd.FileName);
                }
            }
        }
    }
}
