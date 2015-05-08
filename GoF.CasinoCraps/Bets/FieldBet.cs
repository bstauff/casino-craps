﻿namespace GoF.CasinoCraps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a field bet in craps.
    /// </summary>
    public class FieldBet : Bet
    {
        private int odds;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldBet"/> class.
        /// </summary>
        /// <param name="amount">The amount of the bet.</param>
        public FieldBet(int amount) : base(amount)
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
            if (roll.DiceTotal == 3 || 
                roll.DiceTotal == 4 ||
                roll.DiceTotal == 9 ||
                roll.DiceTotal == 10 ||
                roll.DiceTotal == 11)
            {
                odds = 1;
                Status = BetStatus.Won;
            }
            else if (roll.DiceTotal == 2)
            {
                odds = 2;
                Status = BetStatus.Won;
            }
            else if (roll.DiceTotal == 12)
            {
                odds = 3;
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
