using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*过滤器模式
过滤器模式（Filter Pattern）或标准模式（Criteria Pattern）是一种设计模式，这种模式允许开发人员使用不同的标准来过滤一组对象，通过逻辑运算以解耦的方式把它们连接起来。这种类型的设计模式属于结构型模式，它结合多个标准来获得单一标准。*/
namespace 设计模式之过滤器模式
{
    ////Person类中的代码：
    //public class Person
    //{
    //    private String name; // 姓名  
    //    private String gender; // 性别  
    //    private String marital; // 婚姻情况  

    //    public Person(String name, String gender, String marital)
    //    {
    //        this.name = name;
    //        this.gender = gender;
    //        this.marital = marital;
    //    }

    //    public String getName()
    //    {
    //        return name;
    //    }

    //    public void setName(String name)
    //    {
    //        this.name = name;
    //    }

    //    public String getGender()
    //    {
    //        return gender;
    //    }

    //    public void setGender(String gender)
    //    {
    //        this.gender = gender;
    //    }

    //    public String getMarital()
    //    {
    //        return marital;
    //    }

    //    public void setMarital(String marital)
    //    {
    //        this.marital = marital;
    //    }

    //    public override String toString()
    //    {
    //        return "Person [name=" + name + ",gender=" + gender + ", marital=" + marital + "]";
    //    }
    //}

    ///// <summary>
    ///// Filter接口中的代码：
    ///// </summary>
    //public interface Filter
    //{
    //    // 根据传过来的Person列表，根据一定的条件过滤，得到目标集合  
    //    List<Person> filter(List<Person> persons);
    //}

    ///// <summary>
    ///// MaleFilter类中的代码：
    ///// </summary>
    //public class MaleFilter : Filter
    //{
    //    public List<Person> filter(List<Person> persons)
    //    {
    //        List<Person> result = new List<Person> { };
    //        for (Person person : persons)
    //        {
    //            if ("MALE".equalsIgnoreCase(person.getGender()))
    //            {
    //                result.add(person);
    //            }
    //        }
    //        return result;
    //    }
    //}

    ///// <summary>
    ///// 处理“并且”逻辑的过滤器类FilterAnd类中的代码：
    ///// </summary>
    //public class FilterAnd : Filter
    //{
    //    private Filter filter;
    //    private Filter otherFilter;

    //    public FilterAnd(Filter filter, Filter otherFilter)
    //    {
    //        this.filter = filter;
    //        this.otherFilter = otherFilter;
    //    }


    //    public override List<Person> filter(List<Person> persons)
    //    {
    //        List<Person> tmpList = filter.filter(persons);
    //        return otherFilter.filter(tmpList);
    //    }
    //}
    ///// <summary>
    ///// 处理“或者”逻辑的过滤器类FilterOr类中的代码：
    ///// </summary>
    //public class FilterOr : Filter
    //{
    //    private Filter filter;
    //    private Filter otherFilter;

    //    public FilterOr(Filter filter, Filter otherFilter)
    //    {
    //        this.filter = filter;
    //        this.otherFilter = otherFilter;
    //    }


    //    public override List<Person> filter(List<Person> persons)
    //    {
    //        List<Person> tmpList1 = filter.filter(persons);
    //        List<Person> tmpList2 = otherFilter.filter(persons);
    //        for (Person person : tmpList2)
    //        {
    //            if (!tmpList1.contains(person))
    //            {
    //                tmpList1.add(person);
    //            }
    //        }
    //        return tmpList1;
    //    }
    //}

