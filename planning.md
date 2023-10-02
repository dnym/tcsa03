# Planning

## Clarifications
*Quoted answers come from [ChatGPT](https://chat.openai.com/) who plays the role of external stakeholder (i.e. customer).*

- Who is this for?
- Text console only? Any requirements (e.g. for text height or width)?
- What should happen if the database cannot be created? If the tables can't be created?
- Should database location be user controllable?
- How should the program function when it can only track one habit? Is it fine to only record times and quantities of a generic "unit"? E.g. the user chooses to insert a record and is asked something like "how many units?". Or should it be user configurable? If so, directly in the program or by editing a config file?
- Should the units be integers or floating point numbers?
- Should the user be able to specify a time and date for a record? Or should it always assume "now"?
  - If time is entered as a full string, it must be interpreted based on a culture. This culture can be automatically set to the system's culture, but should it be overridable? Alternatively, time can be input piecewise (first year, then month, then ...).
- Does the menu need anything more than "insert record", "view records", "modify records", "delete records", "quit"? And "options"? Should the view and modify menu items be combined? Or perhaps view-modify-delete into one?
- `0` is the quit key. Does that mean that all menu entries should be number keys only?
- When viewing or modifying records, there may be a long list of records. Should it be paginated? Should the user select a record by pressing a number between 1-n where n is the total number of records, or where n is the number of records on screen? Or some other way?
- What info should be shown when viewing a record?
- What happens if entering the view/modify/delete screen when there are no records?
- "All possible errors" should be handled, but what does this mean other than user input? For example, guarding against hardware failure (e.g. memory corruption) seems overkill.
- The original requirements state "The application should only be terminated when the user inserts 0", but what does it mean to insert `0`? That the user should be able to exit by pressing `0`, and only by pressing `0`, but in what situations does this apply? Only in the main menu, or anywhere in the app? E.g. when asked to enter a number of habit units, the user enters `0`, and the program exits?
- What information should be entered into the readme file?
- When developing multi-habit record keeping, is it fine to require a new database, or must database migration be allowed for upgrading users?
- What types of units should be allowed for multi-habit record keeping? Integers only, floating point numbers only, or both, or both plus boolean?
- When developing multi-habit record keeping, what information should a habit carry? Name, name of unit of measurement, type of unit?
- When developing a statistics view, what information should be queryable? E.g. sum of records between two dates etc.
