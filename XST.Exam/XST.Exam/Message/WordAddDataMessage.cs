using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Message
{
    internal class WordAddDataMessage : ValueChangedMessage<bool>
    {
        public WordAddDataMessage(bool value) : base(value)
        {
        }
    }
}
