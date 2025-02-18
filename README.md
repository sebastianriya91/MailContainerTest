### Mail Container Test 

The code for this exercise has been developed to manage the transfer of mail items from one container to another for processing.

#### Process for transferring mail

- Lookup the container the mail is being transferred from.
- Check the containers are in a valid state for the transfer to take place.
- Reduce the container capacity on the source container and increase the destination container capacity by the same amount.

#### Restrictions

- A container can only hold one type of mail.


#### Assumptions

- For the sake of simplicity, we can assume the containers have an unlimited capacity.

### The exercise brief

The exercise is to take the code in the solution and refactor it into a more suitable approach with the following things in mind:

- Testability
- Readability
- SOLID principles
- Architectural design of the code

You should not change the method signature of the MakeMailTransfer method.

You should add suitable tests into the MailContainerTest.Test project.

There are no additional constraints, use the packages and approach you feel appropriate, aim to spend no more than 2 hours. Please update the readme with specific comments on any areas that are unfinished and what you would cover given more time.

### Dev Work : Author: Riya Sebastian

SOLID Principles:

1. Interface Segregation: Created IContainerDataStore and made BackUp & Mail CDS to inherit + Interfaces used for startegies + factories
2. Single Responsibility Principle - Refactored MailTransferService & extracted the logic to decide the mail container data store to Factory. Initialized this factory in constructor 
3. Dependency injection - Made service loosely coupled to  data store factory by constructor injection (Dependency injection). No instantiation in ctor/ method
4. Open closed Principle - creation of DataStore instances into a factory which makes code testable and removes duplication.
5. Liskov Subs : To-do : Create abstract classes for data store


TDD:
Unit test for service logic (although continer is not set, verified the false scenarios)
Unit testing for factory
Unit test for strategy and individual processors

patterns Used:
1. Factory Pattern for determining ContainerDataStore
2. Strategy pattern to determine Processor for different kinds to mail & to execute transfer 
