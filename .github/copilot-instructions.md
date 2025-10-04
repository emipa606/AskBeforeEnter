# GitHub Copilot Instructions for Ask Before Enter Mod

Welcome to the "Ask Before Enter" RimWorld mod development guidance. This document aims to provide comprehensive instructions, coding patterns, conventions, and suggestions for using GitHub Copilot in your modding project. This guide will help streamline the development process of the "Ask Before Enter" mod and enhance its integration with RimWorld's systems.

## Mod Overview and Purpose

**Mod Name**: Ask Before Enter

**Purpose**: The "Ask Before Enter" mod allows players to prevent unwanted visitor groups, trade caravans, or travelers from entering their colony at inopportune times. It achieves this by providing a notification and options for visitors to wait or return later, thus averting potential threats, such as automatic triggering of dormant mech clusters.

### Key Features and Systems

1. **Visitor Management**: Offers control over incoming groups with options to delay their entrance or request their temporary departure.
2. **Notifications**: Alerts players when a caravan or visitor group is approaching, enabling timely decision-making.
3. **Mod Options**: Customizable settings to select which groups the notification and control should apply to.
4. **Harmony Patching**: Subtle integration into the game’s incident and group handling systems using the Harmony library for seamless gameplay experiences.

### Coding Patterns and Conventions

- **Naming Conventions**: Follow C# standard conventions, using PascalCase for classes and methods, and camelCase for local variables.
- **Class Design**: Separate class responsibilities clearly, such as `GameComponent_RefusalTracker` for tracking refusal states and `AskBeforeEnterMod` for mod initialization.
- **Method Usage**: Focus on single responsibility in methods; methods within `IncidentWorker_*_TryExecuteWorker` handling the decision-making logic for visitor events.

### XML Integration

- Use XML for defining mod settings and configuration details, linking them with `AskBeforeEnterSettings`.
- Make use of XML-definitions for easy alterations of mod configurations.

### Harmony Patching

- Apply Harmony patches to incident worker classes like `IncidentWorker_TraderCaravanArrival_TryExecuteWorker`, `IncidentWorker_TravelerGroup_TryExecuteWorker`, and `IncidentWorker_VisitorGroup_TryExecuteWorker` to modify how these incidents trigger visitor arrival events.
- Ensure that patches are applied and removed correctly to prevent conflicts with other mods and maintain the game's stability.

### Suggestions for Copilot

When using GitHub Copilot for the "Ask Before Enter" mod, consider the following suggestions:

1. **Boilerplate Code**: Utilize Copilot for generating repetitive boilerplate code, especially when creating new classes or methods that adhere to existing patterns.
2. **Harmony Integration**: Allow Copilot to assist in writing Harmony patch attributes and look for patterns in patching methods.
3. **XML Handling**: Leverage Copilot's understanding to write and manage XML configuration files efficiently.
4. **Mod Options Integration**: Use Copilot to suggest code for interacting with modular parts of RimWorld's settings and integrate mod options smoothly.

By following the above instructions and utilizing GitHub Copilot effectively, you can enhance the development workflow of the "Ask Before Enter" RimWorld mod. These structured guidelines will help maintain code consistency and integrate the mod efficiently with the game's existing mechanics.
