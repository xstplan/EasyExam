using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Helper;

namespace XST.Exam.Model
{
    public static class WordConfig
    {

        public static string ConfigPath= "config/config.ini";

        /// <summary>
        /// 单词练习类型
        /// </summary>
        public static bool NumberTimesType { get; set; } = Convert.ToBoolean(IniFileHelper.ReadValue(ConfigPath, "WordConfig", "NumberTimesType"));
        /// <summary>
        /// 练习多少个
        /// </summary>
        public static int NumberTimes { get; set; } = Convert.ToInt32(IniFileHelper.ReadValue(ConfigPath, "WordConfig", "NumberTimes"));
        /// <summary>
        /// 间隔颜色
        /// </summary>
        public static int WordOffset { get; set; } = Convert.ToInt32(IniFileHelper.ReadValue(ConfigPath, "WordConfig", "WordOffset"));

        /// <summary>
        /// 分类名称
        /// </summary>
        public static string Category { get; set; } = IniFileHelper.ReadValue(ConfigPath, "WordConfig", "Category");

        /// <summary>
        /// 随机词汇
        /// </summary>
        public static bool AllRandom { get; set; } =Convert.ToBoolean( IniFileHelper.ReadValue(ConfigPath, "WordConfig", "AllRandom"));
        
        /// <summary>
        /// 是否重复记住步骤
        /// </summary>
        public static bool Remember { get; set; } = Convert.ToBoolean(IniFileHelper.ReadValue(ConfigPath, "WordConfig", "Remember"));

        

    }
}
