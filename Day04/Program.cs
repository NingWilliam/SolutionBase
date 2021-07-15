
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        #region 方法重载
        static void Main1(string[] args)
        {
            int second = GetTotalSecondByMinuteHourDay(2,1,1);

            //方法重载
            //定义：方法名称相同，参数列表不同
            //作用：在不同条件下，解决同一类问题，让调用者仅仅记忆1个方法

            //弊端：调用者需要解决同一个问题，记忆大量方法
            //需要显示不同的数据，调用方法
            Console.WriteLine();
            Console.WriteLine(100);
            Console.WriteLine(true);
            Console.WriteLine(1.5);
        }

        //每日一练
        //1.根据分钟数 计算 总秒数
        //2.根据分钟数 小时数 计算 总秒数
        //3.根据分钟数 小时数 天数 计算 总秒数

        private static int GetTotalSecondByMinute(int minute)
        { // 分钟-->秒
            return minute * 60;
        }
        private static int GetTotalSecondByMinuteHour(int minute, int hour)
        { // 小时-->分钟
            return GetTotalSecondByMinute(minute + hour * 60);
            
        }
        private static int GetTotalSecondByMinuteHourDay(int minute, int hour,int day)
        { // 天-->小时
            return GetTotalSecondByMinuteHour(minute, hour + day * 24);
        }

        /********************************/
        private static int GetTotalSecond(int minute)
        { // 分钟-->秒
            return minute * 60;
        }
        private static int GetTotalSecond(int minute, int hour) 
        { // 小时-->分钟
            return GetTotalSecond(minute + hour * 60);

        }
        private static int GetTotalSecond(int minute, int hour, int day)
        { // 天-->小时
            return GetTotalSecond(minute, hour + day * 24);
        }
        #endregion

        #region 递归
        static void Main2()
        {
            // 递归 数组
            // 递：反复调用，将需要的内容"递"給最后一级
            // 归：逐层返回，将结果"归"还给最高一级   
            int result = GetFactorial(3);//第一次调用时
        }

        //计算阶乘 (请使用递归算法实现) 5! ==> 5 * 4 * 3 * 2 * 1
        private static int GetFactorial(int num)//3
        {
            /*
             3 * 3 - 1 
             2 * 2 - 1 // 第二次内部调用
             1 return 1 // 第三次调用
             */
            if (num == 1) return 1;
            //方法内部又调用自身的过程
            //核心思想：将问题转移给范围缩小的子问题
            //适用性：在解决问题过程中，又遇到相同问题
            //优势: 将特别复杂的问题简单化
            //缺点: 性能较差
            //注意：防止堆栈溢出
            return num * GetFactorial(num - 1);
        }

        /*
         * 编写一个函数，计算当参数为8时的结果为多少？
         * (请使用递归实现)
         * 1 - 2 + 3 - 4 + 5 - 6 + 7
         */
         private static int GetValue(int num)
        {
            if (num == 1) return 1;

            if (num % 2 == 0)
                return GetValue(num - 1) - num;
            else
                return GetValue(num - 1) + num;
        }
        #endregion
        
        #region 数组
        static void Main3()
        {
            //数组：一组数据类型相同的变量组合。
            //声明
            //第一种
            int[] array; //null
            //初始化 new 数据类型[容量]
            array = new int[6];
            //通过索引读写每个元素
            array[0] = 1;// 将数据1赋值给数组的第1个元素
            array[1] = 2;// 将数据2赋值给数组的第2个元素
            array[3] = 3;// 将数据3赋值给数组的第4个元素
            //数组遍历
            for (int i = 0; i < array.Length; i++)
            {
                //0 1 2 3 4 5
                Console.WriteLine(array[i]);
                
            }
        }

        static void Main4()
        {

            float[] scoreArray = CreateScoreArray();

            //float[] array = new float[3];
            //array[0] = 8;
            //array[1] = 5;
            //array[2] = 9;

            float max = GetMax(scoreArray);

            Console.WriteLine("最高分为:" + max);
            Console.ReadLine();
        }

        private static float[] CreateScoreArray()
        {

            Console.WriteLine("请输入学生总数:");
            int count = int.Parse(Console.ReadLine());

            float[] scoreArray = new float[count];
            for (int i = 0; i < scoreArray.Length;)
            {
                Console.WriteLine("请输入第{0}个学生成绩", i + 1);

                float score = float.Parse(Console.ReadLine());
                if (score >= 0 && score <= 100)
                    scoreArray[i++] = score;
                else
                    Console.WriteLine("成绩有误");
            }
            return scoreArray;
        }

        //定义查找数组元素最大值的方法float[]
        private static float GetMax(float[] array)
        {
            //假设第一个元素为最大值
            float max = array[0];
            //依次与后面元素进行比较
            for(int i = 1; i < array.Length; i++)
            {
                //如果发现更大的元素
                if(max<array[i])
                   max=array[i]; //重新赋值替换最大值
            }
            return max;
        }

        static void Main5()
        {
            //数组其他写法

            //初始化 + 赋值
            //第二种写法
            string[] array01 = new string[] { "a", "b" };

            //声明 + 初始化 + 赋值
            //第三种写法
            bool[] array02 = { true, false, false };

            
            //float[] temp = new float[3] { 5, 3, 7 };

            float max = GetMax(new float[] { 5, 3, 7 });
            //float max = GetMax({1,3,7});

            //调用方法
            int days = GetTotalDays(2021,5,17);
        }
        #endregion

        #region 练习
        //练习
        //定义方法：根据年月日，计算当天是本年的第几天
        //累加1、2 整月天数 31 + 29
        //再累加 当月 天数 
        //提示：将每月天数存储到数组中
        private static int GetTotalDays(int year,int month,int day)
        {
            int[] daysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            //判断:如果是闰年，2月为29天
            if (IsLeapYear(year)) daysOfMonth[1] = 29;
            int days = 0;

            for(int i = 0; i < month - 1; i++)
            {
                days += daysOfMonth[i];
            }
            days += day;
            return days;
        }
        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        #endregion

        #region 数组相关知识
        static void Main6()
        {
            int[] array = new int[] { 1, 48, 5, 9, 6, 7, 5, 8, 9, 36, 2 };
            //需求：将数组每个元素显示在控制台中
            //正序 索引 0 1 2 3 4 5 ......
            for (int i = 0; i < array.Length; i++)
            {
                //Console.WriteLine(array[i]);
            }

            //倒序 索引 ...... 0 1 2 3 4 5
            for (int i = array.Length - 1; i >= 0; i--)
            {
                //Console.WriteLine(array[i]);
            }

            //语法
            //foreach(元素类型 变量名 in 数组名称)
            //{
            //    变量名 即 数组中每个元素
            //}

            //只能读取全部元素(语句本身)
            //不能修改元素
            //从头到尾 依次 读取 数组元素
            //优点：使用简单
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            //新知识01
            //推断类型：根据所赋数据 推断出类型
            //适用性：数据类型名称较长
            var v1 = 1; // int
            var v2 = "1"; // string
            var v3 = '1'; // char
            var v4 = true; // bool
            var v5 = 1.0; // double

            //新知识02
            //声明 父类类型 赋值 子类对象
            Array arr01 = new int[2];
            Array arr02 = new double[2];
            Array arr03 = new string[1];

            PrintElement(new int[] { 12, 34, 5, 6 });
            PrintElement(new float[] { 12, 34, 5, 6 });

            //新知识03
            //object 万类之祖
            //声明 Object类型 赋值 任意类型
            object o1 = 1;
            object o2 = true;
            object o3 = new int[3];
        }

        private static void Fun1(object obj)
        {
            //任意类型
        }

        //定义方法：将数组所有元素显示到控制台中
        private static void PrintElement(Array arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region 数组常用方法及属性
        private static void Main7()
        {
            //查找数组元素 1.Array.IndexOf 2.Array.LastIndexOf

            //1.Array.IndexOf(arr, obj); // 查找的是arr数组中第一个出现obj元素的索引 
            //int[] arr = new int[] { 1, 4, 6548, 8, 3, 4, 3 };
            //int index = Array.IndexOf(arr, 4);
            //2.Array.LastIndexOf(arr, obj); // 查找的是arr数组中最后一个出现obj元素的索引 
            int[] arr = new int[] { 1, 4, 6548, 8, 3, 4, 3 };
            //int index = Array.LastIndexOf(arr, 4);
            //查找不存在的元素，返回值会是-1


            //判断数组中是否存在指定元素
            //bool result = Array.IndexOf(arr, 2) >= 0;

            //复制：Array.Copy
            int[] arr2 = new int[10];
            Array.Copy(arr,arr2,2);

            //克隆：数组名.Clone
            int[] obj = (int[])arr.Clone();

            //排序：Array.Sort
            Array.Sort(arr);

            //反转：Array.Reverse
            Array.Reverse(arr);

            Console.WriteLine(obj[0]);
            //Console.ReadLine();
        }
        #endregion

        //备注：本行语句放到方法外，类内
        static Random random = new Random();
    }
}
