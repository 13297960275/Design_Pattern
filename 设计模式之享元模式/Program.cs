using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*享元模式
享元模式（Flyweight Pattern）主要用于减少创建对象的数量，以减少内存占用和提高性能。这种类型的设计模式属于结构型模式，它提供了减少对象数量从而改善应用所需的对象结构的方式。
享元模式尝试重用现有的同类对象，如果未找到匹配的对象，则创建新对象。我们将通过创建 5 个对象来画出 20 个分布于不同位置的圆来演示这种模式。由于只有 5 种可用的颜色，所以 color 属性被用来检查现有的 Circle 对象。
介绍
意图：运用共享技术有效地支持大量细粒度的对象。
主要解决：在有大量对象时，有可能会造成内存溢出，我们把其中共同的部分抽象出来，如果有相同的业务请求，直接返回在内存中已有的对象，避免重新创建。
何时使用： 1、系统中有大量对象。 2、这些对象消耗大量内存。 3、这些对象的状态大部分可以外部化。 4、这些对象可以按照内蕴状态分为很多组，当把外蕴对象从对象中剔除出来时，每一组对象都可以用一个对象来代替。 5、系统不依赖于这些对象身份，这些对象是不可分辨的。
如何解决：用唯一标识码判断，如果在内存中有，则返回这个唯一标识码所标识的对象。
关键代码：用 HashMap 存储这些对象。
应用实例： 1、JAVA 中的 String，如果有则返回，如果没有则创建一个字符串保存在字符串缓存池里面。 2、数据库的数据池。
优点：大大减少对象的创建，降低系统的内存，使效率提高。
缺点：提高了系统的复杂度，需要分离出外部状态和内部状态，而且外部状态具有固有化的性质，不应该随着内部状态的变化而变化，否则会造成系统的混乱。
使用场景： 1、系统有大量相似对象。 2、需要缓冲池的场景。
注意事项： 1、注意划分外部状态和内部状态，否则可能会引起线程安全问题。 2、这些类必须有一个工厂对象加以控制。*/
namespace 设计模式之享元模式
{
    /// <summary>
    /// 客户端调用
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 定义外部状态，例如字母的位置等信息
            int externalstate = 10;
            // 初始化享元工厂
            FlyweightFactory factory = new FlyweightFactory();

            // 判断是否已经创建了字母A，如果已经创建就直接使用创建的对象A
            Flyweight fa = factory.GetFlyweight("A");
            if (fa != null)
            {
                // 把外部状态作为享元对象的方法调用参数
                fa.Operation(--externalstate);
            }
            // 判断是否已经创建了字母B
            Flyweight fb = factory.GetFlyweight("B");
            if (fb != null)
            {
                fb.Operation(--externalstate);
            }
            // 判断是否已经创建了字母C
            Flyweight fc = factory.GetFlyweight("C");
            if (fc != null)
            {
                fc.Operation(--externalstate);
            }
            // 判断是否已经创建了字母D
            Flyweight fd = factory.GetFlyweight("D");
            if (fd != null)
            {
                fd.Operation(--externalstate);
            }
            else
            {
                Console.WriteLine("驻留池中不存在字符串D");
                // 这时候就需要创建一个对象并放入驻留池中
                ConcreteFlyweight d = new ConcreteFlyweight("D");
                factory.flyweights.Add("D", d);
            }

            Console.Read();
        }
    }

    /// <summary>
    /// 享元工厂，负责创建和管理享元对象
    /// </summary>
    public class FlyweightFactory
    {
        // 最好使用泛型Dictionary<string,Flyweighy>
        //public Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();
        public Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("A", new ConcreteFlyweight("A"));
            flyweights.Add("B", new ConcreteFlyweight("B"));
            flyweights.Add("C", new ConcreteFlyweight("C"));
        }

        public Flyweight GetFlyweight(string key)
        {
            // 更好的实现如下
            //Flyweight flyweight = flyweights[key] as Flyweight;
            //if (flyweight == null)
            //{
            //    Console.WriteLine("驻留池中不存在字符串" + key);
            //    flyweight = new ConcreteFlyweight(key);
            //}
            //return flyweight;
            return flyweights[key] as Flyweight;
        }
    }

    /// <summary>
    ///  抽象享元类，提供具体享元类具有的方法
    /// </summary>
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    // 具体的享元对象，这样我们不把每个字母设计成一个单独的类了，而是作为把共享的字母作为享元对象的内部状态
    public class ConcreteFlyweight : Flyweight
    {
        // 内部状态
        private string intrinsicstate;

        // 构造函数
        public ConcreteFlyweight(string innerState)
        {
            this.intrinsicstate = innerState;
        }

        /// <summary>
        /// 享元类的实例方法
        /// </summary>
        /// <param name="extrinsicstate">外部状态</param>
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体实现类: intrinsicstate {0}, extrinsicstate {1}", intrinsicstate, extrinsicstate);
        }
    }
}
