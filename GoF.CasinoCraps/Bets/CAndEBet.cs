﻿namespace GoF.CasinoCraps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a C&E bet in craps.
    /// </summary>
    public class CAndEBet : Bet
    {
        private int odds;

        /// <summary>
        /// Initializes a new instance of the <see cref="CAndEBet"/> class.
        /// </summary>
        /// <param name="amount">The amount of the bet.</param>
        public CAndEBet(int amount)
            : base(Convert.ToInt32(amount / 2))
        {
            odds = 0;
        }

        /// <summary>
        /// Gets the payout odds of the bet.
        /// </summary>
        public override int Odds
        {
            get
            {
                return odds;
            }
        }

        /// <summary>
        /// Notifies the bet that the dice have been rolled.
        /// </summary>
        /// <param name="roll">The roll.</param>
        public override void DiceRolled(Roll roll)
        {
            if (roll.IsCraps)
            {
                odds = 3;
                Status = BetStatus.Won;
            }
            else if (roll.Name == RollName.Yo)
            {
                odds = 7;
                Status = BetStatus.Won;
            }
            else
            {
                Status = BetStatus.Lost;
            }
        }

        /// <summary>
        /// Notifies the bet that the round has ended.
        /// </summary>
        /// <param name="args">The RoundEndedEventArgs arguments.</param>
        public override void RoundEnded(RoundEndedEventArgs args)
        {
            // Do nothing.
        }
    }
}
