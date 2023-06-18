using System;
using HarmonyLib;
using PeterHan.PLib.Options;

namespace minitoolbox.建筑配置项.碎石机
{
    // Token: 0x02000036 RID: 54
    [HarmonyPatch(typeof(RockCrusherConfig), "CreateBuildingDef")]
    public class RockCrusher_Attributes_Config
    {
        // Token: 0x060001A3 RID: 419 RVA: 0x0000485C File Offset: 0x00002A5C
        public static void Postfix(ref BuildingDef __result)
        {
            __result.EnergyConsumptionWhenActive = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Electricity;
            bool flag = !SingletonOptions<ConfigurationItem>.Instance.RockCrusher_SelfHeating;
            __result.Floodable = !SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Submerge;
            __result.Overheatable = !SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Overheat;
            __result.SelfHeatKilowattsWhenActive = (flag ? 4f : 0f);
        }
    }
}
