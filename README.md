# MultiValueDictionary

## About the Project
Command Line interface application for reading and updating a multivalue dictionary stored in memory.

## Built With
* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Installation
1. Clone the repository
2. Open the solution in Visual Studio 2022
3. Ensure 'MultiValueDictionary' is set as the startup project
4. If using Visual Studio, run the project using F5 or the Start button
5. A CLI should appear as a seperate window or within Visual Studio

## How to use
The program runs in a continuous loop awaitng input from the command line.
Type a command, add parameters, and press enter.

Commands
* add \<key\> \<member\>
* allmembers
* clear
* exit
* items
* keys
* keyexists \<key\>
* members \<key\>
* memberexists \<key\> \<member\>
* remove \<key\> \<member\>
* removeall \<key\>
