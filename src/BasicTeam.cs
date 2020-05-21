using System;
using System.Collections.Generic;
using System.Linq;

namespace Spite
{
	/// <summary>
	/// Represents a team.
	/// </summary>
	[Serializable]
	public class BasicTeam : ITeam
	{
		internal ICollection<IEntity> entities = new List<IEntity>();

		/// <inheritdoc/>
		public int ManagedEntityCount => entities.Count(e => e != null);

		/// <inheritdoc/>
		public TeamStanding CurrentStanding { get; private set; }

		/// <inheritdoc/>
		public ICollection<IEntity> Entities => entities;

		/// <inheritdoc/>
		public void AddEntity(IEntity entity)
		{
			entities.Add(entity);
		}

		/// <summary>
		/// Retrieves the entity at the specified index.
		/// </summary>
		/// <param name="index">The index of the entity.</param>
		/// <returns>The entity at the given index.</returns>
		public IEntity GetEntityByIndex(int index)
		{
			if (index < 0 || entities.Count <= index)
				throw new ArgumentOutOfRangeException(nameof(index));
			return entities.ElementAt(index);
		}

		/// <summary>
		/// Sets the number of entities available to this team.
		/// </summary>
		/// <param name="entityCount">The number of entities that can be on the team, or the default starting number.</param>
		public void InitializeEntityCount(uint entityCount)
		{	
			entities = new IEntity[entityCount];
		}

		/// <inheritdoc/>
		public TeamStanding DetermineStanding(IArena context)
		{
			throw new NotImplementedException();
		}
	}
}