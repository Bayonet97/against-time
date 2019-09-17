using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Objects.Interaction
{
    class WoodInteractable : InteractableObject
    {
        public override void Interact(bool hasItem)
        {
            base.Interact(hasItem);
            if (hasItem)
                Destroy(gameObject);
            //   UpdateTextToShow("You put the log in your wheelbarrow.");
        }
    }
}
