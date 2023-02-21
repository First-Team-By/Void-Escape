using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    private static List<string> _firstNameRus = new List<string>() { "���������", "�������", "������", "��������", "�������", "�����", "������", "�����", "�����", "��������" };
    
    private static List<string> _secondNameRus = new List<string>() { "�������", "������", "��������", "�������", "�����", "�������", "������", "�������", "�������", "������" };

    public static string CreateFullName()
    {
        string firstName = _firstNameRus[Random.Range(0, _firstNameRus.Count)];

        string secondName = _secondNameRus[Random.Range(0, _secondNameRus.Count)];

        return firstName + " " + secondName;
    }

}
