using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Obi;
namespace JellerFellers
{
    public class LevelCollisionHandler : MonoBehaviour
    {
        ObiSolver solver;

        ObiSoftbody softbody;
        List<ObiCollider> stars = new List<ObiCollider>();

        List<ObiCollider> coins = new List<ObiCollider>();




        ObiCollider deathPitCollider;
        ObiCollider winCollider;

        public UnityEvent onDeath = new UnityEvent();
        public UnityEvent onFinish = new UnityEvent();

        private void Awake()
        {
            solver = GetComponent<ObiSolver>();
            deathPitCollider = FindObjectOfType<DeathBox>().GetComponent<ObiCollider>();
            winCollider = FindObjectOfType<WinCollider>().GetComponent<ObiCollider>();
            Debug.Log(winCollider.gameObject);
            softbody = FindObjectOfType<Player_Controller_Obi>().GetComponent<ObiSoftbody>();
        }

        // Start is called before the first frame update
        void OnEnable()
        {
            solver.OnCollision += Solver_OnCollision;
            onFinish.AddListener(FinishLevel);
            onDeath.AddListener(Death);
        }

        void FinishLevel()
        {
            winCollider.GetComponent<WinCollider>().HandleWin();
        }
        void Death()
        {
            deathPitCollider.GetComponent<DeathBox>().HandleDeath();
        }

        private void OnDisable()
        {
            solver.OnCollision -= Solver_OnCollision;
        }


        public void AddStar(ObiCollider collider)
        {
            stars.Add(collider);
        }
        public void AddCoin(ObiCollider collider)
        {
            coins.Add(collider);
        }
        private void Solver_OnCollision(ObiSolver s, ObiSolver.ObiCollisionEventArgs e)
        {
            var world = ObiColliderWorld.GetInstance();
            foreach (Oni.Contact contact in e.contacts)
            {
                // look for actual contacts only:
                if (contact.distance > 0.01)
                {
                    var col = world.colliderHandles[contact.bodyB].owner;

                    if (col.gameObject.tag == "Collectable")
                    {
                        if (col.gameObject.GetComponent<Star>())
                        {
                            col.gameObject.GetComponent<Star>().CollectStar();
                            return;
                        }
                        else if (col.gameObject.GetComponent<Coin>())
                        {
                            col.gameObject.GetComponent<Coin>().CollectCoin();
                            return;
                        }
                    }
                    else
                    {
                        if (col.gameObject.GetComponent<DeathBox>())
                        {
                            onDeath.Invoke();
                            return;
                        }
                        else if (col.gameObject.GetComponent<WinCollider>())
                        {

                            onFinish.Invoke();
                            return;
                        }
                    }


                }
            }
        }
    }

}