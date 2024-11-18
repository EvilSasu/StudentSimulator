# StudentSimulator

## Project Overview
The **StudentSimulator** game simulates a life of a student, where players manage various aspects such as energy, hunger, wisdom, and health while navigating through different life events and scenarios. The game includes interactions with various systems such as dialogue, choice-making, and mini-games. The core mechanics are driven by in-game time, player stats, and event-driven storytelling, providing a dynamic experience with multiple possible outcomes.

## Core Classes

### 1. **PlayAnimation**
**Purpose**: This class is used to control animations on a GameObject using either an Animation or an Animator.

**Key Features**:
- **PlayAnimat(AnimationClip ac)**: Plays an animation using the Animation component.
- **UseTrigger(string trigger)**: Sets a trigger in the Animator to control state changes in animations.

### 2. **AudioController**
**Purpose**: Manages audio playback for both background music and sound effects.

**Key Features**:
- Initializes volume settings based on an AudioVolume component found in the scene.
- Plays background music and sound effects through two AudioSource components.
- Allows for smooth transitions between music clips using the **SwitchMusic** method and updates volumes gradually.

### 3. **BackgroundController**
**Purpose**: Manages background images in the game, allowing for dynamic switching between different backgrounds.

**Key Features**:
- Switches between two background images using triggers and an Animator.
- Allows for setting specific images directly and plays the first dialogue when needed.
- Plays a first story scene dialogue using **PlayFirstDialogue**.

### 4. **ChooseController**
**Purpose**: Manages the choice system in the game, displaying options to the player and handling interactions.

**Key Features**:
- Displays multiple choice options based on a **ChooseScene**.
- Each choice may trigger different events and lead to different story outcomes.
- Adjusts the size of the choices dynamically and allows for choosing a scene through the **PerfomChoose** method.
- Controls enabling and disabling of the choice system.

### 5. **ChooseLabelController**
**Purpose**: Represents an individual choice label in the game and manages interactions with it.

**Key Features**:
- Responds to pointer clicks, hover, and exit to trigger specific game events and dialogues.
- Contains logic for checking conditions (e.g., player stats, game data) to determine if a choice is available.
- Supports different conditions like checking player attributes (money, energy, wisdom, etc.) and game-specific conditions like the time of day or day of the week.

### 6. **DialogueController**
**Purpose**: Manages the flow of dialogues, including playing scenes, switching backgrounds, and triggering choices.

**Key Features**:
- Handles transitions between scenes (e.g., story and choice scenes).
- Plays dialogue and controls interaction with the player (e.g., advancing dialogue with mouse clicks or spacebar).
- Controls buttons like phone, map, and go-to-room based on the state of the dialogue.
- Manages the State of the dialogue (NORMAL, ANIMATE, CHOICE).
- Plays appropriate audio for each dialogue line.
- Handles scene transitions (background changes and dialogue updates).

### 7. **DialoguePanelController**
**Purpose**: Manages the UI for displaying dialogue text, speaker information, and animations.

**Key Features**:
- Displays the dialogue text and controls the typing animation for each sentence.
- Manages speaker names, speaker images, and typing sound effects.
- Handles the flow of dialogue, including playing the next sentence and skipping dialogue.
- Responds to game events during dialogue (e.g., triggering certain actions based on the current sentence).
- Controls the visibility of the dialogue panel (hides and shows based on triggers).
- Plays sound effects for typing and stops the sound when the dialogue is complete.

### 8. **Speaker**
**Purpose**: Defines the properties of a speaker in the dialogue system (e.g., name, image, typing sound).

**Key Features**:
- Stores the speaker's name, text color, and image.
- Defines a sound effect for typing during dialogue.

### 9. **StoryScene**
**Purpose**: Represents a scene in the story with multiple sentences of dialogue.

**Key Features**:
- Contains a list of `Sentence` objects, each with text, speaker information, and associated game events.
- Includes a background image for the scene and defines the next scene that follows.
- Each sentence can trigger a specific game event (like modifying player stats or triggering actions).
- Manages the audio for each sentence, including music and sound effects.

### 10. **GameScene**
**Purpose**: A base class for all types of scenes in the game.

**Key Features**:
- Serves as a base for more specific scene types like `StoryScene` and `ChooseScene`.
- Can be extended to create various types of scenes with their own specific logic.

### 11. **BlockerController**
**Purpose**: Controls the appearance of a "blocker" UI element, such as a dimmed overlay or screen block.

**Key Features**:
- Sets the blocker to a dark, semi-transparent color.
- Resets the blocker to fully transparent.

