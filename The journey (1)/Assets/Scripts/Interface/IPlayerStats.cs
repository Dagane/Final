using UnityEngine;

public interface IPlayerStats
{
    Vector3 GetPosition();
    void SetPosition(Vector3 pos);

    int GetHealth();
    void SetHealth(int health);
    int GetHachas();
    void SetHachas(int cantHachas);
    int GetTroncos();
    void SetTroncos(int canTroncos);
}
