using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class DeadState : IState
    {
        // Hareket 
        public float speed;

        // Component
        public Animator animator; 
        public AnimatorControllerParameter[] parameters;
        public NavMeshAgent navMeshAgent;

        public DeadState(DeadStateData deadStateData)
        {
            this.speed = deadStateData.speed;
            //this.animator = deadStateData.animator;
            //this.navMeshAgent = deadStateData.navMeshAgent;
        }

        public void OnStateEnter()
        {
            Debug.Log("Enter Dead State");
            ChangeNavMeshAgentSpeed();
            PlayAnimation();
        }

        public void OnStateExit()
        {
            Debug.Log("Exit Dead State");
        }

        public void OnStateFixedUpdate()
        {
            Debug.Log("FixedUpdate Dead State");
        }

        public void OnStateUpdate()
        {
            Debug.Log("Update Dead State");
        }

        private void ChangeNavMeshAgentSpeed()
        {
            navMeshAgent.speed = speed;
        }

        private void PlayAnimation()
        {
            parameters = animator.parameters;

            foreach (AnimatorControllerParameter parameter in parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Bool)
                {
                    animator.SetBool(parameter.name, false);
                }
            }

            animator.SetTrigger("isDead");
        }
    }
