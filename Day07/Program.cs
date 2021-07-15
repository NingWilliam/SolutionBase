using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    class Program
    {
        private static readonly User u1;

        static void Main1(string[] args)
        {
            //数据类型
            //(1)值类型: 直接存储数据。(int、bool、char、枚举)
            //(2)引用类型: 存储数据的引用(内存地址) (数组、接口、object、string)
            //(3)方法执行在栈中，执行完毕清除栈帧。                                      
            //(4)局部变量的值类型: 声明在栈中，数据在栈中。
            //(5)局部变量的引用类型: 声明在栈中，数据在堆中，栈中存储数据的引用。
            //(6)区分修改的是栈中存储的引用，还是堆中数据 (看 赋值号 "=" 的左边)

            int a;//a存储在栈中
            a = 1;//数据1存储在栈中

            int[] arr01;//arr01在栈中 因为是局部变量，所以开空间的地方是栈。
            arr01 = new int[] { 1, 2 };//数组存储在堆中 arr01存数组的引用

            string[] arr02 = new string[1] { "希" };
            arr02[0] = "希";
            arr02[0] = "泽";

            string name = "老王";
            name = "老孙";

            int[] a1 = new int[] { 1 };
            Fun1(a1);
            Console.WriteLine(a1[0]);//1
        }

        private static void Fun1(int[] a)
        {
            a = new int[] { 2 };
        }

        static void Main2()
        {
            //0000000001 | 0000000010 ==> 0000000011
            //PrintPersonStyle(PersonStyle.tall | PersonStyle.rich);

            //数据类型转换
            //int ==> Enum
            PersonStyle style01 = (PersonStyle)2;

            //Enum ==> int
            int enumBumber = (int)(PersonStyle.beauty | PersonStyle.handsome);
            //PrintPersonStyle((PersonStyle)2);

            PersonStyle style02 =
                (PersonStyle)Enum.Parse(typeof(PersonStyle), "beauty");

            //Enum ==> string
            string strEnum = PersonStyle.handsome.ToString();

        }

        //枚举   类和对象
        //增强代码可读性，限定取值。

        private static void PrintPersonStyle(PersonStyle style)
        {
            if ((style & PersonStyle.tall) == PersonStyle.rich)
                Console.WriteLine("高");
            if ((style & PersonStyle.rich) == PersonStyle.tall)
                Console.WriteLine("豪");
            if ((style & PersonStyle.handsome) != 0)
                Console.WriteLine("帅");
            if ((style & PersonStyle.white) == PersonStyle.white)
                Console.WriteLine("白");
            if ((style & PersonStyle.beauty) != 0)
                Console.WriteLine("美");
        }

        //类和对象
        static void Main3()
        {
            //声明Student类型的引用
            Student student01;
            //指向Student类型的对象(实例化Student类型对象)
            student01 = new Student();

            student01.SetName("煊");
            student01.SetAge(18);
            //student01.age = 81;

            Student student02 = student01;
            student02 = new Student();
            student02.SetName("沁");

            Console.WriteLine(student01.GetName());

            Student student03 = new Student();
            student03.Name = "羽"; // 执行Name的set代码块
            student03.Age = 19;

            Console.WriteLine(student03.Name); // 执行Name的get代码块
            Console.WriteLine(student03.Age);

            Student student04 = new Student("杨涵", 14);
        }

        static void Main4()
        {
            Student s01 = new Student();
            s01.Name = "赵";
            s01.Age = 19;

            Student s02 = new Student("钱", 20);

            Student[] studentsArray = new Student[5];
            studentsArray[0] = s01;
            studentsArray[1] = s02;
            studentsArray[2] = new Student("孙", 21);
            studentsArray[3] = new Student("李", 17);
            studentsArray[4] = new Student("周", 16);

            //练习：查找年龄最小的学生(返回Student类型的引用)
            Student min = GetStudentByMiniMumAge(studentsArray);
        }

        private static Student GetStudentByMiniMumAge(Student[] students)
        {
            Student minStudent = students[0];
            for (int i = 1; i < students.Length; i++)//从第二个开始往后比较
            {
                if (minStudent.Age > students[i].Age)//比较年龄
                    minStudent = students[i]; //替换引用
            }
            return minStudent;
        }

        static void Main()
        {
            //每日一练
            User user01 = new User();
            //数组初始化 必须 指定大小
            //User[] userArray = new User[?];
            //读写元素 必须通过 索引
            //userArray[?] = user01;

            /*
             用户集合类 UserList
             {
                 private User[] data; //真正存储用户的字段

                 //两个构造函数
                 public UserList():this(8)
                 {
                     //创建类的对象时 不给参数 则执行无参数构造函数
                     //data = new User[8];
                 }
                 public UserList(int capacity)
                 {
                     //创建类的对象时 给参数 则执行有一个参数的构造函数
                     data = new User[capacity];
                 }

                 //添加元素
                 public void Add(User value)
                 {
                     
                     data[?] = value;
                     //如果容量不够？
                     //扩容：开辟更大的数组  拷贝原始数据  替换引用
                 }
                 
                 //获取元素
                 public User GetElement(int index)
                 {
                     //返回值
                     return data[index]
                 }
                 //插入功能  删除功能
             }

             * 需求
             * UserList list = new UserList(3);
             * list.Add(u1);
             * list.Add(u2);
             * list.Add(u3);
             * list.Add(u4);
             * 
             * for (int i = 0;i < list.Count; i++)
             * {
             *     User user = list.GetElement(i);
             *     user.PrintUser();
             * }
             * 
             */

            //UserList list = new UserList();
            //list.Add(u1);
            //list.Add(new User());
            //list.Add(new User());
            //list.Add(new User());

            //for (int i = 0; i < list.Count; i++)
            //{
            //    User user = list.GetElement(i);
            //    user.PrintUser();
            //}

            // C# 集合        List<数据类型>
            // User[]           new User[];
            List<User> list02 = new List<User>(2);
            list02.Add(u1);
            list02.Add(new User());
            // list02.Insert()
            // list02.RemoveAt()
            // list02.Remove()
            User u2 = list02[0]; // 根据索引获取元素
            //读取索引元素
            for (int i = 0; i < list02.Count; i++)
            {
                User u = list02[i];
            }

            // 字典集合  根据 ？ 查找 ？
            Dictionary<string, User> dic = new Dictionary<string, User>();
            dic.Add("lh",new User("lh","123"));
            User lhUser = dic["lh"];
        }
    }
}