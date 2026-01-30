# The Spell Brigade - Speed Mod

[English](#english) | [中文](#中文)

---

## English

A BepInEx mod for **The Spell Brigade** that allows you to control game speed dynamically.

### Features

- 🚀 **Adjustable game speed** from 1.0x to 10.0x (increment: 0.5x)
- ⌨️ **Hotkey controls** for quick speed adjustments
- 📊 **Real-time display** showing current speed in top-right corner
- 💾 **Pause-resume persistence** - speed is restored after game pauses (e.g., skill upgrade menus)

### Installation

#### Prerequisites
- **BepInEx 6** (IL2CPP version) must be installed
- Download from: [BepInEx Releases](https://github.com/BepInEx/BepInEx/releases)

#### Steps
1. Download `SpellBrigadeSpeedMod.dll` from [Releases](https://github.com/ChongZhiCZ/TheSpellBrigade.SpeedMod/releases)
2. Copy the DLL to:
   ```
   <Game Installation Path>/BepInEx/plugins/
   ```
3. Launch the game - the mod will load automatically

### Usage

#### Keyboard Controls

| Key | Action |
|-----|--------|
| **Numpad +** or **=** | Increase speed by 0.5x |
| **Numpad -** or **-** | Decrease speed by 0.5x |
| **R** or **Backspace** | Reset speed to 1.0x |

#### Speed Display

The current game speed is displayed in the **top-right corner** of the screen (e.g., "Speed: 2.5x").

### Technical Details

- Built with **BepInEx 6** (IL2CPP)
- Uses **Il2CppInterop** for C# ↔ IL2CPP interoperability
- Dynamically adjusts `Time.timeScale` to control game speed
- Automatically restores speed after pause/resume events

### Notes

- Speed adjustments affect game time but not real-time UI elements
- Pause menus and dialogs temporarily set speed to 0 (normal behavior)
- Speed settings persist through pause screens

---

## 中文

《The Spell Brigade》的 BepInEx 模组，允许动态控制游戏速度。

### 功能特性

- 🚀 **可调节游戏速度**：1.0倍至10.0倍（步进0.5倍）
- ⌨️ **快捷键控制**：快速调整速度
- 📊 **实时显示**：右上角显示当前速度
- 💾 **暂停恢复**：游戏暂停后（如技能升级菜单）自动恢复速度

### 安装方法

#### 前置要求
- 必须安装 **BepInEx 6**（IL2CPP 版本）
- 下载地址：[BepInEx Releases](https://github.com/BepInEx/BepInEx/releases)

#### 安装步骤
1. 从 [Releases](https://github.com/ChongZhiCZ/TheSpellBrigade.SpeedMod/releases) 下载 `SpellBrigadeSpeedMod.dll`
2. 将 DLL 文件复制到：
   ```
   <游戏安装目录>/BepInEx/plugins/
   ```
3. 启动游戏 - 模组将自动加载

### 使用说明

#### 键盘控制

| 按键 | 功能 |
|-----|------|
| **小键盘+** 或 **=** | 提高速度 0.5倍 |
| **小键盘-** 或 **-** | 降低速度 0.5倍 |
| **R** 或 **Backspace** | 重置速度为 1.0倍 |

#### 速度显示

当前游戏速度显示在屏幕**右上角**（例如："Speed: 2.5x"）。

### 技术细节

- 基于 **BepInEx 6**（IL2CPP）构建
- 使用 **Il2CppInterop** 实现 C# ↔ IL2CPP 互操作
- 通过动态调整 `Time.timeScale` 控制游戏速度
- 自动处理暂停/恢复事件并恢复速度设置

### 注意事项

- 速度调整影响游戏时间，但不影响实时UI元素
- 暂停菜单和对话框会临时将速度设为0（正常行为）
- 速度设置在暂停界面中保持不变

---

## License

MIT License - Feel free to modify and distribute.

## Credits

Developed with Claude Code.
