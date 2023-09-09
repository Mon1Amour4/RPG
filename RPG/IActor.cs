

namespace RPG
{
    internal interface IActor
    {
        string Name { get; }
        int Health { get; }
        bool IsAlive { get; }
        uint AttackPower { get; }

        void ReceiveDamage(IActor actor, uint Damage);
    }
}
