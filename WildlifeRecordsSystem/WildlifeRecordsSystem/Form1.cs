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

        //method enters edit mode and disables sensitive buttons and input boxes
        public void EnterEditMode()
        {
            txtAnimalID.ReadOnly = true;   //removes the option to change the ID
            btnAdd.Enabled = false;         //The add button is disabled to prevent duplicates being created
            btnSaveChanges.Enabled = true;  //Enables the save changes button
        }

        //Method exits edit mode and clears all input boxes
        public void ExitEditMode()
        {
            txtAnimalID.ReadOnly = false;   //disables read only on the input box after editing
            btnAdd.Enabled = true;          //The add button is enabled after editing
            btnSaveChanges.Enabled = false; //Save changes only enables when in editing mode

            //Clears the editboxes when exiting editmode
            txtAnimalID.Clear();
            txtAnimalAge.Clear();
            txtAnimalName.Clear();
            txtAnimalSpecies.Clear();
            txtRecoveryScore.Clear();
        }
        //Method for loading information from the datagridview into inputboxes
        private void LoadInfo(DataGridViewRow row)
        {
            //Tells is what is stored in the clicked cell and turns it into a string
            txtAnimalID.Text = row.Cells[0].Value?.ToString();
            txtAnimalName.Text = row.Cells[1].Value?.ToString();
            txtAnimalSpecies.Text = row.Cells[2].Value?.ToString();
            txtAnimalAge.Text = row.Cells[3].Value?.ToString();
            txtRecoveryScore.Text = row.Cells[4].Value?.ToString();
            EnterEditMode();
        }

        private void StatusCalculation(int score, out string status, out string housingunit)
        {
            if (score <= 19)
            {
                status = ("Critical");
                housingunit = ("Intensive Care Unit");
            }
            else if (score <= 39)
            {
                status = ("Serious");
                housingunit = ("High-Dependency Ward");
            }
            else if (score <= 59)
            {
                status = ("Stable");
                housingunit = ("Recovery Ward");
            }
            else if (score <= 79)
            {
                status = ("Recovering");
                housingunit = ("Outdoor Enclosure");
            }
            else
            {
                status = ("Release-Ready");
                housingunit = ("Pre-Release Camp");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        //Requirement 4.1: The user can select a row and delete it. The program removes the record from the grid and from animals.txt. If no row is selected, show an error message.
        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvAnimals.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvAnimals.SelectedRows[0];
                string animalIdToDelete = selectedRow.Cells["AnimalID"].Value.ToString();
                string animalNameToDelete = selectedRow.Cells["Name"].Value.ToString();


                DialogResult result = MessageBox.Show("Delete " + animalIdToDelete + "(" + animalNameToDelete + ")? This cannot be undone.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Remove the record from animals.txt
                        string filePath = Path.Combine(Application.StartupPath, "animals.txt");
                        var lines = File.ReadAllLines(filePath, Encoding.UTF8).Where(line => !line.StartsWith(animalIdToDelete + "|", StringComparison.OrdinalIgnoreCase)).ToArray();
                        File.WriteAllLines(filePath, lines, Encoding.UTF8);
                    }
                    catch (IOException)
                    { 
                        MessageBox.Show("animals.txt could not be updated. It may be open in another program.", "File error");
                    }
                    catch (UnauthorizedAccessException)
                    { 
                        MessageBox.Show("Access denied to modify animals.txt.", "File error"); 
                    }
                    
                 
                    LoadAnimals(); // Refresh the DataGridView after deletion
                }
            }
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {

        }

        private void frmView_Load(object sender, EventArgs e)
        {

        }

        //Clears the inputboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            ExitEditMode();  
            
        }

        //Save the changes permanently towards the text file and the data grid view
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnimalID.Text))
            {
                MessageBox.Show("Select an animal first", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //captures name and species variables
            string name = txtAnimalName.Text.Trim();
            string species = txtAnimalSpecies.Text.Trim();

            //If statement for validating input box inputs
            if (name.Length < 1 || name.Length > 30 || name.Contains("|"))
            {
                MessageBox.Show("Name must be between 1 and 30 characters and not contain '|'.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalName.Focus();
                return;
            }

            //If statement for validating input box inputs
            if (species.Length < 1 || species.Length > 30 || species.Contains("|"))
            {
                MessageBox.Show("Species must be between 1 and 30 characters and not contain '|'.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalSpecies.Focus();
                return;
            }

            //If statement for validating input box inputs
            if (!int.TryParse(txtAnimalAge.Text.Trim(), out int age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalAge.Focus();
                return;
            }

            //If statement for validating input box inputs
            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out int recoveryscore) || recoveryscore < 0 || recoveryscore > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecoveryScore.Focus();
                return;
            }

            StatusCalculation(recoveryscore, out string status, out string housingunit);

            //captures id again
            string id = txtAnimalID.Text.Trim().ToUpper();
            string newAnimalline = $"{id}|{name}|{species}|{age}|{recoveryscore}|{status}|{housingunit}";

            string path = Path.Combine(Application.StartupPath, "animals.txt"); //file path towards text file

            try
            {
                string[] animal = File.ReadAllLines(path, Encoding.UTF8);  //read all lines

                //Checks where the ID's match in the text file and the new changed animal values
                for (int i = 0; i < animal.Length; i++)
                {
                    string[] part = animal[i].Split('|');

                    if (string.Equals(part[0].Trim(), id, StringComparison.OrdinalIgnoreCase))
                    {
                        animal[i] = newAnimalline;
                        break;
                    }
                }
                File.WriteAllLines(path, animal, Encoding.UTF8);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("animals.txt could not be found.", "File error");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The folder containing animals.txt could not be found.", "File error");
                return;
            }
            catch (IOException)
            {
                MessageBox.Show("animals.txt is in use by another program. Please close it and try again.", "File error");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to read animals.txt.", "File error");
                return;
            }

            LoadAnimals();  //refreshed the grid from the file
            ExitEditMode(); //Exits editing mode
        }

        //Allows you to edit a record that you clicked
        private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Simply ignores clicks on the header
            if (e.RowIndex < 0)
            {
                return;
            }
            //Which row was clicked
            DataGridViewRow clickedRow = dgvAnimals.Rows[e.RowIndex];
            LoadInfo(clickedRow);
        }

        //Allows you to search for an animal ID
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txtSearch.Text.Trim();

            

            if (string.IsNullOrWhiteSpace(searchID))
            {
                MessageBox.Show("Enter an animal ID", "Search box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //loops through entire datagridview
            foreach (DataGridViewRow row in dgvAnimals.Rows)
            {
                string rowID = row.Cells[0].Value?.ToString();  //RowID is declared to compare
                

                if (string.Equals(rowID, searchID, StringComparison.OrdinalIgnoreCase)) //Ignores case sensitive inputs
                {
                    LoadInfo(row);
                    return;
                }
            }
            //Shows an error if the record wasnt found
            MessageBox.Show($"The Record {searchID} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSearch.Clear();

        }
    }
}
