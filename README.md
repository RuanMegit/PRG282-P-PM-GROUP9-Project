 <a id="top"></a>
<div align="center">
 Baobab Ridge Wildlife Rehabilitation Records System
PRG282-P-PM-GROUP9-Project
A version-controlled C# Windows Forms application using text files, Git and GitHub
Features · Quick Start · Button Guide · Feature Details · Error Handling · Limitations · Team
</div>
---
 About
Baobab Ridge needs a simple way to record the animals it rehabilitates.
This app lets you view, add, update, delete and summarise animal records.
Records are stored in a plain text file: `animals.txt`.
Validation makes sure only clean data is saved.
💡 Each feature below is collapsible. Click a ▶ heading to open it.
---
<a id="features"></a>
 Features
#	Feature	What it does	Built by
1	 View	Shows valid animals in a grid	Ruan Megit
2	 Add	Adds a new record with validation	Zukhanye Mayekiso
3	 Update	Searches by ID, edits and saves	Angelo Badenhorst
4	 Delete	Removes a record after confirmation	Omphile Nthoesane
5	 Summary Report	Totals, averages and status counts	Omphile Nthoesane

---
<a id="quick-start"></a>
 Quick Start
Clone the repository from GitHub.
Open the solution in Visual Studio.
Press `F5` to run.
The animals in `animals.txt` appear in the grid.
Try this first:
[ ] Look at the grid.
[ ] Add an animal with an ID like `WR-009`.
[ ] Click a row, change a value, then click Save Changes.
[ ] Search for an animal by ID.
[ ] Generate a Summary Report.
[ ] Delete the animal you added.
⬆ Back to top
---
<a id="button-guide"></a>
 Button Guide
Button	What happens	Edit mode needed?
Add	Validates and adds a new record	No (disabled while editing)
Search	Finds a record by ID and enters edit mode	No
Save Changes	Validates and saves your edits	Yes
Clear	Empties all input boxes	No
Delete	Confirms, then removes the record	Select a row first
Summary Report	Writes `summary.txt` and opens the summary form	No
 ID format: `WR-` followed by the record number, e.g. `WR-009`
