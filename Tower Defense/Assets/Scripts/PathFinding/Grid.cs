using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    int width;
    int height;
    float cellSize;

    int[,] gridArray;

    TextMesh[,] textArray;

    Vector3 originPosition;

    public Grid(int w,int h,float cS,Vector3 origin)
    {
        width = w;
        height = h;
        cellSize = cS;

        originPosition = origin;
        
        gridArray = new int[w, h];
        textArray = new TextMesh[w, h];



        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                textArray[i,j] = CreateWorldText(gridArray[i,j].ToString(),null,GetWorldPosition(i,j) + new Vector3(cellSize,cellSize) * 0.5f,5,Color.white,TextAnchor.MiddleCenter,TextAlignment.Center);

                Debug.DrawLine(GetWorldPosition(i,j),GetWorldPosition(i,j+1),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, h), GetWorldPosition(w, h), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(w, 0), GetWorldPosition(w,h), Color.white, 100f);

        //SetValue();   
    }


    public void SetValue(int x,int y,int value)
    {
        if(x >= 0 && y >= 0 && x < width && y <height)
        {
            gridArray[x, y] = value;
            textArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPositon,int value)
    {
        int x, y;

        GetXY(worldPositon, out x, out y);
        SetValue(x,y,value);
    }


    public int GetValue(int x,int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
            return gridArray[x, y];
        else
            return 0;
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x, y;

        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
    void GetXY(Vector3 worldPosition,out int x,out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x/cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }
    Vector3 GetWorldPosition(int x,int y)
    {
        return new Vector3(x,y) * cellSize + originPosition;
    }
    TextMesh CreateWorldText(string text,Transform parent = null,Vector3 localPosition = default(Vector3),int fontSize = 40,
        Color color = default(Color),TextAnchor anchor = default(TextAnchor),TextAlignment aligment = default(TextAlignment),int sortingOrder = 0)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent,text,localPosition,fontSize,(Color)color,anchor,aligment,sortingOrder);

    }
    TextMesh CreateWorldText(Transform parent,string text,Vector3 localPosition,int fontSize,Color color,TextAnchor anchor,TextAlignment alignment,int sortingOrder)
    {
        GameObject go = new GameObject("World Text",typeof(TextMesh));

        Transform t = go.transform;
        t.SetParent(parent, false);
        t.localPosition = localPosition;

        TextMesh mesh = go.GetComponent<TextMesh>();
        mesh.anchor = anchor;
        mesh.alignment = alignment;
        mesh.text = text;
        mesh.fontSize = fontSize;
        mesh.color = color;
        mesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return mesh;

    }
}
