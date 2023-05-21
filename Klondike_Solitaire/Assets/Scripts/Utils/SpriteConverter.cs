using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteConverter
{
    public SpriteConverter() { }

    public Sprite[,] ConvertToSprites(Texture2DArray textureArray)
    {
        //TODO refactor
        int columnCount = 13; 
        int rowCount = 4;
        //
        int lenght = textureArray.depth;

        Texture2D[] textures = new Texture2D[lenght];
        Texture2D texture = new Texture2D(textureArray.width, textureArray.height, TextureFormat.RGBA32, false);

        for (int i = 0; i < lenght; i++)
        {
            Color[] pixels = textureArray.GetPixels(i);
            texture.SetPixels(pixels);
            texture.Apply();
            textures[i] = texture;
        }

        Texture2D[,] outputArray = ConvertTo2DArray(textures, rowCount, columnCount);


        Sprite[,] sprites = new Sprite[rowCount, columnCount];

        for (int x = 0; x < rowCount; x++)
        {
            for (int y = 0; y < columnCount; y++)
            {
                var tempTexture = outputArray[x, y];
                Sprite sprite = Sprite.Create(tempTexture, new Rect(0, 0, tempTexture.width, tempTexture.height), Vector2.zero);

                sprites[x, y] = sprite;
            }
        }

        return sprites;
    }
    private T[,] ConvertTo2DArray<T>(T[] inputArray, int rows, int columns)
    {
        if (inputArray.Length != (rows * columns))
        {
            throw new ArgumentException("Input array length does not match the specified rows and columns.");
        }

        T[,] outputArray = new T[rows, columns];
        int index = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                outputArray[row, col] = inputArray[index];
                index++;
            }
        }

        return outputArray;
    }
}