using UnityEngine;
using System.Collections;


public class MonsterRespawn : MonoBehaviour {


	private ArrayList respawns = new ArrayList();

	void FixedUpdate () {
		foreach (Tuple<GameObject, float> r in respawns) {
			if(Time.time >= r.b) {
				r.a.SetActive(true);
				respawns.Remove(r);
				break;
			}
		}
	}

	public void RegisterForRespawn(GameObject obj, float respawnInSeconds) {
		respawns.Add(new Tuple<GameObject, float>(obj, Time.time + respawnInSeconds));
	}
}
