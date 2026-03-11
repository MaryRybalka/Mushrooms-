using UnityEngine;

namespace MushroomNocturne.Story
{
    public class CampaignProgression : MonoBehaviour
    {
        public enum ActState
        {
            Act1Arrival,
            Act2Ruins,
            Act3Choice,
            Act4Finale,
            Completed
        }

        [SerializeField] private ActState currentAct = ActState.Act1Arrival;

        public ActState CurrentAct => currentAct;

        public void AdvanceAct()
        {
            if (currentAct == ActState.Completed) return;
            currentAct += 1;
            Debug.Log($"Campaign advanced to: {currentAct}");
        }
    }
}
