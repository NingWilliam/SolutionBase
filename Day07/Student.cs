
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    /// <summary>
    /// 定义 学生类
    /// </summary>
    class Student
    {
        //数据成员
        //字段: 存储数据  (比喻成老板 - 私有的)
        //字段首字母小写
        private string name;

        //属性: 保护字段 本质就是2个方法  (比喻成助理 - 公开的)
        //属性首字母大写
        public string Name
        {
            //读取时保护
            get
            { return name; }
            //写入时保护 value 要设置的数据
            set
            { this.name = value; }
        }

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { this.sex = value; }
        }

        private int age;

        public int Age
        {
            get
            { return this.age; }

            set
            {
                if (value <= 24 && value >= 12)
                    this.age = value;
                else
                    throw new Exception("异常");
            }
        }

        //构造函数：提供了创建对象的方式，常常用于初始化类的数据成员。
        //一个类若没有构造函数，那么编译器会自动提供一个无参数构造函数。
        //每个类必须至少有一个构造函数。
        //一个类若具有构造函数，那么编译器不会提供无参数构造函数。

        //本质：方法
        //特点：没有返回值,也不能写void、与类同名、创建对象时自动调用(不能手动调用)
        //方法名称相同，参数列表不同 - 方法重载
        //如果不希望在类的外部被创建对象，就将构造函数私有化
        //private Student() {}

        public Student()
        {
            Console.WriteLine("创建对象就执行");
        }

        public Student(string name):this()
        {
            //Student(); 调用无参数构造函数
            this.name = name;
        }

        public Student(string name,int age):this(name)
        {
            //Student(name);
            //this.name = name; // 构造函数如果为字段赋值，属性中的代码块不会执行
            this.Age = age; // 内部有逻辑判断，则给属性赋值
        }

        //方法成员
        public void SetName(string name)
        {
            int a = 1;//就近原则
            Console.WriteLine(this.name);
            //this 这个对象(引用)s
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetAge(int age)
        {
            if (age <= 20 && age >= 16)
                this.age = age;
            else
                throw new Exception("我不要");
        }

        public int GetAge()
        {
            return this.age;
        }

        //局部变量声明都在栈中，因为方法在栈中。
        //类是引用类型，所以类和对象的成员变量无论是值类型还是引用类型都声明在堆中。
    }
}
