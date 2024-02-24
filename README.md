# Drawing

## Design Explained

- There are 3 main projects in order to separate out different primary concerns.
	- .Host is the "UI" project just visualising out outputs
	- .Abstractions is the service and model definitions kept separate to allow for a more modular design
	- .Core is where the heavy lifting happens, being the implementations of the abstractions glued together using DI
- Another big reason why I chose to split the projects in this way is that the "UI" project is not strongly coupled to the "Core" project.
	- They are linked together in DI and leverage the abstraction contracts in order to promote high cohesion with low coupling.

- One key aspect I was particularly focused on was not coupling together a particular shape type to it's render method.
	- The rendering logic is an isolated and singular responsibility built to be modular and extendable
- I leverage SOA in order to have a service contract definition and to leverage only the interface contracts in consuming code.
	- I use this pattern to allow for easier modification and development whereby we can modify the internals of a implementation without breaking the contract. 

### Core
- The core project is where the majority of the heavy lifting is happening.
- In this project, I leveraged the strategy pattern in order to essentially build up the rendered outputs
	- This allows for flexible code re-use for the shared aspects of rendering
	- It allows for easy extension as and when new rendering requirements arise
	- It is very modular which allows for testing on each level in isolation as well as the component as a whole
- The builder pattern has also been leveraged here.
	- This allows for a easy and fluent method of chaining together widgets
	- Adds an easy to use class for drawing management
- The main 3 benefits of the way this project has been designed are:
	- Flexibility: New rendering strategies can be easily added without changing existing code, adhering to the open/closed principle.
	- Decoupling: Rendering logic is decoupled from the widget representation and drawing service, simplifying maintenance and scalability.
	- Reusability: The strategy and service components can be reused across different parts of the application or in different projects with similar requirements.


### Tests
- There are unit test projects for the abstractions as well as the core
	- These cover each class in isolation
- We have a Core.Test.Component project which is used to test the core project as a whole with all of the strategies used. 

## Ways to improve
- Use FluentValidations in place of the Validate methods in the core models
- Adding extensions to WidgetDrawingBuilder to allow for specific object creation.
	- for example `builder.AddRectangle(...)`