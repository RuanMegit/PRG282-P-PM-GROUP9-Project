using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
        }

        public void LoadAnimals()
        {
            // Clear first so repeated calls never produce duplicate rows.
            dgvAnimals.Rows.Clear();

            string filePath = Path.Combine(Application.StartupPath, "animals.txt");
            int skipCount = 0; // a counter to notify user how many lines was skiped when reading the file
            var validator = new AnimalValidator(); //Caling AnimalValidator method to catch invalid lines
            var existingIds = new List<string>(); // Track IDs seen so far so duplicates within the file are also rejected.

            try
            {
                // Requirement 2.5: Create empty file, show empty grid, no error.
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Empty, Encoding.UTF8);
                    return;
                }

                // Requirement 2.1: Load animals.txt and show every valid record.
                foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
                {
                    // Skip blanks and wrong column counts before handing off to the validator.
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

                    // Delegate all field validation (ID, name, species, age, score) to the validator.
                    bool ok = validator.TryValidateAnimal(
                        id,
                        name,
                        species,
                        ageTxt,
                        scoreTxt,
                        existingIds,
                        out string normalizedId,
                        out _);

                    if (!ok)
                    {
                        skipCount++;
                        continue;
                    }

                    // Remember the accepted ID so later duplicates are rejected too.
                    existingIds.Add(normalizedId);

                    dgvAnimals.Rows.Add(
                        normalizedId,
                        name,
                        species,
                        int.Parse(ageTxt),
                        int.Parse(scoreTxt),
                        status,
                        housing);
                }

                // Reporting skipped lines once after loading finishes.
                if (skipCount > 0)
                {
                    MessageBox.Show($"{skipCount} malformed line(s) were skipped while loading animals.txt.", "Continue to view records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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



        //Methods for Add, Update, Delete functionality

        //Method 1: to calculate the housing unit and status from recovery score without the user nedding to enter it (Add, Update)
        public void StatusCalculation(int score, out string status, out string housingunit)
        {
            if (score <= 19)
            {
                status = "Critical";
                housingunit = "Intensive Care Unit";
            }
            else if (score <= 39)
            {
                status = "Serious";
                housingunit = "High-Dependency Ward";
            }
            else if (score <= 59)
            {
                status = "Stable";
                housingunit = "Recovery Ward";
            }
            else if (score <= 79)
            {
                status = "Recovering";
                housingunit = "Outdoor Enclosure";
            }
            else
            {
                status = "Release-Ready";
                housingunit = "Pre-Release Camp";
            }
        }

        //Method 2: to clear user input text boxes to start over (Add, Update, Delete)
        private void ClearTextBoxes()
        {
            txtAnimalID.Clear();
            txtAnimalName.Clear();
            txtAnimalSpecies.Clear();
            txtAnimalAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalID.Focus();
        }

        //method 3: enters edit mode and disables sensitive buttons and input boxes (Update)
        public void EnterEditMode()
        {
            txtAnimalID.ReadOnly = true;   //removes the option to change the ID
            btnAdd.Enabled = false;        //The add button is disabled to prevent duplicates being created
            btnDelete.Enabled = false;     //The delete button is disabled to prevent line deletion
            btnSaveChanges.Enabled = true;  //Enables the save changes button
        }

        //Method 4: exits edit mode and clears all input boxes (Update)
        public void ExitEditMode()
        {
            txtAnimalID.ReadOnly = false;   //disables read only on the input box after editing
            btnAdd.Enabled = true;          //The add button is enabled after editing
            btnDelete.Enabled = false;      //The delete button is enabled after editing
            btnSaveChanges.Enabled = false; //Save changes only enables when in editing mode

            ClearTextBoxes();
        }

        //Method 5: for loading information from the datagridview into inputboxes
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

        //Method 6: Store all ids to prevent duplecation errors
        private List<string> GetExistingIds()
        {
            List<string> ids = new List<string>();
            if (File.Exists("animals.txt"))
            {
                string[] lines = File.ReadAllLines("animals.txt");
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length > 0) ids.Add(parts[0]);
                }
            }
            return ids;
        }



        // Feature: ADD ANIMAL RECORD LINE Functionality
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Storing user input from text boxes
            string id = txtAnimalID.Text;
            string name = txtAnimalName.Text;
            string species = txtAnimalSpecies.Text;
            string age = txtAnimalAge.Text;
            string score = txtRecoveryScore.Text;

            //Validatation
            List<string> existingIds = GetExistingIds(); //storing all id string to prevent duplication

            AnimalValidator validator = new AnimalValidator();

            bool isValid = validator.TryValidateAnimal(id, name, species, age, score, existingIds, out string normalizedId, out string errorMessage);

            //if user input was wrong the user will be notifyed with a message
            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (errorMessage.Contains("ID")) txtAnimalID.Focus();
                else if (errorMessage.Contains("Name")) txtAnimalName.Focus();
                else if (errorMessage.Contains("Species")) txtAnimalSpecies.Focus();
                else if (errorMessage.Contains("Age")) txtAnimalAge.Focus();
                else if (errorMessage.Contains("Score")) txtRecoveryScore.Focus();

                return;
            }

            txtAnimalID.Text = normalizedId;

            try
            {
                // score comes in as a string from the textbox and hase been validated as correct.
                int scoreValue = int.Parse(score);
                // now we call method to calculate the status and housing unit.
                StatusCalculation(scoreValue, out string status, out string housingunit);
                   
                //Storing new line to animals.txt file
                string newRecord = $"{normalizedId}|{name.Trim()}|{species.Trim()}|{age.Trim()}|{score.Trim()}|{status}|{housingunit}";

                string filePath = Path.Combine(Application.StartupPath, "animals.txt");

                File.AppendAllText(filePath,newRecord + Environment.NewLine,Encoding.UTF8); ;

                MessageBox.Show($"Animal {normalizedId} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Loading new new record to show accurate data and clearning textboxes for new opperation
                LoadAnimals();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Feature: DELETE ANIMAL RECORD LINE Functionality
        //Handles the Delete button: asks for confirmation, removes the selected animal from animals.txt, refreshes the grid and clears the form if that animal was loaded
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataGridViewRow selectedRow = dgvAnimals.SelectedRows[0];
                string animalIdToDelete = selectedRow.Cells["AnimalID"].Value.ToString();
                string animalNameToDelete = selectedRow.Cells["Name"].Value.ToString();

                //Delete confirmation message box to prevent accidental deletion
                DialogResult result = MessageBox.Show("Delete " + animalIdToDelete + " (" + animalNameToDelete + ")? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        return;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access denied to modify animals.txt.", "File error");
                        return;
                    }

                    LoadAnimals(); // Refresh the DataGridView after deletion

                    if (string.Equals(txtAnimalID.Text.Trim(), animalIdToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        ExitEditMode(); // Clear input boxes if the deleted record was being edited
                    }
                }
            }
        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {

        }

        //Clears the inputboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            ExitEditMode();  
            
        }



        // Feature: UPDATE ANIMAL RECORD LINE Functionality
        //Save the changes permanently towards the text file and the data grid view
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnimalID.Text))
            {
                MessageBox.Show("Select an animal first", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtAnimalID.Text;
            string name = txtAnimalName.Text;
            string species = txtAnimalSpecies.Text;
            string age = txtAnimalAge.Text;
            string score = txtRecoveryScore.Text;

            //Validate User input for name, species, age and score in validator class methods
            AnimalValidator validator = new AnimalValidator();
            bool isValid = validator.TryValidateAnimalUpdate(name, species, age, score, out string errorMessage);

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (errorMessage.Contains("Name")) txtAnimalName.Focus();
                else if (errorMessage.Contains("Species")) txtAnimalSpecies.Focus();
                else if (errorMessage.Contains("Age")) txtAnimalAge.Focus();
                else if (errorMessage.Contains("Score")) txtRecoveryScore.Focus();

                return;
            }

            //Calculation the status and housing unit automaticaly
            int scoreint = Int32.Parse(score);
            StatusCalculation(scoreint, out string status, out string housingunit);

            //captures id again
            id = txtAnimalID.Text.Trim().ToUpper();
            string newAnimalline = $"{id}|{name}|{species}|{age}|{score}|{status}|{housingunit}";

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

        private void frmView_Shown(object sender, EventArgs e)
        {
            //Deselect the automatically selected first row so "no row selected" is possible
            dgvAnimals.ClearSelection();
            dgvAnimals.CurrentCell = null;
        }
    }
}
