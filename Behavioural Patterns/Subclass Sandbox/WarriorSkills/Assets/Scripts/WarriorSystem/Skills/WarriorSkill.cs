using DG.Tweening;
using UnityEngine;

namespace WarriorSystem.Skills
{
    public abstract class WarriorSkill
    {
        protected WarriorBase _warrior;
        
        public abstract void Perform();
        public virtual int SkillId => 0;

        protected WarriorSkill(WarriorBase warriorBase)
        {
            _warrior = warriorBase;
        }
        
        protected void Move(Vector3 direction, float distance, float duration)
        {
            _warrior.transform.DOMove(_warrior.transform.position + direction * distance, duration);
        }

        protected void SpawnParticle(ParticleSystem warriorParticle)
        {
           warriorParticle.Play();
        }

        protected void SetAnimation(string trigger)
        {
            _warrior.GetComponent<Animator>().SetTrigger(trigger);
        }
    }
}
