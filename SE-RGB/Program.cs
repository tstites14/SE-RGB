using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRage;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        List<IMyInteriorLight> Lights;
        Modes Mode;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update1;

            Lights = new List<IMyInteriorLight>();
            GridTerminalSystem.GetBlocksOfType(Lights);

            //Filter Lights so only lights that specifically need RGB are part of the list
            Lights = Lights.Where(item => item.CustomData.Contains("RGB")).ToList();
        }

        public void Main(string argument, UpdateType updateSource)
        {
            Echo($"Number of lights: {Lights.Count}");

            foreach (var light in Lights)
            {
                light.Color = GetNextColor(light);
                Echo($"Color: {light.Color}");
            }
        }

        public enum Modes
        {
            Pulse,
            Wave
        }

        public Modes GetMode(string customData)
        {
            switch (customData)
            {
                case "W":
                    return Modes.Wave;
                case "P":
                    return Modes.Pulse;
                default:
                    return Modes.Pulse;
            }
        }

        public Color GetNextColor(IMyInteriorLight currentLight)
        {
            Color currentColor = currentLight.Color;
            Vector3 hsv = currentColor.ColorToHSVDX11();

            hsv.Y = 1;
            hsv.Z = 1;

            if (hsv.X < 1)
            {
                hsv.X += 0.005f;
            }
            else
            {
                hsv.X = 0;
            }

            Echo(hsv.ToString());
            return ColorExtensions.HSVtoColor(hsv);
        }
    }
}
