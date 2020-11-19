using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
    public Button _optionOne;
    public Button _optionTwo;
    public Button _optionThree;
    private Scene _currentScene;

    // Start is called before the first frame update
    void Start()
    {
        _optionOne.onClick.AddListener(OptionOneClicked);
        _optionTwo.onClick.AddListener(OptionTwoClicked);
        _optionThree.onClick.AddListener(OptionThreeClicked);

        _currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OptionOneClicked()
    {
        if (ContinueStory.instance.finished())
        {
            switch (_currentScene.name)
            {
                //Room 1
                case "Room1P4":
                    SceneManager.LoadSceneAsync("Room1O1", LoadSceneMode.Single);
                    break;

                //Room 2
                case "Room2P3":
                    SceneManager.LoadSceneAsync("Room2O1", LoadSceneMode.Single);
                    break;

                //Room 3
                case "Room3P3":
                    SceneManager.LoadSceneAsync("Room3O1", LoadSceneMode.Single);
                    break;

                //Room 4
                case "Room4P2":
                    SceneManager.LoadSceneAsync("Room4O1", LoadSceneMode.Single);
                    break;

                //Last Hub Room
                case "HubRoomFinalChoice":
                    SceneManager.LoadSceneAsync("Ending1", LoadSceneMode.Single);
                    break;
            }
        } else
        {
            ContinueStory.instance.currentSection++;
            ContinueStory.instance.setProperTexts();
        }
    }

    void OptionTwoClicked()
    {
        switch (_currentScene.name)
        {
            //Room 1
            case "Room1P4":
                SceneManager.LoadSceneAsync("Room1O2", LoadSceneMode.Single);
                break;

            //Room 2
            case "Room2P3":
                SceneManager.LoadSceneAsync("Room2O2", LoadSceneMode.Single);
                break;

            //Room 3
            case "Room3P3":
                SceneManager.LoadSceneAsync("Room3O2", LoadSceneMode.Single);
                break;

            //Room 4
            case "Room4P2":
                SceneManager.LoadSceneAsync("Room4O2", LoadSceneMode.Single);
                break;

            //Last Hub Room
            case "HubRoomFinalChoice":
                SceneManager.LoadSceneAsync("Ending2", LoadSceneMode.Single);
                break;
        }
    }

    void OptionThreeClicked()
    {
        switch (_currentScene.name)
        {
            //Room 1
            case "Room1P4":
                SceneManager.LoadSceneAsync("Room1O3", LoadSceneMode.Single);
                break;

            //Room 2
            case "Room2P3":
                SceneManager.LoadSceneAsync("Room2O3", LoadSceneMode.Single);
                break;

            //Room 3
            case "Room3P3":
                SceneManager.LoadSceneAsync("Room3O3", LoadSceneMode.Single);
                break;

            //Room 4
            case "Room4P2":
                SceneManager.LoadSceneAsync("Room4O3", LoadSceneMode.Single);
                break;

            //Last Hub Room
            case "HubRoomFinalChoice":
                SceneManager.LoadSceneAsync("Ending3", LoadSceneMode.Single);
                break;
        }
    }
}
