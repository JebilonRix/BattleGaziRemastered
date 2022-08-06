using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAudio", menuName = "EnemyAudio")]
public class EnemyAudio : ScriptableObject
{
    [SerializeField] private AudioClip[] _catch;
    [SerializeField] private AudioClip[] _run;
    [SerializeField] private AudioClip[] _seen;

    public AudioClip GetRandomAudio(string type)
    {
        type = type.ToLower();

        if (type == "catch")
        {
            return _catch[Random.Range(0, _catch.Length)];
        }
        else if (type == "run")
        {
            return _run[Random.Range(0, _run.Length)];
        }
        else if (type == "seen")
        {
            return _seen[Random.Range(0, _seen.Length)];
        }
        else
        {
            return null;
        }
    }
}