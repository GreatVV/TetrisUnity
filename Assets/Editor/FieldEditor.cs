using UnityEditor;
using UnityEngine;

[CustomEditor(typeof (Field))]
public class FieldEditor : Editor
{
    private void OnSceneGUI()
    {
        var field = target as Field;
        field.Position = Handles.PositionHandle(field.Position, Quaternion.identity);
        field.SpawnPosition = Handles.PositionHandle(field.SpawnPosition, Quaternion.identity);

        var pos = field.Position;
        var size = field.Size;
        var verts = new[]
                    {
                        new Vector3(pos.x, pos.y, 0),
                        new Vector3(pos.x + size.x, pos.y, 0),
                        new Vector3(pos.x + size.x, pos.y + size.y, 0),
                        new Vector3(pos.x, pos.y + size.y, 0)
                    };
        Handles.DrawSolidRectangleWithOutline(verts, new Color(1,0,0,0.3f), new Color(1,1,1,0.1f));
        Handles.DotCap(0,field.SpawnPosition, Quaternion.identity, 1f);
    }
}