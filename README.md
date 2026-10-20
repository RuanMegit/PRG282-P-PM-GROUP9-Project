#  Baobab Ridge Wildlife Rehabilitation Records System

**PRG282 – Programming Project | Group 9**

A version-controlled C# Windows Forms application for managing wildlife rehabilitation records using text-file storage, data validation, and Git/GitHub collaboration.

##  Project Overview

The **Baobab Ridge Wildlife Rehabilitation Records System** is a desktop application designed to help users view, update, delete, and report on animal rehabilitation records.

The application uses a text file (`animals.txt`) to store animal information and a Windows Forms interface to display and manage records. It also includes input validation to help maintain data quality and prevent invalid or duplicate records from being saved.

This project demonstrates practical skills in C# development, file handling, exception handling, Windows Forms, data validation, and collaborative version control.

##  Key Features

| Feature | Description |
|---|---|
|  View Animal Records | Displays animal records in a DataGridView, including validation results. |
|  Search Records | Finds an animal using its unique Animal ID. |
|  Update Records | Allows existing animal information to be edited and saved permanently. |
|  Delete Records | Removes selected animal records after confirmation. |
|  Summary Report | Calculates animal statistics and recovery-status totals. |
|  Data Validation | Checks records and input values to help prevent invalid or duplicate data. |
|  Clear Form | Clears the input fields on the form. |
|  Text-File Storage | Reads and updates animal information in `animals.txt` and writes reports to `summary.txt`. |
|  Error Handling | Uses exception handling to manage common file and access errors. |
|  Version Control | Uses Git and GitHub to support collaboration and source-code management. |

##  Technologies Used

- **C#** — application logic and functionality.
- **Windows Forms** — desktop user interface.
- **DataGridView** — displays animal records in a tabular format.
- **Text files** — stores animal records and generated summary reports.
- **Git** — version control and branch management.
- **GitHub** — repository hosting and team collaboration.
- **Validation and exception handling** — helps maintain data integrity and handle errors.

##  Getting Started

### Prerequisites

- Windows operating system.
- Visual Studio with the required C# and Windows Forms development tools.
- Git, if you want to clone the repository or contribute to development.

### Installation and Setup

1. Clone the repository from GitHub or download the project files.
2. Open the solution or project in Visual Studio.
3. Confirm that `animals.txt` is available in the expected application directory.
4. Build the project and resolve any environment-specific configuration issues.
5. Run the Windows Forms application.
6. View the animal records displayed in the DataGridView and explore the available features.

**Note:** The application relies on the text-file location expected by the code. Ensure that the file is available in the correct directory when running the application.

##  How to Use the Application

### 1. View Animal Records

Launch the application to load the animal records from `animals.txt`. The records are displayed in the DataGridView, with validation performed through the Validator class.

The repository was initially populated with eight valid animal records and two invalid records to support testing of the record-validation functionality.

### 2. Search for an Animal

1. Enter the animal's ID in the Animal ID field.
2. Use the required `WR-` prefix followed by the record number.
3. Click the Search button to locate the record.

The search is not case-sensitive. Searching for a record automatically enters edit mode.

### 3. Update an Animal Record

1. Search for the animal you want to update, or select its row in the DataGridView.
2. Edit the relevant fields.
3. Click **Save Changes**.
4. Allow the application to validate the updated information.
5. If validation succeeds, the changes are saved to `animals.txt`.

The update process checks the entered values to help prevent invalid or duplicate data.

### 4. Clear the Form

Click the **Clear** button to clear the input fields and prepare the form for another operation.

### 5. Delete an Animal Record

1. Select the animal record in the DataGridView.
2. Click the **Delete** button.
3. Review the confirmation message.
4. Select **Yes** to confirm deletion or **No** to cancel.

After a confirmed deletion, the record is removed from `animals.txt`, the DataGridView is refreshed, and the form is cleared if the deleted record was being edited.

### 6. Generate a Summary Report

Use the Summary Report feature to calculate and display key rehabilitation statistics.

The report includes:

- Total number of animals.
- Average animal age.
- Average recovery score.
- Number of animals in each recovery-status category.

The generated report is saved to `summary.txt` and displayed in a separate Windows Form named `frmSummary`.

##  Validation and Error Handling

Data validation is an important part of the application because it helps protect the integrity of the animal records.

### Record Validation

The Validator class checks the lines in `animals.txt` to determine whether records are valid. This validation is used when displaying records in the DataGridView.

### Update Validation

The `TryValidateUpdate()` method validates the values entered into the text boxes before an existing animal record is updated.

This helps prevent faulty or duplicate information from being written to the file.

### Exception Handling

The Save Changes functionality uses a `try-catch` block to handle common file-related errors, including:

- `FileNotFoundException` — the required file cannot be found.
- `DirectoryNotFoundException` — the specified directory cannot be found.
- `IOException` — an input/output operation fails.
- `UnauthorizedAccessException` — the application does not have the required access permissions.

