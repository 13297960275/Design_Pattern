using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*建造者模式
建造者模式（Builder Pattern）使用多个简单的对象一步一步构建成一个复杂的对象。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
一个 Builder 类会一步一步构造最终的对象。该 Builder 类是独立于其他对象的。
介绍
意图：将一个复杂的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
主要解决：主要解决在软件系统中，有时候面临着"一个复杂对象"的创建工作，其通常由各个部分的子对象用一定的算法构成；由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定。
何时使用：一些基本部件不会变，而其组合经常变化的时候。
如何解决：将变与不变分离开。
关键代码：建造者：创建和提供实例，导演：管理建造出来的实例的依赖关系。
应用实例： 1、去肯德基，汉堡、可乐、薯条、炸鸡翅等是不变的，而其组合是经常变化的，生成出所谓的"套餐"。 2、JAVA 中的 StringBuilder。
优点： 1、建造者独立，易扩展。 2、便于控制细节风险。
缺点： 1、产品必须有共同点，范围有限制。 2、如内部变化复杂，会有很多的建造类。
使用场景： 1、需要生成的对象具有复杂的内部结构。 2、需要生成的对象内部属性本身相互依赖。
注意事项：与工厂模式的区别是：建造者模式更加关注与零件装配的顺序。*/
/// <summary>
/// 以组装电脑为例子
/// 每台电脑的组成过程都是一致的，但是使用同样的构建过程可以创建不同的表示(即可以组装成不一样的电脑，配置不一样)
/// 组装电脑的这个场景就可以应用建造者模式来设计
/// </summary>
namespace 设计模式之建造者模式
{
    /// <summary>
    /// 客户类
    /// </summary>
    class Customer
    {
        static void Main(string[] args)
        {
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }
    }

    /// <summary>
    /// 小王和小李难道会自愿地去组装嘛，谁不想休息的，这必须有一个人叫他们去组装才会去的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// 指挥创建过程类
    /// </summary>
    public class Director
    {
        // 组装电脑
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    /// <summary>
    /// 电脑类
    /// </summary>
    public class Computer
    {
        // 电脑组件集合
        private IList<string> parts = new List<string>();

        // 把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑开始在组装.......");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("电脑组装好了");
        }
    }

    /// <summary>
    /// 抽象建造者，这个场景下为 "组装人" ，这里也可以定义为接口
    /// </summary>
    public abstract class Builder
    {
        // 装CPU
        public abstract void BuildPartCPU();
        // 装主板
        public abstract void BuildPartMainBoard();

        // 当然还有装硬盘，电源等组件，这里省略

        // 获得组装好的电脑
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小王啊
    /// </summary>
    public class ConcreteBuilder1 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小李啊
    /// 又装另一台电脑了
    /// </summary>
    public class ConcreteBuilder2 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }
}
