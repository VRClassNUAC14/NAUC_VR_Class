using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType
    {
        Left,
        Right,
        DontHit
    }
    public BlockType myBlockType = BlockType.Left;
    public ParticleSystem Explosion;
    ScoreKeeper scoreKeeper;
    float speed = 0.01f;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>().GetComponent<ScoreKeeper>();
    }
    void FixedUpdate()
    {
        transform.position -= Vector3.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("LeftSaber") && myBlockType == BlockType.Left)
        {
            scoreKeeper.IncreaseScore();
        }
        else if (other.name.Contains("RightSaber") && myBlockType == BlockType.Right)
        {
            scoreKeeper.IncreaseScore();
        }
        else
        {
            scoreKeeper.DecreaseLives();
        }
        gameObject.SetActive(false);
        ParticleSystem newExplode = Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(newExplode.gameObject, 2.0f);
    }
}
