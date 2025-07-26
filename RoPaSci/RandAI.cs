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
    }

    // Create LastChoiceAI class here that extends RandAI
    internal class LastChoiceAI : RandAI
    {
        private Program.Move? lastChoice;
        public LastChoiceAI(List<Program.Move> allowedMoves) : base(allowedMoves)
        {
            lastChoice = null;
        }
        // Implement logic to remember the last choice and use it in the next move
    }

}
