using Configurations;
using UnityEngine;

namespace Behaviors
{
    public class GameBehaviour : MonoBehaviour
    {
        [SerializeField, Header("GlobalSettings")]
        private GlobalSettings globalSettings = new GlobalSettings();
    
        public GlobalSettings GlobalSettings
        {
            get { return globalSettings; }
        }
    
        public void UpdateData(GlobalSettings data)
        {
            globalSettings = data;
        }
    }
}
