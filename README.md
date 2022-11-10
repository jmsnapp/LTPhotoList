# LTPhotoList
This is my Technical Showcase for Lean TECHniques.

## The Assignment
There was a choice of two assignments.  I selected the first- **The Photo Album**.  The other assignment, **The Gilded Rose**, uses all non-Microsoft(TM) technologies, none of which I am familiar with.  While it is a lot of fun to learn new technologies, I felt that Lean TECHniques probably wanted something in a couple of days, not a couple of months.

### The Photo Album
Create a console application that displays photo ids and titles in an album. The photos are available in this online web service: [https://jsonplaceholder.typicode.com/photos](https://jsonplaceholder.typicode.com/photos)  
Hint: Photos are filtered with a query string. This will return photos within albumId=3  
`https://jsonplaceholder.typicode.com/photos?albumId=3`  
- You can use any language
- Any open source libraries
- Unit tests are encouraged
- Post your solution on any of the free code repositories and send us a link:
    - `https://github.com/`
    - `https://gitlab.com/`
    - `https://bitbucket.org/`

Provide a README that contains instructions on how to build and run your application.  
Spend as much (or little) time as you’d like on this. Feel free to use any resources available.  

Example Output:

`>photo-album 2`  
`[53] soluta et harum aliquid officiis ab omnis consequatur`  
`[54] ut ex quibusdam dolore mollitia`  
...  
`>photo-album 3`  
`[101] incidunt alias vel enim`  
`[102] eaque iste corporis tempora vero distinctio consequuntur nisi nesciunt`

## My Choices
First off, this was going to be a C# application as that is what I am most familiar with.  Actually, I could have also used VB.NET, but I am showing my age enough as it is.

I used MS Visual Studio Community Edition to write the project.  **WE ARE MICROSOFT.  YOU WILL BE ASSIMILATED.  RESISTANCE IS FUTILE.**  I could have used Visual Studio Code, but why not use the big shop tools if you have them?  

The application is built on .NET 6 (.NET 7 just dropped yesterday, and it is not a long term support version anyway, so I think I can wait on that a bit).

I added three Nuget packages to the project:  
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Json
- Newtonsoft.Json

Let me explain the last one first.  You may ask yourself, "Self, why isn't he using the _Microsoft System.Text.Json_ library and keeping everything Microsofty?  I mean, really.  He just did the Borg thing a minute ago."  The answer is quite simple.  The _Microsoft System.Text.Json_ library cannot parse JSON effectively except for the SIMPLEST structures.  You give it an unnamed array like the expected return for the sample API, and it cannot convert it to a .NET object type.  Also, heaven forbid you want to MODIFY  or CREATE any sort of JSON using an object model (like, maybe, building a JSON object for a http request body?).  The _Microsoft System.Text.Json_ library is **READ ONLY**.  So- if you want use JSON in a .NET environment, then use Newtonsoft. Yes, I sound snarky, because I am disappointed that Microsoft did so well on almost everything else in .NET 5+, but failed to complete what is effectively just a text parser that someone else already has done.  Microsoft shoves XML and various derivatives of XML down everyone's throat for over two decades and has extensive XML support in their Frameworks, but they can't handle writing out JSON?

The other two packages are to support the use of an _appsettings.json_ file for the application.  In this application, I have a couple of application settings, one for the base URL for the photo album, and one for the parameter name that is going to be supplied.  This looked like a very straightforward application, so I wanted to add SOME other reasonable feature besides exception handling.

##  Where are my unit tests?
This is a VERY simple application, and has no classes other than the program itself.  There is no real need for unit tests for what is essentially a single method call.  All the test cases would be trivial or require that the data being returned from the sample API not change, which defeats the purpose of accessing an API for data.  I COULD mock up the API, but again, that results in a trivial test.  Also, the native MS Test Mock support requires Visual Studio Enterprise (something that Microsoft does not point out in their Test Mock documentation except in one line of one document).

## Compling and Running the Application
You should be able to open this solution in Visual Studio 2022 or the equivalent version of Visual Studio Code and compile "out of the box".  Other than the _Newtonsoft.Json.dll_, everything else is pure Microsoft.  Nothing in this app SHOULD be dependent on MS Windows operating systems.  If you are set to the "Release" configuration in Visual Studio or VS Code, then the binaries should be output to {SOLUTION_DIRECTORY}\LTPhotoList\bin\Release\net6.0  Scoop everthing into a *.ZIP file (or other file archive format of your choice).  You don't have to have the *.PDB file in there (it is for debugging), or the _..\runtimes_ directory structure (since there are no platform specific files.  The _System.Text.Encodings.Web.dll_ file that is in there is a copy of the one that is in the root of the distibution).  Unzip your archive in a directory on your target machine, double click on the _LTPhotoList.exe_ file in that target directory, and you should see a console come up.

If this were a real contract, then someone other than myself would have paid for WixTools, this would be packaged into a self-installing SETUP.EXE.

I hope this meets your needs for assessing my skills, coding style, and problem solving approaches.

Matthew Snapp  
Matthew.Snapp@Outlook.com
