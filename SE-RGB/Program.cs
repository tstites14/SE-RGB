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

        public Program()
        {
            Lights = new List<IMyInteriorLight>();
            GridTerminalSystem.GetBlocksOfType(Lights);

            //Filter Lights so only lights that specifically need RGB are part of the list
            Lights = Lights.Where(item => item.CustomData == "RGB").ToList();

            Runtime.UpdateFrequency = UpdateFrequency.Update1;
        }

        public void Main(string argument, UpdateType updateSource)
        {
            Echo($"Number of lights: {Lights.Count}");
        }
    }
}
