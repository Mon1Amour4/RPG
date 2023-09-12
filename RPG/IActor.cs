

namespace RPG
{
    internal interface IActor
    {
        string Name { get; }
        float Health { get; } // Changed to float from uint
        bool IsAlive { get; }
        float AttackPower { get; } // Changed to float from uint

        void ReceiveDamage(ICharacter character, float Damage); // Changed to float from uint
    }
}
 