# 🏗️ Project Architecture

This project follows a **modular and scalable architecture** designed for long-term development and easy maintenance.  
Each system has a single responsibility and is isolated from the others, making the codebase easier to extend, debug, and test.

---

# 📂 Project Structure

```text
Assets/
│
├── Art/                # Models, textures, materials, animations and VFX
├── Audio/              # Music, sound effects and voice lines
├── Docs/               # Project documentation
├── Fonts/              # Fonts
├── Prefabs/            # Game prefabs
├── Scenes/             # Unity scenes
├── ThirdParty/         # External plugins and assets
│
└── Game/
    ├── Bootstrap/
    ├── Core/
    ├── Gameplay/
    ├── UI/
    ├── Data/
    ├── Services/
    ├── Interfaces/
    ├── Networking/
    ├── Configs/
    ├── Tests/
    └── Editor/
```

---

# 🚀 Bootstrap

The application's entry point.

Responsible for:

- Initializing the game
- Installing services
- Loading the first scene
- Registering global systems

Files:

```text
GameBootstrap.cs
GameInstaller.cs
SceneLoader.cs
DependencyContainer.cs
```

---

# ⚙️ Core

Contains the engine-independent systems used throughout the project.

Examples:

- Event Bus
- Object Pool
- Save System
- Audio Manager
- Input
- Logger
- Time Service
- State Machine
- Validators
- Extensions
- Commands

The Core layer should never contain gameplay-specific logic.

---

# 🎮 Gameplay

Contains every gameplay mechanic.

Current modules:

```text
Player
Enemy
Weapons
Projectiles
Damage
Camera
Inventory
Experience
Economy
WaveSystem
Base
Construction
Crafting
NPC
Resources
World
Systems
```

Each module is fully isolated and contains only its own logic.

---

# 👤 Player

The player is split into multiple independent systems.

```text
Player
│
├── Controllers
├── Components
├── Input
├── Movement
├── Combat
├── Health
├── Skills
├── Experience
├── Animation
├── Interaction
├── Data
├── StateMachine
└── States
```

This allows adding new mechanics without modifying unrelated code.

---

# 🧟 Enemy

Enemies are built using a modular component architecture.

```text
Enemy
│
├── AI
│   ├── Navigation
│   ├── Sensors
│   ├── DecisionMaking
│   ├── StateMachine
│   └── States
│
├── Components
├── Types
├── Spawn
├── Loot
└── EnemyFactory.cs
```

Enemy types:

- Walker
- Runner
- Tank
- Spitter
- Boss

---

# 🔫 Weapons

Weapon logic is separated from weapon data.

```text
Weapons
│
├── Firearms
│   ├── Pistols
│   ├── Rifles
│   ├── Shotguns
│   └── Snipers
│
├── Melee
├── Explosives
├── Mods
│
├── Weapon.cs
├── WeaponFactory.cs
└── WeaponManager.cs
```

---

# 🏠 Base

The base is a standalone gameplay module.

Includes:

- Buildings
- Generator
- Storage
- Laboratory
- Defense
- Survivors
- Upgrade system

Future gameplay systems can be added without affecting existing modules.

---

# 📦 Data

Contains all game data.

Examples:

- ScriptableObjects
- Items
- Weapons
- Characters
- Buildings
- Waves
- Save Data
- Localization
- UI Data

Gameplay logic should never hardcode values.

---

# 🎨 UI

UI is completely separated from gameplay logic.

Examples:

- HUD
- Main Menu
- Pause Menu
- Inventory
- Loading Screen
- Settings
- Game Over

UI should communicate with gameplay through events or services.

---

# 🔧 Services

Global services used by multiple systems.

Examples:

- Audio Service
- Save Service
- Scene Service
- Spawn Service
- UI Service

---

# 🔌 Interfaces

Shared interfaces used across the project.

Examples:

```text
IDamageable
IInteractable
IWeapon
IEnemy
IPoolable
ISaveable
IUpgradeable
```

Using interfaces reduces coupling between systems.

---

# 📡 Event-Driven Architecture

Gameplay systems communicate using events instead of direct references.

Example:

```text
Enemy dies
        │
        ▼
EnemyKilledEvent
        │
        ├── Experience System
        ├── Loot System
        ├── Quest System
        ├── Wave System
        └── UI
```

This keeps systems independent and easier to maintain.

---

# 🎯 Design Principles

The project follows several software engineering principles:

- Single Responsibility Principle (SRP)
- Composition over Inheritance
- Event-Driven Architecture
- Modular Design
- Data-Driven Development
- Separation of Concerns
- Dependency Injection (planned)

---

# 📈 Scalability

The architecture is designed to support future features, including:

- Multiplayer
- More enemy types
- New weapons
- Additional NPCs
- New base buildings
- Expanded crafting
- Technology tree
- Dynamic world events
- Save slots
- Mod support

without requiring major architectural changes.

---

# 📚 Documentation

Additional documentation can be found inside the `Docs/` directory.

- Architecture.md
- Gameplay.md
- AI.md
- SaveSystem.md
- CodingStyle.md

---

# 💡 Goal

The primary goal of this architecture is to build a maintainable, scalable and clean codebase that can evolve as the project grows while keeping gameplay systems independent and easy to extend.