using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.建筑配置项.碎石机
{
    //碎石机
    [HarmonyPatch(typeof(RockCrusherConfig), "CreateBuildingDef")]
    public class RockCrusher_Attributes_Config
    {
        public static void Postfix(ref BuildingDef __result)
        {
            //耗电
            __result.EnergyConsumptionWhenActive = 碎石机.功率;
            //自热
            bool setJs = 碎石机.发热;
            //淹没
            __result.Floodable = 碎石机.淹没;
            //过热
            __result.Overheatable = 碎石机.过热;
            __result.SelfHeatKilowattsWhenActive = (setJs ? 16f : 0f);
        }
    }
}
