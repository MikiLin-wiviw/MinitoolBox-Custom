using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using UnityEngine;

namespace minitoolbox.储存配置项.智能储物箱
{
    [HarmonyPatch(typeof(StorageLockerSmartConfig), "DoPostConfigureComplete")]
    public class StorageBoxSmart_Storage_Config
    {
        private static void Postfix(GameObject go)
        {
            //智能储物箱容量
            go.AddOrGet<Storage>().capacityKg = 智能储物箱.容量;
            Debug.LogFormat("MinBox::已调整储物箱容量为：{0}kg", 智能储物箱.容量);
        }
    }
}
