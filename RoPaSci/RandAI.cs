using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoPaSci
{
    internal class RandAI
    {
        private List<Program.Move> allowedMoves;

        public RandAI(List<Program.Move> allowedMoves)
        {
            this.allowedMoves = allowedMoves;
        }

        public virtual Program.Move GetMove()
        {
            return GetRandomMove();
        }

        public virtual void UpdateKnowledge(Program.Move playerMove)
        {
            // Random AI does not need to update knowledge
        }

        protected Program.Move GetRandomMove()
        {
            Random random = new();
            int index = random.Next(allowedMoves.Count);
            return allowedMoves[index];
        }
    }

    // Create LastChoiceAI class here that extends RandAI
    internal class LastChoiceAI : RandAI
    {
        private Program.Move? lastChoice;
        public LastChoiceAI(List<Program.Move> allowedMoves) : base(allowedMoves)
        {
            lastChoice = null;
        }

        public override Program.Move GetMove()
        {
            if (lastChoice.HasValue)
            {
                // Use the last choice logic to determine the next move
                return lastChoice.Value;
            }
            else
            {
                // If no last choice, fallback to random move
                return GetRandomMove();
            }
        }
        public override void UpdateKnowledge(Program.Move playerMove)
        {
            // Update the last choice with the player's move
            lastChoice = playerMove;
        }
    }

}
