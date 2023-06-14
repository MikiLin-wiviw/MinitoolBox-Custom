﻿using HarmonyLib;
using minitoolbox.电力配置项.大型变压器;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.Power_Systems.PowerTransformer_Changes
{
    //变压器与大型变压器自热配置
    [HarmonyPatch(typeof(PowerTransformerConfig), "CreateBuildingDef")]
    public class PowerTransformer
    {
        public static void Postfix(ref BuildingDef __result)
        {
            //大型变压器自热
            bool Generator_Heat = 大型变压器.自热;
            __result.ExhaustKilowattsWhenActive = (Generator_Heat ? 0.25f : 0f);
            __result.SelfHeatKilowattsWhenActive = (Generator_Heat ? 1f : 0f);
            __result.ExhaustKilowattsWhenActive = 0f;
            __result.SelfHeatKilowattsWhenActive = (Generator_Heat ? 1f : 0f);
            Debug.LogFormat("已调整大型变压器自热为：{0}", 大型变压器.自热);
        }
    }
}
