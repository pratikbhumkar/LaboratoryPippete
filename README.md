# Laboratory Pipette

### Laboratory pipette representation for myDNA test.
### .Net core console based application.

#### Steps to run project from Terminal:
1. Download the code.
2. Open the folder in your favorite IDE.
3. Open terminal and execute the below commands.
4. cd ./LaboratoryPipette
5. Open terminal
6. dotnet run

#### Steps to run test cases from Visual Studio:
1. Open project.
2. Hit 'Run all test cases'

#### Steps to run test cases from Terminal:
1. Download the code.
2. Open terminal and execute the below commands.
3. cd ./LaboratoryPipette
4. Open terminal
5. run dotnet test

### Assumptions

- The arm will fill the pipette in one single drop/pump. So once dropped status will be full.
- Commands are case sensitive.
- Console based input.

### Sample Commands and reponses
- Place 
  - Place command. Takes in the x,y cordinates and places the robotic arm over the well.
  - Sample Command Place 1,1
  
- Drop
  - Drop command drops the liquid into the well.
  - Sample Command Drop

- Detect
  - Detect command Detects the liquid's status for the current well.
  - Sample Command Detect
  - Sample output FULL/EMPTY
  
- MoveNorth
  - MoveNorth command moves the robotic arm one step in upward direction.
  - Sample Command Move N.
  
- MoveSouth
  - MoveSouth command moves the robotic arm one step in downward direction.
  - Sample Command Move S.

- MoveEast
  - MoveEast command moves the robotic arm one step in Eastern direction.
  - Sample Command Move E.
  
- MoveWest
  - MoveWest command moves the robotic arm one step in Western direction.
  - Sample Command Move W. 
  
- Report
  - Report command creates and prints a string 
  - Sample Command 'Report'.
  - Sample Output '1,1,EMPTY'

