#  Baobab Ridge Wildlife Rehabilitation Records System

**PRG282 – Programming Project | Group 9**

A version-controlled C# Windows Forms application for managing wildlife rehabilitation records using text files, data validation, and Git/GitHub collaboration.

---

##  Project Overview

The **Baobab Ridge Wildlife Rehabilitation Records System** is a desktop application designed to help users manage animal rehabilitation records efficiently.

The application allows users to view, add, update, and delete animal records, as well as generate summary reports containing important statistics about the animals in the system.

Animal information is stored in a text file named `animals.txt`, while generated summary reports are saved to `summary.txt`. The application uses a Windows Forms interface to display and manage records, supported by validation logic that helps prevent invalid or duplicate information from being saved.

This project demonstrates practical skills in C# programming, Windows Forms development, file handling, data validation, exception handling, reporting, and collaborative software development using Git and GitHub.

##  Key Features

| Feature | Description |
|---|---|
|  View Animal Records | Displays animal records in a DataGridView, including validation results. |
|  Add Animal Record | Captures new animal information and validates it before saving. |
|  Search Records | Finds existing animal records using their unique Animal IDs. |
|  Update Records | Allows users to modify existing animal information and save the changes permanently. |
|  Delete Records | Removes selected animal records after user confirmation. |
|  Summary Report | Calculates animal statistics, average age, average recovery score, and recovery-status totals. |
|  Data Validation | Checks required fields, ID formats, numeric values, and duplicate records. |
|  Clear Form | Clears the input fields on the form. |
|  Text-File Storage | Uses `animals.txt` for animal records and `summary.txt` for generated reports. |
|  Error Handling | Handles common file-access and input/output errors. |
|  Version Control | Uses Git and GitHub for repository management and team collaboration. |

##  Technologies Used

- **C#** — application logic and functionality.
- **Windows Forms** — desktop graphical user interface.
- **DataGridView** — displays animal records in a tabular format.
- **Text files** — stores animal records and summary reports.
- **Git** — version control and branch management.
- **GitHub** — repository hosting and team collaboration.
- **Validation and exception handling** — helps maintain data integrity and handle errors.

##  Getting Started

### Prerequisites

Before running the application, ensure that you have:

- A Windows computer.
- Visual Studio with the required C# and Windows Forms development tools.
- Git installed if you intend to clone the repository or contribute to development.

### Installation and Setup

1. Clone the GitHub repository or download the project files.
2. Open the solution or project in Visual Studio.
3. Ensure that `animals.txt` is available in the directory expected by the application.
4. Build the project and resolve any environment-specific configuration issues.
5. Run the Windows Forms application.
6. View the loaded animal records in the DataGridView and explore the available features.

**Important:** The application relies on the text-file location expected by the code. Make sure the file is available in the correct directory when running the application.

##  How to Use the Application

### 1. View Animal Records

Launch the application to load animal records from `animals.txt`.

The records are displayed in the DataGridView, with the `AnimalValidator` class checking whether existing records are valid or malformed.

The initial test data contained eight valid animal records and two invalid animal records to support testing of the validation functionality.

### 2. Add an Animal Record

1. Fill in all the required input fields.
2. Click the **Add** button.
3. If any field is invalid, read the error message and correct the relevant information.
4. Click Add again after correcting the errors.
5. If validation succeeds, the record is appended to `animals.txt`.
6. The DataGridView refreshes to display the new animal, and the input fields are cleared.

**Animal ID format:** Animal IDs must follow the `WR-` format followed by the record number, for example, `WR-009`.

The application checks the ID format, required fields, numeric ranges, and duplicate IDs before saving the record.

### 3. Search for an Animal

1. Enter the animal's ID in the Animal ID field.
2. Use the required `WR-` prefix followed by the record number.
3. Click the **Search** button to locate the record.

The search is not case-sensitive. Searching for a record automatically enters edit mode, assuming the user intends to update the record.

### 4. Update an Animal Record

