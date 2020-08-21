using Spite;

namespace SpiteBattleship
{
    abstract class BattleshipActor : IActor<BattleshipTeam>
    {
        public BattleshipTeam Team { get; }

        abstract public string Name { get; }

        public BattleshipActor(BattleshipTeam team)
        {
            Team = team;
        }

        public abstract ICommand GetAction();
    }
}
