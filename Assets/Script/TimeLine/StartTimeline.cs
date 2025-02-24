using UnityEngine.Playables;
using UnityEngine;

public class StartTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeLine;
    void Start()
    {
        //_timeLine = GetComponent<PlayableDirector>();
    }

    

private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Hero"))
    {
        PressButton();
        Debug.Log("555");
    }

}


    void PressButton()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _timeLine.Play();
        }
    }
}
