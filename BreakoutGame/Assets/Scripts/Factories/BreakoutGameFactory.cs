using System.Collections;
using System.Collections.Generic;
using BreakoutGame;
using UnityEngine;

public class BreakoutGameFactory : MonoBehaviour
{
	[SerializeField]
	private GameObject _breakoutGamePrefab;

	public BreakoutGameController CreateBreakoutGame(BreakoutGameConfig config)
	{
        var breakoutGameObject = Instantiate(_breakoutGamePrefab);
        breakoutGameObject.name = _breakoutGamePrefab.name;
        var breakoutGameController = breakoutGameObject.GetComponent<BreakoutGameController>();
        return breakoutGameController;
	}
}
