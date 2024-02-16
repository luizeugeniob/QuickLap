# QuickLap

Here, you will find a .NET Core project used as a study case to evaluate the different performances of using `IClassFixture` in your xUnit projects. The comparison was also between an in-memory database and a real database. Check out the results in English [here](https://medium.com/lodgify-technology-blog/optimizing-unit-tests-with-shared-context-73da7b6ddb8d), or in Portuguese [here](https://medium.com/@luizeugeniob/otimizando-testes-unitários-com-contexto-compartilhado-c7ea558be07a).

The results were collected by executing the tests through the command line with verbosity normal and logging them as a TRX file in a versioned folder.

```sh
dotnet test --verbosity n --logger:"trx;LogFileName=v{version}\{file-name}.trx"
```
