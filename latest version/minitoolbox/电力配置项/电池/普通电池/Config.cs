﻿using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.电力配置项.电池.普通电池
{
    public class 普通电池
    {
        public static float 电池容量 = SingletonOptions<ConfigurationItem>.Instance.BatteryNormal_Capacity * 1000f;
        public static float 电源损耗 = SingletonOptions<ConfigurationItem>.Instance.BatteryNormal_Loss ? 0f : 0.6666667f;

    }
}
