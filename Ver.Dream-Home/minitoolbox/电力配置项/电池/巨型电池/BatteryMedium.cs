using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace minitoolbox.电力配置项.电池.巨型电池
{
    [HarmonyPatch(typeof(BatteryMediumConfig), "DoPostConfigureComplete")]
    public class BatteryMedium
    {
        public static void Postfix(GameObject go)
        {
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = 巨型电池.电池容量;
            battery.joulesLostPerSecond = 巨型电池.电源损耗;
            Debug.LogFormat("已调整巨型电池电池容量为：{0}，巨型电池电源损耗{1}", 巨型电池.电池容量, 巨型电池.电源损耗);
        }
    }
}
