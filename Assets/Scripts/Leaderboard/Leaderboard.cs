using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LeaderBoard
{
    [Serializable]
    public class Player
    {
        public string Name;
        public int Score;
        public int Position;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private List<Player> _players;
        [SerializeField] private List<Cell> _cells;
        [SerializeField] private Panel _editPanel;

        [SerializeField] private Transform _itemsParent;
        [SerializeField] private Cell _itemPrefab;
        
        [SerializeField] private Player _selectedPlayer;

        public void AddPlayer(string name, int score)
        {
            Player player = new Player(name, score);
            _players.Add(player);
            
            BuildTable();
        }

        public void RemoveSelectedPlayer()
        {
            if (_selectedPlayer == null)
            {
                return;
            }
            else
            {
                _players.Remove(_selectedPlayer);
                _selectedPlayer = null;
            }
            
            BuildTable();
        }

        public void Edit(string name, int score)
        {
            int indexEditingPlayer = _players.IndexOf(_selectedPlayer);
            Player editingPlayer = _players[indexEditingPlayer];

            editingPlayer.Name = name;
            editingPlayer.Score = score;
            
            BuildTable();
        }

        private void BuildTable()
        {
            int playersCount = _players.Count -1;
            int childCount = _itemsParent.childCount - 1;
            
            if (childCount < playersCount)
            {
                var cell = Instantiate(_itemPrefab, _itemsParent);
                _cells.Add(cell);
            }
            else if(childCount > playersCount)
            {
                Destroy(_itemsParent.GetChild(childCount).gameObject);
                _cells.Remove(_cells.Last());
            }
            
            SortPlayers();

            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].Position = i +1 ;
                _cells[i].SetPlayer(_players[i]);
                
                _cells[i].PickPlayer += (player) => _selectedPlayer = player;
                _cells[i].EditPlayer += () => _editPanel.ShowPanel();
            }
        }

        private void SortPlayers()
        {
            var playersSorted= from p in _players
                orderby p.Score descending
                select p;

            _players = playersSorted.ToList();
        }
            
    }
}
