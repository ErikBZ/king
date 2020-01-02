using UnityEngine;
using UnityEngine.SceneManagement;

namespace King.Utilities
{
    public class LoadScene : MonoBehaviour
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        public void Load(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
