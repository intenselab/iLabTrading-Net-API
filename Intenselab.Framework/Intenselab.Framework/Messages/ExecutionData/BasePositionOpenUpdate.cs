namespace IntenseLab.Framework.Messages
{
    public abstract class BasePositionOpenUpdate : ExecutionData
    {
        public double Open { get; set; }
        public double LastPrice { get; set; }
        public OpenUpdateReason OpenUpdateReason { get; set; }
    }
}
