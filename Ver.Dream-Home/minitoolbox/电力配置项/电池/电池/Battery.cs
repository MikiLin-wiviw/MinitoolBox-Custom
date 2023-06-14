using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace minitoolbox.电力配置项.电池.电池
{
    [HarmonyPatch(typeof(BatteryConfig), "DoPostConfigureComplete")]
    public class SmallBattery
    {
        public static void Postfix(GameObject go)
        {
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 电池.电池容量;
            battery.joulesLostPerSecond = 电池.电源损耗;
            Debug.LogFormat("已调整电池电池容量为：{0}，电池电源损耗{1}", 电池.电池容量, 电池.电源损耗);
        }
    }
}
