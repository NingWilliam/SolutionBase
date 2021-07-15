using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        //交错数组  参数数组  数据类型

        #region 交错数组
        
        static void Main1(string[] args)
        {
            //[行,列]
            int[,] arr = null;
            arr = new int[5, 3];
            arr[0, 2] = 100;

            //交错数组:每个元素都是独立的一维数组，分布通常想象为"不规则的表格"
            //不规则的用交错、规则的用二维
            //数组分类:一维、多维、交错
            //交错不属于多维数组
            int[][] array02;//null
            //创建具有4个元素的交错数组
            array02 = new int[4][];
            //创建一维数组 赋值给 交错数组的第一个元素
            array02[0] = new int[3];
            array02[1] = new int[5];
            array02[2] = new int[4];
            array02[3] = new int[1];
            //将数据1 赋值给 交错数组的第一个元素 的 第一个元素
            array02[0][0] = 1;
            array02[1][2] = 2;
            array02[1][4] = 3;
            array02[2][1] = 4;
            array02[2][3] = 5;

            foreach (int[] array in array02)//交错数组内的元素是数组
            {
                foreach(int element in array)//交错数组内数组的元素
                {
                    Console.WriteLine(element);
                }
            }

            //array02.Length 交错数组元素数(理解为 : 行数)
            for (int r = 0; r < array02.Length; r++)
            {
                for (int c = 0; c < array02[r].Length; c++)
                {
                    Console.Write(array02[r][c] + "\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region 参数数组

        static void Main2()
        {
            int result01 = Add(new int[] { 1, 34, 24, 65, 82 });
            int result02 = Add(1, 34, 24, 65, 82);
            int result03 = Add();

            Console.WriteLine("{0 }{ 1}{ 2}",new object[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("{0 }{ 1}{ 2}", 1, 2, 3, 4, 5);
        }

        //Params:参数数组
        //整数相加的方法
        //当类型确定 个数不确定的情形 用数组做
        //对于方法内部而言:就是个普通数组
        //对于方法外部(调用者)而言:
        //--可以传递数组
        //--传递一组数据类型相同的变量集合
        //--可以不传递数组
        //作用: 简化调用者调用方法的代码
         
        private static int Add(params int[] arr)
        {
            int sum = 0;
            foreach(var item in arr)
            {
                sum += item;
            }
            return sum;
        }

        #endregion

        #region 数据类型

        static void Main3()
        {
            //值类型               引用类型
            //int bool char      string Array
            //变量名可以理解为内存地址的别名
            //1.因为方法执行在栈中，所以在方法中声明的变量都在栈中
            //2.又因为值类型直接存储数据，所以数据存储在栈中
            //3.又因为引用类型存储数据的引用，所以数据在堆中，栈中存储数据的内存地址。
            //存什么给什么
            //不管值类型还是引用类型，声明在方法里面的都是在栈上。
            //引用类型传递进来，不需要返回值，但要确保方法内部指向的对象

            //a在栈中  1在栈中
            int a = 1;
            int b = a;
            a = 2;
            Console.WriteLine(b);

            //arr在栈中存储数组对象的引用(内存地址) 1在堆中
            int[] arr = new int[] { 1 };
            int[] arr2 = arr;
            //看赋值号左边中括号，没有中括号指的就是栈，有中括号改的就是堆中的数据
            //arr[0] = 2;//修改的是堆中的数据
            arr = new int[] { 2 };//修改的是栈中存储的引用
            Console.WriteLine(arr2[0]);

            string s1 = "男";
            string s2 = s1;
            s1 = "女";//修改的是栈中存储的引用
            //s1[0] = "女";//堆中的文字 不能修改
            Console.WriteLine(s2);

            //o1在栈中   数据1 在堆中
            object o1 = 1;
            object o2 = o1;//o2得到的是 数据1 的地址
            o1 = 2;//修改的是栈中o1存储的引用
            Console.WriteLine(o2);//1
        }

        //值类型与引用类型的应用
        static void Main4()
        {
            int num01 = 1, num02 = 1;
            bool r1 = num01 == num02; //true 因为值类型存储的是数据，所以比较的也是数据

            int[] arr01 = new int[] { 1 }, arr02 = new int[] { 1 };//这个比较的并不是1
            bool r2 = arr01 == arr02; //false 因为引用类型存储的是数据的引用，所以比较的是存储的引用
            bool r3 = arr01[0] == arr02[0];//这个比较的才是数组内存储的1

            int a = 1;
            int[] arr = new int[] { 1 };
            Fun1(a, arr);//实参将 数据1、数组引用 赋值给形参
            Console.WriteLine(a);
            Console.WriteLine(arr[0]);
        }

        static void Main5()
        {
            int a = 1;//存数据
            int[] arr = new int[] { 1 };//存引用
            Fun1(a, arr);

            int a2 = 1;
            Fun2(ref a2);
            Console.WriteLine(a2);//2

            //区别2: 输出参数 传递 之前可以不赋值
            int a3;//用于接受方法的结果
            Fun3(out a3);
            Console.WriteLine(a3);//2
        }

        //值参数: 按值传递 -- 传递实参变量存储的内容
        //传递信息
        private static void Fun1(int a,int[] arr)
        {
            a = 2;
            arr[0] = 2;
            arr = new int[] { 2 };
        }

        //引用参数: 按引用传递 -- 传递实参变量自身的内存地址
        //作用: 改变数据
        private static void Fun2(ref int a)
        {//方法内部修改引用参数 实质上就是在修改实参变量
            a = 2;
        }

        //输出参数: 按引用传递 -- 传递实参变量自身的内存地址.
        //作用: 返回结果
        private static void Fun3(out int a)
        {//区别1: 方法内部必须为输出参数赋值
            a = 2;
        }

        static void Main6()
        {
            //频繁的new，容易产生垃圾，尽量减少。
            //int[] arr = new int[100];
            //arr = new int[100];

            int num01 = 100, num02 = 200;
            Swop(ref num01, ref num02);

            int area;
            int perimeter;
            CalculateRect(15, 20, out area, out perimeter);

            //int number = int.Parse("250+");

            int result;
            //TryParse方法，返回两个结果
            //out: 转换后的结果
            //返回值: 是否可以转换
            bool re = int.TryParse("250+", out result);
        }

        //练习

        //练习1: 定义 两个整数交换的方法
        private static void Swop(ref int one, ref int two)
        {
            int temp = one;
            one = two;
            two = temp;
        }

        //练习2: 根据矩形长、宽计算面积(长 * 宽)与周长((长 + 宽) * 2)
        private static void CalculateRect(int lenght,int width,out int area,out int perimeter)
        {
            area = lenght * width;
            perimeter = (lenght + width) * 2;
        }

        //拆装箱
        //值类型到object 或者 object到值类型 才叫做拆装箱
        static void Main7()
        {
            int a = 1;

            //装箱操作即值类型到object的隐式转换
            //装箱操作: "比较"消耗性能("最")
            object o = a;

            //拆箱操作即object到值类型的显式转换
            //拆箱操作: "比较"消耗性能
            int b = (int)o;

            int num = 100;
            string str = num.ToString();//没装箱

            string str02 = "" + num;//装箱：值类型和字符串直接相加
            //string str02 = string.Concat("", num); //int==>object转换
        }

        //形参object类型，实参传递值类型，则装箱
        //可以通过 重载、泛型 避免。

        private static  void Fun1(object obj)
        {

        }

        //String
        static void Main8 ()
        {
            string s1 = "八戒";
            string s2 = "八戒";//同一个字符串

            string s3 = new string(new char[] { '八', '戒' });
            string s4 = new string(new char[] { '八', '戒' });

            bool r1 = object.ReferenceEquals(s3, s4);

            //字符串池
            //目的: 提高内存利用率
            //字符串的不可变性
            //字符串常量进入内存不得再次改变，因为在原位置改变会使其它对象内存被破坏，导致内存泄露。

            //重新开辟空间 存储 新字符串，再替换栈中引用
            s1 = "悟空";
            //将文本"八戒"改为"悟空"
            Console.WriteLine(s1);

            //每次修改，都是重新开辟新的空间存储数据，替换栈中引用
            object o1 = 1;
            o1 = 2.0;
            o1 = "qwert";
            o1 = true;

            //游戏中，这种代码不建议写
            //string strNumber = "";
            //for (int i = 0; i < 10; i++)
            //{
            //    //          ""  + "0"
            //    //          "0" + "1" 每次拼接产生新的对象，替换引用(原有数据产生1个垃圾)
            //    strNumber = strNumber + i.ToString();
            //}
            //Console.WriteLine(strNumber);

            //可变字符串 一次开辟可以容纳10个字符大小的空间
            //优点: 可以在原有空间修改字符串
            //适用性: 频繁对字符串操作(增加 替换 移除)
            StringBuilder builder = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                builder.Append(i);
            }
            builder.Append("新的内容");
            string result = builder.ToString();
            builder.Insert(0, "builder");
            //builder.Replace()
            //builder.Remove()

            s1 = s1.Insert(0, "s1");      
        }

        //先自学字符串常用方法
        //再做练习题
        //1.单词反转 How are you ==> you are How
        public string StringReverse(string targetString)
        {
            char[] toArray = targetString.ToCharArray();
            System.Array.Reverse(toArray);
            return new string(toArray);
        }

        //2.字符反转 How are you ==> uoy era woH
        public string WordReverse(string targetString)
        {
            string[] toArray = targetString.Split(' ');
            System.Array.Reverse(toArray);
            return string.Join("", toArray);
        }

        //3.查找指定字符串中不重复出现的文字(重复的文字保留1个)
        public static string FindNotContainString(string targetString)
        {
            StringBuilder builder = new StringBuilder(targetString.Length);
            foreach (char c in targetString)
            {
                if (builder.ToString().IndexOf(c) == -1)
                    builder.Append(c);
            }
            return builder.ToString();
        }

        #endregion

    }
}

