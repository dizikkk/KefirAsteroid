using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerModel playerModel;
    [SerializeField] private PlayerView playerView;

    private WeaponController weaponController;
    private WeaponModel weaponModel;
    [SerializeField] private WeaponView weaponView;

    private AsteroidsSpawnController asteroidsSpawnController;
    private AsteroidsSpawnModel asteroidsSpawnModel;
    [SerializeField] private AsteroidsSpawnView asteroidsSpawnView;

    private UFOSpawnController ufoSpawnController;
    private UFOSpawnModel ufoSpawnModel;
    [SerializeField] private UFOSpawnView ufoSpawnView;

    private UFOController ufoController;
    private UFOModel ufoModel;
    private List<UFOView> ufoView;

    private AsteroidController asteroidController;
    private List<AsteroidView> asteroidView;

    private SmallAsteroidController smallAsteroidController;
    private List<SmallAsteroidView> smallAsteroidView;

    private EnemiesController enemiesController;

    private UIController uiController;
    private UIModel uiModel;
    [SerializeField] private UIView uiView;

    private void Start()
    {
        playerModel = new PlayerModel();
        playerController = new PlayerController(playerView,playerModel);

        weaponModel = new WeaponModel();
        weaponController = new WeaponController(weaponModel, weaponView);

        ufoView = new List<UFOView>();
        ufoModel = new UFOModel();
        ufoController = new UFOController(ufoModel, ufoView, playerController);

        smallAsteroidView = new List<SmallAsteroidView>();
        smallAsteroidController = new SmallAsteroidController(smallAsteroidView);

        asteroidView = new List<AsteroidView>();
        asteroidController = new AsteroidController(asteroidView, smallAsteroidController);

        asteroidsSpawnModel = new AsteroidsSpawnModel();
        asteroidsSpawnController = new AsteroidsSpawnController(asteroidsSpawnModel, asteroidsSpawnView, asteroidController);

        ufoSpawnModel = new UFOSpawnModel();
        ufoSpawnController = new UFOSpawnController(ufoSpawnModel, ufoSpawnView, ufoController);

        enemiesController = new EnemiesController(ufoController, asteroidController, smallAsteroidController);

        uiModel = new UIModel();
        uiController = new UIController(uiModel, uiView, weaponModel, playerController, enemiesController);
    }
}