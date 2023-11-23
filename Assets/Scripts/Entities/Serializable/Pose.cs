using UnityEngine;

public class Pose
{
    public string Name { get; set; }
    public string Path { get; set; }
    public Sprite Sprite { get; set; }

    public Pose(string name, string path)
    {
        Name = name;
        Path = path;
    }
}

