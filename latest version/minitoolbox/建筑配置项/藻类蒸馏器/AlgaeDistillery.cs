using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ElementConverter;

namespace minitoolbox.建筑配置项.藻类蒸馏器
{
    //原油精炼器

    [HarmonyPatch(typeof(AlgaeDistilleryConfig), "ConfigureBuildingTemplate")]
    public class AlgaeDistillery
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {

            go.AddOrGet<ElementConverter>().outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(SingletonOptions<ConfigurationItem>.Instance.AlgaeVolume * 0.001f, SimHashes.Algae, 303.15f, false, true, 0f, 1f, 1f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(SingletonOptions<ConfigurationItem>.Instance.AlgaeDirtyWaterVolume * 0.001f, SimHashes.DirtyWater, 303.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
        }
    }
}
