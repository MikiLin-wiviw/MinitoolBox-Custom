using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;

namespace minitoolbox.建筑配置项.聚合物压塑器
{
    // Token: 0x0200002D RID: 45
    [HarmonyPatch(typeof(PolymerizerConfig), "ConfigureBuildingTemplate")]
    public class Polymerizer
    {
        // Token: 0x0600018E RID: 398 RVA: 0x000043E0 File Offset: 0x000025E0
        public static void Postfix(PolymerizerConfig __instance, ref GameObject go)
        {
            if (SingletonOptions<ConfigurationItem>.Instance.Polymerizer_Water)
            {
                go.AddOrGet<ElementConverter>().consumedElements = new ElementConverter.ConsumedElement[]
                {
                    new ElementConverter.ConsumedElement(GameTags.Water, SingletonOptions<ConfigurationItem>.Instance.Polymerizer_WaterUse, true)
                };
                go.AddOrGet<ConduitConsumer>().capacityTag = GameTags.Water;
            }
            go.AddOrGet<ElementConverter>().outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(SingletonOptions<ConfigurationItem>.Instance.Polymerizer_PolypropyleneOutput, SimHashes.Polypropylene, 348.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
                new ElementConverter.OutputElement(0.008333334f, SimHashes.Steam, 378.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
                new ElementConverter.OutputElement(0.008333334f, SimHashes.CarbonDioxide, 393.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
        }
    }
}

//new ElementConverter.OutputElement(0.5f, SimHashes.Polypropylene, 348.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
//new ElementConverter.OutputElement(0.008333334f, SimHashes.Steam, 473.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
//new ElementConverter.OutputElement(0.008333334f, SimHashes.CarbonDioxide, 423.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)