<div align="center">
 Baobab Ridge Wildlife Rehabilitation Records System
PRG282-P-PM-GROUP9-Project
A version-controlled C# Windows Forms application using text files, Git and GitHub
Features · Quick Start · Button Guide · Feature Details · Known Limitations · Team
</div>
---
 About the Project
Welcome! Baobab Ridge needs a simple, reliable way to record the animals it rehabilitates. This app lets you view, add, update, delete and summarise animal records. Everything is stored in a plain text file (`animals.txt`), and strict validation makes sure only clean data ever gets saved.

---
🧭 Features at a Glance
#	Feature	What it does	Built by
1	 View	Loads valid animals into a grid, skips invalid lines	Ruan Megit
2	 Add	Captures a new record with full validation	Zukhanye Mayekiso
3	 Update	Search by ID, edit and save changes	Angelo Badenhorst
4	 Delete	Removes a record after confirmation	Omphile Nthoesane
5	Summary Report	Totals, averages and status counts	Omphile Nthoesane
---
 Quick Start
Clone the repository from GitHub.
Open the solution in Visual Studio.
Run the application (press `F5`).
The animals in `animals.txt` appear in the grid straight away. 🎉
A first five-minute tour you can try:
[ ] Look at the grid. Valid animals are shown, invalid lines in the file are skipped.
[ ] Add a new animal with an ID like `WR-009`.
[ ] Click a row to load it, change a value and click Save Changes.
[ ] Search for an animal by its ID (not case sensitive).
[ ] Generate a Summary Report.
[ ] Delete the animal you added.
---
 Button Guide
Button	What happens	Needs edit mode?
Add	Validates and appends a new record	No (disabled while editing)
Search	Finds a record by ID and enters edit mode	No
Save Changes	Validates and saves your edits to `animals.txt`	Yes
Clear	Empties all input boxes	No
Delete	Asks for confirmation, then removes the record	Select a row first
Summary Report	Writes `summary.txt` and opens the summary form	No
>  **ID format:** Animal IDs use the `WR-` prefix followed by the record number, e.g. `WR-009`.
---
 Feature Details
