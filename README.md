# Outdoor Equipment Rental System
A C# console application that simulates a full equipment rental business, built as an academic project to demonstrate object-oriented programming principles.

## Features
- Rent multiple equipment types: Bicycles, Kayaks, and Tents
- Multiple pricing strategies: standard, weekend, and high-season rates
- Full rental lifecycle management with state validation
- Three payment modes: cash (with change), card, and simple payment
- Automatic late fee and damage penalty calculation
- Rental reports with cost breakdown and reservation status

## Concepts Applied
- **Inheritance** — `Equipo` base class extended by `Bicicleta`, `Kayak`, and `TiendaCampana`
- **Polymorphism** — `TarifaEquipo` base class overridden by `TarifaFinDeSemana` and `TarifaTemporadaAlta`
- **Encapsulation** — private fields with public getters/setters, `private set` on reservation properties
- **Method Overloading** — `ComprobantePago.Pagar()` handles cash, card, and simple payment modes
- **Enums** — `EstadoReserva` manages reservation state transitions
- **Collections** — `List<Equipo>` and `List<Reserva>` for managing inventory and reservations
- **DateTime** — rental duration calculation and automatic late fee application
- **State Machine** — enforced flow: Pending → Confirmed → Delivered → Returned → Closed / Canceled

## Project Structure
```
├── Equipo.cs              # Base equipment class
├── Bicicleta.cs           # Bicycle subclass
├── Kayak.cs               # Kayak subclass
├── TiendaCampana.cs       # Tent subclass
├── TarifaEquipo.cs        # Base pricing class
├── TarifaFinesDeSemana.cs # Weekend pricing subclass
├── TarifaTemporadaAlta.cs # High-season pricing subclass
├── Reserva.cs             # Reservation with state machine logic
├── GestorReserva.cs       # Reservation manager and report generator
├── ComprobantePago.cs     # Payment handler with overloaded methods
├── Cliente.cs             # Customer class
└── Program.cs             # Entry point and demo
```

## How to Run
```bash
dotnet run
```
Requires [.NET 9](https://dotnet.microsoft.com/download)

## Author
Javies J. Canales Rodriguez  
<<<<<<< HEAD
Inter American University of Puerto Rico, Arecibo Campus
=======
Inter American University of Puerto Rico, Arecibo Campus
>>>>>>> 2b6cab08056120948ea948c9fbf3b8c4c2fd2767
