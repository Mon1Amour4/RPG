using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG.Characters
{

    internal class Rogue : AbstractCharacter
    {
        // Вынести данные в JSON файлы конфигурации
        // Использовать статический конструктор типа для инициализации таблиц
        // Использовать System.Text.Json для десериализации
        // [JsonPropertyName("foo")]
        private readonly static Dictionary<uint, float> rogueAttackPowerTable = new Dictionary<uint, float>(); //changed to private
        private readonly static Dictionary<uint, float> rogueHealthTable = new Dictionary<uint, float>();//changed to private
        protected override string typeName => rogueTypeName;
        protected readonly static string rogueTypeName = typeof(Rogue).Name;

        protected override Dictionary<uint, float> PowerTable => rogueAttackPowerTable;
        protected override Dictionary<uint, float> HealthTable => rogueHealthTable;

        static Rogue()
        {
            Deserialization(ref rogueAttackPowerTable, ref rogueHealthTable, rogueTypeName);
        }
        public Rogue(string name, float baseHealth, float baseAttackPower)
                : base(name, baseHealth, baseAttackPower)
        {
            // IMPLEMENACION

        }

    }
}