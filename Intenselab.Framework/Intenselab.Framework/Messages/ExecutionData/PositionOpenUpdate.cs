using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    [Export]
    [IntenseLabPacket]
    public class PositionOpenUpdate : BasePositionOpenUpdate
    {
        public string Symbol { get; set; }
    }
}
