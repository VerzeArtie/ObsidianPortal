using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ObsidianPortal
{
    public partial class Unit
    {
        private void SetupProperty(FIX.RaceType race, FIX.JobClass jobType, string unitName, int strength, int agility, int intelligence, int stamina, int mind, int move, int range, int healRange, int effectRange, int cost, string skill)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            this.Race = race;
            this.job = jobType;
            this.FullName = unitName;
            this.BaseStrength = strength;
            this.BaseAgility = agility;
            this.BaseIntelligence = intelligence;
            this.BaseStamina = stamina;
            this.BaseMind = mind;
            this.AttackRange = range;
            this.EffectRange = effectRange;
            this.HealRange = healRange;
            this.MovePoint = move;
            this.Cost = cost;
            this.SkillName = skill;

            this.CurrentLife = this.MaxLife;
            this.CurrentTime = FIX.MAX_TIME;
            this.CurrentMovePoint = this.MovePoint;
            this.Dead = false;
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public void InitializeEnemy(string unitName)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");

            this.ally = Ally.Enemy;
            this.FullName = unitName;

            switch (unitName)
            {
                case FIX.ENEMY_HIYOWA_BEATLE:
                    SetupProperty(FIX.RaceType.Monster, FIX.JobClass.MonsterA, FIX.ENEMY_HIYOWA_BEATLE, 16, 1, 1, 5, 2, 1, 1, 1, 1, 1, FIX.NONE);
                    break;

                case FIX.ENEMY_HENSYOKU_PLANT:
                    SetupProperty(FIX.RaceType.Monster, FIX.JobClass.MonsterA, FIX.ENEMY_HIYOWA_BEATLE, 16, 1, 1, 5, 2, 1, 1, 1, 1, 1, FIX.NONE);
                    break;

                case FIX.ENEMY_GREEN_CHILD:
                    break;

                case FIX.ENEMY_TINY_MANTIS:
                    break;

                case FIX.ENEMY_KOUKAKU_WURM:
                    break;

                case FIX.ENEMY_MANDRAGORA:
                    break;
            }

            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }

        public void Initialize(string unitName, FIX.RaceType race, FIX.JobClass jobType, Ally ally)
        {
            Debug.Log(MethodBase.GetCurrentMethod().Name + "(S)");
            this.job = jobType;
            this.ally = ally;
            this.FullName = unitName;

            if (race == FIX.RaceType.Human && jobType == FIX.JobClass.Fighter) { SetupProperty(race, jobType, FIX.HUMAN_FIGHTER, 9, 6, 2, 20, 2, 3, 1, 0, 2, 10, FIX.DASH); }
            if (race == FIX.RaceType.Human && jobType == FIX.JobClass.Ranger) { SetupProperty(race, jobType, FIX.HUMAN_ARCHER, 7, 9, 4, 16, 2, 3, 2, 0, 3, 10, FIX.REACHABLETARGET); }
            if (race == FIX.RaceType.Human && jobType == FIX.JobClass.Magician) { SetupProperty(race, jobType, FIX.HUMAN_MAGICIAN, 3, 7, 7, 13, 2, 3, 2, 0, 2, 10, FIX.EARTHBIND); }
            if (race == FIX.RaceType.TimeKeeper && jobType == FIX.JobClass.TimeKeeper) { SetupProperty(race, jobType, FIX.TIME_KEEPER, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, FIX.NONE); }

            Debug.Log(MethodBase.GetCurrentMethod().Name + "(E)");
        }
    }
}
