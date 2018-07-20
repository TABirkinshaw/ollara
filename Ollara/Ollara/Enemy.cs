using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Enemy : BaseUnit
    {
        public Enemy(String name, Race race)
        {
            this.name = name;
            this.race = race;
        }

        private float meleeDamage;
        private float meleeAccuracy;
        private float criticalChance;
        private float rangedAccuracy;
        private float spellMitigation;
        private float dodgeChance;
        private float initiative;
        private float physicalMitigation;
        private float debuffResistance;
        private float panicResistance;

        public override String Name
        {
            get { return name; }
        }

        public override Race Race
        {
            get { return race; }
        }

        public override float MaximumHealth
        {
            get { return maximumHealth; }
            set { maximumHealth = value; }
        }

        public override float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public override float MaximumEnergy
        {
            get { return maximumEnergy; }
            set { maximumEnergy = value; }
        }

        public override float CurrentEnergy
        {
            get { return currentEnergy; }
            set { currentEnergy = value; }
        }

        public override float Luck
        {
            get { return luck; }
            set { luck = value; }
        }

        public override float Panic
        {
            get { return panic; }
            set { panic = value; }
        }

        public override Weapon Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }

        public override List<Ability> AbilityList
        {
            get { return abilityList; }
        }

        public override void AddAbility(Ability ability)
        {
            abilityList.Add(ability);
        }

        public override float MeleeDamage
        {
            get { return meleeDamage; }
        }

        public override float MeleeAccuracy
        {
            get { return meleeAccuracy; }
        }

        public override float CriticalChance
        {
            get { return criticalChance; }
        }

        public override float RangedAccuracy
        {
            get { return rangedAccuracy; }
        }

        public override float GetAbilityDamage(Ability ability)
        {
            float damage = 0;
            damage += ability.Power;
            // alter damage another way?
            return damage;
        }

        public override float GetAbilityAccuracy(Ability ability)
        {
            float accuracy = 0;
            accuracy += ability.Accuracy;
            // alter accuracy another way?
            return accuracy;
        }

        public override float SpellMitigation
        {
            get { return spellMitigation; }
        }

        public override float DodgeChance
        {
            get { return dodgeChance; }
        }

        public override float Initiative
        {
            get { return initiative; }
        }

        public override float PhysicalMitigation
        {
            get { return physicalMitigation; }
        }

        public override float DebuffResistance
        {
            get { return debuffResistance; }
        }

        public override float PanicResistance
        {
            get { return panicResistance; }
        }

        public override float GetHealStrength(Ability ability)
        {
            float heal = 0;
            heal += ability.Power;
            // alter it another way?
            return heal;
        }

        public override float GetBuffStrength(Ability ability)
        {
            float buff = 0;
            buff += ability.Power;
            // alter it another way?
            return buff;
        }

        public override float GetDebuffStrength(Ability ability)
        {
            float debuff = 0;
            debuff += ability.Power;
            // alter it another way?
            return debuff;
        }
    }
}
