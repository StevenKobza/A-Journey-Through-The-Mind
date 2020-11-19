
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueStory : MonoBehaviour
{
    public Button button;
    public Button _doorButton;
    public Button _settingsButton;

    public Text displayText;
    public Text displayNameText;
    private Text buttonText;

    private Scene currentScene;

    public int currentSection;

    public bool multiChoice;
    public bool hubRoom;
    private bool skipLine;
    private bool spaceHeld;

    public Image _spriteRenderer;
    private Image _bgImage;

    public Sprite Orpheus;
    public Sprite eurydiceStage0;
    public Sprite eurydiceStage1;
    public Sprite eurydiceStage2;
    public Sprite eurydiceStage3;

    public static ContinueStory instance;

    public Font _font;

    private List<string> sceneZeroStrings;
    private List<string> sceneOneStrings;
    private List<string> sceneTwoStrings;
    private List<string> sceneThreeStrings;
    private List<string> sceneFourStrings;
    private List<string> sceneFiveStrings;
    private List<string> sceneSixStrings;
    private List<string> sceneSevenStrings;
    private List<string> sceneEightStrings;
    private List<string> endingOneStrings;
    private List<string> endingTwoStrings;
    private List<string> endingThreeStrings;
    private List<string> currentStrings;
    private List<string> currentCharacters;
    private Image[] bgImages;

    private Text[] _texts;
    
    public AudioSource audioSource;
    public AudioClip _click;
    public AudioSource _bgAudio;
    public AudioClip _bgClip;

    private bool SceneLoaded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        _settingsButton.onClick.AddListener(clickedSettings);
        currentScene = SceneManager.GetActiveScene();
        if (multiChoice == false)
        {
            button.onClick.AddListener(ClickedButton);
        } 
        if (hubRoom == true)
        {
            _doorButton.onClick.AddListener(ClickedDoor);
            _doorButton.gameObject.GetComponent<Image>().color = Color.white;
        }
        addSpecificTexts();
        displayText.enabled = true;
        if (displayText != null && displayNameText != null)
        {
            displayText.font = _font;
            displayNameText.font = _font;
        }
        _texts = GetComponentsInChildren<Text>();
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].font = _font;
        }
        setProperTexts();
        instance = this;
        bgImages = GetComponentsInChildren<Image>();
        for (int i = 0; i < bgImages.Length; i++)
        {
            if (bgImages[i].CompareTag("bgImage"))
            {
                _bgImage = bgImages[i];
                Debug.Log(_bgImage.name);
            }
        }
        if (multiChoice == false)
        {
            buttonText = button.gameObject.GetComponentInChildren<Text>();
            buttonText.text = "Continue";
        }
        playBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (currentSection >= currentStrings.Count - 1 && currentScene.name.Contains("HubRoom") && multiChoice == false && hubRoom == true)
        {
            button.gameObject.SetActive(false);
            _doorButton.gameObject.GetComponent<Image>().color = new Color(0.753f, 0.557f, 0.525f, 1.0f);
        }
        
        if (Input.GetKey(KeyCode.Space) && spaceHeld == false)
        {
            spaceHeld = true;
            ClickedButton();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceHeld = false;
        }
    }

    void ClickedDoor()
    {
        if (currentSection < currentStrings.Count-1)
        {
            Debug.Log("fail");
        } else
        {
            switch (currentScene.name)
            {
                case "HubRoom":
                    SceneManager.LoadSceneAsync("Room1", LoadSceneMode.Single);
                    break;
                case "HubRoom2":
                    SceneManager.LoadSceneAsync("Room2", LoadSceneMode.Single);
                    break;
                case "HubRoom3":
                    SceneManager.LoadSceneAsync("Room3", LoadSceneMode.Single);
                    break;
                case "HubRoomFinal":
                    SceneManager.LoadSceneAsync("Room4", LoadSceneMode.Single);
                    break;
            }
        }
    }

    void ClickedButton()
    {
        Debug.Log(currentScene.name);
        if (currentSection >= currentStrings.Count - 1)
        {
            Debug.Log("why won't you die");
            switch (currentScene.name)
            {
                //Room 1 different Scenes
                case "Room1":
                    SceneManager.LoadSceneAsync("Room1P2", LoadSceneMode.Single);
                    break;
                case "Room1P2":
                    SceneManager.LoadSceneAsync("Room1P3", LoadSceneMode.Single);
                    break;
                case "Room1P3":
                    SceneManager.LoadSceneAsync("Room1P4", LoadSceneMode.Single);
                    break;
                case "Room1O1":
                    SceneManager.LoadSceneAsync("HubRoom2", LoadSceneMode.Single);
                    break;
                case "Room1O2":
                    SceneManager.LoadSceneAsync("HubRoom2", LoadSceneMode.Single);
                    break;
                case "Room1O3":
                    SceneManager.LoadSceneAsync("HubRoom2", LoadSceneMode.Single);
                    break;

                //Room 2 Different Scenes
                case "Room2":
                    SceneManager.LoadSceneAsync("Room2P2", LoadSceneMode.Single);
                    break;
                case "Room2P2":
                    SceneManager.LoadSceneAsync("Room2P3", LoadSceneMode.Single);
                    break;
                case "Room2O1":
                    SceneManager.LoadSceneAsync("HubRoom3", LoadSceneMode.Single);
                    break;
                case "Room2O2":
                    SceneManager.LoadSceneAsync("HubRoom3", LoadSceneMode.Single);
                    break;
                case "Room2O3":
                    SceneManager.LoadSceneAsync("HubRoom3", LoadSceneMode.Single);
                    break;

                //Room 3 Different Scenes
                case "Room3":
                    SceneManager.LoadSceneAsync("Room3P2", LoadSceneMode.Single);
                    break;
                case "Room3P2":
                    SceneManager.LoadSceneAsync("Room3P3", LoadSceneMode.Single);
                    break;
                case "Room3O1":
                    SceneManager.LoadSceneAsync("HubRoomFinal", LoadSceneMode.Single);
                    break;
                case "Room3O2":
                    SceneManager.LoadSceneAsync("HubRoomFinal", LoadSceneMode.Single);
                    break;
                case "Room3O3":
                    SceneManager.LoadSceneAsync("HubRoomFinal", LoadSceneMode.Single);
                    break;

                //Room 4 Different Scenes
                case "Room4":
                    SceneManager.LoadSceneAsync("Room4P2", LoadSceneMode.Single);
                    break;
                case "Room4O1":
                    SceneManager.LoadSceneAsync("HubRoomFinal 1", LoadSceneMode.Single);
                    break;
                case "Room4O2":
                    SceneManager.LoadSceneAsync("HubRoomFinal 1", LoadSceneMode.Single);
                    break;
                case "Room4O3":
                    SceneManager.LoadSceneAsync("HubRoomFinal 1", LoadSceneMode.Single);
                    break;

                //Hub Rooms
                case "HubRoom":
                    SceneManager.LoadSceneAsync("Room1", LoadSceneMode.Single);
                    break;
                case "HubRoom2":
                    SceneManager.LoadSceneAsync("Room2", LoadSceneMode.Single);
                    break;
                case "HubRoom3":
                    SceneManager.LoadSceneAsync("Room3", LoadSceneMode.Single);
                    break;
                case "HubRoomFinal":
                    SceneManager.LoadSceneAsync("Room4", LoadSceneMode.Single);
                    break;
                case "HubRoomFinal 1":
                    SceneManager.LoadSceneAsync("HubRoomFinalChoice", LoadSceneMode.Single);
                    break;

                //Endings
                case "Ending1":
                    Debug.Log("why won't you run");
                    SceneManager.LoadScene("Starting", LoadSceneMode.Single);
                    break;
                case "Ending2":
                    SceneManager.LoadSceneAsync("Ending2P2", LoadSceneMode.Single);
                    break;
                case "Ending2P2":
                    SceneManager.LoadSceneAsync("HubRoom", LoadSceneMode.Single);
                    break;
                case "Ending3":
                    SceneManager.LoadSceneAsync("HubRoom", LoadSceneMode.Single);
                    break;
            }
        } else if (currentSection >= currentStrings.Count - 2 && currentScene.name == "Ending3")
        {
            _bgImage.color = Color.black;
            currentSection++;
            setProperTexts();
            buttonText.text = "Restart Game";

        } else if (currentSection >= currentStrings.Count - 2 && currentScene.name.Contains("Ending"))
        {

            currentSection++;
            setProperTexts();
            buttonText.text = "Restart Game";
        }
        
        else
        {
            currentSection++;
            setProperTexts();
        }
    }

    void clearList(string scene)
    {
        if (currentStrings != null)
        {
            currentStrings.Clear();
        }

        if (currentCharacters != null)
        {
            currentStrings.Clear();
        }

        currentCharacters = new List<string>();
        currentStrings = new List<string>();
        switch(scene)
        {
            case "zero":
                if (sceneZeroStrings != null)
                {
                    sceneZeroStrings.Clear();
                }
                sceneZeroStrings = new List<string>();
                break;
            case "one":
                if (sceneOneStrings != null)
                {
                    sceneOneStrings.Clear();
                }
                sceneOneStrings = new List<string>();
                break;
            case "two":
                if (sceneTwoStrings != null)
                {
                    sceneTwoStrings.Clear();
                }
                sceneTwoStrings = new List<string>();
                break;
            case "three":
                if (sceneThreeStrings != null)
                {
                    sceneThreeStrings.Clear();
                }
                sceneThreeStrings = new List<string>();
                break;
            case "four":
                if (sceneFourStrings != null)
                {
                    sceneFourStrings.Clear();
                }
                sceneFourStrings = new List<string>();
                break;
            case "five":
                if (sceneFiveStrings != null)
                {
                    sceneFiveStrings.Clear();
                }
                sceneFiveStrings = new List<string>();
                break;
            case "six":
                if (sceneSixStrings != null)
                {
                    sceneSixStrings.Clear();
                }
                sceneSixStrings = new List<string>();
                break;
            case "seven":
                if (sceneSevenStrings != null)
                {
                    sceneSevenStrings.Clear();
                }
                sceneSevenStrings = new List<string>();
                break;
            case "eight":
                if (sceneEightStrings != null)
                {
                    sceneEightStrings.Clear();
                }
                sceneEightStrings = new List<string>();
                break;
            case "eOne":
                if (endingOneStrings != null)
                {
                    endingOneStrings.Clear();
                }
                endingOneStrings = new List<string>();
                break;
            case "eTwo":
                if (endingTwoStrings != null)
                {
                    endingTwoStrings.Clear();
                }
                endingTwoStrings = new List<string>();
                break;
            case "eThree":
                if (endingThreeStrings != null)
                {
                    endingThreeStrings.Clear();
                }
                endingThreeStrings = new List<string>();
                break;
        }
    }

    void addSpecificTexts()
    {
        switch (currentScene.name)
        {
            //Room 1 Different Scenes
            case "Room1":
                clearList("one");
                sceneOneStrings.Add("This looks familiar…It’s a high school. My old high school! I remember now. This is where we first met.");
                sceneOneStrings.Add("We were in the same class and one day she approached me shyly, arms protectively crossed over her chest, " +
                    "and asked me if I had notes from the past couple days because she had been home with a cold.");
                sceneOneStrings.Add("I hadn’t really spoken to her much before. She was kind of shy and awkward - I suppose I was too. " +
                    "Maybe that’s why she felt comfortable approaching me of all people. After that, we started sharing notes with each other in class.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneOneStrings;
                break;
            case "Room1P2":
                clearList("one");
                break;
            case "Room1P3":
                clearList("one");
                break;
            case "Room1P4":
                clearList("one");
                sceneOneStrings.Add("It wouldn’t kill me to miss it, but I was still young enough that I’d get in trouble for ditching. " +
                    "And I remember exactly what I said that day. I looked her in her eyes, her grey stormy eyes, and said:");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneOneStrings;
                break;
            case "Room1O1":
                clearList("one");
                sceneOneStrings.Add("I said “yes.” I said “absolutely yes!” Between our hectic schedules, hers especially, when was the next chance we’d have to hang out outside of school?");
                sceneOneStrings.Add("I had to take it. We hung out at the library for a couple hours, got damn near kicked out for giggling loudly and bothering some other patrons, " +
                    "but somehow we managed to study for our chemistry test.");
                sceneOneStrings.Add("After that we went out and got pizza at a popular by-the-slice place nearby. She made fun of me because I liked pineapples on mine, but I didn’t care.");
                sceneOneStrings.Add("I loved hearing her laugh. I think that’s when I realized I liked her. I liked her quite a lot. So I told her. And it turned out that she liked me too.");
                sceneOneStrings.Add("By summer’s end, we had begun to hang out often, and texted nearly every day. We had some nice date nights despite our lousy teenage income: mini golf, bowling, the new taco place that had opened up. ");
                sceneOneStrings.Add("It was always fun, because I was with her. Everything was fun with her. We made each other laugh a lot. I don’t think I had ever felt as worthy of love as she made me feel.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneOneStrings;
                break;
            case "Room1O2":
                clearList("one");
                sceneOneStrings.Add("“Maybe another day.” My practise couldn’t be put off, or else I’d get shit from my mom. " +
                    "I suggested to her that we’d find another day to hang out outside of school. We continued to share notes during class.");
                sceneOneStrings.Add("One day one of the popular girls noticed and she swiped the notebook from her hand, " +
                    "read it aloud to the other students and started mocking her, and me. She made fun of her for being nice to me, and me for being a loser.");
                sceneOneStrings.Add("She also accused her of liking me. She blushed and got angry, but never denied it. " +
                    "After class that day, we finally made our trip to the library to study together.");
                sceneOneStrings.Add("She assured me that that popular girl was being ridiculous, so I asked her: " +
                    "“about us being losers, or about you liking me?” And she looked me in the eyes, then bashfully back down at her notebook. “You’re not a loser.”");
                sceneOneStrings.Add("I noticed her cheeks turn rosy as I looked back down at my notes as well. I cleared my throat and muttered “I like you too.”");
                sceneOneStrings.Add("By summer’s end, we had begun to hang out often, and texted nearly every day. We had some nice date nights despite our lousy teenage income: mini golf, bowling, the new taco place that had opened up. ");
                sceneOneStrings.Add("It was always fun, because I was with her. Everything was fun with her. We made each other laugh a lot. I don’t think I had ever felt as worthy of love as she made me feel.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneOneStrings;
                break;
            case "Room1O3":
                clearList("one");
                sceneOneStrings.Add("I knew her theatre practice was really important to her, so I figured since I was busy maybe she could use the day off.");
                sceneOneStrings.Add("I wanted to make sure she could keep her focus where it belonged, and I wanted to do the same. She could go home, rest, " +
                    "and do some studying in her own time and I could go to my practise and then study later in the evening.");
                sceneOneStrings.Add("She seemed slightly disappointed, but agreed. We continued sharing notes, though it felt a bit more subdued over the following weeks. " +
                    "We didn’t get a chance to hang out properly until summer break a few weeks later, when we went to a cafe to catch up.");
                sceneOneStrings.Add("We slowly started to reconnect and had admitted that we liked each other over the summer.");
                sceneOneStrings.Add("By summer’s end, we had begun to hang out often, and texted nearly every day. We had some nice date nights despite our lousy teenage income: mini golf, bowling, the new taco place that had opened up. ");
                sceneOneStrings.Add("It was always fun, because I was with her. Everything was fun with her. We made each other laugh a lot. I don’t think I had ever felt as worthy of love as she made me feel.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneOneStrings;
                break;

            //Room 2 Different Scenes
            case "Room2":
                clearList("three");
                sceneThreeStrings.Add("A forest? When were we in a forest? … The camping trip. I had almost forgotten about it. After graduating, we decided to go on a camping trip during that summer.");
                sceneThreeStrings.Add("It was a popular activity for a lot of recent graduates from our school. We wanted to try and avoid the other students while camping and " +
                    "just have a fun time to ourselves, but our parents didn’t really like the idea of us going alone.");
                sceneThreeStrings.Add("So, we went with some of her friends and I brought along one of the few friends I had, Billy, whom I had known since the third grade.");
                sceneThreeStrings.Add("Despite having our other friends, we spent most of our time with each other. One evening, the others had gone off on a hike, " +
                    "Billy included since he was bored with me spending time with her.");
                sceneThreeStrings.Add("While they were gone, it had started to get dark. We were worried that they wouldn’t make it back, so we waited outside as the sky slowly shifted to a deep, dark indigo");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneThreeStrings;
                break;
            case "Room2P2":
                clearList("three");
                sceneThreeStrings.Add("This lantern... we used it to light the campsite because we couldn’t figure out how to get the campfire going between us. It was pretty scary, not being able to see more than fifteen feet in front of you. ");
                sceneThreeStrings.Add("Terrifying. The only other light was from the moon and stars. We sent our friends texts, but expected to have to wait some time for a response. " +
                    "The reception was spotty out in the woods and we knew it might be a while even if they got the messages.");
                sceneThreeStrings.Add("While we waited, we tried to keep busy. She taught me the rules to play blackjack, and I taught her how to spot some constellations in the sky. " +
                    "After a while of waiting with no response, we heard a rustling come from the woods around us.");
                currentStrings = sceneThreeStrings;
                break;
            case "Room2P3":
                clearList("three");
                sceneThreeStrings.Add("We called out, but no one answered. Then we heard another rustling. “Should we go check it out?” she whispered to me. I gazed into her eyes. " +
                    "She looked a bit worried, but not entirely scared. I, on the other hand, was about ready to start quaking. I said:");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneThreeStrings;
                break;
            case "Room2O1":
                clearList("three");
                sceneThreeStrings.Add("“Let’s check it out.” I tried to seem brave, taking a deep inhale of courage and cool night air. " +
                    "She nodded and slowly started approaching the source of the sound. I stood just behind her, holding the lantern so we could see.");
                sceneThreeStrings.Add("As we tiptoed over, another rustle of branches filled the air. I think she was holding her breath at that point, " +
                    "trying to avoid making even the smallest of sounds. As we neared the bush,");
                sceneThreeStrings.Add("I angled the lantern in an attempt to focus the light on the space behind it, more of it being illuminated as we got closer, " +
                    "until- “BOO!” The both of us shrieked, filling the once calm night with our high pitched squeals. And then the sound of laughter.");
                sceneThreeStrings.Add("“I told you he’d scream like a girl.” When I realized what was going on, I held the lantern properly once " +
                    "more to see that it was the trekking group that had left earlier, all keeled over in laughter. It seemed to have all been Billy’s idea.");
                sceneThreeStrings.Add("As I held my stomach, taking in deep breaths in an attempt to regain my composure, I realized even she was laughing now. I released a single small chuckle.");
                sceneThreeStrings.Add("I remained a bit uneasy for the rest of the evening. But we all gathered around the fire that we finally managed to start and chatted for a while before heading off to sleep, and I eventually felt a bit better.");
                sceneThreeStrings.Add("She teased me a bit about how afraid I had been, but when she made fun of me, it never hurt. It only made me feel centered and loved.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneThreeStrings;
                break;
            case "Room2O2":
                clearList("three");
                sceneThreeStrings.Add("“Let’s just stay here and see if it happens again.” I kept my eyes on the spot in the darkness where I was quite sure the sound occurred. “Okay. I’m sure it was nothing anyway,” she responded.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("We turned back to the light of our lantern and the cards laid out. She was about to draw a card when we heard the noise again. “It’s still there,” she said.");
                currentCharacters.Add("Eurydice");
                sceneThreeStrings.Add(" “It’s probably just a raccoon, or… or maybe a fox or something,” I responded, trying to rationalize it the best I could. “Or a bear,” she said, looking up at me. ");
                currentCharacters.Add("Eurydice");
                sceneThreeStrings.Add("I could tell she was trying to look brave, but she was also gritting her teeth the way she did when she was anxious about something.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("“Well, if we don’t look, we won’t have to know.” I chuckled awkwardly. We heard the sound a couple more times before the hiking group finally returned. Billy gave me a playful punch to the shoulder as he took a seat beside me.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("“What was that for?” I whined. “We were making all those noises, trying to pull one over on you, and you didn’t even go check it out. Some boyfriend you are,” he laughed, slouching in his seat.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("“That was you?” I should have known Billy would try to pull a prank to impress the girls. I doubt it would have worked anyway.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("I remained a bit uneasy for the rest of the evening. But we all gathered around the fire that we finally managed to start and chatted for a while before heading off to sleep, and I eventually felt a bit better.");
                currentCharacters.Add("Orpheus");
                sceneThreeStrings.Add("She teased me a bit about how afraid I had been, but when she made fun of me, it never hurt. It only made me feel centered and loved.");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneThreeStrings;
                break;
            case "Room2O3":
                clearList("three");
                sceneThreeStrings.Add("“Maybe we should get back in the tent. Just in case.” I felt protective all of a sudden. Although, admittedly, my knees had begun to shake a bit too. She bit her bottom lip. " +
                    "It didn’t seem like she was scared until she noticed I was. And I was sure she had noticed.");
                sceneThreeStrings.Add("“Okay.” She cleaned up her card deck and we closed ourselves off inside the tent. I wanted to speak with her, to tell her not to worry and that we’d be fine, but I was also trying to listen to the world outside the tent.");
                sceneThreeStrings.Add("I wasn’t sure what to do. My biggest fear was that the rustling was from a bear. I figured that had to be the worst case scenario. ");
                sceneThreeStrings.Add("A few minutes later,");
                sceneThreeStrings.Add("we heard the sounds of chatter and laughter from our friends who had gone on the hike. We left the tent to greet them. The sounds had mysteriously stopped from then on and everyone acted like nothing had happened, though I had my suspicions.");
                sceneThreeStrings.Add("I remained a bit uneasy for the rest of the evening. But we all gathered around the fire that we finally managed to start and chatted for a while before heading off to sleep, and I eventually felt a bit better.");
                sceneThreeStrings.Add("She teased me a bit about how afraid I had been, but when she made fun of me, it never hurt. It only made me feel centered and loved.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneThreeStrings;
                break;

            //Room 3 Different Scenes
            case "Room3":
                clearList("five");
                sceneFiveStrings.Add("Now I definitely remember this - the beach where we made wishes for our lives and our futures. We put them in bottles and let them float out to sea, and we’d never felt closer to each other.");
                sceneFiveStrings.Add("Two little bottles in the vast, unimaginable expanse of the ocean. A lot like us, I suppose. We arrived at the beach with a small picnic basket, " +
                    "filled with sushi, fresh fruit, and sodapop. After enjoying our meal and exploring the beach for crabs, we had an idea.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFiveStrings;
                break;
            case "Room3P2":
                clearList("five");
                sceneFiveStrings.Add("We had some leftover bottles from our drinks, and she had a notebook in her bag. So we decided to write down our wishes, put them in the bottles, and let them float away");
                currentStrings = sceneFiveStrings;
                break;
            case "Room3P3":
                clearList("five");
                sceneFiveStrings.Add("I knew exactly what I wanted to write in mine too. I took the pen, and I wrote “I wish…”:");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFiveStrings;
                break;
            case "Room3O1":
                clearList("five");
                sceneFiveStrings.Add("It was all I’d ever really wanted. Because no matter what else happened, I knew it’d be worth it if she was there. I knew we’d get through it if we were together. ");
                sceneFiveStrings.Add("As I tucked the wish into the bottle, I glanced over at her doing the same, windy sea air blowing her hair into her face. She smiled at me as she closed up her bottle.");
                sceneFiveStrings.Add("“I suppose I’m not allowed to ask what you’ve written,” she chuckled. “It might not come true if I tell you,” I laughed back.");
                sceneFiveStrings.Add("We walked to the edge of the pier and tossed them into the ocean. The very idea of my wish filled me with hope. It felt like it was the day that everything would change.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFiveStrings;
                break;
            case "Room3O2":
                clearList("five");
                sceneFiveStrings.Add("If I had my dream job, I could be the best version of myself for her. I could come home from work happy and feeling like I was making a difference in the world. ");
                sceneFiveStrings.Add("I could probably even support whatever she wanted to do, if she needed any help. I glanced out to the sea, imagining our bright future.");
                sceneFiveStrings.Add("“I suppose I’m not allowed to ask what you’ve written,” she chuckled. “It might not come true if I tell you,” I laughed back.");
                sceneFiveStrings.Add("We walked to the edge of the pier and tossed them into the ocean. The very idea of my wish filled me with hope. It felt like it was the day that everything would change.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFiveStrings;
                break;
            case "Room3O3":
                clearList("five");
                sceneFiveStrings.Add("I could have whatever I wanted, and she would be taken care of, free to pursue whatever she wanted as well.");
                sceneFiveStrings.Add("And we’d never have to worry about having our needs met, or our dreams. It would all be within our grasp.");
                sceneFiveStrings.Add("“I suppose I’m not allowed to ask what you’ve written,” she chuckled. “It might not come true if I tell you,” I laughed back.");
                sceneFiveStrings.Add("We walked to the edge of the pier and tossed them into the ocean. The very idea of my wish filled me with hope. It felt like it was the day that everything would change.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFiveStrings;
                break;

            //Room 4 Different Scenes
            case "Room4":
                clearList("seven");
                sceneSevenStrings.Add("Oh… oh no. I know exactly what this memory is. The last day that I saw her. She didn’t tell me why she had to leave, or where she was going, or even why.");
                sceneSevenStrings.Add("I had no idea if this was brought on by me, or by something intrinsic in her that needed to move on. I didn’t know, and she struggled to explain it to me in any way that made sense.");
                sceneSevenStrings.Add("She messaged me one day, out of the blue, and told me to meet her here. I had a feeling something was wrong. In fact, " +
                    "I had felt that way for a couple months before that day but I thought perhaps she was just in a normal slump that would pass with time, or that maybe I was overanalyzing it. ");
                
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneSevenStrings;
                break;
            case "Room4P2":
                clearList("seven");
                sceneSevenStrings.Add("We met, she told me that she had to go, and she asked me to take something with me to remember her by. I could tell it pained her to do this, " +
                    "so I’m sure she had a good reason, but I still felt hurt and confused as I glanced at the mementos before me:");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneSevenStrings;
                break;
            case "Room4O1":
                clearList("seven");
                sceneSevenStrings.Add("Maybe I was feeling nostalgic, but seeing our old notes written inside the notebook, her handwriting from all the messages we sent back and forth during class, " +
                    "it made me feel a peculiar mix of happiness and sadness.");
                sceneSevenStrings.Add("It seemed like the perfect way to remember her. I could always see how awkward and shy we were, and related to how we left off, more mature, with a bit more wisdom, but still carrying a lust for life.");
                sceneSevenStrings.Add("I held the memento in my hands, clutching it against my chest. “I still don’t understand, why do you have to leave?” I asked her. ");
                sceneSevenStrings.Add("“It’s hard to explain…” she crossed her arms over her body. “Try me,” I challenged her. “It’s just something I have to do.” “That’s not enough, I have to know why.” ");
                sceneSevenStrings.Add("“I’m sorry,” she said, her voice cracking as she blinked tears out of her eyes. Before I could say anything else, she turned and ran off in the other direction. And I never saw her again.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Eurydice");
                currentStrings = sceneSevenStrings;
                break;
            case "Room4O2":
                clearList("seven");
                sceneSevenStrings.Add("It made sense to take the lantern to me. It was symbolic of how we approached the darkness, the uncertainty, how we conquered or failed to conquer the fear.");
                sceneSevenStrings.Add("We might have done well, we might not have, but we faced it nonetheless. And that’s what truly mattered.");
                sceneSevenStrings.Add("I held the memento in my hands, clutching it against my chest. “I still don’t understand, why do you have to leave?” I asked her. ");
                sceneSevenStrings.Add("“It’s hard to explain…” she crossed her arms over her body. “Try me,” I challenged her. “It’s just something I have to do.” “That’s not enough, I have to know why.” ");
                sceneSevenStrings.Add("“I’m sorry,” she said, her voice cracking as she blinked tears out of her eyes. Before I could say anything else, she turned and ran off in the other direction. And I never saw her again.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Eurydice");
                currentStrings = sceneSevenStrings;
                break;
            case "Room4O3":
                clearList("seven");
                sceneSevenStrings.Add("I was surprised at first, I thought perhaps she hadn’t even thrown hers in the ocean that day, but I knew what I saw.");
                sceneSevenStrings.Add("She revealed that she made a second wish that day, one that she decided to keep for herself. ");
                sceneSevenStrings.Add("She placed it inside of this new bottle, and I could keep it. “Keep it inside the bottle, or else it won’t come true,” she laughed sadly. I felt a pang of sorrow. ");
                sceneSevenStrings.Add("Part of me would always want to know what it said. Maybe one day…");
                sceneSevenStrings.Add("I held the memento in my hands, clutching it against my chest. “I still don’t understand, why do you have to leave?” I asked her. ");
                sceneSevenStrings.Add("“It’s hard to explain…” she crossed her arms over her body. “Try me,” I challenged her. “It’s just something I have to do.” “That’s not enough, I have to know why.” ");
                sceneSevenStrings.Add("“I’m sorry,” she said, her voice cracking as she blinked tears out of her eyes. Before I could say anything else, she turned and ran off in the other direction. And I never saw her again.");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Orpheus");
                currentCharacters.Add("Eurydice");
                currentCharacters.Add("Eurydice");
                currentStrings = sceneSevenStrings;
                break;

            //Hub Rooms
            case "HubRoom":
                clearList("zero");
                sceneZeroStrings.Add("Where am I? This doesn’t look familiar to me. The last thing I remember… actually, I can’t even recall. How did I get here?");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("Hello? Who’s there? No… no, it can’t be. Is it really you?");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("It is you. I haven’t seen you since… since… I don’t even remember.");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("Yes. It’s been a very long time. I’m glad you remember me.");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("How could I ever forget?");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("But you don't remember the last time you saw me?");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("No, I’m sure I do remember, it’s just not coming to me right now. I remember, I just can’t recall it.");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("Excuses, excuses.");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("Do you know what this place is then? Do you know why I’m here?");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("I can’t tell you why you’re here, you’ll have to figure that out for yourself. What I can tell you is that this place is a digital projection of your mind.");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("My mind? I don’t understand. How did I get here? Is this real?");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("It might not be real in the traditional sense, but you are still experiencing it. So, I suppose, it is still in a sense ‘real.’");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("I… I still don’t understand. I don’t understand anything.");
                currentCharacters.Add("Orpheus");
                sceneZeroStrings.Add("It will all become clear. These doors you see around the room? These are memories. Memories that have stuck with you for one reason or another. ");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("The answers you seek lie in these rooms. It is a journey you will have to take alone, but I will be waiting here when you return from each.");
                currentCharacters.Add("Eurydice Ghost");
                sceneZeroStrings.Add("This is so strange, but I’ll do as you say. I don’t think I have much of a choice anyway.");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneZeroStrings;
                break;
            case "HubRoom2":
                clearList("two");
                sceneTwoStrings.Add("Welcome back. How did it go?");
                currentCharacters.Add("Eurydice Less Ghost");
                sceneTwoStrings.Add("I saw the day we first met, back in school. It’s so strange, I remembered nothing before entering the room but it all slowly came back to me.");
                currentCharacters.Add("Orpheus");
                sceneTwoStrings.Add("Well, what do you think?");
                currentCharacters.Add("Eurydice Less Ghost");
                sceneTwoStrings.Add("I think… I kind of wish I could go back and tell myself how lucky I was. I was a lonely kid, and you were " +
                    "one of the few people who made me feel less lonely. Some people spend their whole lives feeling lonely.");
                currentCharacters.Add("Orpheus");
                sceneTwoStrings.Add("I see. I’d guess that everyone has memories they wish they knew the importance of at the time. I felt pretty lonely too. I had friends, but they didn’t always get me.");
                currentCharacters.Add("Eurydice Less Ghost");
                sceneTwoStrings.Add("Yes, now that you say that I kind of remember you telling me that before.");
                currentCharacters.Add("Orpheus");
                sceneTwoStrings.Add("Well, whenever you’re ready, head into the next room.");
                currentCharacters.Add("Eurydice Less Ghost");
                currentStrings = sceneTwoStrings;
                break;
            case "HubRoom3":
                clearList("four");
                sceneFourStrings.Add("Back again.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneFourStrings.Add("Yeah. I saw the camping trip. When we heard the noises in the forest.");
                currentCharacters.Add("Orpheus");
                sceneFourStrings.Add("Oh yeah. You were so scared that night.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneFourStrings.Add("I was, but we got through it. It was the darkness that made it terrifying. The not knowing what was hiding in there. Besides, as I recall, you were scared too. I know you like to pretend you weren’t.");
                currentCharacters.Add("Orpheus");
                sceneFourStrings.Add("Heh, you got me there. So, so far, we met one another, we faced uncertainty together. In the next room, we’ll see what other hardships were faced together.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneFourStrings.Add("I suppose so");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneFourStrings;
                break;
            case "HubRoomFinal":
                clearList("six");
                sceneSixStrings.Add("So, what did you see this time?");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("The day at the beach, when we had the picnic and we put our wishes inside of bottles and let them float away.");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("Right, I remember too. Our dreams of the future, how we thought everything would go, it was all inside those little bottles.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("You never did tell me what you wrote in yours.");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("And I still can’t tell you.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("Why is that? Don’t I deserve to know by now?");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("How could I tell you when I, myself, have no idea?");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("How could you not know? Did you forget?");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("I thought maybe you’d have figured it out by now. You know I’m not really her, right?");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("What… what do you mean?");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("I look like her, and I act like her, but I am not her. Remember what I told you? This is your mind, and your memories. All I can be is who you remember her as.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("Oh. I suppose that makes sense. So, in other words, you’re just her the way I remember her, you don’t have her memories. ");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("You don’t know what she wrote that day, or what she thought about any of this. You can only be what I saw of her, what I remember of her.");
                currentCharacters.Add("Orpheus");
                sceneSixStrings.Add("Exactly.");
                currentCharacters.Add("Eurydice Almost Final");
                sceneSixStrings.Add("I’m not going to lie, I was hoping you were. Well, I suppose I still have one more room.");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneSixStrings;
                break;
            case "HubRoomFinal 1":
                clearList("eight");
                sceneEightStrings.Add("I’m back.");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("You saw it? The last day we spoke, I assume?");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("Yeah, it was the last day. I don’t feel like I understand it any better than I did that day.");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("Since you’re just my memory of her, I know you can’t tell me why she left, but… I don’t know. I don’t know what I want from you anymore.");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("It’s complicated, isn’t it? I can only tell you why you think she left, which may be of comfort, but nothing more.");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("Well, like you said, I suppose this isn’t entirely fabricated. It’s not real, but it’s not entirely unreal either. Why do you think she left?");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("Maybe she had dreams that you couldn’t be a part of. Maybe she wanted to travel the world alone, feel free for a bit.");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("I just don’t understand why she couldn’t be free with me, why she couldn’t be honest with me.");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("When you’re someone who is used to being lonely, who maybe even likes being alone, you can never be truly free with the thoughts and opinions of another around you. ");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("You want to be separate, to form your own experiences, feel new emotions. She may have felt stifled around you.");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("But… that’s the last thing I ever wanted. I wanted her to follow her dreams too.");
                currentCharacters.Add("Orpheus");
                sceneEightStrings.Add("I’m not saying it was your fault, I think you know it wasn’t. It’s just the way she was.");
                currentCharacters.Add("Eurydice Final");
                sceneEightStrings.Add("I… I still don’t really like it, but maybe you’re right. So, what happens now?");
                currentCharacters.Add("Orpheus");
                currentStrings = sceneEightStrings;
                break;
            case "HubRoomFinalChoice":
                clearList("eight");
                sceneEightStrings.Add("Well, there is one final door. I think it’s time for you to walk through it now, if you’re ready.");
                currentCharacters.Add("Eurydice Final");
                currentStrings = sceneEightStrings;
                break;
            //Endings
            case "Ending1":
                clearList("eOne");
                endingOneStrings.Add("I… I think I am. I think I understand now. Thanks for guiding me through this.");
                currentCharacters.Add("Orpheus");
                endingOneStrings.Add("Of course. It’s why I’m here.");
                currentCharacters.Add("Eurydice Final");
                endingOneStrings.Add("What’s on the other side of this door?");
                currentCharacters.Add("Orpheus");
                endingOneStrings.Add("The rest of your life. All of this was but one chapter, you’ve still got so much more to go. And maybe you’ll see me again," +
                    " and maybe you won’t. But you don’t have much of a choice. You have to continue on. It’s what we all do. It’s what she is doing at this very moment.");
                currentCharacters.Add("Eurydice Final");
                endingOneStrings.Add("I see, and I understand. Thanks again. Goodbye.");
                currentCharacters.Add("Orpheus");
                endingOneStrings.Add("Goodbye.");
                currentCharacters.Add("Eurydice Final");
                endingOneStrings.Add("I love you. I have always loved you.");
                currentCharacters.Add("Orpheus");
                currentStrings = endingOneStrings;
                break;
            case "Ending2":
                clearList("eTwo");
                endingTwoStrings.Add("So I go through this door, and I won’t see you again?");
                currentCharacters.Add("Orpheus");
                endingTwoStrings.Add("That’s how it works, yes. This is how it should be.");
                currentCharacters.Add("Eurydice Final");
                endingTwoStrings.Add("What if… what if you came with me?");
                currentCharacters.Add("Orpheus");
                endingTwoStrings.Add("I can’t. It’s not my place, I’m not…");
                currentCharacters.Add("Eurydice Final");
                endingTwoStrings.Add("Real? I know you’re not real, but you’re real to me. I just want you around again, that’s all I’ve ever wanted.");
                currentCharacters.Add("Orpheus");
                endingTwoStrings.Add("But I’m not her. I told you-");
                currentCharacters.Add("Eurydice Final");
                endingTwoStrings.Add("I don’t care, you’re her to me. Come with me, we’ll walk through together.");
                currentCharacters.Add("Orpheus");
                endingTwoStrings.Add("I… I don’t know if anything will happen; I can’t leave this place. But, if it will make you feel better, I suppose we can try.");
                currentCharacters.Add("Eurydice Final");
                endingTwoStrings.Add("Thank you! Thank you, thank you, thank you! Here, take my hand.");
                currentCharacters.Add("Orpheus");
                endingTwoStrings.Add("Okay. Let's do this.");
                currentCharacters.Add("Eurydice Final");
                currentStrings = endingTwoStrings;
                break;
            case "Ending2P2":
                clearList("eTwo");
                break;
            case "Ending3":
                clearList("eThree");
                endingThreeStrings.Add("When I walk through this door, I’ll never see you again. Will I?");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("Never say never. I exist in your memory, you can see me whenever you want.");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("You know what I mean. I’ll never see her again.");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("You’ll never know if you don’t head back out there.");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("But if I stay here, I know I’ll get to see you. Every day. Whenever I want. All the time.");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("I was afraid this would happen. This isn’t healthy. You’re meant to move on. Dwelling like this does neither of us any good. You should know that by now.");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("I don’t care. None of it matters without you, I can’t make anything make sense without you. I want to stay here. Please don’t make me leave. Please. I love you, I always have.");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("This isn’t right. You shouldn’t stay.");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("But it’s what I want, it’s the only thing I’ve ever truly wanted. Don’t I get a choice?");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("It’s your mind, you’re the only one with the choice. But, as a part of your memories, " +
                    "a part of you that is your experience yet still separate from you, I can also let you know that this is not ideal. " +
                    "Letting go is healthy; it’s normal. It doesn’t mean you have to forget, it just means continuing on anyway.");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("I don’t want to continue on without you. I’m not ready. I can’t!");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("Well then, I don’t like this one bit, but I can’t make you go. How long do you think you’ll stay?");
                currentCharacters.Add("Eurydice Final");
                endingThreeStrings.Add("I don’t know yet, all I know is this is the closest I’ve felt to normal in so long. I can’t just let this go. I love you.");
                currentCharacters.Add("Orpheus");
                endingThreeStrings.Add("I'm sure she loved you too.");
                currentCharacters.Add("Eurydice Final");
                currentStrings = endingThreeStrings;
                break;
        }
    }

    public bool finished()
    {
        bool temp;
        if (currentSection == currentStrings.Count -1)
        {
            temp = true;
        } else
        {
            temp = false;
        }
        return temp;
    }

    public void setProperTexts()
    {
        if (currentStrings.Count >= 1)
        {
            displayText.text = currentStrings[currentSection];
        }

        if (currentCharacters.Count >= 1)
        {
            //displayNameText.text = currentCharacters[currentSection];
            if (currentCharacters[currentSection] == "Orpheus")
            {
                displayNameText.text = currentCharacters[currentSection];
            } else if (currentCharacters[currentSection].Contains("Eurydice"))
            {
                displayNameText.text = "Eurydice";
            } else
            {
                displayNameText.text = "";
            }
            switch (currentCharacters[currentSection])
            {
                case "Orpheus":
                    _spriteRenderer.sprite = Orpheus;
                    break;
                case "Eurydice Ghost":
                    _spriteRenderer.sprite = eurydiceStage0;
                    break;
                case "Eurydice Less Ghost":
                    _spriteRenderer.sprite = eurydiceStage1;
                    break;
                case "Eurydice Almost Final":
                    _spriteRenderer.sprite = eurydiceStage2;
                    break;
                case "Eurydice Final":
                    _spriteRenderer.sprite = eurydiceStage3;
                    break;
                case "none":
                    _spriteRenderer.enabled = false;
                    break;
            }
        }
    }

    public void playClick() 
    {
        audioSource.PlayOneShot(_click, Settings.volume);
    }

    public void playBackgroundMusic()
    {
        Debug.Log(Settings.musicSet);
        if (Settings.musicSet == true)
        {
            _bgAudio.clip = _bgClip;
            _bgAudio.volume = Settings.volume;
            _bgAudio.Play();
        }
    }

    public void clickedSettings()
    {
        Settings.currentClip = _bgClip;
        Settings.things = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

}
