using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*桥接模式
桥接（Bridge）是用于把抽象化与实现化解耦，使得二者可以独立变化。这种类型的设计模式属于结构型模式，它通过提供抽象化和实现化之间的桥接结构，来实现二者的解耦。
这种模式涉及到一个作为桥接的接口，使得实体类的功能独立于接口实现类。这两种类型的类可被结构化改变而互不影响。
我们通过下面的实例来演示桥接模式（Bridge Pattern）的用法。其中，可以使用相同的抽象类方法但是不同的桥接实现类，来画出不同颜色的圆。
介绍
意图：将抽象部分与实现部分分离，使它们都可以独立的变化。
主要解决：在有多种可能会变化的情况下，用继承会造成类爆炸问题，扩展起来不灵活。
何时使用：实现系统可能有多个角度分类，每一种角度都可能变化。
如何解决：把这种多角度分类分离出来，让它们独立变化，减少它们之间耦合。
关键代码：抽象类依赖实现类。
应用实例： 1、猪八戒从天蓬元帅转世投胎到猪，转世投胎的机制将尘世划分为两个等级，即：灵魂和肉体，前者相当于抽象化，后者相当于实现化。生灵通过功能的委派，调用肉体对象的功能，使得生灵可以动态地选择。 2、墙上的开关，可以看到的开关是抽象的，不用管里面具体怎么实现的。
优点： 1、抽象和实现的分离。 2、优秀的扩展能力。 3、实现细节对客户透明。
缺点：桥接模式的引入会增加系统的理解与设计难度，由于聚合关联关系建立在抽象层，要求开发者针对抽象进行设计与编程。
使用场景： 1、如果一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性，避免在两个层次之间建立静态的继承联系，通过桥接模式可以使它们在抽象层建立一个关联关系。 2、对于那些不希望使用继承或因为多层次继承导致系统类的个数急剧增加的系统，桥接模式尤为适用。 3、一个类存在两个独立变化的维度，且这两个维度都需要进行扩展。
注意事项：对于两个独立变化的维度，使用桥接模式再适合不过了。*/
namespace 设计模式之桥接模式
{
    /// <summary>
    /// 抽象概念中的遥控器，扮演抽象化角色
    /// </summary>
    public class RemoteControl
    {
        // 字段
        private TV implementor;

        // 属性
        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        /// <summary>
        /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
        /// </summary>
        public virtual void On()
        {
            implementor.On();
        }

        /// <summary>
        /// 关电视机
        /// </summary>
        public virtual void Off()
        {
            implementor.Off();
        }

        /// <summary>
        /// 换频道
        /// </summary>
        public virtual void SetChannel()
        {
            implementor.tuneChannel();
        }
    }

    /// <summary>
    /// 具体遥控器
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("---------------------");
            base.SetChannel();
            Console.WriteLine("---------------------");
        }
    }

    //##############   TV   ####################

    /// <summary>
    /// 电视机，提供抽象方法
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void tuneChannel();
    }

    /// <summary>
    /// 长虹牌电视机，重写基类的抽象方法
    /// 提供具体的实现
    /// </summary>
    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    /// <summary>
    /// 三星牌电视机，重写基类的抽象方法
    /// </summary>
    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }

    // ###############     桥接模式  #################
    /// <summary>
    /// 以电视机遥控器的例子来演示桥接模式
    /// </summary>
    //class Client
    //{
    //    static void Main(string[] args)
    //    {
    //        // 创建一个遥控器
    //        RemoteControl remoteControl = new ConcreteRemote();
    //        // 长虹电视机
    //        remoteControl.Implementor = new ChangHong();
    //        remoteControl.On();
    //        remoteControl.SetChannel();
    //        remoteControl.Off();
    //        Console.WriteLine();

    //        // 三星牌电视机
    //        remoteControl.Implementor = new Samsung();
    //        remoteControl.On();
    //        remoteControl.SetChannel();
    //        remoteControl.Off();
    //        Console.Read();
    //    }
    //}

    //###################    实例     ###################

    // 客户端调用
    // 类似Web应用程序
    class Client
    {
        static void Main(string[] args)
        {
            BusinessObject customers = new CustomersBusinessObject("ShangHai");
            customers.Dataacces = new CustomersDataAccess();

            customers.Add("小六");
            Console.WriteLine("增加了一位成员的结果：");
            customers.ShowAll();
            customers.Delete("王五");
            Console.WriteLine("删除了一位成员的结果：");
            customers.ShowAll();
            Console.WriteLine("更新了一位成员的结果：");
            customers.Update("Learning_Hard");
            customers.ShowAll();

            Console.Read();
        }
    }

    // BLL 层
    public class BusinessObject
    {
        // 字段
        private DataAccess dataacess;
        private string city;

        public BusinessObject(string city)
        {
            this.city = city;
        }

        // 属性
        public DataAccess Dataacces
        {
            get { return dataacess; }
            set { dataacess = value; }
        }

        // 方法
        public virtual void Add(string name)
        {
            Dataacces.AddRecord(name);
        }

        public virtual void Delete(string name)
        {
            Dataacces.DeleteRecord(name);
        }

        public virtual void Update(string name)
        {
            Dataacces.UpdateRecord(name);
        }

        public virtual string Get(int index)
        {
            return Dataacces.GetRecord(index);
        }
        public virtual void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0}的顾客有：", city);
            Dataacces.ShowAllRecords();
        }
    }

    public class CustomersBusinessObject : BusinessObject
    {
        public CustomersBusinessObject(string city)
            : base(city) { }

        // 重写方法
        public override void ShowAll()
        {
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    /// <summary>
    /// 相当于三层架构中数据访问层（DAL）
    /// </summary>
    public abstract class DataAccess
    {
        // 对记录的增删改查操作
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void UpdateRecord(string name);
        public abstract string GetRecord(int index);
        public abstract void ShowAllRecords();
    }

    public class CustomersDataAccess : DataAccess
    {
        // 字段
        private List<string> customers = new List<string>();

        public CustomersDataAccess()
        {
            // 实际业务中从数据库中读取数据再填充列表
            customers.Add("Learning Hard");
            customers.Add("张三");
            customers.Add("李四");
            customers.Add("王五");
        }
        // 重写方法
        public override void AddRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            customers.Remove(name);
        }

        public override void UpdateRecord(string updatename)
        {
            customers[0] = updatename;
        }

        public override string GetRecord(int index)
        {
            return customers[index];
        }

        public override void ShowAllRecords()
        {
            foreach (string name in customers)
            {
                Console.WriteLine(" " + name);
            }
        }

    }


}
