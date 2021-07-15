using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    /// <summary>
    /// 用户类
    /// </summary>
    class User
    {
        //字段
        private string loginId;

        //属性 包含2个方法
        public string Loginid
        {
            get { return this.loginId; }
            set { this.loginId = value; }
        }

        //自动属性 包含1个字段 2个方法
        public string Password { get; set; }

        //构造函数
        public User()//允许不给参数创建User类
        {

        }

        public User(string loginId,string pwd)//允许提供两个参数参见类的对象
        {
            this.loginId = loginId;
            this.Password = pwd;
        }

        //方法
        public void PrintUser()
        {
            Console.WriteLine("账号: {0}, 密码: {1}",Loginid,Password);
        }
    }
}
