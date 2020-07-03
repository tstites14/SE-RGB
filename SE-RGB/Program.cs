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

            //Sort lights by the order specified in the light's custom data
            Lights = Lights.OrderBy(key =>
            {
                string cd = key.CustomData.Split(' ')[1];
                int cdOrder = int.Parse(cd.Remove(0, 1));

                return cdOrder;
            }).ToList();

            foreach (var light in Lights)
            {
                string cd = light.CustomData.Split(' ')[1];
                char cdMode = cd.ToCharArray()[0];
                int cdOrder = int.Parse(cd.Remove(0, 1));

                Mode = GetMode(cdMode);
                Echo("Mode: " + Mode.ToString());

                if (Mode == Modes.Pulse)
                {
                    light.Color = GetNextColor(light);
                    Echo($"Color: {light.Color}");
                }
                else if (Mode == Modes.Wave)
                {
                    float offset = 0.08f * cdOrder - 1;
                }

            }
        }

        public enum Modes
        {
            Pulse,
            Wave
        }

        public Modes GetMode(char customData)
        {
            switch (customData)
            {
                case 'W':
                    return Modes.Wave;
                case 'P':
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

        public Color GetNextColor(IMyInteriorLight currentLight, float offset)
        {
            Color currentColor = currentLight.Color;
            Vector3 hsv = currentColor.ColorToHSVDX11();

            hsv.X += offset;
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
