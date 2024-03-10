using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Model
{
    [SugarTable("base_exam_word", "单词表")]
    public class BaseExamWord
    {
        /// <summary>
        /// 单词唯一标识符。
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 设置单词
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// 单词的定义。
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 表示单词的词性枚举，其中1表示名词，2表示动词，3表示形容词，4表示副词，5表示代词，6表示介词，7表示连词，8表示感叹词，9表示其他。
        /// </summary>
        public string PartOfSpeech { get; set; }

        /// <summary>
        /// 单词创建时间。
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
