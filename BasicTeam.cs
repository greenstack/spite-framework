﻿using System;
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
		public bool AreAllAlive => AliveEntityCount == ManagedEntityCount;

		/// <inheritdoc/>
		public int AliveEntityCount => entities.Count(e => e.IsAlive);

		/// <inheritdoc/>
		public int ManagedEntityCount => entities.Count(e => e != null);

		/// <inheritdoc/>
		public TeamStanding CurrentStanding => throw new NotImplementedException();

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
		/// <param name="isSizeCapped">Whether or not the amount of entities on the team can increase.</param>
		/// <param name="entityCount">The number of entities that can be on the team, or the default starting number.</param>
		public void InitializeEntityCount(uint entityCount, bool isSizeCapped)
		{
			if (isSizeCapped)
			{
				entities = new IEntity[entityCount];
			}
			else
			{
				entities = new List<IEntity>((int)entityCount);
			}
		}

		/// <inheritdoc/>
		public TeamStanding DetermineStanding(Arena context)
		{
			throw new NotImplementedException();
		}
	}
}