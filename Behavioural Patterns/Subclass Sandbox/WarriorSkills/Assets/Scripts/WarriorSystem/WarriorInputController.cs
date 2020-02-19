using System;
using UnityEngine;
using WarriorSystem.Skills;

namespace WarriorSystem
{
    public class WarriorInputController : MonoBehaviour
    {
        private WarriorSkillManager _warriorSkillManager;
        
        public event Action<WarriorSkill> OnPerformSkillPressed;
        
        public void Initialize(WarriorSkillManager warriorSkillManager)
        {
            _warriorSkillManager = warriorSkillManager;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (OnPerformSkillPressed != null) 
                    OnPerformSkillPressed(_warriorSkillManager.GetSkillByID(1));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (OnPerformSkillPressed != null) 
                    OnPerformSkillPressed(_warriorSkillManager.GetSkillByID(2));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (OnPerformSkillPressed != null) 
                    OnPerformSkillPressed(_warriorSkillManager.GetSkillByID(3));
            }
        }
    }
}
