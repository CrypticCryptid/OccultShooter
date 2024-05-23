/* *
* @file TEST_PlayerController.cs
* @author Alec Ege
* @brief A temporary stand in for player movement. The object teleports to predetermined transforms in an array
* @date 2024 - 05 - 23
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PlayerController : MonoBehaviour
{
    public Vector3[] positions;
    public int posNum;

    void Update()
    {
        gameObject.transform.position = positions[posNum];
    }
}
