using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.电力配置项.电池.电池
{
    public class 电池
    {
        public static float 电池容量 = SingletonOptions<ConfigurationItem>.Instance.电池容量 * 1000f;
        public static float 电源损耗 = SingletonOptions<ConfigurationItem>.Instance.电池漏电 ? 0f : 1.6666666f;

    }
}
