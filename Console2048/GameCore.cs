using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    /// <summary>
    /// 游戏核心类，负责处理游戏核心算法，与界面无关
    /// </summary>
    class GameCore
    {
        private int[,] map;
        private int[] mergeArray;
        private int[] removeZeroArray;

        public int[,] Map
        {
            get { return this.map; }
        }

        public GameCore()
        {
            map = new int[4, 4];
            mergeArray = new int[4];
            removeZeroArray = new int[4];
            emptyLocationList = new List<Location>(16);
            random = new Random();
            originalMap = new int[4, 4];
        }

        #region 数据合并

        private void RemoveZero()
        {
            // 每次去零操作，都要"清空"去零数组元素
            Array.Clear(removeZeroArray, 0, 4); // 0 0 0 0
            int index = 0;
            for (int i = 0; i < mergeArray.Length; i++)
            {
                if (mergeArray[i] != 0)
                    removeZeroArray[index++] = mergeArray[i];
            }
            removeZeroArray.CopyTo(mergeArray, 0);
        }

        private void Merge()
        {
            RemoveZero();

            for (int i = 0; i < mergeArray.Length - 1; i++)
            {
                if (mergeArray[i] != 0 && mergeArray[i] == mergeArray[i + 1])
                {
                    mergeArray[i] += mergeArray[i + 1];
                    mergeArray[i + 1] = 0;
                }
            }
            RemoveZero();
        }

        #endregion

        #region 移动

        private void MoveUp()
        {
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = 0; r < map.GetLength(0); r++)
                    mergeArray[r] = map[r, c];
                Merge();
                for (int r = 0; r < map.GetLength(0); r++)
                    map[r, c] = mergeArray[r];
            }
        }

        private void MoveDown()
        {
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = map.GetLength(0) - 1; r >= 0; r--)
                    mergeArray[3 - r] = map[r, c];
                Merge();

                for (int r = map.GetLength(0) - 1; r >= 0; r--)
                    map[r, c] = mergeArray[3 - r];
            }
        }

        private void MoveLeft()
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                    mergeArray[c] = map[r, c];

                Merge();

                for (int c = 0; c < map.GetLength(1); c++)
                    map[r, c] = mergeArray[c];
            }
            
        }

        private void MoveRight()
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = map.GetLength(1)-1; c >= 0; c--)
                    mergeArray[3 - c] = map[r, c];

                Merge();

                for (int c = map.GetLength(1) - 1; c >= 0; c--)
                    map[r, c] = mergeArray[3 - c];
            }
        }

        private int[,] originalMap;
        /// <summary>
        /// 地图是否发生变化
        /// </summary>
        public bool IsChange { get; set; }

        public void Move(MoveDirection direction)
        {
            // 移动前 记录 map --> originalMap
            Array.Copy(map, originalMap, map.Length);
            IsChange = false; // 假设没有变化

            switch (direction)
            {
                case MoveDirection.Up:
                    MoveUp();
                    break;
                case MoveDirection.Down:
                    MoveDown();
                    break;
                case MoveDirection.Left:
                    MoveLeft();
                    break;
                case MoveDirection.Right:
                    MoveRight();
                    break;
            }
            // 移动后 对比 map
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r,c] != originalMap[r, c])
                    {
                        IsChange = true;
                        return;
                    }
                }
            }
        }

        #endregion

        #region 生成数字

        // 需求：在空白位置，随机产生一个2(90%)或者4(10).
        // 分析：先计算所有空白位置
        //      再随机选择一个位置
        //      随机2、4

        private List<Location> emptyLocationList;

        private void CalculateEmpty()
        {
            // 每次统计空位置前，先清空列表
            emptyLocationList.Clear();

            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    if (map[r, c] == 0)
                    {
                        // 记录 r c，一个空位置
                        // 将多个基本数据类型，封装为一个自定义类型
                        emptyLocationList.Add(new Location(r, c));
                    }
                }
            }
        }

        private Random random;

        public void GenerateNunber()
        {
            CalculateEmpty();
            if (emptyLocationList.Count > 0)
            {
                int randomIndex = random.Next(0, emptyLocationList.Count);
                Location loc = emptyLocationList[randomIndex];
                map[loc.RIndex, loc.CIndex] = random.Next(0, 10) == 1 ? 4 : 2;
            }   
        }

        #endregion

        // 游戏结束
        // 没有空位置
        // 不能合并
    }
}
 