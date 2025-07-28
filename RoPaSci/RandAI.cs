using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoPaSci
{
    internal class RandAI
    {
        protected List<Program.Move> allowedMoves;

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
                // Use the last choice logic to determine the next move using losing moves from allowed moves
                var losingMoves = Program.LosingMoves[lastChoice.Value];
                var validLosingMoves = losingMoves.Where(move => allowedMoves.Contains(move)).ToList();
                if (validLosingMoves.Count > 0)
                {
                    Random random = new();
                    int index = random.Next(validLosingMoves.Count);
                    return validLosingMoves[index];
                }
                else
                {
                    // no valid move that will win against last choice
                    return GetRandomMove();
                }
            }
            else
            {
                // no last choice
                return GetRandomMove();
            }
        }
        public override void UpdateKnowledge(Program.Move playerMove)
        {
            lastChoice = playerMove;
        }
    }

}
