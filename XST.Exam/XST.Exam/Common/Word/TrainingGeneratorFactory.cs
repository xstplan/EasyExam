using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Common.Word;

namespace XST.Exam.Common.Word
{
    public class TrainingGeneratorFactory
    {
        private static Random random = new Random();

        private static List<Type> generatorTypes = new List<Type>
    {
        typeof(WordTrainingGenerator),  
        // typeof(OtherTrainingGenerator),
    };

        public static ITrainingGenerator GetRandomGenerator(int minDifficulty, int maxDifficulty)
        {
            if (minDifficulty > maxDifficulty)
                throw new ArgumentException("无效的难度范围");

            int difficulty = random.Next(minDifficulty, maxDifficulty + 1);

            //根据您的要求调整难度等级
            switch (difficulty)
            {
                case 1:
                    return CreateGenerator(typeof(RandomWordGenerator));
                 
                case 2:
                    return CreateGenerator(typeof(WordTrainingGenerator));
                case 3:
                    return CreateGenerator(typeof(WritingWordsGenerator));
                default:
                    return CreateGenerator(typeof(WritingWordsGenerator));
            }
        }
        private static ITrainingGenerator CreateGenerator(Type generatorType)
        {
            return Activator.CreateInstance(generatorType) as ITrainingGenerator;
        }
    }
}
    
