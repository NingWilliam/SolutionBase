using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Program
    {
        // 继承   static   结构体   2048核心类
        static void Main1(string[] args)
        {
            // 父类 只能使用 父类成员
            Person person01 = new Person();

            // 子类 可以使用 父类成员
            Student stu01 = new Student();
            stu01.Name = "";

            // 父类型的引用 指向 子类的对象
            // 只能使用父类成员
            Person person02 = new Student();
            // 如果需要访问该子类成员，需要强制类型转换
            Student stu02 = (Student)person02;
            // 异常
            //Teacher teacher02 = (Teacher)person02;
            // 如果转换失败 不会抛出异常
            Teacher teacher02 = person02 as Teacher;

            if (teacher02 != null)
                teacher02.Salary = 100; // null.Salary = 100;
        }

        // static
        static void Main2()
        {
            Student stu01; // 类被加载，静态数据成员存在

            stu01 = new Student();//0-->1
            Student stu02 = new Student();//0-->1
            Student stu03 = new Student();//0-->1

            // 通过引用 调用
            Console.WriteLine(stu03.InstanceCount); // 1
            // 通过类名 调用
            Console.WriteLine(Student.StaticCount);

            Student.Fun1(); // 静态调用
            stu03.Fun2();// 通过引用调用实例方法，都会自动的传递引用

            // 需求: 统计Student类，创建的对象数量
        }

        static void Main()
        {
            /*[行,列]
              00    01   02   03
              10    11   12   13
              20    21   22   23
             */

            // 需求：在二维数组中，获取某个元素某个方向上的元素

            Direction dir = Direction.Left;
        }
    }
}
