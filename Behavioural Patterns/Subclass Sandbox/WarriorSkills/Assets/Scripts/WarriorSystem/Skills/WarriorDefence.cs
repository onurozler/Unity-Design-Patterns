using Utils;
using WarriorSystem.Anim;

namespace WarriorSystem.Skills
{
    public class WarriorDefence : WarriorSkill
    {
        public override int SkillId => 3;

        public WarriorDefence(WarriorBase warriorBase) : base(warriorBase)
        {
        }

        public override void Perform()
        {
            SetAnimation(WarriorSkillAnim.DEFENCE_TRIGGER);
            Move(-_warrior.transform.forward, 5f, 0.5f);
        }
    }
}
