// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommodityPosition.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    /// <summary>
    ///     Represents update of "Position" structure on commodity routes.
    /// </summary>
    [Export]
    [IntenseLabPacket]
    public class CommodityPosition : BasePosition
    {
        /// <summary>
        ///     TicketNo of correspond position
        /// </summary>
        public long ReferenceTicketNo { get; set; }

        /// <summary>
        ///     Name of correspond account.
        /// </summary>
        public string ReferenceAccountName { get; set; }

        /// <summary>
        ///     Value indicating whether position is delivered.
        /// </summary>
        public CommodityPositionStatus PositionStatus { get; set; }

        /// <summary>
        ///     Value indicating whether position is closed.
        /// </summary>
        public CommodityPositionStatus ReferencePositionStatus { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return
                $"Commodity Position : Account Name = {AccountName}, Symbol = {Symbol}, Side = {Side}, Shares = {Shares}, Price = {Price:F}, Open = {Open:F}, LastUpdate = {Time.TimeOfDay}";
        }
    }
}
