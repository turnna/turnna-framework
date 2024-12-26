# Framework

## Overview
This project is a unity framework build on top of Unity6, designed to help developers build applications more efficiently. This  project is inspired from design patterns and game architecture using ScriptableObjects. It’s intended to be explored together with the e-book, [Create modular game architecture in Unity with ScriptableObjects](https://unity.com/resources/create-modular-game-architecture-with-scriptable-objects-ebook).

## Getting Started
Start the project from the BootScene scene in Assets/Core/Scene. 

## File structure
This project's scripts are structured in a feature-based architecture. Each feature is a folder that contains all the scripts and assets related to that feature. The features are:

- Audio: Contains the audio manager, audio mixer.
- EventChannels: Contains the event channels and events.
- Game: Contains the game manager and game-related assets.
- Input: Contains the input manager and input control.
- SceneManagement: Contains the scene manager and scene loader.
- UI: Contains the UI manager and UXML.
- Utilities: Contains helper classes and structs that are used across the project.
    - SaveLoad: Contains the static save/load system.

For other assets, such as prefabs, ScriptableObject data, clips. They are stored in the Resources folder.

## To do
- [x] Set up scene management (loading, transitions)
- [ ] Implement basic UI elements (menus, buttons, HUD)
- [x] Integrate audio management (background music, sound effects)
- [x] Develop save/load system (player progress, settings)
- [ ] Create core gameplay mechanics (player movement, interactions)
- [x] Establish input management (keyboard, mouse, gamepad)
