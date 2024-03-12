using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Message
{
    public class WordTrainMessage : ValueChangedMessage<object>
    {
        public WordTrainMessage(object value) : base(value)
        {
        }
    }
}
