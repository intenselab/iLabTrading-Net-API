// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionUpdate.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System.ComponentModel.Composition;

namespace IntenseLab.Framework.Messages
{
    [Export]
    [IntenseLabPacket]
    public class Position : BasePosition
    {
        /// <summary>
        ///     Value indicating already earned sum of money.
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        ///     <see cref="object.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return
                $"Position : Account Name = {AccountName}, Symbol = {Symbol}, Side = {Side}, Shares = {Shares}, Price = {Price:F}, Open = {Open:F}, Close = {Close:F}, LastUpdate = {Time.TimeOfDay}";
        }
    }
}
