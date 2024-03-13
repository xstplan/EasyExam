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
       /// 单词唯一标识符。
       /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 训练类型Id 如单词，词汇，句子等类型，如“单词”
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? TypeId { get; set; }


        /// <summary>
        /// 训练的内容Id，如单词：苹果Id为1，那么TrainingId也是1
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? TrainingId { get; set; }

        /// <summary>
        /// 难度
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? DifficultyLevel { get; set; }


        /// <summary>
        /// 次数
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? NumberTimes { get; set; }
        /// <summary>
        /// 成功
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? SuccessNumber { get; set; }

        /// <summary>
        /// 错误次数
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ErrorNumber { get; set; }

    }

}
