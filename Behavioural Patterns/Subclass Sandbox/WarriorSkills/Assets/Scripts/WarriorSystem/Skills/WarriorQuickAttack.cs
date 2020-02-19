using Utils;
using WarriorSystem.Anim;

namespace WarriorSystem.Skills
{
    public class WarriorQuickAttack : WarriorSkill
    {
        public override int SkillId => 1;

        public WarriorQuickAttack(WarriorBase warriorBase) : base(warriorBase)
        {
        }
        
        public override void Perform()
        {
            // First Spawn Particle and move then animate after 0.5 seconds
            Move(_warrior.transform.forward,5f,0.5f);
            SpawnParticle(_warrior.GetWarriorParticles().BloodEffect);
            Timer.Instance.TimerWait(0.5f, ()=> SetAnimation(WarriorSkillAnim.QUICK_ATTACK_TRIGGER));
        }
    }
}
