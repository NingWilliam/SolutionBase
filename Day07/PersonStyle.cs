using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    [Flags]
    enum PersonStyle
    {
        //tall = 0,         //0000000000
        //rich = 1,         //0000000001
        //handsome = 2,     //0000000010
        //white = 3,        //0000000011
        //beauty = 4        //0000000100

        tall = 1,         //0000000001
        rich = 2,         //0000000010
        handsome = 4,     //0000000100
        white = 8,        //0000001000
        beauty = 16       //0000010000
    }

    /*
     * 选择多个枚举值
     * 运算符 | (按位或)：两个对应的二进制为中有一个为1，结果位 为1
     * tall | rich ==> 0000000000 | 0000000001 ==> 0000000001
     * 
     * 条件:
     * 1.任意多个枚举值做 | 运算的 结果不能与其它枚举值相同(值以2的n次方递增)
     * 2.定义枚举是，使用[Flags] 特性修饰
     * 
     * 判断标志枚举 是否包含指定枚举值
     * 运算符 & （按位与)：两个对应的二进制为中都为1，结果位 为1
     * 0000000011 & 0000000001 ==> 0000000001
     */
}
