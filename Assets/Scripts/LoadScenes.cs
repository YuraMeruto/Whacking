using UnityEngine.SceneManagement;
public class LoadScenes
{
    static LoadScenes instance = new LoadScenes();
    public static LoadScenes Instance
    {
        get
        {
            return instance;
        }
    }

    public void LoadScene(string scene_name)
    {

        SceneManager.LoadScene(scene_name);
    }
}
