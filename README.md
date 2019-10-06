# Ninquirer
A dotnet lib inspired by Inquirer.js and prompts.

Our goal is to make asking those tough questions easier. 🙋🙋‍♂️

## Confirm
A Yes/No decision can be requested with the following snipit.
```csharp
bool result = Prompt.Confirm("Would you like to use the default config?");
```

```
> ? Would you like to use the default config?  
```

Pressing keys that are not `Y` or `n`, gives feedback showing the invalid input highlighted in red after the question

After an option has been selected, the result is shown on the same line as the question keeping with the idea of feedback to the user.
```
> ? Would you like to use the default config? Yes
```


## Build
From the src directory
```
dotnet build
```

## Test
From the src directory
```
dotnet test
```

## Interactive Demo
From the src directory
```
dotnet run --project Ninquirer.Demo/Ninquirer.Demo.csproj
```
