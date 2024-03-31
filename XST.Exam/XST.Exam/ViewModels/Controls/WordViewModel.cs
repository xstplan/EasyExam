using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Message;
using XST.Exam.Views.Controls;
using XST.Model;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordViewModel: ObservableObject
    {

        private static List<BaseTrainingRecords> _trainingRecordsList = new List<BaseTrainingRecords>(); 
        
        /// <summary>
        /// 添加训练记录
        /// </summary>
        /// <param name="trainingRecords">历史记录</param>
        protected void SetRecords(BaseTrainingRecords  trainingRecords) 
        {
            _trainingRecordsList.Add(trainingRecords);
        }
        /// <summary>
        /// 获取训练记录
        /// </summary>
        /// <returns></returns>
        protected List<BaseTrainingRecords> GetRecords( )
        {
            return _trainingRecordsList;
        }
        /// <summary>
        /// 清空训练记录
        /// </summary>
        protected void ClearRecords() 
        {
            _trainingRecordsList.Clear();
        }
        [RelayCommand]
        public void Exit()
        {
            WeakReferenceMessenger.Default.Send(new LockMenuMessage(true));
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordStart()));
        }

        [RelayCommand]
        public void WordEnd()
        {
            WeakReferenceMessenger.Default.Send(new LockMenuMessage(true));
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordEnd()));
        }
    }
}
