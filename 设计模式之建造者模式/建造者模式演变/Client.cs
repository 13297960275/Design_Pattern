using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 建造者模式演变
{
    /// <summary>
    /// 建造者模式的演变
    /// 省略了指挥者角色和抽象建造者角色
    /// 此时具体建造者角色扮演了指挥者和建造者两个角色
    /// </summary>
    public class Builder
    {
        // 具体建造者角色的代码
        private Product product = new Product();
        public void BuildPartA()
        {
            product.Add("PartA");
        }
        public void BuildPartB()
        {
            product.Add("PartB");
        }
        public Product GetProduct()
        {
            return product;
        }
        // 指挥者角色的代码
        public void Construct()
        {
            BuildPartA();
            BuildPartB();
        }
    }

    /// <summary>
    /// 产品类
    /// </summary>
    public class Product
    {
        // 产品组件集合
        private IList<string> parts = new List<string>();

        // 把单个组件添加到产品组件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("产品开始在组装.......");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("产品组装完成");
        }
    }

    // 此时客户端也要做相应调整
    class Client 
    {
        private static Builder builder;
        static void Main(string[] args)
        {
            builder = new Builder();
            builder.Construct();
            Product product = builder.GetProduct();
            product.Show();
            Console.Read();
        }
    }
}
