using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.储存配置项.智能储物箱
{
    [HarmonyPatch(typeof(StorageLockerSmartConfig), "CreateBuildingDef")]
    public class StorageBoxSmart_Attributes_Config
    {
        private static void Postfix(ref BuildingDef __result)
        {
            //是否会过热
            //__result.Overheatable = 智能储物箱.过热;
        }
    }
}
