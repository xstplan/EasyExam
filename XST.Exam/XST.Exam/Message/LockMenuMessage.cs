using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Message
{
    /// <summary>
    /// 锁定窗口
    /// </summary>
    public class LockMenuMessage : ValueChangedMessage<bool>
    {
        public LockMenuMessage(bool value) : base(value)
        {
        }
    }
}
