using System;

namespace SpiteRpg
{
    /// <summary>
    /// The view for combat.
    /// </summary>
    class CombatMenu
    {
        internal RpgEntity[] actors = new RpgEntity[3];

        public void Display()
        {
            // Show who the player is up against
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("VS. SHADOW SORCERESS");
            Console.WriteLine("HEALTH: 100");
            Console.WriteLine("SPARKS:   0");
            Console.WriteLine("HEADACHE: 0");
            Console.WriteLine("BLIND:    0");

            // Show player info
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("PLAYER HEALTH: 09");
            WritePhase(1, false, actors[0]);
            WritePhase(2, true, actors[1]);
            WritePhase(3, false, actors[2]);
        }

        private void WritePhase(int phaseNum, bool currentPhase, RpgEntity character)
        {
            Console.Write($"Phase {phaseNum}:");
            var characterOutput = character == null ?
                '?' :
                character.CharacterName[0];
            if (currentPhase)
            {
                Console.Write($"<{characterOutput}>");
            }
            else
            {
                Console.Write($" {characterOutput} ");
            }
            Console.WriteLine();
        }
    }
}
