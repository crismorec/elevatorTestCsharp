Elevator Control System - Cristhian Moreno Project

This is a technical test for an elementary elevator control system. The system manage 4 elevators in a building with 10 floors. I focus in clean code, maintainability and avoid the common bugs of "yo-yoing" movement.
🚀 Architectural Overview

The solution is developed using .NET 8 and is structured for be "production-ready" for a SaaS or B2B environment. I separate the logic in different layers:

    Abstractions: Define the contracts for elevators.

    Models: Keep the configurations and enums for status and direction.

    Services: The "brain" of the system where the movement algorithm lives.

    Unit Tests: A dedicated project using NUnit for validate the logic.

🛠️ Key Features & Fixes

I have pay attention to the feedback of previous tests for not repeat same mistakes:

    No Yo-Yoing Logic: The car keep moving in one direction until all passengers in that way are finish.

    Strict Validation: Security check for avoid invalid floors like 208 or negative numbers.

    Concurrency: Use of lock and CancellationToken for handle many requests at same time without "crawl" the performance.

    Accurate Timing: Every floor move is exactly 10 seconds and doors stay open for 10 seconds, as requested in manual.

🧪 Testing Coverage

The solution include a test project unitTestElevator. This is very important because tests prevent bugs before they happen.

    Boundary Tests: Check what happen if user input very high or low floors.

    Logic Tests: Ensure the elevator start at floor 1.

    State Tests: Validate that status change from Moving to DoorsOpen correctly.

🖥️ How to Run

    Open the solution .sln in Visual Studio 2022 or VS Code.

    Build the solution for restore the dependencies.

    Run elevatorTest for see the terminal with the simulation.

    (Optional) Open Test Explorer and run all tests for see the green checks.
