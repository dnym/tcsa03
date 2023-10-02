# Habit Logger
An implementation of [the third project of The C# Academy](https://www.thecsharpacademy.com/project/12).

## Project Description
The project is a console based habit logger: the user can manage a single habit to track, and record the performing of this habit.

### Requirements
- Allow the registration of a single habit.
- Allow for tracking the habit by quantity (not time).
- Store and retrieve data from a SQLite database.
- Create database upon application start, if none exists.
- Create required tables in database upon database creation.
- Show the user a menu of options.
- Allow recording habit execution: insertion, deletion, updating, viewing.
- Handle all possible errors to guard against crashing.
- Allow for exiting the application only inputting `0`.
- Only interact with the database using ADO.NET and raw SQL (i.e. no mappers).
- Keep a README file.
 
### Bonus Features
- [ ] Allow the registration of multiple habits.
- [ ] Allow the registration of habit-specific units of measurement.
- [ ] Let the user view specific statistical information about recorded habits.
