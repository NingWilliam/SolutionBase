using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void Main1(string[] args)
        {
            //方法重载 递归 数组
            //1.5f 1.9f 2.0f
            float[] array = new float[3] { 1.5f, 1.9f, 2.0f };
            array[2] = 3.0f;

            foreach (float element in array)
            {
                Console.WriteLine(element);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        /*每天一练
         彩票生成器
         红球：1-33    6个  不能重复
         蓝球：1-16    1个
         *
         (1)在控制台中购买彩票的方法int[7]
         * "请输入第1个红球号码"
         * "号码不能超过1-33" "当前号码已经存在"
         * 
         (2)随机产生一注彩票的方法int[7]
         * random.Next(1,34)
         * 要求：红球号码不能重复，且按照从小到大排序
         * 
         (3)两注彩票比较的方法，返回中奖等级
         * 先计算红球、蓝球中奖数量上
         * 
         * 在Mian中测试
         */

        private static int[] BuyTicket()
        {
            //创建数组，存储一注彩票七个数的数组
            int[] ticket = new int[7];

            //前6个红球 循环六遍 下标：0 1 2 3 4 5
            for (int i = 0; i < 6;)
            {
                Console.WriteLine("请输入第{0}个红球号码:",i+1);
                int redNumber = int.Parse(Console.ReadLine());
                if (redNumber < 1 || redNumber > 33)
                    Console.WriteLine("购买的号码超过范围");
                //大于等于0就是说在这个数组内有索引，存在则提示
                else if (Array.IndexOf(ticket, redNumber) >= 0)
                    Console.WriteLine("号码已经存在");
                else
                    ticket[i++] = redNumber;
            }

            //第7个蓝球
            while (true)
            {
                Console.WriteLine("请输入蓝球号码:");
                int blueNumber = int.Parse(Console.ReadLine());
                if (blueNumber >= 1 && blueNumber <= 16)
                {
                    ticket[6] = blueNumber;
                    break;
                }
                else
                {
                    Console.WriteLine("号码超过范围");
                }
            }
            return ticket;
        }

        static Random random = new Random();

        //机选
        //创建数组-先放前六个(for) 产生数 小于零说明不存在 
        private static int[] CreateRandomTicket()
        {
            int[] ticket = new int[7];
            for (int i = 0; i < 6;)
            {
                int redNumber = random.Next(1, 34);
                //redNumber在数组中不存在
                if (Array.IndexOf(ticket, redNumber) < 0)
                    ticket[i++] = redNumber;
            }
            ticket[6] = random.Next(1, 17);
            //红球号码排序
            Array.Sort(ticket, 0, 6);
            return ticket;
        }

        //两注彩票比较
        private static int TicketEquals(int[] myTicket, int[] randomTicket)
        {
            //计算红球、蓝球中奖数量
            int blueCount = myTicket[6] == randomTicket[6] ? 1 : 0;
            int redCount = 0;
            //我的第i个红球号码，在随机彩票中的红球号码中是否存在
            //myTicket[0]   randomTicket
            for (int i = 0; i < 6;i++)
                if (Array.IndexOf(randomTicket,myTicket[i], 0, 6) >= 0)
                    redCount++;

            int level;
            if (blueCount + redCount == 7)
                level = 1;
            else if (redCount == 6)
                level = 2;
            else if (redCount + blueCount == 6)
                level = 3;
            else if (redCount + blueCount == 5)
                level = 4;
            else if (redCount + blueCount == 4)
                level = 5;
            else if (blueCount == 1)
                level = 6;
            else
                level = 0;
            return level;

        }

        private static void Main2()
        {
            int[] myTicket = BuyTicket();
            int level;
            int count = 0;
            do
            {
                count++;

                int[] randomTicket = CreateRandomTicket();

                level = TicketEquals(myTicket, randomTicket);
                if (level != 0)
                    Console.WriteLine("恭喜,{0}等奖。累加消费:{1:c}元", level,count*2);
            } while (level != 1);
        }

        //for for
        private static void Main3()
        {
            //for for 二维数组 交错数组
            //外层循环控制行
            //for (int r = 0; r < 3; r++)//       0         1          2
            //{//内层循环控制列
            //    for (int c = 0; c < 4; c++)//0 1 2 3   0 1 2 3     0 1 2 3
            //    {
            //        Console.Write("数组\t");
            //    }
            //    Console.WriteLine();//换行
            //}

            //for (int r = 0; r < 4; r++)
            //{
            //    for (int c = 0; c <= r; c++)
            //    {
            //        Console.Write("#");
            //    }
            //    Console.WriteLine();
            //}

            for (int r = 0; r < 4; r++)
            {
                //1.for (int c = 0; c < 4 - r; c++)
                for (int c = 3; c >= r; c--)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        
         /* 自定义排序算法
         * 2 8 6 1
         * 将第一个元素设置为最小值
         * 使用第一个位置元素 依次与后面元素 进行比较
         * 1 8 6 2
         * 将第二个元素设置为最小值
         * 使用第二个位置元素 依次与后面元素 进行比较
         * 1 2 8 6
         * 将第三个元素设置为最小值
         * 使用第三个位置元素 依次与后面元素 进行比较
         * 1 2 6 8
         * 总结:4个数 比较3轮 第一轮比较3次，第二轮比较2次，第三轮比较1次
         */

        private static void Main4()
        {
            //arr 存数组的引用
            int[] arr = { 2, 8, 6, 1 };
            arr = OrderBy2(arr);

            bool result = IsRepeating(arr);
        }

        //冒泡排序
        //存在问题: 每轮交换次数可能更多
        private static int[] OrderBy1(int[] array)
        {

            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {
                for (int i = currentIndex + 1; i < array.Length; i++)//从第二个数，即下标为1的元素开始比较
                {
                    if (array[currentIndex] > array[i])
                    {
                        //array[currentIndex] array[i];
                        int temp = array[currentIndex];
                        array[currentIndex] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
            
        }

        //选择排序: 每轮比较仅仅交换一次
        private static int[] OrderBy2(int[] array) {
            //需要与后面比较的元素索引
            for (int currentIndex = 0; currentIndex < array.Length - 1; currentIndex++)
            {//外层循环       1            2             3
                int minIndex = currentIndex;
                //后面元素的索引
                for (int i = currentIndex + 1; i < array.Length; i++)//作比较
                {//内层循环 1 2 3         2 3            3
                    //记录需要交换的索引   i
                    if (array[minIndex] > array[i]) minIndex = i;

                }
                if (minIndex != currentIndex)
                {
                    int temp = array[currentIndex];
                    array[currentIndex] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
            return array;
        }

        //定义检查数组中是否存在相同元素的方法int[]
        private static bool IsRepeating(int[] array)
        {
            //取出元素
            for (int i = 0; i < array.Length - 1;i++)
            {
                //依次与后面的元素比较
                for (int j = i + 1 ; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        return true;
                }
            }
            return false;
        }

        //二维数组
        static void Main5()
        {
            //数组分类: 一维数组  (多)二维数组  交错数组
            //下标                [行,列]
            //                    [横,竖]

            //创建5行3列的二维数组
            int[,] array = new int[5, 3];
            //array.Length --> 15

            //将数据6赋值给数组的第1行第三列
            array[0, 2] = 6;
            array[1, 0] = 13;
            array[3, 1] = 5;

            // 获取数组中所有元素
            //foreach (int item in array)
            //{
            //    Console.WriteLine(item);
            //}

            //for for
            //将第一行显示到控制台中 0,0   0,1   0,2
            //array.GetLength(0) 行数  5
            //array.GetLength(1) 列数  3
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    Console.Write(array[r, c]+"\t");
                }
                Console.WriteLine();
            }

            float[,] scoreArray = CreateScoreArray();
            PrintDoubleArray(scoreArray);
        }

        /*1.在控制台中录入学生成绩的方法
         * "请输入学生总数:"
         * "请输入科目数:"
         * "请输入第1个学生的第1门成绩:"
         * "请输入第1个学生的第2门成绩:"
         * "请输入第2个学生的第1门成绩:"
         * "请输入第2个学生的第2门成绩:"
         * 
         *       科目1         科目2
         * 学生1
         * 学生2
         * 学生3
         * 
         * 2.在控制台中，以表格显示二维数组元素
         */

        private static float[,] CreateScoreArray()
        {
            Console.WriteLine("请输入学生总数: ");
            int studentCount = int.Parse(Console.ReadLine());

            Console.WriteLine("请输入科目数: ");
            int subjectCount = int.Parse(Console.ReadLine());

            float[,] scoreArray = new float[studentCount, subjectCount];

            //学生
            for (int r = 0; r < scoreArray.GetLength(0); r++)
            {
                //科目
                for (int c = 0; c < scoreArray.GetLength(1); c++)
                {
                    Console.WriteLine("请输入第{0}个学生的第{1}门成绩: ",r + 1,c + 1);
                    scoreArray[r, c] = float.Parse(Console.ReadLine());
                }
            }
            return scoreArray;
        }

        private static void PrintDoubleArray(Array array)
        {
            for (int r = 0; r < array.GetLength(0); r++)
            {
                for (int c = 0; c < array.GetLength(1); c++)
                {
                    Console.Write(array.GetValue(r,c) + "\t");
                }
                Console.WriteLine();
            }
        }

        /********************************* 2048核心算法 *********************************/
        /* 需求分析
         * 
         * 上移
         * -- 从上而下 获取列数据，形成一维数组
         * 2 2 0 0 --> 4 0 0 0
         * 2 2 2 0 --> 4 0 2 0 --> 4 2 0 0
         * 2 0 2 0 --> 2 2 0 0 --> 4 0 0 0
         * 2 0 2 4 --> 2 2 4 0 --> 4 0 4 0 --> 4 4 0 0
         * -- 合并数据
         *   --去零: 将0元素移到末尾
         *   --相邻相同,则合并(将后一个元素累加到前一个元素上，后一个元素清零)
         *   --去零: 将0元素移到末尾
         * -- 将一维数组元素 还原至原列
         * 
         * 下移1.0
         * -- 从上而下 获取列数据，形成一维数组
         * -- 合并数据
         *   --去零: 将0元素移到开头
         *   --相邻相同,则合并(将前一个元素累加到前一个元素上，前一个元素清零)
         *   --去零: 将0元素移到末尾
         * -- 将一维数组元素 还原至原列
         * 
         * 下移2.0
         * -- 从上而下 获取列数据，形成一维数组
         * -- 合并数据
         *   --去零: 将0元素移到开头
         *   --相邻相同,则合并(将前一个元素累加到前一个元素上，前一个元素清零)
         *   --去零: 将0元素移到末尾
         * -- 将一维数组元素 还原至原列
         * 
         * 左移
         * 
         * 右移
         * 
         * 编码
         * 1.定义去零方法(针对一维数组): 将0元素移至末尾
         * 2.合并数据方法
         *   --去零: 将0元素移到末尾
         *   --相邻相同,则合并(将后一个元素累加到前一个元素上，后一个元素清零)
         *   --去零: 将0元素移到末尾
         * 3.上移
         *   -- 从上而下 获取列数据，形成一维数组
         *   -- 调用合并数据方法
         *   -- 将一维数组元素 还原至原列
         * 4.下移
         *   -- 从下而上 获取列数据，形成一维数组
         *   -- 调用合并数据方法
         *   -- 将一维数组元素 还原至原列
         * 5.左移
         * 6.右移
         */
        static void Main()
        {
            int[,] map = new int[4, 4]
            {
                {2,2,4,8},
                {2,4,4,4},
                {0,8,4,0},
                {2,4,0,4},
            };

            PrintDoubleArray(map);
            Console.WriteLine("上移");
            //map = MoveUp(map);
            //MoveDown(map);
            //MoveUp(map);
            Move(map, MoveDirection.Up);
            PrintDoubleArray(map);

            Console.WriteLine("下移");
            //map = MoveDown(map);
            //MoveDown(map);
            //MoveUp(map);
            Move(map, MoveDirection.Down);
            PrintDoubleArray(map);
        }

        private static void RemoveZero(int[] array)
        {
            //2 0 0 2
            //0 0 0 0
            int[] newArray = new int[array.Length];

            int index = 0;
            //将非零元素 依次 赋值给新数组
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                    newArray[index++] = array[i];
            }
            //return newArray;
            //array = newArray;替换引用，方法外不会收到影响
            //array[0] = newArray[0];通过引用修改堆中数组对象
            newArray.CopyTo(array, 0);
        }

        private static void Merge(int[] array)
        {
            //array = RemoveZero(array);
            RemoveZero(array);

            //合并数据
            for (int i = 0; i < array.Length - 1; i++)
            {
                //相邻相同
                if (array[i]!=0 && array[i] == array[i + 1])
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0;
                    //统计合并位置
                }
            }
            //array = RemoveZero(array);
            RemoveZero(array);
            //return array;
        }

        private static void MoveUp(int[,] map)
        {
            // 从上而下 获取每列数据，形成一维数组
            /*
             * 0,0  0,1  0,2  0,3
             * 1,0  1,1  1,2  1,3
             * 2,0  2,1  2,2  2,3
             * 3,0  3,1  3,2  3,3
             */
            int[] mergeArray = new int[map.GetLength(0)];

            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = 0; r < map.GetLength(0); r++)
                    mergeArray[r] = map[r, c];

                //mergeArray = Merge(mergeArray);
                Merge(mergeArray);

                for (int r = 0; r < map.GetLength(0); r++)
                    map[r, c] = mergeArray[r];
            }
            //return map;
        }

        private static void MoveDown(int[,] map)
        {
            // 从下而上 获取每列数据，形成一维数组
            /*
             * 0,0  0,1  0,2  0,3
             * 1,0  1,1  1,2  1,3
             * 2,0  2,1  2,2  2,3
             * 3,0  3,1  3,2  3,3
             */

            int[] mergeArray = new int[map.GetLength(0)];
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = map.GetLength(0) - 1; r >= 0; r--)
                    mergeArray[3 - r] = map[r, c]; //从头到尾存入一维数组

                //mergeArray = Merge(mergeArray);
                Merge(mergeArray);

                for (int r = map.GetLength(0) - 1; r >= 0; r--)
                    map[r, c] = mergeArray[3 - r];
            }
            //return map;
        }

        private static void MoveLeft(int[,] map)
        {
            // 从左往右 获取每列数据，形成一维数组
            /*
             * 0,0  0,1  0,2  0,3
             * 1,0  1,1  1,2  1,3
             * 2,0  2,1  2,2  2,3
             * 3,0  3,1  3,2  3,3
             */
        }

        private static void MoveRight(int[,] map)
        {

        }

        //数据类型 int     值: 0 1 2 3......
        private static void Move(int[,]map,int direction)
        {

        }

        //数据类型 MoveDirection     值: MoveDirection.Up MoveDirection.Down......
        private static void Move(int[,] map, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUp(map);
                    break;
                case MoveDirection.Down:
                    MoveDown(map);
                    break;
                case MoveDirection.Left:
                    MoveLeft(map);
                    break;
                case MoveDirection.Right:
                    MoveRight(map);
                    break;
            }
        }

        //每日一练: 左移动 右移动
    }
}
 