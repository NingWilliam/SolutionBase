using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 字面意思：using xx; 正在使用 xx 的命名空间;
// 引入命名空间

// 定义命名空间[类的住址]：对类进行逻辑上的划分，避免重名
namespace Day01
{
    // 定义类[做工具]
    class Program
    {
        // 定义方法[做功能]
        // 程序的主入口方法
        static void Main1()
        {
            //Ctrl + A 全选
            //Ctrl + K + F 对齐
            //Ctrl + K + C 注释选中行
            //Ctrl + K + U 取消注释行
            /**********程序从本行开始运行**********/
            /**************[语句]*************/
            //自上而下 逐语句执行
            //代码：编程即是对计算机下达的指令
            //字面意思：控制台.写一行("内容");
            //现象：在控制台中显示括号内的文本
            //作用：将括号内的文本 写到 控制台中
            Console.WriteLine("请输入您的姓名:");

            //字面意思：控制台.读一行("内容");
            //现象：暂停程序(按回车键继续)
            //作用：将用户在控制台中输入的文本(姓名) 读取到 程序中来(name)
            string name = Console.ReadLine();

            //字面意思：控制台.标题 = "内容";
            Console.Title = "我的第一个程序";

            Console.WriteLine("您好:" + name);

            Console.ReadLine();//让程序在本行暂停

            // = 赋值号：先看右边，将右边的结果 赋值一份 给左边

            //写代码 .cs --> 生成 .exe --> 运行

            //Console 是类[工具]
            //WriteLine/ReadLine 是方法[动词的功能] 方法一定要小括号
            //Title 是属性[名词的修饰] 属性不要写小括号
            //类.方法(); 调用语句[使用某个类中的功能]
            /**********程序从本行停止运行**********/

            //十进制 人
            //二进制 从末尾开始数，逢二进一 电脑

            //声明：在内存中开辟空间
            string gunName;
            //赋值：在该空间存储数据
            gunName = "AK47";
            //声明 + 赋值：在内存中开辟空间并存储数据。
            int age = 18;
            //在同一范围内，变量不能重复声明
            //string gunName;
            //变量可以重复赋值
            gunName = "M416";
            //变量在使用前必须赋值
            Console.WriteLine(age);
        }

        static void Main2()
        {
            // 调试：排除错误的能力
            // 1.在可能出错的行加断点
            // 2.按F5 启动调试
            // 3.按F11 逐语句执行
            // 4.按Shift + F5停止调试
            // 5.按Ctrl + F5开始执行(不调试)

            // 精度的缺失
            float num01 = 3.0f;
            float num02 = 2.9f;
            float result = num01 - num02;
            bool b1 = result == 0.1f;
            Console.WriteLine(b1); // false

            //decimal num01 = 3.0m;
            //decimal num02 = 2.9m;
            //decimal result = num01 - num02;
            //bool b1 = result == 0.1m;
            //Console.WriteLine(b1); // true

            //练习：
            //在控制台中，录入枪的信息
            //"请输入枪的名称:"
            //"请输入弹夹容量:"
            //"请输入当前弹夹内子弹数量:"
            //"请输入剩余子弹数量:"
            //在一行显示:
            //枪的名称是:xxx,弹夹容量:xxx,弹夹子弹数:xx,剩余子弹数:xx.

            //Console.WriteLine("请输入枪的名称:");
            //string gunName = Console.ReadLine();
            //Console.WriteLine("请输入弹夹容量:");
            //string ammoCapacity = Console.ReadLine();
            //Console.WriteLine("请输入当前弹夹内子弹数量:");
            //string currentAmmoBullets = Console.ReadLine();
            //Console.WriteLine("请输入剩余子弹数量:");
            //string remainBullets = Console.ReadLine();

            //Console.WriteLine("枪的名称:" + gunName + ",弹夹容量:" + ammoCapacity + ",当前弹夹子弹数量:" + currentAmmoBullets + ",剩余子弹数量:" + remainBullets);
            //Console.ReadLine();
        }

        static void Main3()
        {

            // 整型 int
            int n1 = 1;
            // 非整型 float（赋值要加后缀）
            float n2 = 1.0f;
            // 非数值型
            // char 字符 (存储单个字符)
            char c1 = '1';
            // string 字符串（字符串/多个字符）
            string s1 = "123";
            // bool 布尔型（真或假）
            bool b1 = true;
            bool b2 = false;
        }
       
    }
}
