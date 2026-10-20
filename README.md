 Baobab Ridge Wildlife Rehabilitation Records System
PRG282-P-PM-GROUP9-Project
A robust, version-controlled C# Windows Forms application built with text files, Git, and GitHub.

Welcome to Baobab Ridge!
Managing wildlife rehabilitation records requires precision, security, and ease of use. This application provides a seamless desktop experience for tracking animal intakes, updates, and summaries. Built collaboratively by Group 9, this project showcases a modular C# Windows Forms architecture with strict data validation and comprehensive error handling.

Core Features at a Glance
 Add Records: Seamlessly capture new animal data with rigorous validation checks to prevent duplicates or corrupt entries.

 View Data: Instantly populate a clean, easy-to-read DataGridView with valid records from our database.

 Update Records: Search by Animal ID, edit details safely, and save permanent changes back to the system.

 Delete Records: Remove records permanently with safety confirmation prompts to prevent accidents.

 Summary Reports: Generate real-time statistics on animal counts, average ages, and recovery statuses, automatically exported to a text file.

 Meet the Team & How It Works
 Angelo Badenhorst
Feature 3: Update Feature

What I Built: I engineered the Update feature, allowing users to search for a specific ID, modify its values, and save changes permanently. It includes an edit mode and a convenient clear button.

How to Use It:

Search: Enter the ID including the initials WR- followed by the record number (e.g., WR-001). Not case-sensitive.

Save Changes: Must be in "Edit Mode" (achieved by searching for a record or selecting a row in the DataGridView). The app runs validation checks to prevent faulty/duplicate data before saving.

Clear Button: Instantly wipes all input boxes clean.

Error Handling: The Save Changes button uses a robust Try-Catch block to handle FileNotFoundException, DirectoryNotFoundException, IOException, and UnauthorizedAccessException.

Important Methods:

EnterEditMode(): Locks the ID box, disables Add, enables Delete, and enables Save.

ExitEditMode(): Unlocks the ID box, enables Add, enables Delete, disables Save, and clears text boxes.

LoadInfo(): Pulls data from the clicked DataGridView row into the input boxes and triggers Edit Mode.

TryValidateUpdate(): Validates all textbox inputs before committing the update.

Limitations: The Search button automatically enters you into Edit Mode, assuming you intend to update the record.

 Ruan Megit
GitHub Setup, View Feature, animals.txt Creation

What I Built: I set the foundation for our collaboration by creating the GitHub repository, setting up the README, .gitignore, and the blank form project. I added all team members as collaborators and created individual branches. I also created the initial animals.txt file (containing 8 valid and 2 invalid records) and linked the records to the DataGridView. Finally, I oversaw code cleanups and deduplication.

How to Use It: Simply launch the application, and the valid animals will automatically populate the DataGridView.

Important Methods: Utilized a Validator class to check whether lines in the animals.txt file are valid or malformed before displaying them.

 Omphile Nthoesane (604593)
Feature 4 (Delete) & Feature 5 (Summary Report)

What I Built:

Delete: Allows users to select and permanently remove a record. Includes a confirmation prompt to prevent accidents, refreshes the grid, and clears the form if the deleted record was being edited.

Summary Report: Calculates total animals, average age, average recovery score, and status category counts. Saves to summary.txt and displays in frmSummary.

How to Use It:

Delete: Select a row ➔ Click Delete ➔ Confirm "Yes".

Summary Report: Click the Summary Report button. The report saves as summary.txt (overwriting old reports) and displays the results. Empty states show "0" for totals and "N/A" for averages.

Error Handling: Both features handle missing selections gracefully. They utilize Try-Catch blocks for IOException (file in use) and UnauthorizedAccessException (permission denied) to prevent app crashes.

Important Methods:

btnDelete_Click(): Validates selection, confirms, removes from file, and refreshes the grid.

CalculateSummary(): Computes stats based on loaded DataGridView records.

btnSummaryReport_Click(): Calls the calculation, writes the file, and opens the display form.

Limitations: Malformed records in the text file are not deleted. The summary only calculates from valid records loaded into the grid. Deletion relies on unique Animal IDs.

 Zukhanye Mayekiso (603121)
Feature 2: Add Animal Record & Validation

What I Built: I created the Add feature, focusing on ensuring only clean, valid data enters animals.txt. I also built the shared AnimalValidator class to keep validation rules consistent across the entire application (Add, Update, and file-loading).

How to Use It:

Fill in all input fields.
Click Add.
If invalid, an error message explains what to fix.
If valid, the record appends to the file, and the grid refreshes.
Note: IDs must follow the WR- format (e.g., WR-009).

Error Handling: Runs comprehensive validation (ID format, empty fields, numeric ranges, duplicate IDs) before saving. Uses Try-Catch to handle FileNotFoundException, DirectoryNotFoundException, IOException, and UnauthorizedAccessException.

Important Methods:

btnAdd_Click(): Runs checks, appends to file, and refreshes the grid.

ValidateAnimal(): The core validation routine.

AnimalValidator: Shared validation logic class.

Limitations: Strict validation means ID format changes require validator updates. Duplicate checks rely solely on the Animal ID. Manually adding malformed records to the text file will only be caught upon app load.

 Tech Stack & Architecture
Language: C# (.NET Framework)

UI: Windows Forms (WinForms)

Data Storage: Plain Text Files (.txt)

Version Control: Git & GitHub

Design Patterns: Separation of concerns (Business Logic, Validation, UI) and Data Binding.
