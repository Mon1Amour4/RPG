using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RPG.Characters
{
    internal class Rogue : AbstractCharacter
    {
        // Вынести данные в JSON файлы конфигурации
        // Использовать статический конструктор типа для инициализации таблиц
        // Использовать System.Text.Json для десериализации
        // [JsonPropertyName("foo")]
        readonly static Dictionary<uint, float> rogueAttackPowerTable = new Dictionary<uint, float>()
        {
            {1, 32.5f},
            {2, 40.0f },
            {3, 47.5f },
            {4, 55.0f },
            {5, 62.5f },
            {6, 73.0f }

        };
        readonly static Dictionary<uint, float> rogueHealthTable = new Dictionary<uint, float>()
        {
            {1, 87.0f},
            {2, 99.0f },
            {3, 111.0f },
            {4, 123.0f },
            {5, 135.0f },
            {6, 142.0f }
        };

        protected override Dictionary<uint, float> HealthTable => rogueHealthTable;
        protected override Dictionary<uint, float> PowerTable => rogueAttackPowerTable;

        public Rogue(string name, float baseHealth, float baseAttackPower)
            : base(name, baseHealth, baseAttackPower)
        {
            // IMPLEMENACION
        }

    }
}