⬆ Back to top
---
<a id="feature-details"></a>
Feature Details
<details>
<summary><b> Feature 1: View Animals</b> · Ruan Megit</summary>
<br>
What I built
Created the GitHub repository with the README, `.gitignore` and a blank form project.
Added every member as a collaborator.
Created some of the branches needed to get started.
Created `animals.txt` with 8 valid and 2 invalid records.
Linked every record to a DataGridView row with its column name.
Helped clean up the other parts and remove duplicated code.
How to use it
Start the Windows Forms application.
The animals load into the DataGridView automatically.
Important methods
Validator class
Checks every line in `animals.txt`.
Decides if it is valid or invalid before it is displayed.
</details>
<details>
<summary><b> Feature 2: Add Animal Record and Validation</b> · Zukhanye Mayekiso (603121)</summary>
<br>
What I built
The Add feature, which captures a new animal record.
Only clean, valid data reaches `animals.txt`.
On Add, the program checks that:
the ID follows the correct format
no required field is blank
age and recovery score are numbers within sensible ranges
the Animal ID doesn't already exist
If a check fails:
a clear message is shown
nothing is written
If all checks pass:
the record is appended to `animals.txt`
the DataGridView refreshes
the input fields are cleared
The shared AnimalValidator class (later moved into the business logic layer):
checks whether existing records are valid or malformed
keeps rules consistent across Add, Update and file loading
How to use it
Fill in all the input fields.
Click Add.
If a field is invalid, read the message, fix it and click Add again.
If valid, you get a confirmation and the animal appears in the grid.
Error handling
Every field is validated before saving.
Numeric fields must be real numbers in range (age can't be negative).
Duplicate IDs are caught before writing.
Try-Catch handles `FileNotFoundException`, `DirectoryNotFoundException`, `IOException` and `UnauthorizedAccessException`.
Important methods
`btnAdd_Click()`: runs the checks, appends the record, refreshes the grid.
`ValidateAnimal()`: checks ID format, required fields, numeric ranges and duplicates.
AnimalValidator class: shared by Add and file loading.
Limitations
Strict rules mean the validator needs updating if the ID format changes.
Duplicate checks rely on unique Animal IDs.
Records added to `animals.txt` by hand are only flagged on load, not corrected.
</details>
<details>
<summary><b> Feature 3: Update Animal Record</b> · Angelo Badenhorst</summary>
<br>
What I built
Search and update: find a record by ID and change its values.
Save Changes button: saves the edits permanently in the text file.
Clear button: clears all input boxes.
How to use it
Search
Enter the full ID with the `WR-` prefix and number.
It is not case sensitive.
Save Changes
The program must be in edit mode.
Get there by searching, or by selecting a row in the grid.
The record passes several validation checks (no faulty or duplicate data).
It is then saved to the text file.
Clear: just click it.
Error handling
Save Changes uses Try-Catch to handle:
file not found
directory not found
IO exception
unauthorized access
Important methods
`EnterEditMode()`
Makes the AnimalID box read-only.
Disables Add.
Enables Delete.
Enables Save Changes.
`ExitEditMode()`
Makes the AnimalID box editable again.
Re-enables Add.
Disables Save Changes.
Clears the text boxes.
`LoadInfo()`
Loads a clicked grid row into the input boxes.
Calls `EnterEditMode()`.
`TryValidateUpdate()`: validates the values entered for the update.
Limitations
Search automatically puts you into edit mode.
</details>
<details>
<summary><b> Feature 4: Delete Animal Record</b> · Omphile Nthoesane (604593)</summary>
<br>
What I built
Lets users permanently remove an animal record.
Asks for confirmation first, to prevent accidents.
After deleting:
the record is removed from `animals.txt`
the DataGridView refreshes
the form clears if that animal was being edited
How to use it
Select a record in the DataGridView.
Click Delete.
Choose Yes to confirm or No to cancel.
Error handling
No row selected: a message asks you to select one, nothing is deleted.
The confirmation shows the animal's ID and name.
`IOException` (e.g. file open elsewhere): message shown, record not deleted.
`UnauthorizedAccessException` (no permission): message shown, record not deleted.
Important methods
`btnDelete_Click()`: validates the selection, confirms, removes the record, refreshes the grid and clears the form.
Limitations
Malformed records already in `animals.txt` are not removed.
Deleting relies on unique Animal IDs.
</details>
<details>
<summary><b> Feature 5: Summary Report</b> · Omphile Nthoesane (604593)</summary>
<br>
What I built
Calculates:
total number of animals
average age
average recovery score
number of animals in each recovery status category
Saves the report to `summary.txt`.
Displays the results in a separate form, `frmSummary`.
How to use it
Click Summary Report.
The report is saved as `summary.txt` next to the application executable.
The file is overwritten each time a new report is generated.
Results appear in `frmSummary`.
> With no animal records: total is 0, average age and recovery score show **N/A**, and all five status counts are 0.
Error handling
`IOException` when `summary.txt` is in use by another application.
`UnauthorizedAccessException` when there is no permission to write the file.
Message boxes are shown so the app does not crash.
Important methods
`CalculateSummary()`: works out the totals, averages and status counts from the records in the grid.
`btnSummaryReport_Click()`: calls `CalculateSummary()`, saves `summary.txt` and opens `frmSummary`.
Limitations
Only records loaded into the grid are counted.
Malformed records skipped on load are not included.
</details>
⬆ Back to top
---
<a id="error-handling"></a>
 Error Handling
<details>
<summary><b>How the app protects your data</b></summary>
<br>
Situation	Response
Invalid or blank field	Message explains the problem, nothing is saved
Duplicate Animal ID	Rejected before writing
File or directory not found	Friendly message, no crash
File open elsewhere (`IOException`)	Friendly message, no data lost
No permission (`UnauthorizedAccessException`)	Friendly message, change not applied
Delete with no row selected	Prompt to select a row
</details>
⬆ Back to top
---
<a id="limitations"></a>
Limitations
Animal IDs must be unique (add, update and delete all rely on this).
Malformed lines added by hand are skipped on load, not repaired.
The summary only includes records that loaded successfully.
Changing the ID format means updating the validator.
⬆ Back to top
---
<a id="team"></a>
 Team
Member	Contribution
Angelo Badenhorst	Update feature (search, save changes, clear)
Ruan Megit	GitHub setup, View feature, `animals.txt` creation
Omphile Nthoesane (604593)	Delete and Summary Report
Zukhanye Mayekiso (603121)	Add feature and validation
