using Spite.Properties;
using System;

namespace Spite
{
    /// <summary>
    /// Provides methods useful for building and populating an arena.
    /// </summary>
    public class ArenaBuilder
    {
        private Arena builtArena;

        private TeamBuilder currentTeam;

        private int teamsAdded = 0;

        private TurnScheme? turnScheme = null;

        /// <summary>
        /// Creates an instance of an Arena Builder.
        /// </summary>
        public ArenaBuilder()
        {
        }

        /// <summary>
        /// Sets the number of sides fighting in the arena. Must be the first
        /// method called.
        /// </summary>
        /// <param name="sideCount">The number of sides fighting in this arena.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="Arena(uint)"/>
        /// <seealso cref="InitArena(string, uint)"/>
        public ArenaBuilder InitArena(uint sideCount)
        {
            builtArena = new Arena(sideCount);
            return this;
        }

        /// <summary>
        /// Sets the name of and number of sides fighting in the arena. Must be
        /// the first method called.
        /// </summary>
        /// <param name="arenaName">The name of the arena.</param>
        /// <param name="sideCount">The number of sides fighting in this arena.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="Arena(string, uint)"/>
        /// <seealso cref="InitArena(uint)"/>
        public ArenaBuilder InitArena(string arenaName, uint sideCount)
        {
            builtArena = new Arena(arenaName, sideCount);
            return this;
        }

        /// <summary>
        /// Sets the type of turn scheme that this arena will have.
        /// </summary>
        /// <param name="scheme">The scheme for determining the granularity of turns.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder SetTurnScheme(TurnScheme scheme)
        {
            turnScheme = scheme;
            return this;
        }

        /// <summary>
        /// Adds a team of the specific type to the arena.
        /// </summary>
        /// <typeparam name="TTeam">The type of team to build.</typeparam>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.Start{TTeam}"/>
        public ArenaBuilder AddTeam<TTeam>() where TTeam : ITeam, new()
        {
            AssertArenaWasMade();
            if (teamsAdded == builtArena.SideCount)
                throw new InvalidOperationException($"Cannot add another team to the arena - initialized with {builtArena.Sides.Length} sides");
            currentTeam = new TeamBuilder().Start<TTeam>();
            return this;
        }

        /// <summary>
        /// Sets the size of the team currently being built.
        /// </summary>
        /// <param name="teamSize">The initial size of the team, or the max size of the team.</param>
        /// <param name="isSizeCapped">If the team size cannot increase, set this to true.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.SetTeamSize(uint, bool)"/>
        public ArenaBuilder SetCurrentTeamSize(uint teamSize, bool isSizeCapped)
        {
            AssertTeamBuilder();
            currentTeam.SetTeamSize(teamSize, isSizeCapped);
            return this;
        }

        /// <summary>
        /// Adds the provided entity to the team.
        /// </summary>
        /// <param name="entity">The entity to be added to the team.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.AddEntity(IEntity)"/>
        public ArenaBuilder AddEntityToTeam(IEntity entity)
        {
            AssertTeamBuilder();
            currentTeam.AddEntity(entity);
            return this;
        }

        /// <summary>
        /// Sets the win condition for the current team.
        /// </summary>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder SetWinConditionForTeam(Func<Arena, TeamStanding> winConFunc)
        {
            AssertTeamBuilder();
            currentTeam.SetTeamStandingDeterminer(winConFunc);
            return this;
        }

        /// <summary>
        /// Finishes the team.
        /// </summary>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.Finish"/>
        public ArenaBuilder FinishTeam()
        {
            builtArena.Sides[teamsAdded++] = currentTeam.Finish();
            return this;
        }

        /// <summary>
        /// Finishes the team and provides it as a parameter.
        /// </summary>
        /// <param name="createdTeam">The team that get finished building.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.Finish"/>
        public ArenaBuilder FinishTeam(out ITeam createdTeam)
        {
            createdTeam = currentTeam.Finish();
            builtArena.Sides[teamsAdded++] = createdTeam;
            return this;
        }

        /// <summary>
        /// Finishes the team and provides it as a parameter, cast to the specific type.
        /// </summary>
        /// <typeparam name="T">The team type.</typeparam>
        /// <param name="createdTeam">The team that was created.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        /// <see cref="TeamBuilder.Finish{TTeam}"/>
        public ArenaBuilder FinishTeam<T>(out T createdTeam) where T : ITeam
        {
            createdTeam = currentTeam.Finish<T>();
            builtArena.Sides[teamsAdded++] = createdTeam;
            return this;
        }

        /// <summary>
        /// Finishes building the Arena and returns the built arena.
        /// </summary>
        /// <returns>The built arena.</returns>
        public Arena Finish()
        {
            AssertArenaWasMade();
            return builtArena;
        }

        private void AssertArenaWasMade()
        {
#if DEBUG
            if (builtArena == null)
                throw new InvalidOperationException(Resources.ArenaNotStarted);
#endif
        }

        private void AssertTeamBuilder()
        {
#if DEBUG
            if (currentTeam == null)
                throw new InvalidOperationException(Resources.NoTeamAddedArenaBuilder);
#endif
        }

        private void AssertValidTurnScheme(TurnScheme expected, bool checkForNull)
        {
#if DEBUG
            if (turnScheme != null && checkForNull && 
                (turnScheme & TurnScheme.Entity) == expected)
                throw new InvalidOperationException(Resources.InvalidTurnScheme);
#endif
        }
    }
}
