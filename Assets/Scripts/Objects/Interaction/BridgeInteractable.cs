using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Objects.Interaction
{
    class BridgeInteractable : InteractableObject
    {
        public int _woodAmount;
        [SerializeField] private GameObject _bridgePlanks1;
        [SerializeField] private GameObject _bridgePlanks2;
        [SerializeField] private GameObject _bridgePlanks3;

        public void Start()
        {
            _bridgePlanks1.SetActive(false);
            _bridgePlanks2.SetActive(false);
            _bridgePlanks3.SetActive(false);
        }

        public override void Interact(int amount)
        {
            if (amount <= 0)
            {
                base.Interact();
            }
            else
            {
                _woodAmount++;
                SetInteractionCount(0);
                base.Interact(_woodAmount);
                buildBridge();
            }
        }

        private void buildBridge()
        {
            if (_woodAmount == 1)
            {
               // UpdateTextToShow("You repair the bridge, you feel like you can leave soon.");
                _bridgePlanks1.SetActive(true);
            }
            if (_woodAmount == 2)
            {
             //   UpdateTextToShow("You continue repairing the bridge, you feel like your almost done.");
                _bridgePlanks2.SetActive(true);
            }
            if (_woodAmount == 3)
            {
                //UpdateTextToShow("The bridge is whole again, it looks Safe.");
           //     UpdateTextToShow("You are so proud of yourself.");
                _bridgePlanks3.SetActive(true);
                ToMainMenu();
            }
        }
        private void ToMainMenu()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
