using System;


namespace RPG
{
    internal interface ICharacter : IActor
    {
        uint Experience { get; }
        uint Level { get; }

        void ReceiveExperience(uint Experience);
        void levelUp(); // Added 
        void increaseStats();


    }
}
