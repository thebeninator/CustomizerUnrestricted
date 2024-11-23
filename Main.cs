using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomizerUltimate;
using GHPC.Mission;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(CustomizerUltimateMod), "Unrestricted Customizer", "1.0.0", "ATLAS")]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace CustomizerUltimate
{
    public class CustomizerUltimateMod : MelonMod
    {
        bool done = false;
        UnitClass[] unit_classes = new UnitClass[] {
            UnitClass.Tank,
            UnitClass.IFV,
            UnitClass.APC,
            UnitClass.Scout,
            UnitClass.Transport,
            UnitClass.APC,
            UnitClass.AttackHelicopter,
            UnitClass.ScoutHelicopter,
            UnitClass.TransportHelicopter,
            UnitClass.AntiTankEmplacement,
        };

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            UnitPrefabLookupScriptable all_units = Resources.FindObjectsOfTypeAll<UnitPrefabLookupScriptable>().FirstOrDefault();

            if (!all_units || all_units.AllUnits.Length == 0 || done) return;

            foreach (UnitPrefabLookupScriptable.UnitPrefabMetadata meta in all_units.AllUnits) {
                meta.AlternativeClasses = unit_classes;                             
            }

            done = true;
        }
    }
}