1. Search for the animal you want to update, or select its row in the DataGridView.
2. Edit the relevant fields.
3. Click **Save Changes**.
4. The application validates the updated information.
5. If validation succeeds, the changes are saved to `animals.txt`.

The update process checks the entered values to help prevent invalid or duplicate information from being saved.

### 5. Clear the Form

Click the **Clear** button to clear the input fields on the form.

This allows the user to prepare the form for another operation without manually removing each value.

### 6. Delete an Animal Record

1. Select an animal record in the DataGridView.
2. Click the **Delete** button.
3. Review the confirmation message.
4. Select **Yes** to confirm deletion or **No** to cancel.

After a confirmed deletion, the record is removed from `animals.txt`, the DataGridView refreshes, and the form is cleared if the deleted record was being edited.

### 7. Generate a Summary Report

Use the **Summary Report** feature to calculate and display important rehabilitation statistics.

The report includes:

- Total number of animals.
- Average animal age.
- Average recovery score.
- Number of animals in each recovery-status category.

The generated report is saved to `summary.txt` and displayed in a separate Windows Form named `frmSummary`.

##  Validation and Error Handling

Validation is an important part of the application because it helps maintain the accuracy and consistency of the animal records.

### Record Validation

The shared `AnimalValidator` class checks records loaded from `animals.txt` to determine whether they are valid or malformed.

This validation logic supports the Add feature and file-loading process and helps maintain consistency across the application.

### Add Feature Validation

The Add feature checks the information entered by the user before writing a new record to the file.

Validation includes:

- Animal ID format.
- Required fields.
- Valid numeric values.
- Acceptable numeric ranges.
- Duplicate Animal IDs.

If validation fails, the application displays an error message and prevents the record from being saved.

### Update Feature Validation

The `TryValidateUpdate()` method validates the values entered into the text boxes before an existing record is updated.

This helps prevent invalid or duplicate information from being written to the file.

### Exception Handling

The Add and Save Changes functionality use `try-catch` blocks to handle common file-related exceptions, including:

- `FileNotFoundException` — the required file cannot be found.
- `DirectoryNotFoundException` — the specified directory cannot be found.
- `IOException` — an input/output operation fails.
- `UnauthorizedAccessException` — the application does not have the required access permissions.

These checks help the application respond to common file-related problems rather than allowing them to go unhandled.

## ⚙️ Important Methods and Components

### Add Animal Record & Validation — Zukhanye Mayekiso

| Method / Component | Purpose |
|---|---|
| `btnAdd_Click()` | Handles the Add button click, validates the input, appends the record to `animals.txt`, refreshes the DataGridView, and clears the input fields. |
| `ValidateAnimal()` | Performs the core validation checks, including ID format, required fields, numeric ranges, and duplicate IDs. |
| `AnimalValidator` class | Provides shared validation logic for checking existing animal records and identifying malformed records during file loading. |

### Update Animal Record — Angelo Badenhorst

| Method | Purpose |
|---|---|
| `EnterEditMode()` | Makes the Animal ID field read-only, disables the Add button, enables the Delete button, and enables Save Changes. |
| `ExitEditMode()` | Makes the Animal ID field editable, enables the Add button, enables the Delete button, disables Save Changes, and clears the text boxes. |
| `LoadInfo()` | Loads information from a selected DataGridView row into the input fields and enters edit mode. |
| `TryValidateUpdate()` | Validates the entered values before an existing animal record is updated. |

**Implementation note:** The Search button automatically enters edit mode, assuming the user intends to update the selected record.

### View Feature and Repository Setup — Ruan Megit

The `Validator` class is used to validate records from `animals.txt` before they are displayed in the DataGridView.

The repository setup also included the initial README, `.gitignore`, blank Windows Forms project, collaborator access, development branches, and initial animal records.

Repository cleanup included removing duplicated content and helping maintain project consistency.

### Delete and Summary Report — Omphile Nthoesane

