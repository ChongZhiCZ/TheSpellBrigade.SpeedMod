# The Spell Brigade Speed Mod - Design Document

**Date:** 2026-01-30
**Project:** Unity Mod for The Spell Brigade
**Purpose:** Add game speed control (1x-10x) via hotkeys with on-screen display

---

## Overview

A BepInEx mod for The Spell Brigade that allows players to speed up gameplay from 1x to 10x using hotkeys, with on-screen speed display that matches the game's UI style.

### Technology Stack

- **BepInEx 6.x (IL2CPP)**: Modding framework for IL2CPP Unity games
- **C#**: Mod implementation language
- **Unity's Time.timeScale**: Controls game speed multiplier
- **Unity UI/TextMeshPro**: For styled UI display (with OnGUI fallback)

### Why BepInEx?

The Spell Brigade uses IL2CPP compilation (indicated by `GameAssembly.dll` and `il2cpp_data`), requiring a framework with IL2CPP support. BepInEx 6.x is the most mature and well-supported option with an active community.

---

## User Experience

### Hotkey Controls

- **Numpad + or = key**: Increase speed by 0.5x
- **Numpad - or - key**: Decrease speed by 0.5x
- **Backspace or R key**: Reset to 1x (normal speed)

### Speed Behavior

- **Range**: 1.0x - 10.0x (no slow motion, only speed up)
- **Increment**: 0.5x steps (1.0x → 1.5x → 2.0x → 2.5x...)
- **Clamping**: Stays at min/max when limit reached (no wrapping)
- **Default**: Always starts at 1.0x on game launch
- **Scope**: Affects everything controlled by Unity's time system (animations, physics, timers)

### Visual Display

- **Target**: Match game's UI style (font, color, styling)
- **Implementation**: Explore game's UI system during development (TextMeshPro/Unity UI)
- **Fallback**: Simple text display if game UI is inaccessible
- **Position**: Top-right corner, non-intrusive
- **Content**: "Speed: 2.5x" format

---

## Architecture

### Project Structure

```
SpellBrigadeSpeedMod/
├── SpeedController.cs          # Main mod class (BepInEx plugin)
├── SpeedDisplay.cs             # UI display component
├── Config.cs                   # Configuration management (optional)
└── SpellBrigadeSpeedMod.csproj # Project file
```

### Core Components

#### 1. SpeedController (BepInEx Plugin)
- Inherits from `BasePlugin` (BepInEx IL2CPP)
- Initializes mod in `Load()` method
- Detects hotkey input in `Update()` loop
- Manages `Time.timeScale` value
- Creates and manages SpeedDisplay component

#### 2. SpeedDisplay (MonoBehaviour)
- Attached to persistent GameObject
- Renders speed text on screen
- Attempts to integrate with game's UI system during development
- Falls back to OnGUI if needed

#### 3. Configuration (Optional for v1)
- Can use BepInEx config system for custom hotkeys
- Keep it simple initially with hardcoded keys

---

## Workflow & Data Flow

### Mod Loading Flow

1. Game starts → BepInEx detects and loads mod DLL
2. `SpeedController.Load()` is called
3. Create persistent GameObject with SpeedDisplay component
4. Initialize speed to 1.0x
5. Begin listening for hotkey input

### Runtime Data Flow

```
User presses hotkey
  → SpeedController.Update() detects input
  → Calculate new speed (currentSpeed ± 0.5)
  → Clamp to [1.0, 10.0] range
  → Update Time.timeScale = newSpeed
  → SpeedDisplay reads Time.timeScale
  → Update on-screen display
```

### Key Technical Points

- **Time.timeScale**: Unity's global time scaling, affects animations, physics, coroutines
- **DontDestroyOnLoad()**: Ensures GameObject persists across scene transitions
- **Input detection**: Runs in `Update()` every frame
- **UI updates**: Refresh every frame (optimize by only rebuilding text on change)

---

## Error Handling & Edge Cases

### 1. Game Pause Menu Conflicts
- **Issue**: Game may set `Time.timeScale = 0` for pause
- **Solution**: Detect pause state and disable speed adjustments, or allow game pause to override (acceptable behavior)

### 2. Scene Transitions
- Use `DontDestroyOnLoad()` to maintain mod components across level changes
- Verify and reapply `Time.timeScale` after scene loads if reset by game

### 3. Input Conflicts
- **Issue**: Game may already use chosen hotkeys
- **V1 approach**: Use Numpad keys (typically safe from conflicts)
- **Future improvement**: User-configurable hotkeys via config file

### 4. Performance at High Speeds
- **Issue**: 8x-10x speed may cause physics instability or crashes
- **Mitigation**: Log warnings about high-speed risks
- **Expectation**: User assumes risk (expected mod behavior)

---

## Development & Testing Plan

### Development Environment Setup

1. Install Visual Studio 2022 (or VS Code + .NET SDK)
2. Install BepInEx 6.x IL2CPP to game directory
3. Create C# class library project
4. Reference BepInEx.IL2CPP.dll and Unity libraries
5. Configure build output to BepInEx plugins folder

### Development Steps

1. Implement basic speed control (hotkeys + Time.timeScale)
2. Add simple OnGUI text display to verify functionality
3. Explore game's UI system and attempt style integration
4. Add boundary checks and error handling
5. Test across scene transitions, pause states, etc.

### Testing Methods

- Launch game and check BepInEx console for mod loading
- Test all hotkeys for responsiveness
- Test in different scenes and game states
- Test boundary values (1x and 10x)
- Verify UI display correctness

### Logging

Use BepInEx Logger to record:
- Mod load success
- Speed change events
- UI system initialization status
- Any errors or warnings

---

## Future Enhancements (Out of Scope for V1)

- Configurable hotkeys via BepInEx config
- Preset speed buttons (1x, 2x, 5x, 10x)
- Speed persistence between sessions
- More sophisticated UI integration
- Per-scene speed profiles
