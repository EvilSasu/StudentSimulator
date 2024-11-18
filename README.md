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

## UnityGameEventListener
**Purpose**: This class listens for and responds to custom game events. It connects `GameEvent` with a `UnityEvent` to trigger Unity actions when the event is raised.

**Key Features**:
- Registers and unregisters itself as a listener for a specific `GameEvent` when enabled or disabled.
- Invokes the specified `UnityEvent` (response) when the event is triggered.
- Can handle events that do not require additional parameters (`OnEventRaised`).

## UnityIntGameEventListener
**Purpose**: This class listens for game events that pass an integer as an argument. It connects `IntGameEvent` to a `UnityEvent` that takes an integer parameter.

**Key Features**:
- Registers and unregisters itself as a listener for an `IntGameEvent`.
- Invokes a `UnityEvent<int>` when the event is triggered, passing the integer value from the event.

## GameData
**Purpose**: This class holds and manages the game data, such as the current time, audio volume, and scene information. It also tracks the game’s overall progress and settings.

**Key Features**:
- Stores game time (month, day, hour, minute, second) and scene data.
- Manages audio volume and playing time.
- Handles the initialization of game data on startup and updates game data during gameplay.
- Tracks whether it’s the first time the game is started and plays initial dialogues.

## MapController
**Purpose**: This class manages the map UI, including button interactions and the display of a phone button.

**Key Features**:
- Toggles the visibility of the phone UI and map interaction buttons.
- Handles enabling and disabling of buttons and canvas components.
  
## PhoneController
**Purpose**: This class controls the phone UI, displaying the player's stats and managing its visibility and animations.

**Key Features**:
- Displays player data (money, hunger, wisdom, energy, etc.) on the phone interface.
- Animates the phone's appearance and disappearance based on user interactions.
- Updates UI elements (like sliders and text) when the phone is shown.

## PlayerData
**Purpose**: This class manages the player's personal data, such as money, hunger, energy, and mental health. It also handles items and stats related to the player's progression.

**Key Features**:
- Tracks various player attributes, including money, energy, hunger, and wisdom.
- Allows modifications to these attributes, including increasing and decreasing values based on gameplay.
- Contains methods to check if attributes exceed certain values (e.g., checking if money is greater than a specified amount).
- Manages inventory (pizza, burgers, water, etc.), with methods to add and remove items.

## PopUp  
**Purpose**: This class manages the pop-up animations and behaviors for displaying temporary notifications in the game UI.

**Key Features**:
- Handles the animation of pop-up UI elements based on the `amountOfPopUp` value, ensuring they appear sequentially.
- Initiates the pop-up animation when the game starts through the `AnimatePopUp` coroutine.
- Provides the `StarAnimation` method to allow external triggers for starting the animation.
- After a set duration, triggers a "Hide" animation and removes the pop-up object from the scene.

## PopUpInfoMeneger  
**Purpose**: This class controls the creation and management of multiple pop-ups in the game UI, ensuring proper alignment and handling of different pop-up types.

**Key Features**:
- Instantiates new pop-up objects dynamically when called through `CreatePopUp` or `CreateSpecialPopUp`.
- Adjusts the vertical position of each pop-up to prevent overlap, maintaining an organized UI layout.
- Supports two types of pop-ups: regular ones with dynamic text (showing increases or decreases in values) and special pop-ups with custom text.

## Calendar  
**Purpose**: This class tracks the in-game calendar, including days, months, and the day of the week. It also manages day transitions and special in-game events like rent payments.

**Key Features**:
- Handles transitions between months and days, accounting for the number of days in each month (e.g., February, months with 31 or 30 days).
- Tracks the day of the week, ensuring it is updated correctly as days pass.
- Automates rent payment on specific days (e.g., 10th of each month), deducting money from the player's resources.
- Computes and updates the current day of the week after each day transition.

## Clock  
**Purpose**: This class manages in-game time, including hours, minutes, and seconds, and handles time-related actions such as sleeping and updating the player’s status.

**Key Features**:
- Allows for precise adjustments to in-game time (e.g., adding hours, minutes, or seconds), ensuring smooth transitions between them.
- Tracks time-related status changes for the player, such as energy depletion and hunger increase, based on the time spent.
- Includes the ability for the player to go to sleep, which restores energy and increases hunger, while also advancing the game time by a set number of hours.

## TimeSystem  
**Purpose**: This class controls the flow of time in the game, updating the clock and calendar UI on-screen and managing the ticking of time.

**Key Features**:
- Updates the in-game clock every second, incrementing the seconds counter and handling the flow of time seamlessly.
- Displays the current time and date on-screen in a formatted manner using `TextMeshProUGUI`, including leading zeros for consistency.
- Manages the visual representation of the time and calendar, ensuring that the UI remains accurate and easy to read.


## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact
For questions or contributions, feel free to open an issue or reach out via the [GitHub repository](https://github.com/EvilSasu/StudentSimulator).
