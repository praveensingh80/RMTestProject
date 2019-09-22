# RMTestProject

Steps to Execute the tests:
***************************
-Clone the repository
-Goto the Utilities folder under the RMAutoFramework project
-Execute the shell script StartGrid.sh
-Now open the Nunit console and execute following comand to run tests:
nunit3-console.exe "<Location of project>\RMTestProject\RMTest\bin\Debug\RMTest.dll" --testparam testSetting=dev -noresult
