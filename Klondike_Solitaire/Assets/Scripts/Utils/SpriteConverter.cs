using System;
using UnityEngine;

public class SpriteConverter
{
    const string CARDS_TEXTURES_PATH = "CardsArray";
    private Texture2DArray textureArray;
    public SpriteConverter()
    {
        textureArray = Resources.Load<Texture2DArray>(CARDS_TEXTURES_PATH);
    }

    public Sprite[,] ConvertToSprites()
    {
        int columnCount = 13; 
        int rowCount = 4;

        int lenght = textureArray.depth;

        Texture2D[] textures = new Texture2D[lenght];

        for (int i = 0; i < lenght; i++)
        {
            Texture2D texture = new Texture2D(textureArray.width, textureArray.height, TextureFormat.RGBA32, false);

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