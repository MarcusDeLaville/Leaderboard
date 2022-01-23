using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LeaderBoard
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        public Action<Player> PickPlayer;
        public Action EditPlayer;
    
        [SerializeField] private Text _name;
        [SerializeField] private Text _score;
        [SerializeField] private Text _position;
    
        private Player _currentPlayer;
    
        public void OnPointerClick(PointerEventData eventData)
        {
            PickPlayer?.Invoke(_currentPlayer);

            if (eventData.pointerId == -2)
            {
                EditPlayer?.Invoke();
            }
        }

        public void SetPlayer(Player player)
        {
            _currentPlayer = player;

            _name.text = _currentPlayer.Name;
            _score.text = _currentPlayer.Score.ToString();
            _position.text = _currentPlayer.Position.ToString();
        }
    }
}
