using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Model
{
    [SugarTable("base_training_records", "训练记录表")]
    public class BaseTrainingRecords
    { 
        
        /// <summary>
       /// 训练记录唯一标识符。
       /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 被测试的单词的ID
        /// </summary>
        [SugarColumn(IsNullable = false)] 
        public int WordID { get; set; }

        /// <summary>
        /// 答题是否正确
        /// </summary>
        [SugarColumn(IsNullable = false)] 
        public bool IsCorrect { get; set; }

        /// <summary>
        /// 答题用时
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int AnswerTime { get; set; }
        /// <summary>
        /// 答题的时间
        /// </summary>
        [SugarColumn(IsNullable = true)] 
        public DateTime AnswerDateTime { get; set; }

        /// <summary>
        /// 上次答题的时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? LastAttemptDateTime { get; set; }

        /// <summary>
        /// 尝试答题的次数
        /// </summary>
        [SugarColumn(IsNullable = true)] 
        public int AttemptsCount { get; set; }

        /// <summary>
        /// 是否已经掌握该单词
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool IsMastered { get; set; }
    }

}
