# QuickLap

Here, you will find a .NET Core project used as a study case to evaluate the different performances of using `IClassFixture` in your xUnit projects. The comparison was also between an in-memory database and a real database.

The results were collected by executing the tests through the command line with verbosity normal and logging them as a TRX file in a versioned folder.

```sh
dotnet test --verbosity n --logger:"trx;LogFileName=v{version}\{file-name}.trx"
```
