# Library Management System

A robust and clean C# Console Application built as part of the Backend Track assessment at **Prime Academy**. This project demonstrates the practical application of core software engineering principles, clean code, and solid architecture.

##  Features & Operations
- **Add a New Book:** Dynamically populate the library catalog with unique ISBNs.
- **Register a New User:** Manage library members with discrete student/user records.
- **Borrow a Book:** Validate availability and associate books directly with active user accounts.
- **Return a Book:** Relinquish borrowed titles back to the library pool instantaneously.
- **Search & Filter (Advanced):** Highly flexible filtering utilizing functional programming tools.

---

##  Architecture & Folder Structure
The project follows a decoupled, maintainable directory layout ensuring **Separation of Concerns**:
- `Models/`: Data structures representing core domain entities (`Book.cs`, `User.cs`) enforcing **Encapsulation**.
- `Interfaces/`: Abstract contracts (`ILibraryService.cs`) decoupling code to support **Dependency Inversion**.
- `Services/`: Core business operations and rules implementing the system's logic (`LibraryService.cs`).
- `Program.cs`: A lightweight orchestrator responsible purely for user interaction and application routing.

---

##  Software Engineering Choices

### 1. Object-Oriented Programming (OOP)
- **Encapsulation:** Object states (properties like `Isbn` and `IsBorrowed`) are strictly protected via automatic C# properties `{ get; set; }` and exposed safely through behavior.
- **Abstraction:** The entire user interface coordinates with an interface blueprint (`ILibraryService`), blinding the caller to the underlying data access machinery.

### 2. SOLID Principles Applied
- **S (Single Responsibility):** Every class is single-focused. Models hold data, Services compute behavior, and `Program.cs` manages input/output.
- **O (Open/Closed):** Extensibility is enabled without system modifications. New custom searches can be injected effortlessly without modifying stable service methods.
- **D (Dependency Inversion):** High-level execution flows rely entirely upon abstractions (`ILibraryService`) rather than standard concrete definitions.

### 3. Meaningful Delegate Utilization
Instead of compiling redundant lookup methods for every criteria variant, a singular, high-utility filtration mechanism was developed:
```csharp
List<Book> FindBooks(Func<Book, bool> filter);
```
By utilizing `Func<Book, bool>` as a delegate contract, the calling logic inside `Program.cs` can seamlessly inject complex lookup clauses inline using lambda syntax (e.g., isolating immediate availability or targeting precise authorship), promoting intense code reusability.

---

##  How to Run the Project
1. Clone the repository to your desktop.
2. Open the solution file using **Visual Studio 2022** (or newer).
3. Ensure the project target is configured as a C# Console Application.
4. Press `F5` or click **Start** to run the interactive console wizard.
