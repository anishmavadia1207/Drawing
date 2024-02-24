# Drawing

## Design Overview

- The project architecture is divided into three main areas to clearly separate concerns.
	- `.Host` serves as the visual interface, focusing on displaying outputs.
	- `.Abstractions` houses service and model definitions, maintained separately to foster modularity.
	- `.Core` is the engine room, where the practical implementations of abstractions come to life through Dependency Injection (DI).
- A pivotal reason for this division is to ensure the "UI" component remains loosely connected to the "Core". This is achieved through DI, leveraging abstract contracts to ensure high cohesion without tight coupling.

- A particular focus was to avoid directly linking specific shapes to their rendering logic.
	- The rendering approach is designed to be modular and scalable, tasked with a singular focus.
- By adopting Service-Oriented Architecture (SOA), clear service contracts were established, relying solely on interface contracts for code consumption.
	- This approach provides flexibility for internal modifications without altering the foundational contract.

### Core
- The core project is where the magic happens.
- Here, the strategy pattern was embraced to build out rendered outputs creatively.
	- This strategy enables efficient code reuse for common rendering tasks and seamlessly integrates new rendering capabilities as needed.
	- Its modular nature also significantly simplifies testing, whether for individual components or the system as a whole.
- The builder pattern was also implemented.
	- This approach streamlines the widget assembly process, making it intuitive and manageable.
	- It introduces a user-friendly class for overseeing drawing tasks.
- The design of this project stands out for its:
	- **Flexibility**: New rendering strategies can be incorporated effortlessly, in line with the open/closed principle.
	- **Decoupling**: By separating rendering logic from widget representations and drawing services, maintenance has been simplified and scalability enhanced.
	- **Reusability**: Both strategy and service components are crafted for broad applicability, whether within this project or elsewhere.

### Tests
- The testing framework includes unit tests for both the abstractions and the core components, examining each class in isolation.
- Additionally, the `Core.Test.Component` project facilitates comprehensive testing of the core project, leveraging all implemented strategies.

## Enhancement Suggestions
- Transition to using FluentValidation instead of core model validate methods for more streamlined and powerful validation.
- Introduce extensions to `WidgetDrawingBuilder` for more intuitive object creation, like `builder.AddRectangle(...)`, enhancing the developer experience.