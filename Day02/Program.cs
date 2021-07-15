using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        // 占位符
        static void Main1(string[] args)
        {
            string gunName = "AK47";
            string ammoCapacity = "30";
            // 在字符串中插入变量
            Console.WriteLine("枪的名称为:" + gunName + ",容量为:" + ammoCapacity + "。");
            // 占位符{位置的编号}如果编号大于参数列表长度，则异常
            string str =
                string.Format("枪的名称为:{0},容量为:{1}", gunName, ammoCapacity);
            Console.WriteLine(str);

            // 标准数字格式字符串
            Console.WriteLine("金额:{0:c}", 10); // 以货币的形式显示 — 货币￥10.00
            Console.WriteLine("{0:d2}", 5); // 05 不足两位用0填充
            Console.WriteLine("{0:f1}", 1.26); // 1.3 根据指定精度显示
            Console.WriteLine("{0:p0}", 0.1); // 10% 以百分数显示

            // 转义符 改变字符原始含义 \"  \'  \0
            Console.WriteLine("我爱\"Unity!\"");
            char c1 = '\'';
            char c2 = '\0'; // 空字符

            // \r\n 回车换行 \t 水平制表格
            Console.WriteLine("Hellom,\r\nMy name is \tDoller");

            // .NET程序编译过程
            // 源代码(.cs的文本文件)---CLS编译---通用中间语言(exe dll)---CLR编译---机器码 0 1
            //                      目的:跨语言                     目的:优化 跨平台
        }

        // 运算符
        static void Main2()
        {
            //1.赋值运算符：将右边的值复制给左边
            int a = 1;
            int num01, num02; // 同时声明多个同类型的变量
            num01 = num02 = 1;// 赋值表达式自身也有值，其本身值为所赋值。

            //2.算术运算符：对数字做算术运算 加+ 减- 乘* 除/ 取模%
            int n1 = 15, n2 = 2;
            int r1 = n1 / n2;  // 5 / 2 ==> 2.5 整数不存小数 截断删除留整数 2
            int r2 = n1 % n2;  // 取模(余数)
            // % 取模的作用：
            // (1)判断一个数字能否被另外一个数字整除
            // n1 是否能被2 整除 true 是偶数 false 是奇数
            bool r3 = n1 % 2 == 0;
            // (2)获取整数的个位
            int r4 = n1 % 10;

            string s1 = "宇", s2 = "宙";
            string r5 = s1 + s2;  // 字符串的拼接

            //3.比较运算符 > < >= <= 等于== 不等于!=
            bool r6 = n1 == n2;
            bool r7 = s1 == s2; // 文本是否相同

            //4.逻辑运算符 与&& 或|| 非！
            bool r8 = true && true; // 真 与 真 结果：真
            r8 = false && true; // 假 与 真 结果：假
            r8 = true && false; // 真 与 假 结果：假
            r8 = false && false; // 假 与 假 结果：假
            // 总结：一假俱假 表达 并且 的关系

            bool r9 = true || true; // 真 或 真 结果：真
            r9 = false || true; // 假 或 真 结果 真
            r9 = true || false; // 真 或 假 结果：真
            r9 = false || false; // 假 或 假 结果：假
            // 总结：一真俱真 表达 或者 的关系

            bool r10 = !true; // 取反

            //5.快捷运算符 += *= /= %=
            int num03 = 1;
            num03 = num03 + 5;// 一个变量num01加上另外一个数，再赋值给自身
            num03 += 5;
            Console.WriteLine(num03);

            //6.一元运算符 ++ -- 二元 三元
            //根据操作数划分

            //(1)无论先加还是后加 对于[下一条指令]，都是自增以后的值
            int number01 = 1;
            number01++;
            Console.WriteLine(number01);//2 [下一条指令]

            int number02 = 1;
            ++number02;
            Console.WriteLine(number02);//2 [下一条指令]

            //(2)后加 -> 后自增 -> 先返回值
            int number03 = 1;
            Console.WriteLine(number03++);//1 结果：自增以前

            //(3)先加 -> 先自增 -> 后返回值
            int number04 = 1;
            Console.WriteLine(++number04);//2 结果：自增以后

            //7.三元 数据类型 变量名 = 条件 ？ 满足条件结果:不满足条件结果；
            string str01 = 1 > 2 ? "ok" : "no"; // 三元表达式后面的结果必须兼容
            float r11 = 1 == 1 ? 1.2f : 1.5f;

            //8.优先级 先乘除 后加减 小括号优先级最高
            int r12 = (1 + 2) * 4;
        }

        // 数据类型转换
        static void Main3()
        {
            //数据类型转换
            //sting "18" ==> int 18         

            //1.Parse转换: string转换为其他数据类型
            //待转数据 必须 "像"该数据类型
            string strNumber = "18.0";
            int num01 = int.Parse(strNumber);//18 
            float num02 = float.Parse(strNumber);//18.0

            //2.ToString转换：任意类型转换为string类型
            int number = 18;
            //待转类型 待转变量名 = 变量名.ToString();
            string str = number.ToString();
            //Parse、ToString是数值和字符之间的转换

            //3.隐式转换 : 由小范围 到 大范围的[自动转换]
            byte b3 = 100;
            int i3 = b3;

            //4.显式转换 : 由大范围 到 小范围的[强制转换]
            //备注：有可能发生精度的丢失
            int i4 = 300;
            byte b4 = (byte)i4;//44 括号内存放需要转的类型
            //隐式、显式 通常发生在数值之间

            //由多种变量参与运算，结果自动向较大的类型提升

            float number01 = 1;
            double number02 = 2;
            //short result = (short)(number01 + number02);
            //int result = number01 + number02;
            double result = number01 + number02;

            int a = 1;
            a = a + 3;
            a += 3;

            byte b = 1;
            b += 6;//快捷运算符，不做自动类型提升
            b = (byte)(b + 3);//异常，自动类型提升
            Console.WriteLine(b);
        }

        // 练习
        static void Main4()
        {
            //练习：让用户在控制台中输入一个4位整数
            //计算每位相加和
            //例如：1234 ==> 1+2+3+4 ==> 10

            #region 方案1：从整数中获取每位
            //获取数据
            Console.WriteLine("请输入4位整数:");
            string strNumber = Console.ReadLine(); //"1234"

            //逻辑处理
            // "1234" --> 1234 将string类型转换为int类型
            int number = int.Parse(strNumber);
            //个位
            int result = number % 10;
            //十位
            result += number / 10 % 10;
            //百位
            result += number / 100 % 10;
            //千位
            result += number / 1000;

            //显示结果
            Console.WriteLine("结果为:" + result);
            #endregion

            #region 方案2：从字符串中获取每个字符
            //string str02 = "1234";
            //char c1 = str02[0]; // '1' ==> "1" ==> 1
            char c1 = strNumber[0];//'1'
            string s1 = c1.ToString();//"1"
            int n1 = int.Parse(s1);//1
            //千位
            int result02 = n1;
            //百位
            result02 += int.Parse(strNumber[1].ToString());
            //十位
            result02 += int.Parse(strNumber[2].ToString());
            //个位
            result02 += int.Parse(strNumber[3].ToString());

            Console.WriteLine("结果为:"+result02);
            Console.ReadLine();
            #endregion
        }

        // 选择语句：if语句
        static void Main5()
        {
            //语句: 选择语句 循环语句 跳转语句

            Console.WriteLine("请输入性别:");
            string sex = Console.ReadLine();

            if(sex == "男") // 如果
            {
                Console.WriteLine("您好，先生！");
            }
            else if (sex == "女") // 否则 如果
            {
                Console.WriteLine("您好，女士！");
            }
            else//否则
            {
                Console.WriteLine("性别未知!");
            }
            //C#规定 else属于上方邻近if，if可以单独出现，但else不行。
        }

        // 练习：运算符计算
        static void Main6()
        {
            //练习：让用户在控制台中录入2个数，1个运算符
            //根据运算符 计算 2个数字
            //"请输入第一个数字:"
            //"请输入第二个数字:"
            //"请输入运算符:"
            //"运算符输入有误!"

            //获取数据
            Console.WriteLine("请输入第一个数字:");
            string strNumberOne = Console.ReadLine();
            int numberOne = int.Parse(strNumberOne);

            Console.WriteLine("请输入第二个数字:");
            int numberTwo = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入运算法:");
            string op = Console.ReadLine();

            //逻辑处理 多路分支的判断
            float result;
            //选择语句：if语句
            //if(op == "+") result = numberOne + numberTwo; // 大括号内只有一句话时可以不写大括号
            //else if (op == "-")result = numberOne - numberTwo;
            //else if (op == "*")result = numberOne * numberTwo;
            //else if (op == "/")result = numberOne / numberTwo;
            //else result = 0;

            //选择语句：switch语句
            switch (op)
            {
                case "+":
                    result = numberOne + numberTwo;
                    break;// 退出switch语句
                case "-":
                    result = numberOne - numberTwo;
                    break;
                case "*":
                    result = numberOne * numberTwo;
                    break;
                case "/":
                    result = numberOne / numberTwo;
                    break;
                default:
                    result = 0;
                    break;
            }
            
            //显示结果
            if(op == "+" || op == "-" || op == "*" || op == "/")
                Console.WriteLine("结果为 :"+result);
            else
                Console.WriteLine("运算符输入有误");   
        }

        // 练习：获取成绩等级 
        static void Main7()
        {
            //练习：
            //让用户在控制台中录入一个成绩
            //根据成绩计算等级
            //"优秀" "良好" "及格" "不及格" "成绩有误"

            //获取成绩数据
            Console.WriteLine("请输入一个成绩:");
            int score = int.Parse(Console.ReadLine());

            string message;// 显示消息
            
            if (score < 0 || score > 100)
                message = "成绩有误";
            else if (score >= 90)
                message = "优秀";
            else if (score >= 80)
                message = "良好";
            else if (score >= 60)
                message = "及格";
            else
                message = "不及格";
            Console.WriteLine(message);
        }
        
        // 练习：根据月份判断天数
        static void Main8()
        {
            //练习:让用户在控制台中录入一个月份
            //根据月份判断天数
            //1 3 5 7 8 10 12 返回31天
            //4 6 9 11 返回30天
            //2 返回28天
            Console.WriteLine("请输入月份:");
            int month = int.Parse(Console.ReadLine());

            int day;
            if(month>=1 && month <= 12)
            {
                switch (month)
                {
                    case 2:
                        day = 28;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        day = 30;
                        break;
                    default:
                        day = 31;
                        break;
                }
            }
            else
            {
                day = 0;

            }
            Console.WriteLine("{0}月具有{1}天。",month,day);
            Console.ReadLine();
        }

        #region 每日一练 计算个人所得税
        static void Main9()
        {
            Console.WriteLine("请输入您的税前薪资总额:");
            double quickDeduction = 0,payableIncome = 0; //n 速算扣除数 m 应纳税所得额
            double totalSalaryBeforeTax = Convert.ToDouble(Console.ReadLine());//a 税前薪资总额

            payableIncome = totalSalaryBeforeTax - 3500;//应纳税所得额
            if (payableIncome > -3500 && payableIncome <= 0)
            {
                payableIncome = totalSalaryBeforeTax;
            }
            else if (payableIncome > 0 && payableIncome <= 1500)
            {
                quickDeduction = payableIncome * 0.03;
            }
            else if (payableIncome > 1500 && payableIncome <= 4500)
            {
                quickDeduction = payableIncome * 0.1 - 105;
            }
            else if (payableIncome > 4500 && payableIncome <= 9000)
            {
                quickDeduction = payableIncome * 0.2 - 555;
            }
            else if (payableIncome > 9000 && payableIncome <= 35000)
            {
                quickDeduction = payableIncome * 0.25 - 1005;
            }
            else if (payableIncome > 35000 && payableIncome <= 55000)
            {
                quickDeduction = payableIncome * 0.3 - 2755;
            }
            else if (payableIncome > 55000 && payableIncome <= 80000)
            {
                quickDeduction = payableIncome * 0.35 - 5505;
            }
            else if (payableIncome > 80000)
            {
                quickDeduction = payableIncome * 0.45 - 13505;
            }
            else
            {
                Console.WriteLine("输入错误!");
            }
            {
                Console.WriteLine("实发工资为:{0},个税:{1}", totalSalaryBeforeTax - quickDeduction, quickDeduction);
            }
        }
        #endregion
    }
}
