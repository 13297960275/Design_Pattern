using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式之抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /// <summary>
    /// 抽象工厂类，提供烧菜的抽象方法
    /// </summary>
    public abstract class AbstarctFactory
    {
        public abstract GaiJiaoFan CreateGaiJiaoFan();
        public abstract ChaoFan CreateChaoFan();
    }

    /// <summary>
    /// 厨师1
    /// </summary>
    public class ConcreteFanFactory1 : AbstarctFactory
    {
        public override GaiJiaoFan CreateGaiJiaoFan()
        {
            return new FanQieJiDan();
        }

        public override ChaoFan CreateChaoFan()
        {
            return new JiDanChaoFan();
        }
    }

    /// <summary>
    /// 厨师2
    /// </summary>
    public class ConcreteFanFactory2 : AbstarctFactory
    {
        public override GaiJiaoFan CreateGaiJiaoFan()
        {
            return new TuDouRouSi();
        }

        public override ChaoFan CreateChaoFan()
        {
            return new YangZhouChaoFan();
        }
    }
    /// <summary>
    /// 盖浇饭类别
    /// </summary>
    public abstract class GaiJiaoFan
    {
    }

    /// <summary>
    /// 土豆肉丝盖浇饭
    /// </summary>
    public class TuDouRouSi : GaiJiaoFan
    {
 
    }

    /// <summary>
    /// 番茄鸡蛋盖浇饭
    /// </summary>
    public class FanQieJiDan : GaiJiaoFan
    {
 
    }

    /// <summary>
    /// 炒饭类
    /// </summary>
    public abstract class ChaoFan
    {
 
    }

    /// <summary>
    /// 鸡蛋炒饭
    /// </summary>
    public class JiDanChaoFan : ChaoFan
    {
 
    }

    /// <summary>
    /// 扬州炒饭
    /// </summary>
    public class YangZhouChaoFan : ChaoFan
    {
 
    }
}
