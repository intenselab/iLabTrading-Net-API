using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    [Export]
    [IntenseLabPacket]
    public class CommodityPositionOpenUpdate : BasePositionOpenUpdate
    {
        public long TicketNo { get; set; }
        public long ReferenceTicketNo { get; set; }
    }
}
