# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

This RimWorld mod aims to enhance the player's experience by introducing an achievements system alongside configurable mod settings for visitor interactions. This mod caters to players who enjoy progression systems and enhanced control over interactions with different factions and groups visiting their colony.

## Key Features and Systems

- **Achievements System**: Introduced through the `AchievementsExpanded` framework, allowing players to unlock various achievements as they accomplish specific tasks in-game. The mod integrates trackers to monitor specific actions and trigger achievements.
  
  - **RefusalTracker**: A tracker that monitors refusals of incidents to log and potentially unlock achievements.
  - **GameComponent_RefusalTracker**: A game component that manages the refusal events and aggregates data for the achievement system.

- **Visitor Interaction Settings**: Managed by the `AskBeforeEnter` feature, providing players with settings to configure responses to incoming groups, such as trader caravans and visitors.

## Coding Patterns and Conventions

- **Naming Conventions**: Classes and methods are named using PascalCase, consistent with C# conventions. Internal settings classes are prefixed with `AskBeforeEnter`, indicating their module affiliation.

- **Class Organization**: 
  - Use of `public`, `internal`, and `static` modifiers appropriately to indicate the intended access level and utility.
  - Classes like `AskBeforeEnterSettings` are marked `internal` to restrict their visibility to the enclosing assembly.

- **Method Implementation**: Though method implementations are not explicitly detailed in this mod overview, Copilot can suggest boilerplate code for methods based on usage patterns from similar scenarios.

## XML Integration

- **Mod Settings Serialization**: The `AskBeforeEnterSettings` class leverages RimWorld's XML-based serialization system to store and retrieve settings. XML files define player-configurable parameters which the game loads at runtime.

## Harmony Patching

- **Harmony** is used for runtime method replacement and modification. This mod likely employs Harmony patches in classes such as `IncidentWorker_TraderCaravanArrival_TryExecuteWorker`, `IncidentWorker_TravelerGroup_TryExecuteWorker`, and `IncidentWorker_VisitorGroup_TryExecuteWorker` to intercept and modify behavior when visitors approach.

## Suggestions for Copilot

Given the context of this mod, here are tailored suggestions for using GitHub Copilot to aid development:

1. **Method Stubs**: Use Copilot to auto-generate method stubs within classes, particularly for tracker logic and mod initialization in `Main.cs`.

2. **Harmony Patch Templates**: You can prompt Copilot to suggest templates for common Harmony patch types, such as Prefix and Postfix, to intercept method calls in incident workers.

3. **XML Parsing Code**: Copilot can provide boilerplate code for reading and writing XML settings, crucial for expanding `AskBeforeEnterSettings`.

4. **Code Refactoring Suggestions**: Utilize Copilot to identify opportunities to refactor existing classes into smaller, more maintainable units – for example, by splitting responsibilities within the game components.

5. **Error Handling Patterns**: Copilot can help implement consistent error handling patterns across mod components to enhance robustness.

By instructing GitHub Copilot with these guidelines, you can streamline mod development while adhering to best practices and enhancing the mod's functionality.
