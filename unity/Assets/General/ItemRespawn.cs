using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reposiciona o object caso esse caia do mapa
/// </summary>
public class ItemRespawn : MonoBehaviour
{

    public static Vector3 s_pontoRespawn = new Vector3(1.96700001f, 0.771000028f, -0.853999972f);

    void Start()
    {
        
    }

    void Update()
    {
        // Verifica se o objeto caiu do mapa
        if (transform.position.y <= -2.4f)
        {
            // Reseta a posição
            transform.position = s_pontoRespawn;
		}
    }
}
