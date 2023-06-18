using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static ElementConverter;

namespace minitoolbox.建筑配置项.堆肥堆
{
    //原油精炼器

    [HarmonyPatch(typeof(CompostConfig), "ConfigureBuildingTemplate")]
    public class Compostor
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<Compost>().simulatedInternalTemperature = SingletonOptions<ConfigurationItem>.Instance.Compost_Temperature + 273.15f;
            go.AddOrGet<ElementConverter>().outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(0.1f, SimHashes.Dirt, SingletonOptions<ConfigurationItem>.Instance.Compost_Temperature + 273.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
        }
    }
}
