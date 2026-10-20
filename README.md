 Baobab Ridge Wildlife Rehabilitation Records System

PRG282-P-PM-GROUP9-Project

A version-controlled C# Windows Forms application using text files, Git and GitHub.

This app helps Baobab Ridge keep track of the animals in its care. You can view, add, update, delete and summarise animal records. Records are stored in animals.txt.

Feature 1: View Animals, GitHub Setup and animals.txt

Ruan Megit

What I built

Created the GitHub repository with the README, .gitignore and a blank form project.
Added every member as a collaborator and created some of the starting branches.
Created animals.txt with 8 valid and 2 invalid animal records.
Linked every record to a row in the DataGridView with its column name.
Helped clean up the other parts and remove duplication.

How to use it

Start the application. The animals load into the DataGridView automatically.

Important methods

Validator class: checks each line in animals.txt and decides if it is valid or invalid before it is displayed.
Feature 2: Add Animal Record and Validation

Zukhanye Mayekiso (603121)

What I built

The Add feature, which captures a new animal record.
Before saving, it checks that the ID format is correct, no required field is blank, age and recovery score are valid numbers in range, and the Animal ID doesn't already exist.
If a check fails, a clear message is shown and nothing is written.
If all checks pass, the record is added to animals.txt, the DataGridView refreshes and the input fields are cleared.
The shared AnimalValidator class (now in the business logic layer), which keeps validation consistent across Add, Update and file loading.

How to use it

Fill in all the input fields and click Add.
If a field is invalid, fix it as the message says and click Add again.
Animal IDs use the WR- format followed by the record number, e.g. WR-009.

Error handling

Invalid and duplicate records are rejected with a specific message.
Numeric fields must be real numbers in range (age can't be negative).
Try-Catch handles FileNotFoundException, DirectoryNotFoundException, IOException and UnauthorizedAccessException.

Important methods

btnAdd_Click(): runs the checks, then adds the record and refreshes the grid.
ValidateAnimal(): checks ID format, required fields, numeric ranges and duplicates.
AnimalValidator class: shared validation logic used by Add and file loading.

Limitations

If the ID format changes, the validator must be updated.
The duplicate check relies on Animal IDs being unique.
A malformed record added to animals.txt by hand is only flagged when the file is loaded, not corrected.
Feature 3: Update Animal Record

Angelo Badenhorst

What I built

A search that finds a record by ID so its values can be changed.
A Save Changes button that saves the edits permanently in the text file.
A Clear button that clears all input boxes.

How to use it

Search: enter the ID with the WR- prefix and number. It is not case sensitive.
Save Changes: the program must be in edit mode, which you get by searching for a record or selecting one in the DataGridView. The values are validated for faulty or duplicate data and then saved.
Clear: just click it.

Error handling

Save Changes uses Try-Catch to handle file not found, directory not found, IO exception and unauthorized access.

Important methods

EnterEditMode(): makes the AnimalID box read-only, disables Add, enables Delete and enables Save Changes.
ExitEditMode(): makes the AnimalID box editable again, re-enables Add, disables Save Changes and clears the text boxes.
LoadInfo(): loads a clicked DataGridView row into the input boxes and calls EnterEditMode().
TryValidateUpdate(): validates the values entered for the update.

Limitations

Search automatically puts you into edit mode.
Feature 4: Delete Animal Record

Omphile Nthoesane (604593)

What I built

Lets users permanently remove an animal record.
Asks for confirmation first to prevent accidental deletion.
Removes the record from animals.txt, refreshes the DataGridView and clears the form if that animal was being edited.

How to use it

Select a record in the DataGridView.
Click Delete.
Choose Yes to confirm or No to cancel.

Error handling

If no row is selected, a message asks the user to select one and nothing is deleted.
The confirmation shows the animal's ID and name.
IOException (e.g. the file is open in another application): a message is shown and the record is not deleted.
UnauthorizedAccessException (no permission): a message is shown and the record is not deleted.

Important methods

btnDelete_Click(): validates the selection, confirms, removes the record, refreshes the grid and clears the form.

Limitations

Malformed records already in animals.txt are not removed.
Deleting relies on Animal IDs being unique.
Feature 5: Summary Report

Omphile Nthoesane (604593)

What I built

Calculates the total number of animals, average age, average recovery score and the number of animals in each recovery status.
Saves the report to summary.txt and shows it in a separate form, frmSummary.

How to use it

Click Summary Report.
The report is saved as summary.txt in the same folder as the application executable and is overwritten each time.
The results are shown in frmSummary.
With no animal records, the total is 0, the average age and recovery score show N/A, and all five status counts are 0.

Error handling

IOException when summary.txt is in use by another application.
UnauthorizedAccessException when there is no permission to write the file.
Message boxes are shown so the application does not crash.

Important methods

CalculateSummary(): calculates the totals, averages and status counts from the records in the DataGridView.
btnSummaryReport_Click(): calls CalculateSummary(), saves summary.txt and opens frmSummary.

Limitations

Only records loaded into the DataGridView are counted, so malformed records skipped on load are not included.
