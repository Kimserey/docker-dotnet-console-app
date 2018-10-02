To run the migrations locally, download flyway and place it at the root of the application.
Then run the command:

```
..\..\flyway\flyway  migrate -url=jdbc:sqlite:..\sqlitetest.db -locations=filesystem:./
```

This will apply the migration files found in the current folder and create the database called `sqlitetest.db` under the project folder.