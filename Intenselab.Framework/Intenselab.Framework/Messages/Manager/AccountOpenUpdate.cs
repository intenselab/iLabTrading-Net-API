using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    [Export]
    [IntenseLabPacket]
    public class AccountOpenUpdate : ClientData
    {
        public string AccountName { get; set; }
        public double Open { get; set; }
        public OpenUpdateReason OpenUpdateReason { get; set; }
    }
}
