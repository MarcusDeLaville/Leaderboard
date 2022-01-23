using System;
using UnityEngine;
using UnityEngine.UI;
namespace LeaderBoard
{
    public enum Redacting
    {
        Add,
        Edit
    }
    
    public class EditingPlayer : MonoBehaviour
    {
        [SerializeField] private Redacting _redactingType;
        [SerializeField] private Leaderboard _leaderboard;
        
        [SerializeField] private InputField _nameInput;
        [SerializeField] private InputField _scoreInput;

        [SerializeField] private Button _editButton;

        private void OnEnable()
        {
            _editButton.onClick.AddListener(Edit);
        }

        private void OnDisable()
        {
            _editButton.onClick.RemoveListener(Edit);
        }

        private void Edit()
        {
            if (_nameInput.text == "" && _scoreInput.text == "")
            {
                return;
            }

            string name = _nameInput.text;
            int score = Convert.ToInt32(_scoreInput.text);
            
            switch (_redactingType)
            {
                case Redacting.Add:
                    _leaderboard.AddPlayer(name, score);
                    break;
                case Redacting.Edit:
                    _leaderboard.Edit(name, score);
                    break;
            }
        }
    }
}