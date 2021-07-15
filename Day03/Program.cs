using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        // 短路逻辑
        static void Main1(string[] args)
        {
            // 复习选择语句 运算符
            int n1 = 1, n2 = 2;
            //false
            bool re1 = n1 > n2 && n1++ > 1;
            Console.WriteLine(n1);

            //true
            bool re2 = n1 < n2 || n2++ < 1;
            Console.WriteLine(n2);
        } 

        // 循环语句：for循环
        static void Main2()
        {
            //语句 循环语句 跳转语句 方法
            /*
            for (初始化; 循环条件; 增减变量)
            {
                循环体
            }
             **/
            //用途:
            //作用域:起作用的范围
            //从声明开始 到 } 结束
            //预定次数的循环
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("松鼠");

            }

            //一张纸的厚度为0.01毫米
            //请计算 对折 30次 以后的厚度为多少米？
            float thickness = 0.00001f; //毫米换算成米

            for (int i = 0; i < 30; i++)
            {
                //thickness = thickness * 2;
                thickness *= 2;
            }

            Console.WriteLine("厚度为:" + thickness);

            //1-100之间数字累加
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                // 跳转语句 continue 结束本次循环，继续下次循环
                //if (i % 3 == 0)
                if (i % 3 != 0) continue;// 跳过后面的代码，继续i++循环
                sum += i;
            }
            Console.WriteLine(sum);
        }

        // 循环语句：while循环
        static void Main3()
        {
            /*while (条件)
            {
                循环体
            }*/

            //int i = 0; //声明变量
            //while (i < 5) //满足条件
            //{
            //    Console.WriteLine("天蓬");
            //    i++;
            //}

            //练习：一个球从100米高度落下
            //每次落地后，弹回原高度一半
            //计算，总共弹起 ？次最终落地(最小弹起高度: 0.01米)
            //     总共经过 ？米

            float height = 100;//当前高度
            int count = 0;//存储数据
            float distance = height;//距离
            //下次弹起高度，如果 大于 0.01米
            while (height / 2 >= 0.01f)
            {
                height /= 2;//高度减半
                count++;//计数
                //累加起、落、距离
                distance += height * 2;
                Console.WriteLine("第{0}次弹起高度为:{1}", count, height);

            }
            Console.WriteLine("经过{0}次最终落地", count);
            Console.WriteLine("总共经过{0:f1}米", distance);
        }

        // 循环语句：do while循环
        static void Main4()
        {
            /*do
            {
                循环体
            }while (条件){
            先循环1次循环体，再判断条件。
            }*/

            //猜数字
            //程序产生1-100之间的随机数
            //让玩家重复猜测，直到猜对位置。
            //"大了" "小了" "恭喜，猜对了，总共猜了？次"


            //创建一个随机数工具
            Random random = new Random();
            //产生一个随机数
            int number = random.Next(1, 101);//取下界值、不取上届值，即左等右不等。
            int count = 0;
            while (true)// 死循环
            {
                count++;
                Console.WriteLine("请输入一个数字:");
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber > number)
                    Console.WriteLine("大了");
                else if (inputNumber < number)
                    Console.WriteLine("小了");
                else
                {
                    Console.WriteLine("猜对了，总共猜了{0}次。", count);
                    break;// 循环内加break，退出循环体;
                }
            }
        }

        // 方法：有些语言将其称为函数或者过程。
        // 方法是对一系列语句的命名，表示一个功能或行为。
        static void Main5()
        {
            //定义方法:
            //[访问修饰符] [可选修饰符] 返回类型 方法名称-首字母大写(参数列表)
            //{
                    //方法体
                    //return 结果：
            //}

            //调用方法:
            //方法名称(参数)
            /************方法调用者***********/
            Fun1();

            Fun2();

            //传递参数
            //实参 和 形参 一一对应(类型、顺序、数量)
            Fun3(100, "ok");//实际参数---实际的数据

            //学会调用别人创建的方法
            //1.看名字猜，看描述。
            //2.看参数(类型、名称、描述)            
            //3.看返回值
            //4.测试

            string str = "浩气长歌！";
            str = str.Insert(4,"决");
            //查找指定字符在字符串中的索引
            //int index = str.IndexOf('长');
            //str = str.Remove(2);
            //string str2 = str.Replace('歌','存');
            //bool re = str.StartsWith("浩气");
            //bool re = str.Contains("天");
        }

        //定义方法
        //方法:表示功能
        //返回值：功能的结果
        //返回值就是 方法定义者 告诉 方法调用者的 结果
        //类型：即数据类型 int double float string
        //参数：调用者 需要 提供的 信息
        //void：无返回值
        private static void Fun1()
        {
            Console.WriteLine("Fun1被执行了");
            return; // 没有返回值的方法，也可以写return关键字，但是不能跟任何数据。
        }

        private static float Fun2() // 方法的定义者
        {
            //错误提示---"并非所有的代码路径都返回值"-->方法体中缺少return关键字
            //返回的数据必须与返回的类型兼容
            Console.WriteLine("Fun被执行了");
            return 250; // 1.返回数据 2.退出方法; return后面的语句不会执行
        }

        // 形参 形式参数，实际上未知
        private static void Fun3(int a, string b) // 参数 即声明变量
        {
            Console.WriteLine(a);
        }

        // 如何定义方法
        static void Main6()
        {
            //做界面
            Console.WriteLine("请输入第1个数");
            int one = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入第2个数");
            int two = int.Parse(Console.ReadLine());

            int result = Add(one, two);

            Console.WriteLine("结果为:" + result);
        }
        // 两个整数相加的方法 : [一个]功能
        private static int Add(int one, int two)
        {
            return one + two;
        }

        /*
         * 1.在控制台中显示年历的方法
         *   --调用12遍显示月历
         * 2.在控制台中显示月历的方法
         *   --显示表头 Console.WriteLine("日\t一\t二\t......");
         *   --计算当月1日星期数，输出空白(\t)
         *     Console.Write("\t")
         *   --计算当月天数，输入1\t 2 3 4
         *   --每逢周六换行
         * 3.根据年月日，计算星期数[赠送]
         * 4.计算指定月份的天数
         * 5.判断闰年的方法
         *   2月闰年29天 平年28天
         *   年份能被4整除 但是 不能被100整除
         *   年份能被400整除  
         */

        /// <summary>
        /// 根据年月日，计算星期数的方法
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <param name="day">天</param>
        /// <returns>星期数</returns>
        /// 

        //1.
        private static void PrintYearCalendar(int year)
        {
            for (int i = 1; i <= 12; i++)
            {
                PrintMonthCalendar(year, i);
                Console.WriteLine();
            }
        }

        //2.
        private static void PrintMonthCalendar(int year, int month)
        {
            //1.显示表头
            Console.WriteLine("{0}年{1}月", year, month);
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");

            //2.根据当月1日星期数，显示空白
            int week = GetWeekByDay(year, month, 1);
            for (int i = 0; i < week; i++)
                Console.Write("\t");

            //3.根据当月总天数，显示日
            int days = GetDaysByMonth(year, month);
            for (int i = 1; i <= days; i++)
            {
                Console.Write(i + "\t");
                //4.每逢周六换行
                if (GetWeekByDay(year, month, i) == 6)
                    Console.WriteLine();
            }
        }

        //3.
        private static int GetWeekByDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }

        //4.
        private static int GetDaysByMonth(int year, int month)
        {
            if (month < 1 || month > 12) return 0; // return 减少方法的层级嵌套 
            {
                switch (month)
                {
                    case 2:
                        //if (IsLeapYear(year))
                        //    return 29;
                        //else
                        //    return 28;
                        return IsLeapYear(year) ? 29 : 28; // 三元表达式
                    case 4:
                    case 6:
                    case 9:
                    case 11: 
                        return 30;
                    default:
                        return 31;
                }
            }
        }

        //5.
        private static bool IsLeapYear(int year)
        {
            //if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            //    return true;
            //else
            //    return false;
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        private static void Main()
        {
            Console.WriteLine("亲，输个年呗:");
            int year = int.Parse(Console.ReadLine());

            PrintYearCalendar(year);
            Console.ReadLine();
        }

        //每日一练
        //Console.WriteLine("请输入所要计算的时间，单位为秒");

        //int seconds = int.Parse(Console.ReadLine());  //输入相应数值，转换为int类型

        //int day = seconds / (24 * 3600);          //求得天数
        //int hour = seconds % (24 * 3600) / 3600;        //求得小时
        //int minute = seconds % (24 * 3600) % 3600 / 60;   //求得分钟
        //int sec = seconds % 60;              //求得秒
        //Console.WriteLine($"{seconds}秒为{day}天{hour}时{minute}分{sec}秒");
    }
}
