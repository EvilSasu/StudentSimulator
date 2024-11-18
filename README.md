# StudentSimulator

# Core Classes

## PlayAnimation
**Purpose**: This class is used to control animations on a GameObject using either an Animation or an Animator.

**Key Features**:
- **PlayAnimat(AnimationClip ac)**: Plays an animation using the Animation component.
- **UseTrigger(string trigger)**: Sets a trigger in the Animator to control state changes in animations.

## AudioController
**Purpose**: Manages audio playback for both background music and sound effects.

**Key Features**:
- Initializes volume settings based on an AudioVolume component found in the scene.
- Plays background music and sound effects through two AudioSource components.
- Allows for smooth transitions between music clips using the **SwitchMusic** method and updates volumes gradually.

## BackgroundController
**Purpose**: Manages background images in the game, allowing for dynamic switching between different backgrounds.

**Key Features**:
- Switches between two background images using triggers and an Animator.
- Allows for setting specific images directly and plays the first dialogue when needed.
- Plays a first story scene dialogue using **PlayFirstDialogue**.

## ChooseController
**Purpose**: Manages the choice system in the game, displaying options to the player and handling interactions.

**Key Features**:
- Displays multiple choice options based on a **ChooseScene**.
- Each choice may trigger different events and lead to different story outcomes.
- Adjusts the size of the choices dynamically and allows for choosing a scene through the **PerfomChoose** method.
- Controls enabling and disabling of the choice system.

## ChooseLabelController
**Purpose**: Represents an individual choice label in the game and manages interactions with it.

**Key Features**:
- Responds to pointer clicks, hover, and exit to trigger specific game events and dialogues.
- Contains logic for checking conditions (e.g., player stats, game data) to determine if a choice is available.
- Supports different conditions like checking player attributes (money, energy, wisdom, etc.) and game-specific conditions like the time of day or day of the week.

## DialogueController
**Purpose**: Manages the flow of dialogues, including playing scenes, switching backgrounds, and triggering choices.

**Key Features**:
- Handles transitions between scenes (e.g., story and choice scenes).
- Plays dialogue and controls interaction with the player (e.g., advancing dialogue with mouse clicks or spacebar).
- Controls buttons like phone, map, and go-to-room based on the state of the dialogue.
- Manages the State of the dialogue (NORMAL, ANIMATE, CHOICE).
- Plays appropriate audio for each dialogue line.
- Handles scene transitions (background changes and dialogue updates).

## DialoguePanelController
**Purpose**: Manages the UI for displaying dialogue text, speaker information, and animations.

**Key Features**:
- Displays the dialogue text and controls the typing animation for each sentence.
- Manages speaker names, speaker images, and typing sound effects.
- Handles the flow of dialogue, including playing the next sentence and skipping dialogue.
- Responds to game events during dialogue (e.g., triggering certain actions based on the current sentence).
- Controls the visibility of the dialogue panel (hides and shows based on triggers).
- Plays sound effects for typing and stops the sound when the dialogue is complete.

## Speaker
**Purpose**: Defines the properties of a speaker in the dialogue system (e.g., name, image, typing sound).

**Key Features**:
- Stores the speaker's name, text color, and image.
- Defines a sound effect for typing during dialogue.

## StoryScene
**Purpose**: Represents a scene in the story with multiple sentences of dialogue.

**Key Features**:
- Contains a list of `Sentence` objects, each with text, speaker information, and associated game events.
- Includes a background image for the scene and defines the next scene that follows.
- Each sentence can trigger a specific game event (like modifying player stats or triggering actions).
- Manages the audio for each sentence, including music and sound effects.

## GameScene
**Purpose**: A base class for all types of scenes in the game.

**Key Features**:
- Serves as a base for more specific scene types like `StoryScene` and `ChooseScene`.
- Can be extended to create various types of scenes with their own specific logic.

## BlockerController
**Purpose**: Controls the appearance of a "blocker" UI element, such as a dimmed overlay or screen block.

**Key Features**:
- Sets the blocker to a dark, semi-transparent color.
- Resets the blocker to fully transparent.

## ChooseScene
**Purpose**: Represents a dialogue scene that involves choices for the player, extending the base class `GameScene`.

**Key Features**:
- Contains a list of `ChooseLabel` objects, each representing a choice option the player can select.
- `ChooseLabel` structure includes `text`, `nextScene`, `gameEvent`, and conditionally triggered events.

## EventSystemMaster
**Purpose**: Manages various in-game events, like showing the map, handling buttons, and triggering specific dialogues or game events.

**Key Features**:
- Displays and hides the map UI.
- Enables or disables buttons in the game UI.
- Triggers dialogue events, including the first phone use event.

## GameEvent
**Purpose**: Represents a custom game event that can trigger actions when raised, implementing the `MainGameEvent` class.

**Key Features**:
- Activates all listeners registered to the event.
- Registers and unregisters listeners for the event.

## MainGameEvent
**Purpose**: A base class for defining game events. It is extended by specific event types like `GameEvent` and `IntGameEvent`.

## IGameEventListener
**Purpose**: An interface that classes must implement to listen for game events.

**Key Features**:
- Responds to events with or without integer parameters.

## IntGameEvent
**Purpose**: A custom game event that also includes an integer parameter. Inherits from `MainGameEvent`.

**Key Features**:
- Activates all listeners with an integer value passed as a parameter.

## StartMinigamesEvents
**Purpose**: Handles the logic for starting different minigames, depending on the player's energy and other conditions.

**Key Features**:
- Starts specific minigames like Shop, Roma, Uczelnia, Room, and Piramidy based on the player's energy and game conditions.




## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact
For questions or contributions, feel free to open an issue or reach out via the [GitHub repository](https://github.com/EvilSasu/StudentSimulator).
