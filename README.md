# GrindChat

CEN4090L Software Engineering Capstone Group 9 Project

## Description

GrindChat is a collaborative messaging application developed 
using the C# programming language and the .Net framework. This applicatiion is designed to facilitate seamless 
operations and interactions between various entities such as Users and Teams 
unified under a user-friendly interface.

## Streamlined Onboarding

GrindChat facilitates a hassle-free entry point to a collaborative platform with a simple sign-in or 
sign-up process. Once logged in, users are welcomed by the intuitive UserView, where they can effortlessly 
initiate a new team or integrate into existing projects. The user-friendly interface guarantees a smooth 
navigation experience, allowing teams to concentrate on collaboration without unnecessary complications.

## Efficient Communication & Team Dynamics

At its core, GrindChat is designed to foster dynamic and flexible team collaborations, establishing 
a many-to-many relationship model between teams and users. This approach promotes enriched interaction 
and cohesive team dynamics, providing avenues for both group discussions and personalized conversations. 
GrindChat serves as a centralized hub for stimulating dialogue and streamlined project communications, 
enhancing both group synergy and individual connections.

## Secure Data Transfer

In the rapidly evolving digital landscape, GrindChat prioritizes secure and seamless data transfer 
functionalities within its network. Users can readily share documents and files, fostering an
environment that encourages continuous information flow and collaboration. This feature embodies 
GrindChat's commitment to providing a secure and efficient platform for project management and
execution, emphasizing simplicity without compromising on security.

## Run and Test GrindChat

To execute the program, first install Visual Studio (VS) Community as the primary development environment. 
Before initializing the project, ensure that the following packages are installed:

1. ASP.NET and Web Development
2. Node.js Development
3. Mobile Development for .NET
4. .NET Desktop Development
5. Universal Windows Platform Development
6. Data Storage and Processing

Also, Install the following NuGet Pacages :

1. FireSharp
2. Microsoft.Bcl.Build
3. Microsoft.Net.Http
4. Newtonsoft.Json


Upon successful installation of all the packages, initiate the application by opening the **GrindChat.sls** file. Next, proceed 
to create dependencies for both **GrindChat.API** and **GrindChat.MAUI**. Right-click on **GrindChat.API**, select **Build Dependencies** 
followed by **Project Dependencies...** Under **Depends on**** choose **GrindChat.Library**. Repeat these steps for **GrindChat.MAUI**.

Subsequently, modify the startup settings of the application. Click on **Solution GrindChat (3 out of 3 projects)** and select 
**Configure Startup Project**. In the ensuing configuration window, select **Multiple Projects** and change the action from **None**
to **Start** for both GrindChat.API and GrindChat.MAUI.

Upon altering the startup configuration, it is imperative to update the profile settings to align with your host address. In 
the top toolbar, adjacent to the "Debug" and "Any CPU" dropdown menus, switch the application startup project to the API. Then, 
click on the dropdown menu for **https** and choose **GrindChat.API Debug Properties**. In the "Http" section, modify the App URL 
from "https://localhost:xxxx" to "http://localhost:xxxx," thereby removing the "https" URL. Repeat this process for the 
"Https" option. Note down the 'xxxx' number in your https port, as it will be required in the subsequent step.

To finalize, navigate to **GrindChat\GrindChat.Library\Utilities\WebRequestHandler.cs** and adjust the **port** number to
match your http port number. Save the modifications and proceed to build the solution. You should then witness the 
API terminal and webpage launching, followed by the UI for the solution.


<h3 align="left">Languages and Tools:</h3>
 <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://nodejs.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/nodejs/nodejs-original-wordmark.svg" alt="nodejs" width="40" height="40"/> </a> <a href="https://firebase.google.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/firebase/firebase-icon.svg" alt="firebase" width="40" height="40"/> </a> </p>
