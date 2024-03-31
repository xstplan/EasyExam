using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.Common.Word
{

    /// <summary>
    /// 单词数据处理类
    /// </summary>
    public class WordDataHandler
    {
        private readonly IBaseExamWordService _baseBaseExamWordService;
        private readonly IBaseTrainingRecordsService _baseTrainingRecordsService;
        private readonly Random _random;
        public WordDataHandler(IBaseExamWordService baseBaseExamWordService, IBaseTrainingRecordsService baseTrainingRecordsService)
        {
            _baseBaseExamWordService = baseBaseExamWordService;
            _baseTrainingRecordsService = baseTrainingRecordsService;
            _random = new Random();
        }
        /// <summary>
        /// 数据处理
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="numberTimes">返回数据个数</param>
        /// <returns></returns>
        public List<BaseExamWord> LoadWords(string category, int numberTimes, bool AllRandom = false)
        {
            Service.ToResponse<List<BaseExamWord>> examWordsResponse;
            if (category == "全部")
            {
                examWordsResponse = _baseBaseExamWordService.GetAllBaseExamWords();

            }
            else
            {
                examWordsResponse = _baseBaseExamWordService.Where(a => a.Category == category);
            }

            if (examWordsResponse.Success)
            {
                if (AllRandom)
                {
                    int n = examWordsResponse.Data.Count;
                    //筛选去重
                    while (n > 1)
                    {
                        n--;
                        int k = _random.Next(n + 1);
                        BaseExamWord value = examWordsResponse.Data[k];
                        examWordsResponse.Data[k] = examWordsResponse.Data[n];
                        examWordsResponse.Data[n] = value;
                    }

                    return examWordsResponse.Data.Take(numberTimes).ToList();
                }
                else
                {
                    return examWordsResponse.Data.Take(numberTimes).ToList();
                }
            }
            else
            {
                return new List<BaseExamWord>();
            }
        }


        public void AddWordsTraningRecords(List<BaseTrainingRecords> baseTrainingRecordsList)
        {
            foreach (var item in baseTrainingRecordsList)
            {
                _baseTrainingRecordsService.CreateBaseTrainingRecord (item);
            }

        }
    }
}
