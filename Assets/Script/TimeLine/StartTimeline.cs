using UnityEngine.Playables;
using UnityEngine;

public class StartTimeline : MonoBehaviour
{
    private PlayableDirector _timeLine;
    void Start()
    {
        _timeLine = GetComponent<PlayableDirector>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _timeLine.Play();
        }
    }
}
