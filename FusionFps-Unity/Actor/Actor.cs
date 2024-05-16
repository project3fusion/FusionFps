using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;

namespace FusionFPS.Actors {
    public abstract class Actor : NetworkBehaviour {
        public NetworkVariable<bool> isActive = new NetworkVariable<bool>(true);
    }
}