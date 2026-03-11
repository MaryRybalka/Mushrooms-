using System;
using System.Collections.Generic;
using UnityEngine;

namespace MushroomNocturne.Puzzles
{
    public class SporeRunePuzzle : MonoBehaviour
    {
        [SerializeField] private List<int> expectedOrder = new() { 0, 2, 1, 3 };
        [SerializeField] private GameObject rewardDoor;

        private readonly List<int> _currentInput = new();
        public event Action PuzzleSolved;

        public void InputRune(int runeId)
        {
            _currentInput.Add(runeId);

            int index = _currentInput.Count - 1;
            if (_currentInput[index] != expectedOrder[index])
            {
                _currentInput.Clear();
                return;
            }

            if (_currentInput.Count == expectedOrder.Count)
            {
                Solve();
            }
        }

        private void Solve()
        {
            if (rewardDoor != null)
            {
                rewardDoor.SetActive(false);
            }

            PuzzleSolved?.Invoke();
            Debug.Log("Spore rune puzzle solved.");
        }
    }
}