### 12. **ChooseScene**
**Purpose**: Represents a dialogue scene that involves choices for the player, extending the base class `GameScene`.

**Key Features**:
- Contains a list of `ChooseLabel` objects, each representing a choice option the player can select.
- `ChooseLabel` structure includes `text`, `nextScene`, `gameEvent`, and conditionally triggered events.

### 13. **EventSystemMaster**
**Purpose**: Manages various in-game events, like showing the map, handling buttons, and triggering specific dialogues or game events.

**Key Features**:
- Displays and hides the map UI.
- Enables or disables buttons in the game UI.
- Triggers dialogue events, including the first phone use event.

### 14. **GameEvent**
**Purpose**: Represents a custom game event that can trigger actions when raised, implementing the `MainGameEvent` class.

**Key Features**:
- Activates all listeners registered to the event.
- Registers and unregisters listeners for the event.

### 15. **MainGameEvent**
**Purpose**: A base class for defining game events. It is extended by specific event types like `GameEvent` and `IntGameEvent`.

### 16. **IGameEventListener**
**Purpose**: An interface that classes must implement to listen for game events.

**Key Features**:
- Responds to events with or without integer parameters.

### 17. **IntGameEvent**
**Purpose**: A custom game event that also includes an integer parameter. Inherits from `MainGameEvent`.

**Key Features**:
- Activates all listeners with an integer value passed as a parameter.

### 18. **StartMinigamesEvents**
**Purpose**: Handles the logic for starting different minigames, depending on the player's energy and other conditions.

**Key Features**:
- Starts specific minigames like Shop, Roma, Uczelnia, Room, and Piramidy based on the player's energy and game conditions.

### 19. **UnityGameEventListener**
**Purpose**: This class listens for and responds to custom game events. It connects `GameEvent` with a `UnityEvent` to trigger Unity actions when the event is raised.

**Key Features**:
- Registers and unregisters itself as a listener for a specific `GameEvent` when enabled or disabled.
- Invokes the specified `UnityEvent` (response) when the event is triggered.
- Can handle events that do not require additional parameters (`OnEventRaised`).

### 20. **UnityIntGameEventListener**
**Purpose**: This class listens for game events that pass an integer as an argument. It connects `IntGameEvent` to a `UnityEvent` that takes an integer parameter.

**Key Features**:
- Registers and unregisters itself as a listener for an `IntGameEvent`.
- Invokes a `UnityEvent<int>` when the event is triggered, passing the integer value from the event.

### 21. **GameData**
**Purpose**: This class holds and manages the game data, such as the current time, audio volume, and scene information. It also tracks the game’s overall progress and settings.

**Key Features**:
- Stores game time (month, day, hour, minute, second) and scene data.
- Manages audio volume and playing time.
- Handles the initialization of game data on startup and updates game data during gameplay.
- Tracks whether it’s the first time the game is started and plays initial dialogues.

### 22. **MapController**
**Purpose**: This class manages the map UI, including button interactions and the display of a phone button.

**Key Features**:
- Toggles the visibility of the phone UI and map interaction buttons.
- Handles enabling and disabling of buttons and canvas components.

### 23. **PhoneController**
**Purpose**: This class controls the phone UI, displaying the player's stats and managing its visibility and animations.

**Key Features**:
- Displays player data (money, hunger, wisdom, energy, etc.) on the phone interface.
- Animates the phone's appearance and disappearance based on user interactions.
- Updates UI elements (like sliders and text) when the phone is shown.

### 24. **PlayerData**
**Purpose**: This class manages the player's personal data, such as money, hunger, energy, and mental health. It also handles items and stats related to the player's progression.

**Key Features**:
- Tracks various player attributes, including money, energy, hunger, and wisdom.
- Allows modifications to these attributes, including increasing and decreasing values based on gameplay.
- Contains methods to check if attributes exceed certain values (e.g., checking if money is greater than a specified amount).
### 25. **EventTrigger**
**Purpose**: This class triggers specific in-game events when certain conditions are met, such as time of day, player actions, or dialogue progress.

**Key Features**:
- Listens for specific conditions like player status or time and triggers corresponding events.
- Executes game logic, such as updating the player's status, triggering animations, or starting a mini-game.
- Allows customization of event conditions, making it flexible for various scenarios.

### 26. **GameUIController**
**Purpose**: Controls the visibility and interaction of the game’s user interface, including health, hunger, energy, and wisdom indicators.

**Key Features**:
- Manages the display of key UI elements such as health bars, hunger bars, and wisdom stats.
- Updates UI components in real-time as the player’s stats change during the game.
- Allows toggling between different menus (map, phone, etc.) and handles transitions smoothly.

