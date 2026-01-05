# Functional Requirements

## Database Creation and Structure
- The system shall create a SQL Server database named College1en.
- The system shall create the following tables:
    - Programs
    - Courses
    - Students
    - Enrollments
- The system shall define the required columns and data types for each table as specified.
- The system shall enforce primary keys:
    - Programs: ProgId
    - Courses: CId
    - Students: StId
    - Enrollments: composite key (StId, CId)
- The system shall enforce foreign key relationships between tables.

## Referential Integrity Rules (ON DELETE / ON UPDATE)
- Deleting a program shall delete all courses in that program.
- Updating a program ID shall propagate to related courses.
- A program with enrolled students shall not be deletable.
- Updating a program ID shall propagate to related students.
- Deleting a student shall delete all enrollments of that student.
- Updating a student ID shall propagate to related enrollments.
- A course with enrolled students shall not be deletable.
- A course ID shall not be updatable if there are enrollments for that course.

## Data Population Rules
- The system shall allow insertion of sample data into all tables.
- Program IDs shall follow the format P####.
- Course IDs shall follow the format C######.
- Student IDs shall follow the format S#########.

## Application Architecture
- The system shall be implemented as a 3-tier C# Windows Forms application.
- The application shall use ADO.NET and SQLDataAdapter.
- The main window shall contain a menu with four options:
    - Students
    - Enrollments
    - Courses
    - Programs
- A single DataGridView shall be used and adapted for each option.
- All DataTables shall be loaded into memory before use to avoid foreign key violations.

## Students Management
- The system shall display student data in a DataGridView.
- The system shall allow adding new students.
- The system shall allow modifying existing students.
- The system shall allow deleting one or multiple students.

## Programs Management
- The system shall display program data in a DataGridView.
- The system shall allow adding new programs.
- The system shall allow modifying existing programs.
- The system shall allow deleting one or multiple programs.

## Courses Management
- The system shall display course data in a DataGridView.
- The system shall allow adding new courses.
- The system shall allow modifying existing courses.
- The system shall allow deleting one or multiple courses.

## Enrollments Management
- The system shall display enrollment data including: StId, StName, CId, CName, FinalGrade, ProgId, ProgName
- The system shall allow adding enrollments using an auxiliary form.
- When adding an enrollment:
    - The user shall select a student ID from a dropdown.
    - The student name shall display in a read-only field.
    - The user shall select a course ID from a dropdown.
    - The course name shall display in a read-only field.
- The system shall allow modifying enrollments using an auxiliary form.
- When modifying an enrollment:
    - Student ID and name shall be fixed (read-only).
    - Course ID may be changed.
- The system shall allow deleting one or multiple enrollments.
- The system shall provide a “Manage Final Grade” option using an auxiliary form.
- The Final Grade form shall display StId, StName, CId, and CName as read-only.
- The Final Grade field shall be editable.

## Business Rules
- Each course shall belong to exactly one program.
- Each student shall belong to exactly one program.
- A student shall enroll only in courses belonging to the student’s program.
- FinalGrade shall be either NULL or an integer between 0 and 100.
- New enrollments shall be created with FinalGrade set to NULL.
- The system shall allow resetting FinalGrade to NULL.
- If a FinalGrade is assigned:
    - The enrollment shall not be deletable.
    - The only allowed modification is removing the grade.
- If a FinalGrade is not assigned:
    - The enrollment may be deleted.
    - The enrolled course may be changed.

# Technologies Used
- C#
- Windows Form
- ADO .NET
- DataGridView
- SQL Server Management Studio

# Entity Relationship Diagram
<img width="853" height="473" alt="image" src="https://github.com/user-attachments/assets/717a2505-3cf2-4d11-98b9-ba01cda2f3a7" />

<br>
<br>

Checkout the demo on [LinkedIn](https://www.linkedin.com/feed/update/urn:li:activity:7413979103776747520/)
