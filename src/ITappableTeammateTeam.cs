using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spite
{
	/// <summary>
	/// A team of entities that can be tapped.
	/// </summary>
	public interface ITappableTeammateTeam : ITeam<ITappableTeammate> { }

	/// <summary>
	/// A generic team of entities that can be tapped.
	/// </summary>
	/// <typeparam name="T">The type of entity to contain.</typeparam>
	public interface ITappableTeammateTeam<T> : ITappableTeammateTeam
		where T : ITappableTeammate
	{
	}
}