    ///// <summary>
    ///// 测试类Test中的代码：
    ///// </summary>
    //public class Test
    //{
    //    public static void main(String[] args)
    //    {
    //        // 初始化数据  
    //        List<Person> persons = new ArrayList<>();
    //        persons.add(new Person("霍一", "FEMALE", "MARRIED"));
    //        persons.add(new Person("邓二", "MALE", "MARRIED"));
    //        persons.add(new Person("张三", "MALE", "SINGLE"));
    //        persons.add(new Person("李四", "FEMALE", "MARRIED"));
    //        persons.add(new Person("王五", "MALE", "SINGLE"));
    //        persons.add(new Person("赵六", "FEMALE", "SINGLE"));
    //        persons.add(new Person("孙七", "MALE", "SINGLE"));
    //        persons.add(new Person("罗八", "MALE", "MARRIED"));
    //        persons.add(new Person("刘九", "FEMALE", "SINGLE"));
    //        persons.add(new Person("史十", "FEMALE", "SINGLE"));
    //        // 打印出所有男性的信息  
    //        Console.WriteLine("---------------------所有男性---------------------");
    //        List<Person> maleList = new MaleFilter().filter(persons);
    //        printList(maleList);
    //        // 打印出所有单身的信息  
    //        Console.WriteLine("---------------------所有单身---------------------");
    //        List<Person> singleList = new SingleFilter().filter(persons);
    //        printList(singleList);
    //        // 打印出所有已婚女性的信息  
    //        Console.WriteLine("--------------------所有已婚女性-------------------");
    //        List<Person> marriedFemaleList = new FilterAnd(new MarriedFilter(), new FemaleFilter()).filter(persons);
    //        printList(marriedFemaleList);
    //        // 打印出所有单身或女性的信息  
    //        Console.WriteLine("-------------------所有单身或女性------------------");
    //        List<Person> singleOrFemaleList = new FilterOr(new SingleFilter(), new FemaleFilter()).filter(persons);
    //        printList(singleOrFemaleList);
    //    }

    //    // 打印列表中的数据信息  
    //    private static void printList(List<Person> list)
    //    {
    //        for (Person person : list)
    //        {
    //            Console.WriteLine(person.toString());
    //        }
    //    }
    //}

    #region 普通的实现

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var regulars = new List<Regulars>();

    //        regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则1", AnalysisConditons = "xxxx" });
    //        regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则2", AnalysisConditons = "xxxx" });
    //        regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则3", AnalysisConditons = "xxxx" });
    //        regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则4", AnalysisConditons = "xxxx" });
    //        regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则5", AnalysisConditons = "xxxx" });

    //        var filters = FilterRegularID(regulars);
    //        filters = FilterRegularName(filters);
    //        filters = FilterCondtions(filters);

    //        //... 后续逻辑
    //    }

    //    static List<Regulars> FilterRegularID(List<Regulars> persons)
    //    {
    //        //过滤 “姓名” 的逻辑
    //        return null;
    //    }

    //    static List<Regulars> FilterRegularName(List<Regulars> persons)
    //    {
    //        //过滤 “age” 的逻辑
    //        return null;
    //    }

    //    static List<Regulars> FilterCondtions(List<Regulars> persons)
    //    {
    //        //过滤 “email” 的逻辑
    //        return null;
    //    }
    //}

    /// <summary>
    /// 各种催付规则
    /// </summary>
    public class Regulars
    {
        public int RegularID { get; set; }

        public string RegularName { get; set; }

        public string AnalysisConditons { get; set; }

        public String toString()
        {
            return "Regulars [RegularID=" + RegularID + ",RegularName=" + RegularName + ", AnalysisConditons=" + AnalysisConditons + "]";
        }
    }

    #endregion

    #region 过滤器模式实现

    public interface IFilter
    {
        List<Regulars> Filter(List<Regulars> regulars);
    }

    public class RegularIDFilter : IFilter
    {
        /// <summary>
        /// Regulars的过滤逻辑
        /// </summary>
        /// <param name="regulars"></param>
        /// <returns></returns>
        public List<Regulars> Filter(List<Regulars> regulars)
        {
            List<Regulars> result = new List<Regulars>();
            foreach (Regulars regular in regulars)
            {
                if (regular.RegularID % 2 == 0)
                {
                    result.Add(regular);
                }
            }
            return result;
        }
    }

