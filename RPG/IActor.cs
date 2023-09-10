

namespace RPG
{
    internal interface IActor
    {
        string Name { get; }
        float Health { get; } // Changed to float from uint
        bool IsAlive { get; }
        float AttackPower { get; } // Changed to float from uint

        void ReceiveDamage(IActor actor, float Damage); // Changed to float from uint
    }
}
