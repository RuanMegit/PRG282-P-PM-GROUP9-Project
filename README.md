# PRG282-P-PM-GROUP9-Project
Baobab Ridge Wildlife Rehabilitation Records System  A version-controlled C# Windows Forms application using text files, Git and GitHub 

Angelo Badenhorst
Feature 3 :
I installed the update feature which allows a person search the file for a specified ID and change its values. I also installed a save changes button which saves the new changes permanently inside the text file. A clear button allows you to clear all input boxes on the page

How to use it
-To use the search button, the ID with the initials “WR-“ has to be enter with the records following numbers. Not case sensitive.
-To use the save changes button, the program has to be in edit mode which is achieved by searching for the record to change, or by selecting the desired record from the datagridview. It then goes through multiple validation checks to ensure no faulty or duplicate data is entered and is then saved to the text file.
-No necessary instructions for using a clear button.
Error handling
The Save changes button uses a Try-Catch block with multiple exceptions to handle errors such as file not found, directory not found, IO exception, and unauthorized access.

Important Methods
-EnterEditMode() Changes the AnimalID input box to read only , disables the Add button, enables the Delete button, the save changes button is enabled.
-ExitEditMode() Disables the AnimalID input box from read only , enables the Add button, enables the Delete button, the save changes button is disabled, and the text boxes are cleared.
-LoadInfo() method allows you to click a record in the datagridview and pulls all the information into the input boxes from the clicked row and load EnterEditMode()
Limitations
Search button automatically enters you into editmode assuming you want to.
TryValidateUpdate() to validate all input values in textbox to be updated on that animal.

Ruan Megit (GitHub setup, View feature, animals.txt creation):
I created the GitHub repository with the readme, .GitIgnore, and blank form project and added every member as a collaborator and created some of the branches required to start on a part. I created a blank animals.txt file and added 8 valid animal records and 2 invalid animal records, then i linked all the records to a individual row in datagridview with its corresponding column name, I also helped clean up all the parts and remove duplications.

How to use:
Start the windows form application and the animals will be populated to view wit all its restrictions and requirements.

Important Methods:
I used the validator class to validate that all lines in the animals.txt file is valid or invalid to display in datagridview.

Omphile Nthoesane (604593)
Feature 4 (Delete), Feature 5 (Summary Report)

What I built
1.	Delete: I implemented the Delete Animal Record feature, which allows users to select and permanently remove an animal record from the system. Before deletion, the user is prompted with a confirmation message to prevent accidental removal. The record is then removed from animals.txt, the DataGridView is refreshed, and the form is cleared if the deleted animal was being edited.

2.	Summary Report: I also implemented the Summary Report feature. This calculates the total number of animals, average age, average recovery score, and the number of animals in each recovery status category. The report is saved to summary.txt and displayed in a separate form, frmSummary.

How to Use it
1.	Delete
•	Select an animal record from the DataGridView.
•	Click the Delete button.
•	Choose Yes to confirm deletion or No to cancel.
2.	Summary Report
•	Click the Summary Report button.
•	The report is generated and saved as summary.txt in the same folder as the application executable. The file is overwritten each time a new report is generated.
•	The calculated results are displayed in frmSummary.
•	If there are no animal records, the total will be 0, and the average age and recovery score will display as N/A, and each of the five status counts will be 0.

Error handling
1.	Delete:
•	Shows a message asking the user to select a row if no record is selected, and no deletion takes place.
•	Uses a confirmation dialog displaying the animal’s ID and name, allowing the user to choose Yes or No before deletion.
•	Handles IOException if animals.txt cannot be updated (e.g. if the file is open in another application).
•	Handles UnauthorizedAccessException if the user does not have permission to modify animals.txt. A message is displayed and the record is not deleted.

2.	Summary Report:
•	Handles IOException when summary.txt is being used by another application.
•	Handles UnauthorizedAccessException when the user does not have permission to write the report file.
•	Displays appropriate message boxes so the application does not crash.

Important Methods
•	btnDelete_Click() – Validates the selection, confirms deletion, removes the record from animals.txt, refreshes the DataGridView, and clears the form when necessary.
•	CalculateSummary() – Calculates the total number of animals, average age, average recovery score, and status counts from the records currently loaded in the DataGridView.
•	btnSummaryReport_Click() – Calls CalculateSummary(), creates the summary report, saves it to summary.txt, and opens frmSummary to display the results.
Limitations
•	Malformed records that already exist in animals.txt are not removed when another animal record is deleted.
•	The summary is calculated from records successfully loaded into the DataGridView, so malformed records that were skipped during loading are not included in the report.
•	The delete feature identifies records using Animal IDs therefore it relies on Animal IDs being unique. 

