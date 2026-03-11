using UnityEngine;

namespace MushroomNocturne.Puzzles
{
    public class RuneTrigger : MonoBehaviour
    {
        [SerializeField] private int runeId;
        [SerializeField] private SporeRunePuzzle puzzle;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || puzzle == null) return;
            puzzle.InputRune(runeId);
        }
    }
}
