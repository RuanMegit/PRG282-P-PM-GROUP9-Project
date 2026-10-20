 Baobab Ridge Wildlife Rehabilitation Records System
PRG282-P-PM-GROUP9-Project

A version-controlled C# Windows Forms application using text files, Git, and GitHub.

 Project Overview
This application is designed to manage and track wildlife rehabilitation records. It features a robust system for adding, updating, viewing, and deleting animal records, complete with strict data validation and summary reporting capabilities.

 Team Contributions
1. Angelo Badenhorst
Feature 3: Update Feature

What I built:
I installed the update feature which allows a user to search the file for a specified ID and change its values. I also implemented a "Save Changes" button which saves the new changes permanently inside the text file. A "Clear" button allows the user to clear all input boxes on the page.

How to use it:

Search: The ID must include the initials WR- followed by the record number (e.g., WR-001). It is not case-sensitive.

Save Changes: The program must be in edit mode to save changes. This is achieved by searching for the record to change, or by selecting the desired record from the DataGridView. The app then goes through multiple validation checks to ensure no faulty or duplicate data is entered before saving to the text file.

Clear Button: Clears all input fields. No special instructions required.

Error Handling:
The Save Changes button uses a Try-Catch block with multiple exceptions to handle errors such as FileNotFoundException, DirectoryNotFoundException, IOException, and UnauthorizedAccessException.

Important Methods:

EnterEditMode(): Changes the AnimalID input box to read-only, disables the Add button, enables the Delete button, and enables the Save Changes button.

ExitEditMode(): Removes read-only from the AnimalID input box, enables the Add button, enables the Delete button, disables the Save Changes button, and clears the text boxes.

LoadInfo(): Allows you to click a record in the DataGridView and pulls all the information into the input boxes from the clicked row, then calls EnterEditMode().

TryValidateUpdate(): Validates all input values in the textboxes before updating the animal.

Limitations:

The Search button automatically enters you into edit mode, assuming you want to update the record.

2. Ruan Megit
GitHub Setup, View Feature, animals.txt Creation

What I built:
I created the GitHub repository with the README, .gitignore, and the blank form project. I added every member as a collaborator and created the branches required for everyone to start their parts. I created a blank animals.txt file and added 8 valid animal records and 2 invalid animal records. I then linked all the records to individual rows in the DataGridView with their corresponding column names. I also helped clean up all the parts and remove duplications.

How to use it:
Start the Windows Forms application and the animals will populate to view with all their restrictions and requirements.

Important Methods:

Used the Validator class to validate that all lines in the animals.txt file are valid or invalid before displaying them in the DataGridView.

3. Omphile Nthoesane (604593)
Feature 4 (Delete) & Feature 5 (Summary Report)

What I built:

Delete: I implemented the Delete Animal Record feature, which allows users to select and permanently remove an animal record from the system. Before deletion, the user is prompted with a confirmation message to prevent accidental removal. The record is removed from animals.txt, the DataGridView is refreshed, and the form is cleared if the deleted animal was being edited.

Summary Report: I implemented the Summary Report feature. This calculates the total number of animals, average age, average recovery score, and the number of animals in each recovery status category. The report is saved to summary.txt and displayed in a separate form, frmSummary.

How to Use it:

Delete: Select an animal record from the DataGridView ➔ Click the Delete button ➔ Choose "Yes" to confirm deletion or "No" to cancel.

Summary Report: Click the Summary Report button. The report is generated and saved as summary.txt in the same folder as the application executable (the file is overwritten each time). The calculated results are displayed in frmSummary. If there are no animal records, the total will be 0, and averages will display as N/A.

Error Handling:

Delete: Shows a message asking the user to select a row if no record is selected. Uses a confirmation dialog displaying the animal’s ID and name. Handles IOException if animals.txt cannot be updated, and UnauthorizedAccessException if the user lacks permission to modify the file. The application does not crash.

Summary Report: Handles IOException when summary.txt is being used by another application, and UnauthorizedAccessException for permission issues. Displays appropriate message boxes so the application does not crash.

Important Methods:

btnDelete_Click(): Validates the selection, confirms deletion, removes the record from animals.txt, refreshes the DataGridView, and clears the form.

CalculateSummary(): Calculates the total number of animals, average age, average recovery score, and status counts from the records currently loaded.

btnSummaryReport_Click(): Calls CalculateSummary(), creates the report, saves it to summary.txt, and opens frmSummary.

Limitations:

Malformed records that already exist in animals.txt are not removed when another record is deleted.

The summary is calculated from records successfully loaded into the DataGridView, so skipped/malformed records are not included.

The delete feature relies on Animal IDs being unique.

4. Zukhanye Mayekiso (603121)
Feature 2: Add Animal Record & Validation

What I built:
I was responsible for the Add feature, which lets a user capture a new animal record and add it to the system. The main focus was ensuring only clean, valid data makes it into animals.txt. When the user clicks Add, the program runs a full set of validation checks (checking ID format, required fields, numeric ranges, and duplicate IDs). If anything fails, the user gets a clear error message, and nothing is written. If validation passes, the record is appended to animals.txt, the DataGridView refreshes, and the input fields are cleared.

I also worked on the shared AnimalValidator class (later moved into the business logic layer), which the rest of the system uses to check whether existing records in the file are valid or malformed. This keeps validation consistent across the Add, Update, and file-loading features.

How to use it:

Fill in all the input fields on the form.

Click the Add button.

If any field is invalid, a message box will tell you exactly what's wrong — fix it and click Add again.

If the record is valid, you'll get a confirmation and the new animal will appear in the DataGridView.

Note: Animal IDs should follow the WR- format followed by the record number (e.g., WR-009).

Error Handling:

Validates every field before attempting to save (invalid/duplicate records are rejected with specific messages).

Numeric fields are checked to ensure they are real numbers and within acceptable ranges.

Duplicate Animal IDs are caught before writing.

Uses a Try-Catch block to handle FileNotFoundException, DirectoryNotFoundException, IOException, and UnauthorizedAccessException.

Important Methods:

btnAdd_Click(): Runs validation checks, appends the new record to animals.txt, and refreshes the grid.

ValidateAnimal(): The core validation routine (ID format, required fields, numeric ranges, duplicates).

AnimalValidator class: Shared validation logic used by both the Add feature and the file-loading process.

Limitations:

Validation rules are strict by design; if the ID format changes, the validator must be updated.

The duplicate check is based on Animal ID only.

If a malformed record is manually added to animals.txt outside the app, it will only be flagged when the file is loaded, not corrected.

