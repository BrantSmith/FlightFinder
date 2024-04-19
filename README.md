# FlightFinder -  Software Engineering Task

| Project                     | Description |
| --------------------------- | ----------- |
| `FlightFinder`              | API server (ASP .NET Core Web API) - configured to run on https://localhost:7191 |
| `FlightFinder.UI`           | User interface (ASP .NET Core Web App - Razor Pages) - To define the input string and call the API to determine the number of instances of "flight" in the specified input string |
| `FlightFinder.UnitTests`    | The Unit Test project (NUnit) |

Please ensure that the Solution is configured with multiple startup projects:
- Solution FlightFinder → Configure Startup Projects → Multiple Startup Projects
  - FlightFinder
  - FlightFinder.UI
- Ensure the value of ApiConnString in the *appsettings.json* of **FlightFinder.UI** contains the url and port specified for the ssl Url in *profiles.FlightFinder.applicationUrl* in the *launchSettings.json* of **FlightFinder**

# **Notes on approach identification**
I identified two potential approaches for identifying the count of instances of the word that can be formed from the input string:
### Option 1:
- Place the input string into a character array, excluding all characters that are not in the specified word
- For each character in the specified word, "pop" them one by one from the input string, until the full word is formed
  - Increment the count for each full word
- Return the result
### Option 2:
- Place the input string into a character array, excluding all characters that are not in the specified word
- Iterate over all characters in the character array to identify their counts
- Iterate over all characters in the specified word to identify their counts
- For each character in the specified word, divide the character count from the character array with the same characters count from the word.
  - Store the lowest number - this is the number of times the word can be formed
- Return the result

Option 1 was chosen due to being the more performant solution (average time of 0.004 seconds versus 0.017 seconds for Option 2), in addition to being a more readable implementation