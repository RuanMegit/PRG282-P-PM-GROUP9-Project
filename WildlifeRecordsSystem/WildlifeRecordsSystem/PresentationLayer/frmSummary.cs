using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildlifeRecordsSystem
{
    public partial class frmSummary : Form
    {
        public frmSummary(SummaryResults summary)
        {
            InitializeComponent();

            lblTotalAnimals.Text = summary.TotalAnimals.ToString();
            lblAverageAge.Text = summary.AverageAge.ToString("F2");
            lblAverageRecoveryScore.Text = summary.AverageRecoveryScore.ToString("F2");

            lblCritical.Text = summary.CriticalCount.ToString();
            lblSerious.Text = summary.SeriousCount.ToString();
            lblStable.Text = summary.StableCount.ToString();
            lblRecovering.Text = summary.RecoveringCount.ToString();
            lblReleaseReady.Text = summary.ReleaseReadyCount.ToString();
            }

        private void frmSummary_Load(object sender, EventArgs e)
        {

        }
    }

   
}