These checks help the application handle file errors more reliably.

## ⚙️ Important Methods

### Update Feature — Angelo Badenhorst

| Method | Purpose |
|---|---|
| `EnterEditMode()` | Makes the Animal ID field read-only, disables the Add button, enables the Delete button, and enables Save Changes. |
| `ExitEditMode()` | Makes the Animal ID field editable, enables the Add button, enables the Delete button, disables Save Changes, and clears the text boxes. |
| `LoadInfo()` | Loads the information from a selected DataGridView row into the input fields and enters edit mode. |
| `TryValidateUpdate()` | Validates the entered values before the animal record is updated. |

**Implementation note:** The Search button automatically enters edit mode, assuming the user intends to update the selected record.

### Record Viewing and Repository Setup — Ruan Megit

The Validator class is used to validate animal records loaded from `animals.txt` before they are displayed in the DataGridView.

The repository setup also included the initial README, `.gitignore`, blank Windows Forms project, collaborator access, development branches, and initial animal records. Repository cleanup included removing duplicated content.

### Delete and Summary Report — Omphile Nthoesane

The Delete feature removes selected records after user confirmation and refreshes the displayed data.

The Summary Report functionality calculates the specified statistics, saves them to `summary.txt`, and displays the report using `frmSummary`.

##  Team Contributions

### Angelo Badenhorst — Update Feature

- Implemented the animal-record update functionality.
- Added record searching by Animal ID.
- Implemented edit-mode controls for the form.
- Added Save Changes and Clear functionality.
- Implemented validation and exception handling for updates.

### Ruan Megit — GitHub Setup and View Feature

- Created and configured the GitHub repository.
- Added the README, `.gitignore`, initial project, collaborators, and development branches.
- Created `animals.txt` and populated it with eight valid and two invalid test records.
- Implemented the record-viewing functionality using the DataGridView.
- Used the Validator class to check records.
- Helped clean up duplicated content and improve project consistency.

### Omphile Nthoesane (604593) — Delete and Summary Report

- Implemented the Delete Animal Record feature.
- Added a confirmation prompt to reduce accidental deletions.
- Ensured the text file and DataGridView are updated after deletion.
- Implemented the Summary Report calculations.
- Saved generated statistics to `summary.txt`.
- Created the separate `frmSummary` form to display the report.
  
##  Version Control and Collaboration

Git and GitHub were used to manage the project source code and support team collaboration.

The repository was configured with a README, `.gitignore`, collaborator access, and development branches. Team members contributed their respective features, helping organise the work and maintain a shared project codebase.

This workflow demonstrates the importance of source control when developing an application as a group.

##  Limitations

- Animal records are stored in text files rather than a database.
- The application depends on the correct location and availability of its text files.
- Searching automatically enters edit mode, which may not be ideal when a user only wants to view a record.
- Data integrity depends on the validation rules implemented in the application.
- Text-file storage may become harder to manage as the number of records grows.

##  Possible Future Improvements

- Introduce a database for more scalable record storage.
- Separate viewing and editing modes to make navigation clearer.
- Improve search functionality with additional filters.
- Add automated tests for record validation, updates, and deletions.
- Improve user feedback for validation failures and file-access errors.
- Add export options for summary reports.
- Expand documentation with screenshots and a clearer installation guide.

##  Learning Outcomes

This project provides practical experience in:

- Building desktop applications with C# and Windows Forms.
- Reading, writing, and updating text files.
- Validating user input and stored records.
- Handling file-related exceptions.
- Displaying and managing data using a DataGridView.
- Implementing CRUD-style record-management operations.
- Generating summary statistics and reports.
- Collaborating through Git, GitHub, and branching workflows.

##  Main Project Files

| File or Component | Purpose |
|---|---|
| `animals.txt` | Stores animal rehabilitation records. |
| `summary.txt` | Stores the generated summary report. |
| `frmSummary` | Displays the summary report in a separate form. |
| `DataGridView` | Presents animal records in a tabular view. |
| `Validator` class | Validates animal records loaded from the text file. |
| `EnterEditMode()` | Configures the form for editing a record. |
| `ExitEditMode()` | Resets the form's editing state. |
| `LoadInfo()` | Loads the selected record into the input fields. |
| `TryValidateUpdate()` | Validates updated animal information. |

*The table lists the files, forms, controls, and methods identified in the project description; their exact source-code paths may differ.*

##  Conclusion

The Baobab Ridge Wildlife Rehabilitation Records System brings together animal-record management, validation, file handling, reporting, and version control in a C# Windows Forms application.

Through their individual contributions, the team developed key functionality for viewing, updating, deleting, and summarising animal records while gaining practical experience in collaborative software development.

---

**Project:** PRG282-P-PM-GROUP9-Project  
**Course:** PRG282 — Programming  
**Application:** Baobab Ridge Wildlife Rehabilitation Records System  
**Repository:** Add your GitHub repository URL here.