### 27. **TimeManager**
**Purpose**: Manages the in-game time system, including the simulation of days, hours, and events based on the passage of time.

**Key Features**:
- Updates the in-game time (day, month, hour, minute) on a continuous loop.
- Handles events that are triggered at specific times of the day (e.g., morning, afternoon, evening).
- Allows for pausing and fast-forwarding time, depending on game mechanics.
- Notifies other systems when the time progresses, triggering relevant events and dialogues.

### 28. **StatsManager**
**Purpose**: Manages and updates the player's stats (energy, hunger, wisdom, health) based on gameplay decisions and events.

**Key Features**:
- Tracks changes in player stats and updates them when events (such as eating, studying, or resting) occur.
- Prevents stats from exceeding predefined limits, ensuring balanced gameplay.
- Integrates with UI elements to display changes in real-time (e.g., energy bars, hunger levels).
- Provides methods for modifying stats directly or based on event-driven logic.

### 29. **AchievementManager**
**Purpose**: Tracks and manages player achievements throughout the game, unlocking rewards or additional content based on performance.

**Key Features**:
- Tracks player progress on specific tasks and milestones (e.g., completing a semester, reaching a certain level of wisdom).
- Unlocks achievements and awards when conditions are met.
- Displays achievements on the player’s profile or in a dedicated achievements menu.
- Integrates with the game's progression system, providing additional challenges or rewards.

### 30. **MiniGameController**
**Purpose**: Manages the mini-games within the game, triggering their start, progress, and completion based on the player's decisions or game events.

**Key Features**:
- Starts different mini-games based on in-game events, such as a shop minigame or a puzzle minigame.
- Tracks the player's performance in mini-games and rewards or penalizes accordingly.
- Handles transitions between mini-games and the main game flow.
- Allows for custom mini-games with their own mechanics and rules.

### 31. **InventorySystem**
**Purpose**: Manages the player's inventory, tracking items, consumption, and usage during gameplay.

**Key Features**:
- Stores items the player collects throughout the game, including consumables, key items, and quest items.
- Provides methods for adding, removing, and using items in the inventory.
- Displays the inventory UI when the player accesses it, showing available items and their effects.
- Can trigger item-based events, such as using a healing potion or selling items for money.

### 32. **QuestSystem**
**Purpose**: Tracks and manages quests, including main storyline quests and side quests.

**Key Features**:
- Tracks progress of various quests and objectives.
- Updates quest logs based on player actions and game events.
- Displays active quests in the UI, with details on current objectives.
- Allows players to accept, complete, or fail quests, unlocking new storylines or rewards.

### 33. **GameSaveSystem**
**Purpose**: Manages game save and load functionality, allowing players to save progress and resume at later points.

**Key Features**:
- Saves the game state, including player stats, progress, inventory, and completed events.
- Loads saved data and restores the game to the player’s last saved point.
- Provides multiple save slots and backup options.
- Includes a "quick save" feature for on-the-fly saving during gameplay.

### 34. **EventQueueManager**
**Purpose**: Manages and schedules events that need to happen at specific times or after certain triggers.

**Key Features**:
- Adds events to an event queue that are executed in order based on the game’s progress.
- Supports conditional events that are triggered when specific conditions (like player stats or the time of day) are met.
- Allows for delayed events, ensuring that actions are performed at the right moment in the gameplay flow.
- Manages priorities, ensuring that important events take precedence over less critical ones.

### 35. **NarrativeController**
**Purpose**: Handles the storytelling aspect of the game, guiding players through narrative-driven choices and consequences.

**Key Features**:
- Guides the player through branching storylines, adapting based on the player’s previous choices.
- Tracks narrative decisions and alters the story flow, unlocking new scenarios and dialogues.
- Integrates with the choice system to ensure that decisions have long-term consequences.
- Displays narrative choices and triggers corresponding game events.

## Future Enhancements
- **AI Improvements**: Enhance NPC behaviors to make interactions more dynamic and reflective of player choices.
- **Voice Acting**: Add voice acting for characters to increase immersion and engagement.
- **Multiplayer Mode**: Implement multiplayer features, allowing multiple players to interact in the game world.
- **Expanded Mini-Games**: Add more mini-games to provide variety and challenges.
- **New Storylines**: Introduce new story arcs and events that further develop the game's world and characters.
- **Mobile Version**: Develop a mobile version with touchscreen controls, optimized for tablets and phones.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact
For questions or contributions, feel free to open an issue or reach out via the [GitHub repository](https://github.com/EvilSasu/StudentSimulator).
