# Ninquirer
A dotnet lib inspired by Inquirer.js and prompts.

Our goal is to make asking those tough questions easier. 🙋🙋‍♂️

## Confirm
A Yes/No decision can be requested with the following snipit.
```csharp
using Ninquirer;

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

## Press Any Key to Continue
Somtimes we want to wait for any key to be pressed.

```csharp
using Ninquirer;

Prompt.PressAnyKeyToContinue();
```

Initial output:
```
> Press any key to continue:
```

After a key has been pressed:
```
> Press any key to continue: ✔ 🎉
```

## Select Option
Given a collection of values allows a single item to be selected.

```csharp
using Ninquirer;

var color = Prompt.Select(
  "What is your favourite colour?",
  "Red",
  "Green",
  "Blue");
```

Initial output:
```
? What is your favourite colour?
 ▶ • Red 
   • Green 
   • Blue 
```
Using `Up`, `Down`, `Tab`, `j` and `k` to navigate between each option.
Then using `Enter` to make a selection.

After a selection has been made:
```
? What is your favourite colour? Blue
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
