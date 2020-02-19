using System.Collections.Generic;
using System.Linq;
using WarriorSystem.Skills;

namespace WarriorSystem
{
    public class WarriorSkillManager
    {
        private List<WarriorSkill> _warriorSkills;

        public WarriorSkillManager()
        {
            _warriorSkills = new List<WarriorSkill>();
        }

        public void AddSkill(WarriorSkill warriorSkill)
        {
            _warriorSkills.Add(warriorSkill);
        }

        public WarriorSkill GetSkillByID(int id)
        {
            return _warriorSkills.FirstOrDefault(x => x.SkillId == id);
        }
    }
}
