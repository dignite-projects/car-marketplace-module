using System;
using System.Threading;

namespace Dignite.CarMarketplace.DealerPlatform.UsedCars
{
    /// <summary>
    /// 二手车编号生成
    /// </summary>
    public class UsedCarIdHelper
    {
        /// <summary>
        ///  防止创建类的实例
        /// </summary>
        private UsedCarIdHelper() { }

        private static readonly object Locker = new object();
        private static int _sn = 0;

        /// <summary>
        /// 生成编号
        /// </summary>
        /// <returns></returns>
        public static int GenerateId()
        {
            lock (Locker)   //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == 9999)
                {
                    _sn = 0;
                }
                else
                {
                    _sn++;
                }

                Thread.Sleep(100);

                DateTimeOffset now = DateTimeOffset.UtcNow;
                return (int)now.ToUnixTimeSeconds() + _sn;
            }
        }
    }
}
