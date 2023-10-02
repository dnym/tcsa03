# Planning

## Clarifications
*Quoted answers come from [ChatGPT](https://chat.openai.com/) who plays the role of external stakeholder (i.e. customer).*

- Who is this for?
  - >The Habit Logger is designed for a general audience, primarily adults, without specific demographic or cultural restrictions. It aims to help individuals track and manage their habits effectively, making it versatile for various user groups.
- Text console only? Any requirements (e.g. for text height or width)?
  - >Yes, the Habit Logger is text console-based, and there are no specific requirements for text height or width. It should be adaptable to standard console dimensions for ease of use on different systems.
- What should happen if the database cannot be created? If the tables can't be created?
  - >If the database cannot be created, the application should handle the error gracefully, informing the user and providing guidance on potential solutions. If tables can't be created, a similar approach should be taken, ensuring the application doesn't crash and guiding the user on resolving the issue.
- Should database location be user controllable?
  - >No, the database location should not be user-controllable to maintain simplicity and consistency. The application should manage the database in a predefined location to avoid potential errors or complications from user-defined paths.
- How should the program function when it can only track one habit? Is it fine to only record times and quantities of a generic "unit"? E.g. the user chooses to insert a record and is asked something like "how many units?". Or should it be user configurable? If so, directly in the program or by editing a config file?
  - >The program should function effectively for tracking one habit. It's fine to record times and quantities of a generic "unit" without user configurability. This simplicity can be maintained directly in the program without the need for user-configurable options or config files.
- Should the units be integers or floating point numbers?
  - >The units for habit tracking should be integers to maintain simplicity and consistency in the application. This ensures straightforward data handling without the need for decimal points or floating-point numbers.
- Should the user be able to specify a time and date for a record? Or should it always assume "now"?
  - >The user should be able to specify a time and date for a record if needed. This flexibility allows users to accurately log past habits and maintain a complete record of their habits over time.
  - If time is entered as a full string, it must be interpreted based on a culture. This culture can be automatically set to the system's culture, but should it be overridable? Alternatively, time can be input piecewise (first year, then month, then ...).
    - >It's fine to enter time as a full string without overriding culture since there's no config file. Simplifying the input process without user-configurable culture settings aligns with the application's simplicity and design.
- Does the menu need anything more than "insert record", "view records", "modify records", "delete records", "quit"? And "options"? Should the view and modify menu items be combined? Or perhaps view-modify-delete into one?
  - >The menu can consist of "insert record," "manage records," and "quit" without the need for an "options" menu. Combining view, modify, and delete into one menu is acceptable, simplifying the user interface and enhancing user experience.
- `0` is the quit key. Does that mean that all menu entries should be number keys only?
  - >Yes, to maintain consistency, it's advisable to use number keys for menu selection. This ensures a straightforward user experience and aligns with the quit key, making it intuitive for users to navigate the menu.
- When viewing or modifying records, there may be a long list of records. Should it be paginated? Should the user select a record by pressing a number between 1-n where n is the total number of records, or where n is the number of records on screen? Or some other way?
  - >Pagination is advisable for long lists of records. Users should select records by entering a number between 1 and n, where n is the number of records on the current screen, ensuring a manageable and user-friendly interaction with the data.
- What info should be shown when viewing a record?
  - >When viewing a record, display essential information such as the date and time of the habit execution, the quantity or units, and any additional relevant details about the habit to provide a clear overview of the recorded data.
- What happens if entering the view/modify/delete screen when there are no records?
  - >If entering the view/modify/delete screen with no records, inform the user that there are no records to display or modify and provide an option to return to the main menu. Ensure a clear and user-friendly message.
- "All possible errors" should be handled, but what does this mean other than user input? For example, guarding against hardware failure (e.g. memory corruption) seems overkill.
  - >Handling "all possible errors" primarily refers to graceful handling of user-related errors, input validation, and database-related issues. Protecting against extreme hardware failures is typically beyond the scope of application error handling and can be considered overkill.
- The original requirements state "The application should only be terminated when the user inserts 0", but what does it mean to insert `0`? That the user should be able to exit by pressing `0`, and only by pressing `0`, but in what situations does this apply? Only in the main menu, or anywhere in the app? E.g. when asked to enter a number of habit units, the user enters `0`, and the program exits?
  - >The requirement to exit by inserting `0` applies primarily to the main menu. When the user is in a specific task, such as entering a number of habit units, entering `0` in that context should not exit the program; it should only trigger the exit option from the main menu.
- What information should be entered into the readme file?
  - >The README file should include essential information about the Habit Logger, such as a brief description, installation instructions, how to use the program, any dependencies, and contact information for support or inquiries.
- When developing multi-habit record keeping, is it fine to require a new database, or must database migration be allowed for upgrading users?
  - >For simplicity, it's fine to require a new database when transitioning to multi-habit record keeping. Implementing database migration can be complex and may not be necessary for the scope of this project, especially if it wasn't originally designed for multi-habit tracking.
- What types of units should be allowed for multi-habit record keeping? Integers only, floating point numbers only, or both, or both plus boolean?
  - >For multi-habit record keeping, both integers and floating-point numbers should be allowed as units. Boolean values, while useful in some contexts, may not be suitable for all habit tracking scenarios, so their inclusion should be optional and context-dependent.
- When developing multi-habit record keeping, what information should a habit carry? Name, name of unit of measurement, type of unit?
  - >In multi-habit record keeping, each habit should carry essential information, including its name for identification, the name of the unit of measurement (if applicable), and the type of unit (integer or floating-point) to facilitate consistent tracking and reporting.
- When developing a statistics view, what information should be queryable? E.g. sum of records between two dates etc.
  - >Queryable statistics should include the sum of records between two dates, the average value, and the total count of records. These metrics are relatively easy to compute and provide valuable insights into habit tracking progress.

### More Questions & Decisions
- What if the user enters bad input, e.g. invalid date or quantity?
  - Repeat the input until good input is given, but listen to `Esc` to cancel input.
- Should we ask for confirmation before deletion?
  - Not in MVP.

## MVP Functionality

### Necessary Functionality
- Create SQLite database with tables
- Store records in and retrieve records from DB using ADO.NET
- Menu system for navigating the application
  - Main menu
  - Record input screen
  - Record management screen
    - Pagination

### Possible Later Functionality
- Record multiple habits
  - Create habits
    - Habit creation screen
  - Manage habits
    - Habits management screen
- Set unit per-habit
  - Create unit
    - Unit creation screen
  - Manage units
    - Units management screen
- Calculate & view record statistics

## User Interface
Main menu:
```text
Habit Logger
============

1. Insert Record
2. Manage Records
0. Quit

------------
Press a number to select.
```

Record insertion:
```text
Insert Record
=============

Enter a time and date for this record,
or leave empty for current time: _

-------------
Press [Esc] to cancel insertion.
```

Record insertion:
```text
Insert Record
=============

Enter a time and date for this record,
or leave empty for current time: 2020-02-20 20:20:20

Enter the quantity for this occasion: _

-------------
Press [Esc] to cancel insertion.
```

Record management:
```text
Records (page 2/3)
==================

 1.  8 @ 2020-08-05 14:36:42
 2. 38 @ 2020-12-12 05:41:18
 3. 22 @ 2021-10-03 08:14:37
 4. 17 @ 2021-11-27 16:45:29
 5.  1 @ 2022-04-15 09:23:51
 6. 45 @ 2022-06-19 20:55:03
 7. 11 @ 2022-09-08 22:19:01
 8. 32 @ 2023-01-10 11:07:14
 9.  9 @ 2023-03-28 17:29:56
10.  5 @ 2023-05-30 13:50:27

Select a record to manage: _

------------------
Press [PgUp] to go to the previous page,
[PgDown] to go to the next page,
or [Esc] to go back to the main menu.
```

Single record management:
```text
Viewing Record
==============

Date: 2022-06-19 20:55:03
Quantity: 45

--------------
Press [M] to modify the record,
[D] to delete,
or [Esc] to go back to the main menu.
```

## Logic Checklist
- [x] Taking console text input
  - [x] Interpreting date-time strings
- [x] Printing console text output
- [x] Installing NuGet packages
- [x] Basic C#
- [x] Connecting to SQLite
- [x] Basic SQL
