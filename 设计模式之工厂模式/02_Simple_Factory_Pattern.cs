﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 设计模式之简单工厂模式
{
    ///// <summary>
    ///// 自己做饭的情况
    ///// 没有简单工厂之前，客户想吃什么菜只能自己炒的
    ///// </summary>
    //public class Customer
    //{
    //    /// <summary>
    //    /// 烧菜方法
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <returns></returns>
    //    public static Food Cook(string type)
    //    {
    //        Food food = null;
    //        // 客户A说：我想吃西红柿炒蛋怎么办？
    //        // 客户B说：那你就自己烧啊
    //        // 客户A说： 好吧，那就自己做吧
    //        if (type.Equals("西红柿炒蛋"))
    //        {
    //            food = new TomatoScrambledEggs();
    //        }
    //        // 我又想吃土豆肉丝, 这个还是得自己做
    //        // 我觉得自己做好累哦，如果能有人帮我做就好了？
    //        else if (type.Equals("土豆肉丝"))
    //        {
    //            food = new ShreddedPorkWithPotatoes();
    //        }
    //        return food;
    //    }

    //    static void Main(string[] args)
    //    {
    //        // 做西红柿炒蛋
    //        Food food1 = Cook("西红柿炒蛋");
    //        food1.Print();

    //        Food food2 = Cook("土豆肉丝");
    //        food1.Print();

    //        Console.Read();
    //    }
    //}
    ///// <summary>
    ///// 菜抽象类
    ///// </summary>
    //public abstract class Food
    //{
    //    // 输出点了什么菜
    //    public abstract void Print();
    //}

    ///// <summary>
    ///// 西红柿炒鸡蛋这道菜
    ///// </summary>
    //public class TomatoScrambledEggs : Food
    //{
    //    public override void Print()
    //    {
    //        Console.WriteLine("一份西红柿炒蛋！");
    //    }
    //}

    ///// <summary>
    ///// 土豆肉丝这道菜
    ///// </summary>
    //public class ShreddedPorkWithPotatoes : Food
    //{
    //    public override void Print()
    //    {
    //        Console.WriteLine("一份土豆肉丝");
    //    }
    //}



    ///// <summary>
    ///// 顾客充当客户端，负责调用简单工厂来生产对象
    ///// 即客户点菜，厨师（相当于简单工厂）负责烧菜(生产的对象)
    ///// 自己做饭，如果我们想吃别的菜时，此时就需要去买这种菜和洗菜这些繁琐的操作，有了餐馆（也就是简单工厂）之后，我们就可以把这些操作交给餐馆去做，此时消费者（也就是我们）对菜（也就是具体对象）的依赖关系从直接变成的间接的，这样就是实现了面向对象的另一个原则——降低对象之间的耦合度，下面就具体看看有了餐馆之后的实现代码（即简单工厂的实现）：
    ///// </summary>
    //class Customer
    //{
    //    static void Main(string[] args)
    //    {
    //        // 客户想点一个西红柿炒蛋        
    //        Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
    //        food1.Print();

    //        // 客户想点一个土豆肉丝
    //        Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
    //        food2.Print();

    //        Console.Read();
    //    }
    //}

    ///// <summary>
    ///// 菜抽象类
    ///// </summary>
    //public abstract class Food
    //{
    //    // 输出点了什么菜
    //    public abstract void Print();
    //}

    ///// <summary>
    ///// 西红柿炒鸡蛋这道菜
    ///// </summary>
    //public class TomatoScrambledEggs : Food
    //{
    //    public override void Print()
    //    {
    //        Console.WriteLine("一份西红柿炒蛋！");
    //    }
    //}

    ///// <summary>
    ///// 土豆肉丝这道菜
    ///// </summary>
    //public class ShreddedPorkWithPotatoes : Food
    //{
    //    public override void Print()
    //    {
    //        Console.WriteLine("一份土豆肉丝");
    //    }
    //}

    ///// <summary>
    ///// 简单工厂类, 负责 炒菜
    ///// </summary>
    //public class FoodSimpleFactory
    //{
    //    public static Food CreateFood(string type)
    //    {
    //        Food food = null;
    //        if (type.Equals("土豆肉丝"))
    //        {
    //            food = new ShreddedPorkWithPotatoes();
    //        }
    //        else if (type.Equals("西红柿炒蛋"))
    //        {
    //            food = new TomatoScrambledEggs();
    //        }

    //        return food;
    //    }
    //}

    /*优点与缺点

看完简单工厂模式的实现之后，你和你的小伙伴们肯定会有这样的疑惑（因为我学习的时候也有）——这样我们只是把变化移到了工厂类中罢了，好像没有变化的问题，因为如果客户想吃其他菜时，此时我们还是需要修改工厂类中的方法（也就是多加case语句，没应用简单工厂模式之前，修改的是客户类）。我首先要说：你和你的小伙伴很对，这个就是简单工厂模式的缺点所在（这个缺点后面介绍的工厂方法可以很好地解决），然而，简单工厂模式与之前的实现也有它的优点：

简单工厂模式解决了客户端直接依赖于具体对象的问题，客户端可以消除直接创建对象的责任，而仅仅是消费产品。简单工厂模式实现了对责任的分割。
简单工厂模式也起到了代码复用的作用，因为之前的实现（自己做饭的情况）中，换了一个人同样要去在自己的类中实现做菜的方法，然后有了简单工厂之后，去餐馆吃饭的所有人都不用那么麻烦了，只需要负责消费就可以了。此时简单工厂的烧菜方法就让所有客户共用了。（同时这点也是简单工厂方法的缺点——因为工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都会受到影响，也没什么不好理解的，就如事物都有两面性一样道理）
虽然上面已经介绍了简单工厂模式的缺点，下面还是总结下简单工厂模式的缺点：

工厂类集中了所有产品创建逻辑，一旦不能正常工作，整个系统都会受到影响（通俗地意思就是：一旦餐馆没饭或者关门了，很多不愿意做饭的人就没饭吃了）
系统扩展困难，一旦添加新产品就不得不修改工厂逻辑，这样就会造成工厂逻辑过于复杂。
了解了简单工厂模式之后的优缺点之后，我们之后就可以知道简单工厂的应用场景了：

当工厂类负责创建的对象比较少时可以考虑使用简单工厂模式（）
客户如果只知道传入工厂类的参数，对于如何创建对象的逻辑不关心时可以考虑使用简单工厂模式*/

}