    public class RegularNameFilter : IFilter
    {
        /// <summary>
        /// regularName的过滤方式
        /// </summary>
        /// <param name="regulars"></param>
        /// <returns></returns>
        public List<Regulars> Filter(List<Regulars> regulars)
        {
            List<Regulars> result = new List<Regulars>();
            foreach (Regulars regular in regulars)
            {
                if (Convert.ToInt32(Regex.Replace(regular.RegularName, @"[^\d.\d]", "")) % 2 == 0)
                {
                    result.Add(regular);
                }
            }
            return result;
        }
    }

    public class RegularCondtionFilter : IFilter
    {
        /// <summary>
        /// Condition的过滤条件
        /// </summary>
        /// <param name="regulars"></param>
        /// <returns></returns>
        public List<Regulars> Filter(List<Regulars> regulars)
        {
            List<Regulars> result = new List<Regulars>();
            foreach (Regulars regular in regulars)
            {
                if (Convert.ToInt32(Regex.Replace(regular.AnalysisConditons, @"[^\d.\d]", "")) % 2 == 0)
                {
                    result.Add(regular);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// filter的 And 模式
    /// </summary>
    public class AndFilter : IFilter
    {
        List<IFilter> filters = new List<IFilter>();

        public AndFilter(List<IFilter> filters)
        {
            this.filters = filters;
        }

        public List<Regulars> Filter(List<Regulars> regulars)
        {
            var regularlist = new List<Regulars>(regulars);

            foreach (var criteriaItem in filters)
            {
                regularlist = criteriaItem.Filter(regularlist);
            }

            return regularlist;
        }
    }

    public class OrFilter : IFilter
    {
        List<IFilter> filters = null;

        public OrFilter(List<IFilter> filters)
        {
            this.filters = filters;
        }

        public List<Regulars> Filter(List<Regulars> regulars)
        {
            //用hash去重
            var resultHash = new HashSet<Regulars>();

            foreach (var filter in filters)
            {
                var smallPersonList = filter.Filter(regulars);

                foreach (var small in smallPersonList)
                {
                    resultHash.Add(small);
                }
            }

            return resultHash.ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var regulars = new List<Regulars>();

            regulars.Add(new Regulars() { RegularID = 1, RegularName = "规则1", AnalysisConditons = "1" });
            regulars.Add(new Regulars() { RegularID = 2, RegularName = "规则2", AnalysisConditons = "2" });
            regulars.Add(new Regulars() { RegularID = 3, RegularName = "规则3", AnalysisConditons = "3" });
            regulars.Add(new Regulars() { RegularID = 4, RegularName = "规则4", AnalysisConditons = "4" });
            regulars.Add(new Regulars() { RegularID = 5, RegularName = "规则5", AnalysisConditons = "5" });

            // 打印出所有RegularID为偶数的信息  
            Console.WriteLine("---------------------RegularID为偶数---------------------");
            List<Regulars> idList = new RegularIDFilter().Filter(regulars);
            printList(idList);
            // 打印出所有RegularName包含偶数的信息  
            Console.WriteLine("---------------------RegularName包含偶数---------------------");
            List<Regulars> nameList = new RegularNameFilter().Filter(regulars);
            printList(nameList);
            // 打印出所有AnalysisConditons包含偶数的信息    
            Console.WriteLine("---------------------AnalysisConditons包含偶数---------------------");
            List<Regulars> condList = new RegularCondtionFilter().Filter(regulars);
            printList(condList);
            //追加filter条件
            var filterList = new IFilter[3] {
                                              new RegularIDFilter(),
                                              new RegularNameFilter(),
                                              new RegularCondtionFilter()
                                            };

            var andCriteria = new AndFilter(filterList.ToList());

            //进行 And组合 过滤
            andCriteria.Filter(regulars);

            Console.ReadKey();
        }

        // 打印列表中的数据信息  
        private static void printList(List<Regulars> list)
        {
            foreach (Regulars regulars in list)
            {
                Console.WriteLine(regulars.toString());
            }
        }
    }

    #endregion

}
