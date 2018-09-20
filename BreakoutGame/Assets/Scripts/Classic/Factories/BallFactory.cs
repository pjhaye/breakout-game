using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutGame
{
    public class BallFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ballPrefab;        
        
        public Ball CreateBall(BallConfig ballConfig)
        {
            var ballGameObject = Instantiate(_ballPrefab);
            ballGameObject.name = _ballPrefab.name;
            var ball = ballGameObject.GetComponent<Ball>();
            ball.SetRadius(ballConfig.ballRadius);
            return ball;
        }
    }
}