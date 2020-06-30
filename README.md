# SE-RGB
A Space Engineers script (developed with the Visual Studio 2019 plugin MDK) to simulate modern RGB lighting effects.

An MDK-SE project to be used in Space Engineers to simulate RGB lighting.

Installation:
- Copy Program.cs to C:\Users\USERNAME\AppData\Roaming\SpaceEngineers\IngameScripts\local.
- Open a Programmble Block in Space Engineers.
- Click Edit in the Control Panel.
- Click Browse Scripts.
- Select SE-RGB from the list of available scripts on the left.

Ingame Requirements:
- At least one light that is part of the IMyInteriorLight interface (typically Corner Lights and Interior Lights).
  - Add "RGB" to the Custom Data field of any light and the program will automatically change its color.