<details>
<summary><b> Feature 1: View Animals, GitHub Setup and <code>animals.txt</code></b> (Ruan Megit)</summary>
<br>
What I built
Created the GitHub repository with the README, `.gitignore` and a blank form project.
Added every team member as a collaborator and created some of the branches needed to get started.
Created `animals.txt` with 8 valid and 2 invalid animal records.
Linked every record to its own row in the DataGridView, with matching column names.
Helped clean up the other parts of the project and remove duplicated code.
How to use it
Start the Windows Forms application.
The animals are loaded into the DataGridView automatically, with all their restrictions and requirements applied.
Important methods
Validator class: checks every line in `animals.txt` to decide whether it is valid or invalid before it is displayed in the DataGridView.
</details>
<details>
<summary><b> Feature 2: Add Animal Record and Validation</b> (Zukhanye Mayekiso, 603121)</summary>
<br>
What I built
I was responsible for the Add feature, which lets a user capture a new animal record. The main goal was to make sure only clean, valid data ever reaches `animals.txt`.
When the user clicks Add, the program first checks that:
the ID follows the correct format,
no required fields are blank,
numeric values (such as age and recovery score) are real numbers within sensible ranges, and
the new Animal ID doesn't already exist in the file.
If anything fails, the user gets a clear message and nothing is written. If everything passes, the record is appended to `animals.txt`, the DataGridView refreshes, and the input fields are cleared, ready for the next entry.
I also worked on the shared AnimalValidator class (later moved into the business logic layer). The whole system uses it to check whether records are valid or malformed, which keeps the rules consistent across the Add, Update and file-loading features.
How to use it
Fill in all the input fields on the form.
Click the Add button.
If a field is invalid, a message box explains what's wrong. Fix it and click Add again.
If the record is valid, you'll get a confirmation and the new animal will appear in the DataGridView.
Error handling
Every field is validated before saving, so invalid or duplicate records are rejected with a specific message instead of failing silently.
Numeric fields must be real numbers within acceptable ranges (e.g. age can't be negative).
Duplicate Animal IDs are caught before writing, so two animals can never share an ID.
The save operation uses a Try-Catch block to handle `FileNotFoundException`, `DirectoryNotFoundException`, `IOException` and `UnauthorizedAccessException`, so the app shows a friendly message instead of crashing.
Important methods
`btnAdd_Click()`: runs all validation checks, then appends the new record to `animals.txt` and refreshes the grid.
`ValidateAnimal()`: the core validation routine for ID format, required fields, numeric ranges and duplicates.
AnimalValidator class: shared validation logic used by both the Add feature and the file-loading process, so a record is judged by the same rules wherever it enters the system.
Limitations
Validation rules are strict by design. If the team changes the expected ID format, the validator will need updating too.
The duplicate check is based on Animal ID only, so it relies on IDs being unique across the file.
Validation happens at the point of entry. If a malformed record is added to `animals.txt` manually (outside the app), it will only be flagged when the file is loaded, not corrected.
</details>
<details>
<summary><b> Feature 3: Update Animal Record</b> (Angelo Badenhorst)</summary>
<br>
What I built
Search and update: search the file for a specific ID and change its values.
Save Changes button: saves the edits permanently in the text file.
Clear button: clears all input boxes on the page.
How to use it
Search: enter the full ID including the `WR-` prefix and the record number. It is not case sensitive.
Save Changes: the program must be in edit mode. You get there by searching for the record, or by selecting it in the DataGridView. The record then goes through several validation checks to make sure no faulty or duplicate data is entered, and is saved to the text file.
Clear: no instructions needed, just click it.
Error handling
The Save Changes button uses a Try-Catch block with multiple exceptions to handle a file not found, a directory not found, an IO exception and unauthorized access.
Important methods
`EnterEditMode()`: makes the AnimalID box read-only, disables the Add button, enables the Delete button and enables Save Changes.
`ExitEditMode()`: makes the AnimalID box editable again, re-enables the Add button, disables Save Changes and clears the text boxes.
`LoadInfo()`: when you click a record in the DataGridView, loads that row's information into the input boxes and calls `EnterEditMode()`.
`TryValidateUpdate()`: validates all the values entered for the animal being updated.
Limitations
The Search button automatically puts you into edit mode, assuming that's what you want.
</details>
<details>
<summary><b> Feature 4: Delete Animal Record</b> (Omphile Nthoesane, 604593)</summary>
<br>
What I built
I implemented the Delete Animal Record feature, which lets users permanently remove an animal record from the system. Before deletion, the user is asked to confirm, to prevent accidental removal. The record is then removed from `animals.txt`, the DataGridView is refreshed, and the form is cleared if the deleted animal was being edited.
How to use it
Select an animal record in the DataGridView.
Click the Delete button.
Choose Yes to confirm or No to cancel.
Error handling
If no record is selected, a message asks the user to select a row and nothing is deleted.
The confirmation dialog shows the animal's ID and name, so the user knows exactly what they are removing.
`IOException` is handled if `animals.txt` can't be updated (e.g. it is open in another application).
`UnauthorizedAccessException` is handled if the user doesn't have permission to modify `animals.txt`. A message is displayed and the record is not deleted.
Important methods
`btnDelete_Click()`: validates the selection, confirms the deletion, removes the record from `animals.txt`, refreshes the DataGridView and clears the form when necessary.
Limitations
Malformed records already in `animals.txt` are not removed when another animal record is deleted.
Records are identified by Animal ID, so deletion relies on IDs being unique.
</details>
<details>
<summary><b>Feature 5: Summary Report</b> (Omphile Nthoesane, 604593)</summary>
<br>
What I built
The Summary Report calculates the total number of animals, the average age, the average recovery score, and the number of animals in each recovery status category. The report is saved to `summary.txt` and displayed in a separate form, `frmSummary`.
How to use it
Click the Summary Report button.
The report is generated and saved as `summary.txt` in the same folder as the application executable. The file is overwritten each time a new report is generated.
The calculated results are shown in `frmSummary`.
> If there are no animal records, the total is 0, the average age and recovery score show as N/A, and each of the five status counts is 0.
Error handling
`IOException` is handled when `summary.txt` is being used by another application.
`UnauthorizedAccessException` is handled when the user doesn't have permission to write the report file.
Appropriate message boxes are shown so the application does not crash.
Important methods
`CalculateSummary()`: calculates the total, average age, average recovery score and status counts from the records currently loaded in the DataGridView.
`btnSummaryReport_Click()`: calls `CalculateSummary()`, creates the report, saves it to `summary.txt` and opens `frmSummary` to display the results.
Limitations
The summary is calculated from records successfully loaded into the DataGridView, so malformed records skipped during loading are not included.
</details>
---
 Error Handling Overview
<details>
<summary><b>Click to see how the app protects your data</b></summary>
<br>
Situation	How the app responds
Invalid or blank field	Message explains the problem, nothing is saved
Duplicate Animal ID	Rejected before writing
File missing or directory not found	Friendly message, no crash
File open in another program (`IOException`)	Friendly message, no data lost
No permission to write (`UnauthorizedAccessException`)	Friendly message, change is not applied
Delete with no row selected	Prompt to select a row
</details>
---
 Known Limitations at a Glance
Animal IDs must be unique. Duplicate checks, updates and deletes all rely on this.
Malformed lines added to `animals.txt` by hand are skipped on load, not repaired, and are left untouched by deletes.
The summary report only includes records that loaded successfully.
Changing the ID format means updating the validator.
---
 Meet the Team
Member	Contribution
Angelo Badenhorst	Update feature (search, save changes, clear)
Ruan Megit	GitHub setup, View feature, `animals.txt` creation
Omphile Nthoesane (604593)	Delete and Summary Report
Zukhanye Mayekiso (603121)	Add feature and validation
