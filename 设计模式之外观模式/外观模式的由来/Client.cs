using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 外观模式的由来
{
    /// <summary>
    /// 不使用外观模式的情况
    /// 此时客户端与三个子系统都发送了耦合，使得客户端程序依赖与子系统
    /// 为了解决这样的问题，我们可以使用外观模式来为所有子系统设计一个统一的接口
    /// 客户端只需要调用外观类中的方法就可以了，简化了客户端的操作
    /// 从而让客户和子系统之间避免了紧耦合
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            SubSystemA a = new SubSystemA();
            SubSystemB b = new SubSystemB();
            SubSystemC c = new SubSystemC();
            a.MethodA();
            b.MethodB();
            c.MethodC();
            Console.Read();
        }
    }

    // 子系统A
    public class SubSystemA
    {
        public void MethodA()
        {
            Console.WriteLine("执行子系统A中的方法A");
        }
    }

    // 子系统B
    public class SubSystemB
    {
        public void MethodB()
        {
            Console.WriteLine("执行子系统B中的方法B");
        }
    }

    // 子系统C
    public class SubSystemC
    {
        public void MethodC()
        {
            Console.WriteLine("执行子系统C中的方法C");
        }
    }

}
