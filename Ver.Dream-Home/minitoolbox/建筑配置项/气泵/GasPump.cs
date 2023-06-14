using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.建筑配置项.气泵
{
    //气泵
    [HarmonyPatch(typeof(GasPumpConfig), "CreateBuildingDef")]
    public class GasPump
    {
        public static void Postfix(ref BuildingDef __result)
        {
            //气泵消耗多少瓦
            __result.EnergyConsumptionWhenActive = 气泵.功率;
            //气泵是否过热
            __result.Overheatable = 气泵.过热;
            //输出的热量dtu/s
            bool GasPump_heat = 气泵.发热;
            __result.SelfHeatKilowattsWhenActive = (GasPump_heat ? 2f : 0f);//气泵自身热量增长dtu/s
        }
    }
}
