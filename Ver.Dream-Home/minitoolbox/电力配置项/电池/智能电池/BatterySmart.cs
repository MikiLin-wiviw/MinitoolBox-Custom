using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace minitoolbox.电力配置项.电池.智能电池
{ 
    [HarmonyPatch(typeof(BatterySmartConfig), "DoPostConfigureComplete")]
    public class SmartBattery
    {
        public static void Postfix(GameObject go)
        {
            BatterySmart batterySmart = go.AddOrGet<BatterySmart>();
            batterySmart.capacity = 智能电池.电池容量;
            batterySmart.joulesLostPerSecond = 智能电池.电源损耗;
            Debug.LogFormat("已调整智能电池电池容量为：{0}，智能电池电源损耗{1}", 智能电池.电池容量, 智能电池.电源损耗);
        }
    }
}
