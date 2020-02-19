using UnityEngine;
using Utils;
using WarriorSystem.Anim;

namespace WarriorSystem.Skills
{
    public class WarriorStrongAttack : WarriorSkill
    {
        public override int SkillId => 2;

        public WarriorStrongAttack(WarriorBase warriorBase) : base(warriorBase)
        {
        }

        public override void Perform()
        {
            // First Spawn Particle then move after 0.5 seconds
            SetAnimation(WarriorSkillAnim.STRONG_ATTACK_TRIGGER);
            SpawnParticle(_warrior.GetWarriorParticles().ExplosionEffect);
            Timer.Instance.TimerWait(0.5f, ()=> Move(_warrior.transform.forward, 3f, 1f));
        }
    }
}
