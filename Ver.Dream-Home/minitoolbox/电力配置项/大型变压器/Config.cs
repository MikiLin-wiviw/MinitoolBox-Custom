using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minitoolbox.电力配置项.大型变压器
{
    public class 大型变压器
    {
        public static bool 自热 = SingletonOptions<ConfigurationItem>.Instance.PowerTransformer_SelfHeating ? false : true;
    }
}
