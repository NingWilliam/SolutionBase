using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    /// <summary>
    /// 人
    /// </summary>
    class Person
    {
        //静态成员(饮水机)：静态字段、属性、构造函数、方法
        //实例成员(水杯)：实例字段、属性、构造函数、方法

        public string Name { get; set; }

        //每次创建对象 都存在一份
        public int InstanceCount { get; set; }

        //仅仅存储一份，可以被所有对象共享 
        public static int StaticCount { get; set; }

        //实例构造函数：提供创建对象的方式，初始化类的实例成员
        //实例构造函数私有化，将拒绝在类的外部创建对象
        public Person()
        {
            this.InstanceCount++;
            StaticCount++;
        }

        //静态构造函数：初始化类的静态数据成员
        //不能写访问修饰符
        //仅仅执行1次
        static Person()
        {

        }

        public void Fun1()
        {
            Console.WriteLine(this.Name);
        }

        public static void Fun3()
        {//静态方法中，只能访问静态数据成员
            Console.WriteLine(StaticCount);
        }
    }
}
