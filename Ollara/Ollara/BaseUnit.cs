using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    abstract class BaseUnit
    {
        protected String name;
        protected Race race;
        protected float health;
        protected float energy;
        protected float luck;
        protected float panic;
        protected Weapon weapon;
        protected List<Ability> abilityList;

        public abstract String Name { get; }
        public abstract Race Race { get; }
        public abstract float Health { get; set; }
        public abstract float Energy { get; set; }
        public abstract float Luck { get; set; }
        public abstract float Panic { get; set; }
        public abstract Weapon Weapon { get; set; }
        public abstract List<Ability> AbilityList { get; }
        public abstract void AddAbility(Ability ability);
        public abstract float MeleeDamage { get; }
        public abstract float MeleeAccuracy { get; }
        public abstract float CriticalChance { get; }
        public abstract float RangedAccuracy { get; }
        public abstract float GetAbilityDamage(Ability ability);
        public abstract float GetAbilityAccuracy(Ability ability);
        public abstract float SpellMitigation { get; }
        public abstract float DodgeChance { get; }
        public abstract float Initiative { get; }
        public abstract float PhysicalMitigation { get; }
        public abstract float DebuffResistance { get; }
        public abstract float PanicResistance { get; }
        public abstract float GetHealStrength(Ability ability);
        public abstract float GetBuffStrength(Ability ability);
        public abstract float GetDebuffStrength(Ability ability);
    }
}
