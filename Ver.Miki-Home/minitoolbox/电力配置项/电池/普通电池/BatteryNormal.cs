using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;

namespace minitoolbox.电力配置项.电池.普通电池
{
    [HarmonyPatch(typeof(BatteryConfig), "DoPostConfigureComplete")]
    public class BatteryNormal
    {
        public static void Postfix(GameObject go)
        {
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 普通电池.电池容量;
            battery.joulesLostPerSecond = 普通电池.电源损耗;
            Debug.LogFormat("已调整电池容量为：{0}，电池电源损耗{1}", 普通电池.电池容量, 普通电池.电源损耗);
        }
    }
}