The Delete feature removes selected records after user confirmation and refreshes the displayed data.

The Summary Report functionality calculates the specified statistics, saves them to `summary.txt`, and displays the report using `frmSummary`.

##  Team Contributions

### 1. Angelo Badenhorst — Feature 3: Update Animal Record

**Contribution:**

- Implemented the Update Animal Record feature.
- Added record searching by Animal ID.
- Implemented edit-mode controls for the form.
- Added Save Changes and Clear functionality.
- Implemented validation and exception handling for updates.

**Key focus:** Updating existing records while maintaining data validity and consistency.

### 2. Ruan Megit — GitHub Setup and View Feature

**Contribution:**

- Created and configured the GitHub repository.
- Added the README, `.gitignore`, initial project, collaborators, and development branches.
- Created `animals.txt` and populated it with eight valid and two invalid test records.
- Implemented the record-viewing functionality using the DataGridView.
- Used the Validator class to check records before displaying them.
- Helped clean up duplicated content and improve project consistency.

**Key focus:** Repository setup, record viewing, and file-based record validation.

### 3. Omphile Nthoesane (604593) — Feature 4: Delete and Feature 5: Summary Report

**Contribution:**

- Implemented the Delete Animal Record feature.
- Added a confirmation prompt to reduce accidental deletions.
- Ensured the text file and DataGridView are updated after deletion.
- Implemented Summary Report calculations.
- Saved generated statistics to `summary.txt`.
- Created the separate `frmSummary` form to display the report.

**Key focus:** Record deletion and rehabilitation statistics reporting.

### 4. Zukhanye Mayekiso (603121) — Feature 2: Add Animal Record & Validation

#### What I Built

I was responsible for implementing the **Add Animal Record** feature, which allows users to capture new animal rehabilitation records and add them to the system. My main focus was ensuring that only clean, valid information is saved to `animals.txt`.

When the user clicks the Add button, the application performs several validation checks, including Animal ID format, required fields, numeric ranges, and duplicate IDs. If any validation check fails, the application displays a clear error message and prevents the record from being saved.

When all validation checks pass, the new record is appended to `animals.txt`, the DataGridView refreshes to display the new animal, and the input fields are cleared.

I also contributed to the shared `AnimalValidator` class, which was later moved into the business logic layer. This class provides consistent validation for existing records loaded from the text file, supporting the Add, Update, and file-loading features.

#### How to Use It

1. Fill in all the required input fields on the Windows Forms application.
2. Click the **Add** button.
3. If any information is invalid, read the error message, correct the relevant fields, and click Add again.
4. If the record passes validation, the application confirms the addition, saves the record to `animals.txt`, refreshes the DataGridView, and clears the input fields.
5. Ensure the Animal ID follows the required format: `WR-` followed by the record number, for example, `WR-009`.

#### Error Handling and Validation

- **Animal ID validation:** Checks that the ID follows the required `WR-` format.
- **Required-field validation:** Ensures mandatory fields contain valid information.
- **Numeric validation:** Checks that numeric values are valid numbers and fall within acceptable ranges.
- **Duplicate detection:** Prevents records with existing Animal IDs from being added.
- **User feedback:** Displays specific error messages when validation fails.
- **File error handling:** Uses a `try-catch` block to handle common file-related exceptions, including `FileNotFoundException`, `DirectoryNotFoundException`, `IOException`, and `UnauthorizedAccessException`.

#### Important Methods and Components

| Method / Component | Purpose |
|---|---|
| `btnAdd_Click()` | Handles the Add button click, runs validation, saves the record, refreshes the DataGridView, and clears the input fields. |
| `ValidateAnimal()` | Performs the core validation checks, including ID format, required fields, numeric ranges, and duplicate IDs. |
| `AnimalValidator` class | Provides shared validation logic for checking existing animal records and identifying malformed records during file loading. |

#### Limitations

