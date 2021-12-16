using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CinematicScene.Controller
{
    public class CinematicSceneController : MonoBehaviour
    {
        private float lifeSecondsTimeStage1 = 35;
        private float lifeSecondsTimeStage2 = 8;

        [SerializeField] GameObject _sceneStage_1;
        [SerializeField] Material _skyBoxStage_1;

        [SerializeField] GameObject _sceneStage_2;
        [SerializeField] Material _skyBoxStage_2;

        private void Start()
        {
            _sceneStage_1.active = false;
            _sceneStage_2.active = false;
            StartCoroutine(LifeScene());
        }

        private IEnumerator LifeScene()
        {

            ViewSceneStage1(_skyBoxStage_1, _sceneStage_1);
            yield return new WaitForSeconds(lifeSecondsTimeStage1);
            _sceneStage_1.active = false;

            ViewSceneStage2(_skyBoxStage_2, _sceneStage_2);
            yield return new WaitForSeconds(lifeSecondsTimeStage2);
            _sceneStage_2.active = false;

            LoadGameScene();

        }

        public void ViewSceneStage1(Material skyboxStage1, GameObject sceneStage1)
        {
            RenderSettings.skybox = skyboxStage1;
            sceneStage1.active = true;
        }

        public void ViewSceneStage2(Material skyBoxStage2, GameObject sceneStage2)
        {
            RenderSettings.skybox = skyBoxStage2;
            sceneStage2.active = true;
        }

        public void LoadGameScene() {
            SceneManager.LoadScene("LevelScene");
        }
    }
}

