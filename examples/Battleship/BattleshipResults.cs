using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spite;
using Spite.Interaction;

namespace Battleship
{
	class ForfeitReaction : IReaction
	{
		private readonly ITeam forfeitedTeam;

		public ForfeitReaction(ITeam forfeitedTeam)
		{
			this.forfeitedTeam = forfeitedTeam;
		}

		public ISpiteAction FollowUpAction => null;

		public bool ActionSuccessful => true;

		public object GetReactionData()
		{
			return null;
		}

		public TReactionData GetReactionData<TReactionData>()
		{
			return default;
		}

		public override string ToString()
		{
			return $"{forfeitedTeam} forfeit!";
		}
	}
}
