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
