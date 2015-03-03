using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Checkpoint : MonoBehaviour
    {
        private List<IPlayerRespawnListner> _listners;
 
        public void Awake()
        {
            _listners = new List<IPlayerRespawnListner>();
        }

        public void PlayerHitCheckpoint()
        {
            StartCoroutine(PlayHitCheckpointCo(LevelManager.Instance.CurrentTimeBonus));
        }

        private IEnumerator PlayHitCheckpointCo(int bonus)
        {
            FloatingText.Show("Checkpoint!", "CheckpointText", new CenteredTextPositioner(.5f));
            yield return new WaitForSeconds(0.5f);
            FloatingText.Show(string.Format(" {0} Time Bonus!", bonus), "CheckpointText", new CenteredTextPositioner(.5f));

        }

        public void PlayerLeftCheckpoint()
        {
            
        }

        public void SpawnPlayer(Player player)
        {
            player.RespawnAt(transform);

            foreach (var listener in _listners)
                listener.OnPlayerRespawnInThisCheckpoint(this, player);
        }

        public void AssignObjectToCheckpoint(IPlayerRespawnListner listener)
        {
            _listners.Add(listener);
        }

    }
