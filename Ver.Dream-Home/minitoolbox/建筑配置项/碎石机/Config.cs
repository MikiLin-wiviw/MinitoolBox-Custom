﻿using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.建筑配置项.碎石机
{
    public class 碎石机
    {
        public static bool 操作 = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_automatic ? false : true;
        public static float 功率 = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Electricity;
        public static bool 发热 = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_SelfHeating ? false : true;
        public static bool 淹没 = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Submerge ? false : true;
        public static bool 过热 = SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Overheat ? false : true;
    }
}
