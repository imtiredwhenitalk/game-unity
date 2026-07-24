# 🏗️ Архітектура проєкту

Цей проєкт побудований на **модульній та масштабованій архітектурі**, яка дозволяє легко розширювати функціональність, підтримувати код та додавати нові механіки без необхідності переписувати вже існуючі системи.

Основна ідея — **кожна система відповідає лише за одну конкретну задачу** та мінімально залежить від інших.

---

# 📂 Структура проєкту

```text
Assets/
│
├── Art/                # Моделі, текстури, матеріали, анімації та VFX
├── Audio/              # Музика, звукові ефекти та озвучення
├── Docs/               # Документація проєкту
├── Fonts/              # Шрифти
├── Prefabs/            # Unity Prefab'и
├── Scenes/             # Ігрові сцени
├── ThirdParty/         # Сторонні бібліотеки та плагіни
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

Точка входу в гру.

Відповідає за:

- запуск гри;
- ініціалізацію всіх необхідних систем;
- реєстрацію сервісів;
- завантаження першої сцени.

Основні файли:

```text
GameBootstrap.cs
GameInstaller.cs
SceneLoader.cs
DependencyContainer.cs
```

---

# ⚙️ Core

Ядро проєкту.

Містить системи, які не залежать від конкретної ігрової логіки та можуть використовуватись у будь-якому модулі.

Приклади:

- Event Bus
- Object Pool
- Save System
- Audio Manager
- Input System
- Logger
- Time Service
- State Machine
- Validators
- Extensions
- Commands

У цьому модулі **не повинно бути логіки геймплею**.

---

# 🎮 Gameplay

Містить усю ігрову логіку.

Основні модулі:

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

Кожен модуль є незалежним та відповідає лише за власну функціональність.

---

# 👤 Player

Логіка гравця поділена на окремі незалежні компоненти.

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

Такий підхід дозволяє легко додавати нові можливості без зміни вже існуючих систем.

---

# 🧟 Enemy

Архітектура ворогів також побудована модульно.

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

Типи ворогів:

- Walker
- Runner
- Tank
- Spitter
- Boss

Усі вони використовують спільні компоненти, але мають власні налаштування та поведінку.

---

# 🔫 Weapons

Система зброї відокремлює логіку від даних.

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

Це дозволяє легко додавати нові типи зброї без зміни існуючого коду.

---

# 🏠 Base

База реалізована як окремий модуль.

Включає:

- будівлі;
- генератор;
- сховище;
- лабораторію;
- оборонні споруди;
- систему покращень;
- виживших.

У майбутньому можна легко додавати нові будівлі або механіки без змін інших модулів.

---

# 📦 Data

Усі дані гри знаходяться окремо від логіки.

Приклади:

- ScriptableObject
- предмети
- зброя
- персонажі
- будівлі
- хвилі
- локалізація
- дані UI
- збереження

Жодні значення не повинні бути "зашиті" в код.

---

# 🎨 UI

Інтерфейс повністю відокремлений від ігрової логіки.

Приклади:

- HUD
- Головне меню
- Меню паузи
- Інвентар
- Екран завантаження
- Налаштування
- Game Over

UI взаємодіє з іншими системами через сервіси або події.

---

# 🔧 Services

Глобальні сервіси, які використовуються різними частинами гри.

Приклади:

- Audio Service
- Save Service
- Scene Service
- Spawn Service
- UI Service

---

# 🔌 Interfaces

Спільні інтерфейси для всієї гри.

Наприклад:

```text
IDamageable
IInteractable
IWeapon
IEnemy
IPoolable
ISaveable
IUpgradeable
```

Використання інтерфейсів дозволяє зменшити зв'язність між модулями.

---

# 📡 Архітектура на основі подій

Більшість систем взаємодіє між собою через події, а не через прямі посилання.

Приклад:

```text
Зомбі загинув
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

Такий підхід робить архітектуру більш гнучкою та масштабованою.

---

# 📐 Основні принципи

Під час розробки використовуються наступні принципи:

- SRP (Single Responsibility Principle)
- Composition over Inheritance
- Event-Driven Architecture
- Modular Design
- Data-Driven Development
- Separation of Concerns
- Dependency Injection (планується)

---

# 📈 Масштабованість

Архітектура проєкту одразу розрахована на подальший розвиток.

У майбутньому можна без значних змін додати:

- мультиплеєр;
- нові типи ворогів;
- нову зброю;
- нові будівлі;
- технологічне дерево;
- нові NPC;
- світові події;
- систему модифікацій;
- декілька слотів збережень.

---

# 📚 Документація

Додаткова документація знаходиться у папці `Docs`.

- Architecture.md
- Gameplay.md
- AI.md
- SaveSystem.md
- CodingStyle.md

---

# 🎯 Мета архітектури

Основна мета цього проєкту — створити **чисту, зрозумілу та масштабовану архітектуру**, яку буде легко підтримувати, тестувати та розширювати протягом усього циклу розробки гри.