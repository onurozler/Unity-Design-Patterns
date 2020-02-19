using UnityEngine;
using WarriorSystem.Skills;

namespace WarriorSystem
{
    public class WarriorBase : MonoBehaviour
    {
        private WarriorInputController _warriorInputController;
        private WarriorParticleManager _warriorParticleManager;
        private WarriorSkillManager _warriorSkillManager;
        
        private WarriorSkill _warriorQuickAttack;
        private WarriorSkill _warriorStrongAttack;
        private WarriorSkill _warriorDefence;
        
        private void Awake()
        {
            _warriorInputController = GetComponent<WarriorInputController>();
            _warriorParticleManager = GetComponent<WarriorParticleManager>();
            
            _warriorSkillManager = new WarriorSkillManager();
            _warriorStrongAttack = new WarriorStrongAttack(this);
            _warriorQuickAttack = new WarriorQuickAttack(this);
            _warriorDefence = new WarriorDefence(this);
            
            _warriorSkillManager.AddSkill(_warriorStrongAttack);
            _warriorSkillManager.AddSkill(_warriorQuickAttack);
            _warriorSkillManager.AddSkill(_warriorDefence);
            
            _warriorInputController.Initialize(_warriorSkillManager);

            _warriorInputController.OnPerformSkillPressed += PerformSkill;
        }

        private void PerformSkill(WarriorSkill warriorSkill)
        {
            warriorSkill.Perform();
        }

        public WarriorParticleManager GetWarriorParticles()
        {
            return _warriorParticleManager;
        }
    }
}
