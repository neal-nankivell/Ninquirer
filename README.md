# Ninquirer
A dotnet lib inspired by Inquirer.js and prompts.

Our goal is to make asking those tough questions easier. 🙋🙋‍♂️

[![NuGet](https://img.shields.io/nuget/v/Ninquirer.svg)](https://www.nuget.org/packages/Ninquirer/)
[![github](https://img.shields.io/github/v/release/neal-nankivell/Ninquirer?include_prereleases&label=github)](https://github.com/neal-nankivell/Ninquirer)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v1.4%20adopted-ff69b4.svg)](CODE_OF_CONDUCT.md)
[![Travis Build Status](https://travis-ci.org/neal-nankivell/Ninquirer.svg?branch=master)](https://travis-ci.org/neal-nankivell/Ninquirer)

## Installation
### Package Manager
```powershell
PM > Install-Package Ninquirer
```

### .NET CLI
```bash
> dotnet add package Ninquirer
```

## Features
### Confirm
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

### Press Any Key to Continue
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

### Select Option
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
- `Up`, `Down`, `Tab`, `j` and `k` to navigate between each option.
- `Enter` to make a selection.

After a selection has been made:
```
? What is your favourite colour? Blue
```

### Select Multiple Options
Given a collection of values select 0-n of them.

```csharp
string[] colors = Prompt.SelectMulitple(
    "What are your favourite colours?",
    "Black",
    "DarkBlue",
    "DarkGreen",
    "DarkCyan",
    "DarkRed",
    "DarkMagenta",
    "DarkYellow",
    "Gray",
    "DarkGray"
    "Blue"
    "DarkGray"
    "Green"
    "Cyan"
    "Red"
    "Magenta"
    "Red"
    "Yellow"
    "White"
);
```

Initial output:
```
? What are your favourite colours?
   ○ Black
   ⦿ DarkBlue
   ○ DarkGreen
   ○ DarkCyan
   ⦿ DarkRed
   ○ DarkMagenta
   ⦿ DarkYellow
   ⦿ Gray
   ○ DarkGray
   ○ Blue
 ▶ ○ Green
   ○ Cyan
   ○ Red
   ○ Magenta
   ○ Yellow
   ○ White
```

- `Up`, `Down`, `Tab`, `j` and `k` to navigate between each option.
- `Space Bar` to add/remove and item from the selection.
- `Enter` to finish the selection.

After a selection has been made:
```
? What are your favourite colours? DarkBlue, DarkRed, DarkYellow, Gray
```

### Request string input

```csharp
using Ninquirer;

var name = Prompt.Input("What is your name?");
```

Initial output:
```
? What is your name? 
```

After a string has been typed:
```
? What is your name? Ninquirer
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
