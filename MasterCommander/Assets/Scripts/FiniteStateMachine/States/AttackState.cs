using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class AttackState : IState
    {
        // Hareket 
        public float speed;

        // Component
        public Animator animator;
        public AnimatorControllerParameter[] parameters;
        public NavMeshAgent navMeshAgent;
        public EnemyAI enemyAI;

        // Konum
        public Transform ownTransform;
        public Transform playerTransform;

        // Algýlama
        public float attackRadius;


        //Saldýrý animasyonu baþladýðýnda bize doðru dönme þansý sýfýrlansýn kaçýnma imkaný sunsun
        private bool isAnimationPlaying;
        public AttackState(AttackStateData attackStateData)
        {
            //this.speed = attackStateData.speed;
            //this.animator = attackStateData.animator;
            //this.navMeshAgent = attackStateData.navMeshAgent;
            //this.enemyAI = attackStateData.enemyAI;
            //this.ownTransform = attackStateData.ownTransform;
            //this.playerTransform = attackStateData.playerTransform;
            //this.attackRadius = attackStateData.attackRadius;
        }

        public void OnStateEnter()
        {
            Debug.Log("Enter Attack State");
            ChangeNavMeshAgentSpeed();
            PlayAnimation();
        }

        public void OnStateExit()
        {
            Debug.Log("Exit Attack State");
        }

        public void OnStateFixedUpdate()
        {
            Debug.Log("FixedUpdate Attack State");
        }

        public void OnStateUpdate()
        {
            Debug.Log("Update Attack State");
            if (!isAnimationPlaying)
            {
                LookToPlayer();
            }
        }

        public void ChangeNavMeshAgentSpeed()
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

            // Saldýrý yapýldýðýnda
            animator.SetTrigger("isAttack");
            //AnimationPlaying();
        }

     
        public void LookToPlayer()
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - ownTransform.position);
            ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation, targetRotation, 125 * Time.deltaTime);
        }

        public void AnimationPlaying()
        {
            isAnimationPlaying = true;
        }

        public void AnimationStoping()
        {
            isAnimationPlaying = false;
        }
    }
