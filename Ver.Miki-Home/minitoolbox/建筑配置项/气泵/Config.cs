using PeterHan.PLib.Options;

using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.建筑配置项.气泵
{
    public class 气泵
    {
        public static float 功率 = SingletonOptions<ConfigurationItem>.Instance.GasPump_Electricity;
        public static bool 过热 = SingletonOptions<ConfigurationItem>.Instance.GasPump_Overheat ? false : true;
        public static bool 发热 = SingletonOptions<ConfigurationItem>.Instance.GasPump_SelfHeating ? false : true;
    }
}
