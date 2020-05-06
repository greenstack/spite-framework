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
		internal IList<IEntity> entities = new List<IEntity>();

		private int entitiesAdded = 0;

		/// <inheritdoc/>
		public bool AreAllEntitiesTapped => UntappedEntityCount == 0;

		/// <inheritdoc/>
		public int UntappedEntityCount => ManagedEntityCount - entities.Count(e => e.IsTapped);

		/// <inheritdoc/>
		public bool AreAllAlive => AliveEntityCount == ManagedEntityCount;

		/// <inheritdoc/>
		public int AliveEntityCount => entities.Count(e => e.IsAlive);

		/// <inheritdoc/>
		public int ManagedEntityCount => entities.Count;

		/// <inheritdoc/>
		public void AddEntity(IEntity entity)
		{
			entities.Add(entity);
			entity.ID = new EntityID(entitiesAdded++, this);
		}

		/// <inheritdoc/>
		public void Untap(IEntity entity)
		{
			if (entity.Team != this)
			{
				// Why do we want to throw this...?
				throw new InvalidOperationException("Cannot untap this entity - teams are mismatched.");
			}
			entity.Untap();
		}

		/// <inheritdoc/>
		public void UntapAll()
		{
			foreach (var e in entities)
			{
				e.Untap();
			}
		}

		public IEntity GetEntityByIndex(int index)
		{
			if (index < 0 || entities.Count <= index)
				throw new ArgumentOutOfRangeException("Index out of range");
			return entities[index];
		}
	}
}