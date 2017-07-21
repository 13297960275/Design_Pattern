using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*   单例模式
       单例模式（Singleton Pattern）是最简单的设计模式之一。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
       这种模式涉及到一个单一的类，该类负责创建自己的对象，同时确保只有单个对象被创建。这个类提供了一种访问其唯一的对象的方式，可以直接访问，不需要实例化该类的对象。
       注意：
       1、单例类只能有一个实例。
       2、单例类必须自己创建自己的唯一实例。
       3、单例类必须给所有其他对象提供这一实例。
       介绍
       意图：保证一个类仅有一个实例，并提供一个访问它的全局访问点。
       主要解决：一个全局使用的类频繁地创建与销毁。
       何时使用：当您想控制实例数目，节省系统资源的时候。
       如何解决：判断系统是否已经有这个单例，如果有则返回，如果没有则创建。
       关键代码：构造函数是私有的。
       应用实例： 1、一个党只能有一个主席。 2、Windows 是多进程多线程的，在操作一个文件的时候，就不可避免地出现多个进程或线程同时操作一个文件的现象，所以所有文件的处理必须通过唯一的实例来进行。 3、一些设备管理器常常设计为单例模式，比如一个电脑有两台打印机，在输出的时候就要处理不能两台打印机打印同一个文件。
       优点： 1、在内存里只有一个实例，减少了内存的开销，尤其是频繁的创建和销毁实例（比如管理学院首页页面缓存）。 2、避免对资源的多重占用（比如写文件操作）。
       缺点：没有接口，不能继承，与单一职责原则冲突，一个类应该只关心内部逻辑，而不关心外面怎么样来实例化。
       使用场景： 1、要求生产唯一序列号。 2、WEB 中的计数器，不用每次刷新都在数据库里加一次，用单例先缓存起来。 3、创建的一个对象需要消耗的资源过多，比如 I/O 与数据库的连接等。
       注意事项：getInstance() 方法中需要使用同步锁防止多线程同时进入造成 instance 被多次实例化。*/
namespace 设计模式之单例模式
{
    /// <summary>
    /// 简单单例模式的实现
    /// </summary>
    //public class Singleton
    //{
    //    // 定义一个静态变量来保存类的实例
    //    private static Singleton uniqueInstance;

    //    // 定义私有构造函数，使外界不能创建该类实例
    //    private Singleton()
    //    {
    //    }

    //    /// <summary>
    //    /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
    //    /// </summary>
    //    /// <returns></returns>
    //    public static Singleton GetInstance()
    //    {
    //        // 如果类的实例不存在则创建，否则直接返回
    //        if (uniqueInstance == null)
    //        {
    //            uniqueInstance = new Singleton();
    //        }
    //        return uniqueInstance;
    //    }
    //}

    //###############################################

    /// <summary>
    /// 线程安全的单例模式的实现
    /// 上面的单例模式的实现在单线程下确实是完美的,然而在多线程的情况下会得到多个Singleton实例,因为在两个线程同时运行GetInstance方法时，此时两个线程判断(uniqueInstance ==null)这个条件时都返回真，此时两个线程就都会创建Singleton的实例，这样就违背了我们单例模式初衷了，既然上面的实现会运行多个线程执行，那我们对于多线程的解决方案自然就是使GetInstance方法在同一时间只运行一个线程运行就好了，也就是我们线程同步的问题了,具体的解决多线程的代码如下:
    /// </summary>
    //public class Singleton
    //{
    //    // 定义一个静态变量来保存类的实例
    //    private static Singleton uniqueInstance;

    //    // 定义一个标识确保线程同步
    //    private static readonly object locker = new object();

    //    // 定义私有构造函数，使外界不能创建该类实例
    //    private Singleton()
    //    {
    //    }

    //    /// <summary>
    //    /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
    //    /// </summary>
    //    /// <returns></returns>
    //    public static Singleton GetInstance()
    //    {
    //        // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
    //        // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
    //        // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
    //        lock (locker)
    //        {
    //            // 如果类的实例不存在则创建，否则直接返回
    //            if (uniqueInstance == null)
    //            {
    //                uniqueInstance = new Singleton();
    //            }
    //        }

    //        return uniqueInstance;
    //    }
    //}

    //###############################################

    /// <summary>
    /// 双重锁定单例模式的实现
    /// 上面这种解决方案确实可以解决多线程的问题,但是上面代码对于每个线程都会对线程辅助对象locker加锁之后再判断实例是否存在，对于这个操作完全没有必要的，因为当第一个线程创建了该类的实例之后，后面的线程此时只需要直接判断（uniqueInstance==null）为假，此时完全没必要对线程辅助对象加锁之后再去判断，所以上面的实现方式增加了额外的开销，损失了性能，为了改进上面实现方式的缺陷，我们只需要在lock语句前面加一句（uniqueInstance==null）的判断就可以避免锁所增加的额外开销，这种实现方式我们就叫它 “双重锁定”，下面具体看看实现代码的：
    /// </summary>
    public class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton()
        {
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
