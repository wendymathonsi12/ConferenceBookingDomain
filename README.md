README 
# Conference Room Booking System - Domain Model

This repository contains the core domain model for a Conference Room Booking System. The focus of this project is to use C# as a domain-modeling language to enforce business rules and maintain valid object states without relying on external libraries.

---

## 🏗️ Project Structure

The solution is organized into logical units to ensure readiness for future Web API integration:

* **`ConferenceRoom.cs`**: Represents the physical booking resource.
* **`Booking.cs`**: Manages the lifecycle of a reservation.
* **`BookingRequest.cs`**: A DTO (Data Transfer Object) capturing user intent.
* **`Enums/`**: Contains `BookingStatus` and `RoomLayout` to restrict valid states.

---

## 🛠️ Design Decisions & Justifications

### 1. Class vs. Record Usage
* **`ConferenceRoom` (Class):** Implemented as a class because a room has **Identity**. Even if the name or capacity changes, it remains the same room.
* **`Booking` (Record):** Implemented as a record. Since a booking is essentially a snapshot of a transaction in time, the value-based equality and immutability of records provide a safer way to handle reservation data.

### 2. State Encapsulation
I avoided public fields and used **Property Initializers** (`init`) and **Private Setters**:
* Room `Id` and `Capacity` are set at creation and cannot be modified by external logic, preventing accidental corruption of the domain.
* `BookingStatus` can only be changed via domain methods like `.Confirm()` or `.Cancel()`, ensuring that status transitions are intentional.

### 3. Business Rule Enforcement (Validation)
Rules are enforced within the **Constructors**. This ensures that an object cannot exist in an invalid state (**Always-Valid Domain Model**):
* **Capacity Check:** A room cannot be created with a capacity of 0 or less.
* **Chronological Integrity:** A booking cannot end before it starts.
* **String Validation:** Required fields like Room names cannot be null or whitespace.

### 4. Domain Vocabulary (Enums)
Instead of using strings for layouts or statuses, I used Enums (`RoomLayout`). This prevents "magic strings" and ensures that the system only supports specific, predefined business configurations.

---

## 🚀 Demonstration

The `Program.cs` file serves as a demonstration harness. It executes the following flow:
1.  Instantiates a valid `ConferenceRoom`.
2.  Captures a `BookingRequest` (simulating user input).
3.  Attempts to create a `Booking`, triggering validation logic.
4.  Demonstrates a state transition from `Pending` to `Confirmed`.
5.  Triggers and catches an `ArgumentException` to prove that invalid time ranges are rejected by the domain logic.

---

## 🔧 How to Run
Ensure you have the **.NET 8 SDK** installed.

1. Clone the repository.
2. Navigate to the project folder.
3. Run the following command:
   ```bash
   dotnet run

## 🆕 Assignment 1.2 Updates: Business Logic


### Key Extensions
* **BookingService**: Introduced a service layer to decouple business logic from the entry point (`Program.cs`).
* **LINQ Integration**: Used `.Any()` for overlapping time-slot detection and `.FirstOrDefault()` for room validation.
* **Collection Management**: Utilized `List<T>` to manage in-memory state for rooms and bookings.

### Enforced Business Rules
1.  **No Double-Booking**: Logic ensures that for any given RoomId, new bookings cannot overlap with existing `Confirmed` or `Pending` bookings.
2.  **Room Existence**: The system validates the `RoomId` against the internal collection before processing.
3.  **Fail-Fast Validation**: Logic checks for errors (Missing rooms, overlaps) immediately and returns a rejection before any state change occurs.
