using Mirror;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace GabrielZ.PA.Lobby
{
    public class NetworkGamePlayerPA : NetworkBehaviour
    {
        [SyncVar]
        private string displayName = "Loading...";

        private NetworkManagerPA room;

        private NetworkManagerPA Room
        {
            get
            {
                if (room != null) { return room; }
                return room = NetworkManager.singleton as NetworkManagerPA;
            }
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);

            Room.GamePlayers.Add(this);
        }

        public void OnNetworkDestroy()
        {
            Room.GamePlayers.Remove(this);
        }

        [Server]
        public void SetDisplayName(string displayName)
        {
            this.displayName = displayName;
        }
    }
}
