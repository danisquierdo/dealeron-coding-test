# dealeron-coding-test
*Coding Test for DealerOn Interview*

Instructions
- Run the ConsoleApp application and enter the path to the input file

Assumptions
- The input file will have the same format as the example: 1 line for the plateau, 2 for each rover
- The input will always be 1 plateau and 2 rovers
- A plateau with no length is not valid (endpoint (0,0))
- A rover will follow instructions until it runs into an invalid instruction or is sent to a space that is occupied

Design
- Each class is responsible for its operations and validation
- Factories hide the complexity of creating objects from input strings
- The Plateau class maintains a list of the Rovers currently in it and validates if the position the Rover wants to go to is valid, making sure it won't be out of boundaries or collide with another Rover in the same Plateau
- The Domain layer is created separately so that another application can access the logic, for example a Web application can be used to create the objects and send instructions
- We could use interfaces for the objects and factories to change for a different behavior or input type in the future without having to change any existing code. This would allow us to use Dependency Injection as well
- We should use custom Exception types that relate to the Domain so it's easier to identify and handle the errors
