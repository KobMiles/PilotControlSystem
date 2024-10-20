# Pilot Control System

A simulation of an aircraft control system that includes various components such as the engine, fuel system, and indicators for speed, height, and fuel levels. The system is built with a WPF-based GUI to simulate an aircraft's control panel in real-time.

## Features

- **Aircraft Simulation**: 
    - Simulates core aircraft functions such as engine management and fuel consumption.
    - Implements a control system for adjusting aircraft behavior.
- **Indicators**: 
    - Displays real-time indicators for speed, height, and fuel levels.
- **GUI**: 
    - A WPF-based `InstrumentPanel` for visualizing the control system.
- **Modular Design**: 
    - Object-oriented design with classes for each aircraft component, including:
        - `Aircraft`
        - `Engine`
        - `FuelSystem`
        - `SpeedIndicator`
        - `HeightIndicator`

## Project Structure

```bash
Pilot-Control-System/
├── 20240829_PilotControlSystem.sln       # Solution file
├── 20240829_PilotControlSystem/          # Main project folder
│   ├── App.xaml                          # Application entry point
│   ├── App.xaml.cs                       # Code-behind for application startup
│   ├── InstrumentPanel.xaml              # WPF XAML for instrument panel UI
│   ├── InstrumentPanel.xaml.cs           # Code-behind for the instrument panel
│   ├── Classes/                          # Aircraft components
│   │   ├── Aircraft.cs                   # Main aircraft class
│   │   ├── ControlSystem.cs              # Control system class
│   │   ├── Engine.cs                     # Engine simulation class
│   │   ├── FuelSystem.cs                 # Manages fuel consumption
│   │   ├── Indicators.cs                 # Base class for indicators
│   │   ├── FuelIndicator.cs              # Fuel level indicator
│   │   ├── SpeedIndicator.cs             # Speed indicator
│   │   ├── HeightIndicator.cs            # Height indicator
│   └── AssemblyInfo.cs                   # Assembly information
├── .gitignore                            # Git ignore rules
└── .gitattributes                        # Git attributes
```

## Getting Started

### Prerequisites

- .NET 6 or later
- Visual Studio 2022 (or any compatible IDE with WPF support)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/Pilot-Control-System.git
   ```

2. Open the solution in Visual Studio:

   ```bash
   cd Pilot-Control-System
   ```

3. Build and run the project.

### Usage

- Launch the application to start the aircraft simulation.
- The WPF-based instrument panel will display live updates on speed, height, and fuel levels.
- Adjust control settings in real-time to interact with the simulated aircraft.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
