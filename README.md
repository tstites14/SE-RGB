# SE-RGB
A Space Engineers script (developed with the Visual Studio 2019 plugin MDK) to simulate modern RGB lighting effects.

Installation:
- Copy Program.cs to C:\Users\USERNAME\AppData\Roaming\SpaceEngineers\IngameScripts\local.
- Open a Programmble Block in Space Engineers.
- Click Edit in the Control Panel.
- Click Browse Scripts.
- Select SE-RGB from the list of available scripts on the left.

Ingame Requirements:
- At least one light that is part of the IMyInteriorLight interface (typically Corner Lights and Interior Lights).
  - Add "RGB MODE#" to the Custom Data field of any light and the program will automatically change its color.
    - MODE is replaced by one of two letters:
      - P = Pulse mode (all lights function identically and simply display colors in a rainbow)
      - W = Wave mode (lights change color in a wave pattern based on the order of the numbers chosen by the user)
    - "#" is the non-zero number used to determine the order the lights will change color
    - Example: "RGB P1"
      - RGB tells the program that the light is to be controlled by the programmable block
      - P tells the program that the light is in pulse mode
      - 1 tells the program that the light is the first one to modify
