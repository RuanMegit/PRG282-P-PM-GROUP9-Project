using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildlifeRecordsSystem
{
    public partial class frmView : Form
    {
        // This is where we call the form1, then creating the datagridview collumn names, then importing the animals.txt data into the respective column rows
        public frmView()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadAnimals();
        }

        public void SetupDataGridView()
        {
            // Requirement 2.3: The grid is read-only: users cannot edit cells, add rows or delete rows directly in it. Clicking a cell selects the whole row.Records appear in the same order as in the file.
            dgvAnimals.Columns.Clear();

            dgvAnimals.AutoGenerateColumns = false;

            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;

            // Requirement 2.2: The columns appear in this order with these headers: Animal ID, Name, Species, Age, Recovery Score, Status, Housing Unit.
            dgvAnimals.Columns.Add("AnimalID", "Animal ID");
            dgvAnimals.Columns.Add("Name", "Name");
            dgvAnimals.Columns.Add("Species", "Species");
            dgvAnimals.Columns.Add("Age", "Age");
            dgvAnimals.Columns.Add("RecoveryScore", "Recovery Score");
            dgvAnimals.Columns.Add("Status", "Status");
            dgvAnimals.Columns.Add("HousingUnit", "Housing Unit");

            /* Requirment 2.4: The grid refreshes automatically after every add, update and delete, without restarting the program and without duplicate rows. 
            we must add this code at the end to the Add and update and deltet feature when that feature is implemented
            datagridview1.update();
            datagridview1.refresh();
            */

        }

        public void LoadAnimals()
        {
            // Clear first so repeated calls never produce duplicate rows.
            dgvAnimals.Rows.Clear();

            string filePath = Path.Combine(Application.StartupPath, "animals.txt");
            int skipCount = 0;

            try
            {
                // Requirement 2.5: Create empty file, show empty grid, no error.
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty, Encoding.UTF8);
                    return;
                }

                // Requirement 2.1: When the application starts, it loads animals.txt and shows every valid record in a DataGridView.
                foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        skipCount++;
                        continue;
                    }

                    string[] parts = line.Split('|');
                    if (parts.Length != 7)
                    {
                        skipCount++;
                        continue;
                    }

                    string id = parts[0].Trim();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();
                    string ageTxt = parts[3].Trim();
                    string scoreTxt = parts[4].Trim();
                    string status = parts[5].Trim();
                    string housing = parts[6].Trim();

                    // ID must be WR- followed by exactly 4 digits (case-insensitive).
                    if (!Regex.IsMatch(id, @"^WR-\d{4}$", RegexOptions.IgnoreCase))
                    {
                        skipCount++;
                        continue;
                    }

                    // Age and recovery score must be whole numbers from 0 to 100.
                    if (!int.TryParse(ageTxt, out int age) || age < 0 || age > 100)
                    {
                        skipCount++;
                        continue;
                    }
                    if (!int.TryParse(scoreTxt, out int score) || score < 0 || score > 100)
                    {
                        skipCount++;
                        continue;
                    }

                    // name and species. 1–30 characters. Must not contain the pipe character |.
                    if (string.IsNullOrWhiteSpace(name) || name.Length > 30)
                    {
                        skipCount++;
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(species) || species.Length > 30)
                    {
                        skipCount++;
                        continue;
                    }

                    // if user input an lowercase id it is still acceptable, we just change the text to uppercase
                    dgvAnimals.Rows.Add(id.ToUpper(), name, species, age, score, status, housing);
                }

                // Reporting skipped lines from the reading of the animals.txt file once after loading finishes.
                if (skipCount > 0)
                {
                    MessageBox.Show(
                        $"{skipCount} malformed line(s) were skipped while loading animals.txt.", "Load complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("animals.txt could not be found.", "File error");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The folder containing animals.txt could not be found.", "File error");
            }
            catch (IOException)
            {
                MessageBox.Show("animals.txt is in use by another program. Please close it and try again.", "File error");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to read animals.txt.", "File error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {

        }

        private void dgvAnimals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmView_Load(object sender, EventArgs e)
        {

        }
    }
}
