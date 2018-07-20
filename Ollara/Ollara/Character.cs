using System;
using System.Collections.Generic;
using System.Text;

namespace Ollara
{
    class Character : BaseUnit
    {
        Random rand = new Random();

        public Character(String name, Race race, Background background)
        {
            this.name = name;
            this.race = race;
            this.background = background;

            this.maximumHealth += (rand.Next(10, 16) + race.Health + background.Health);
            this.maximumEnergy += (rand.Next(5, 11) + race.Energy + background.Energy);
            this.might += (rand.Next(2, 6) + race.Might + background.Might);
            this.finesse += (rand.Next(2, 6) + race.Finesse + background.Finesse);
            this.astra += (rand.Next(2, 6) + race.Astra + background.Astra);
            this.agility += (rand.Next(2, 6) + race.Agility + background.Agility);
            this.toughness += (rand.Next(2, 6) + race.Toughness + background.Toughness);
            this.acuity += (rand.Next(2, 6) + race.Acuity + background.Acuity);
            this.empathy += (rand.Next(2, 6) + race.Empathy + background.Empathy);
            this.contempt += (rand.Next(2, 6) + race.Contempt + background.Contempt);
            this.luck = rand.Next(-100, 100);
            this.panic = 0;

            this.currentHealth = this.maximumHealth;
            this.currentEnergy = this.maximumEnergy;
        }

        private Background background;
        private Armour armour;
        private List<Passive> passiveList;
        private float might;
        private float finesse;
        private float astra;
        private float agility;
        private float toughness;
        private float acuity;
        private float empathy;
        private float contempt;
        private Party party;

        public override String Name { get { return name; } }
        public override Race Race { get { return race; } }

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

        public Background Background { get { return background; } }

        public Armour Armour
        {
            get { return armour; }
            set { armour = value; }
        }

        public List<Passive> PassiveList { get { return passiveList; } }

        public void AddPassive(Passive passive)
        {
            passiveList.Add(passive);
        }

        public float Might
        {
            get { return might; }
            set { might = value; }
        }

        public float Finesse
        {
            get { return finesse; }
            set { finesse = value; }
        }

        public float Astra
        {
            get { return astra; }
            set { astra = value; }
        }

        public float Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        public float Toughness
        {
            get { return toughness; }
            set { toughness = value; }
        }

        public float Acuity
        {
            get { return acuity; }
            set { acuity = value; }
        }

        public float Empathy
        {
            get { return empathy; }
            set { empathy = value; }
        }

        public float Contempt
        {
            get { return contempt; }
            set { contempt = value; }
        }

        public Party Party
        {
            get { return party; }
            set { party = value; }
        }

        public override List<Ability> AbilityList { get { return AbilityList; } }

        public override void AddAbility(Ability ability)
        {
            abilityList.Add(ability);
        }

        // Calculated with weapon damage and Might
        public override float MeleeDamage
        {
            get
            {
                float damage = 0;
                damage += might;
                damage += weapon.Damage;
                return damage;
            }
        }

        // Calcated with weapon accuracy and Might
        public override float MeleeAccuracy
        {
            get
            {
                float accuracy = 0;
                accuracy += might;
                accuracy += weapon.Accuracy;
                return accuracy;
            }
        }
        
        // Calculated with weapon crit, Finesse, and Luck
        public override float CriticalChance
        {
            get
            {
                float crit = 0;
                crit += finesse;
                crit += luck;
                crit += weapon.CriticalChance;
                return crit;
            }
        }

        // Calculated with weapon accuracy and Finesse
        public override float RangedAccuracy
        {
            get
            {
                float accuracy = 0;
                accuracy += finesse;
                accuracy += weapon.Accuracy;
                return accuracy;
            }
        }

        // Calculated with spell damage and Astra
        public override float GetAbilityDamage(Ability ability)
        {
            float damage = 0;
            damage += astra;
            damage += ability.Power;
            return damage;
        }

        // Calculated with spell accuracy and Astra
        public override float GetAbilityAccuracy(Ability ability)
        {
            float accuracy = 0;
            accuracy += astra;
            accuracy += ability.Accuracy;
            return accuracy;
        }

        // Calculated with armour resistance stat and Astra
        public override float SpellMitigation
        {
            get
            {
                float mitigation = 0;
                mitigation += astra;
                mitigation += armour.SpellResistance;
                return mitigation;
            }
        }

        // Calculated with armour dodge stat, Agility, and Luck
        public override float DodgeChance
        {
            get
            {
                float dodge = 0;
                dodge += agility;
                dodge += luck;
                dodge += armour.Dodge;
                return dodge;
            }
        }

        // Calculated with Agility
        public override float Initiative
        {
            get
            {
                float initiative = 0;
                initiative += agility;
                return initiative;
            }
        }

        // Calculated with armour defence stat and Toughness
        public override float PhysicalMitigation
        {
            get
            {
                float mitigation = 0;
                mitigation += toughness;
                mitigation += armour.PhysicalDefence;
                return mitigation;
            }
        }

        // Calculated with Acuity
        public override float DebuffResistance
        {
            get
            {
                float resistance = 0;
                resistance += acuity;
                return resistance;
            }
        }

        // Calculated with Acuity
        public override float PanicResistance
        {
            get
            {
                float resistance = 0;
                resistance += acuity;
                return resistance;
            }
        }

        // Calculated with heal strength and Empathy
        public override float GetHealStrength(Ability ability)
        {
            float heal = 0;
            heal += empathy;
            heal += ability.Power;
            return heal;
        }

        // Calculated with buff strength and Empathy
        public override float GetBuffStrength(Ability ability)
        {
            float buff = 0;
            buff += empathy;
            buff += ability.Power;
            return buff;
        }

        // Calculated with debuff strength and Contempt
        public override float GetDebuffStrength(Ability ability)
        {
            float debuff = 0;
            debuff += contempt;
            debuff += ability.Power;
            return debuff;
        }

        // Calculated with panic spread resistance (global), Acuity, Empathy, and Contempt
        public  float PanicSpreadMitigation
        {
            get
            {
                float spreadMitigation = 0;
                spreadMitigation += acuity;
                spreadMitigation += contempt;
                spreadMitigation += party.PanicSpreadMitigation;
                return spreadMitigation;
            }
        }
    }
}