- The validation rules are strict by design. If the Animal ID format changes, the validation logic must also be updated.
- Duplicate detection is based on the Animal ID only.
- Records manually added to `animals.txt` outside the application are flagged as invalid when the file is loaded, but the application does not automatically correct malformed records.

**Key focus:** Adding animal records, validating user input, and supporting consistent validation across the application.

##  Version Control and Collaboration

Git and GitHub were used to manage the project source code and support team collaboration.

The repository was configured with a README, `.gitignore`, collaborator access, and development branches. Team members contributed their respective features, helping organise the work and maintain a shared project codebase.

This workflow demonstrates the importance of source control when developing an application as a group.

##  Project Limitations

The following limitations were identified from the implemented features:

- **Text-file storage:** Animal records are stored in text files rather than a database.
- **File dependency:** The application depends on the correct location and availability of its text files.
- **Search behaviour:** Searching automatically enters edit mode, which may not be ideal when a user only wants to view a record.
- **Strict validation:** Changes to the Animal ID format or validation rules require corresponding updates to the validation logic.
- **Duplicate detection:** Duplicate checks are based on Animal ID.
- **Manual file modifications:** Malformed records added outside the application are flagged during file loading but are not automatically corrected.
- **Data growth:** Managing a large number of records may become more difficult as the text files grow.

##  Possible Future Improvements

The application could be improved further by introducing the following features:

- **Database integration:** Replace text-file storage with a relational database for more scalable record management.
- **Improved search:** Separate viewing and editing modes and introduce additional search filters.
- **Enhanced validation:** Centralise and expand validation rules to make future changes easier to maintain.
- **Automated testing:** Add tests for adding, updating, deleting, and validating records.
- **Improved user feedback:** Provide clearer messages for validation failures and file-access problems.
- **Report exports:** Add options to export summary reports to formats such as PDF or CSV.
- **Better documentation:** Include screenshots, a more detailed installation guide, and examples of the application in use.

##  Learning Outcomes

Through this project, the team gained practical experience in:

- Developing desktop applications using C# and Windows Forms.
- Reading, writing, and updating text files.
- Validating user input and stored records.
- Handling file-related exceptions.
- Displaying and managing data using a DataGridView.
- Implementing record-management operations.
- Calculating statistics and generating summary reports.
- Using Git and GitHub for collaborative software development.
- Organising project work through repository setup and branching.

##  Main Project Files and Components

| File / Component | Purpose |
|---|---|
| `animals.txt` | Stores animal rehabilitation records. |
| `summary.txt` | Stores the generated summary report. |
| `frmSummary` | Displays the summary report in a separate form. |
| `DataGridView` | Presents animal records in a tabular view. |
| `AnimalValidator` class | Provides shared validation logic for animal records. |
| `btnAdd_Click()` | Handles the Add button operation. |
| `ValidateAnimal()` | Validates new animal information before saving. |
| `EnterEditMode()` | Configures the form for editing a record. |
| `ExitEditMode()` | Resets the form's editing state. |
| `LoadInfo()` | Loads the selected record into the input fields. |
| `TryValidateUpdate()` | Validates updated animal information. |

*The table lists the files, forms, controls, and methods identified in the project description. Their exact source-code paths may differ.*

##  Conclusion

The Baobab Ridge Wildlife Rehabilitation Records System brings together animal-record management, input validation, file handling, reporting, and version control in a C# Windows Forms application.

Each team member contributed to a different aspect of the system, from repository setup and record viewing to adding, updating, and deleting animal records and generating summary reports.

The project demonstrates how a team can apply programming concepts and collaborative development practices to build a functional desktop application for managing wildlife rehabilitation records.

---

##  Project Information

- **Project name:** Baobab Ridge Wildlife Rehabilitation Records System
- **Repository:** `PRG282-P-PM-GROUP9-Project`
- **Course:** PRG282 — Programming
- **Application type:** C# Windows Forms desktop application
- **Storage:** Text files
- **Version control:** Git and GitHub

**GitHub Repository:** Replace this line with the URL of your project repository.
