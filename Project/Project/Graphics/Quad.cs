#region File Description
//-----------------------------------------------------------------------------
// Quad.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project
{
    public class Quad
    {
        public Vector3 Origin;

        public Vector3 Normal;
        public Vector3 Up;
        public Vector3 Left;

        public VertexPositionNormalTexture[] Vertices;

        public static readonly short[] Indexes = new short[] { 0, 1, 2, 2, 1, 3 };

        static readonly Vector2 textureUpperLeft = new Vector2(0.0f, 0.0f);
        static readonly Vector2 textureUpperRight = new Vector2(1.0f, 0.0f);
        static readonly Vector2 textureLowerLeft = new Vector2(0.0f, 1.0f);
        static readonly Vector2 textureLowerRight = new Vector2(1.0f, 1.0f);

        public Vector3 LowerLeft
        {
            get { return Vertices[0].Position; }
        }

        public Vector3 UpperLeft
        {
            get { return Vertices[1].Position; }
        }

        public Vector3 LowerRight
        {
            get { return Vertices[2].Position; }
        }

        public Vector3 UpperRight
        {
            get { return Vertices[3].Position; }
        }

        public Vector3 Coord
        {
            get
            {
                return Vertices[1].Position;
            }
        }

        public Quad(Vector3 origin, Vector3 normal, Vector3 up,
            float width, float height)
        {
            Vertices = new VertexPositionNormalTexture[4];
            Origin = origin;
            Normal = normal;
            Up = up;

            // Calculate the quad corners
            Left = Vector3.Cross(normal, Up);
            Vector3 uppercenter = (Up * height / 2) + origin;

            Vector3 upperLeft = uppercenter + (Left * width / 2);
            Vector3 upperRight = uppercenter - (Left * width / 2);
            Vector3 lowerLeft = upperLeft - (Up * height);
            Vector3 lowerRight = upperRight - (Up * height);

            FillVertices(upperLeft, upperRight, lowerLeft, lowerRight);
        }

        private void FillVertices(Vector3 upperLeft, Vector3 upperRight, Vector3 lowerLeft, Vector3 lowerRight)
        {
            // Provide a normal for each vertex
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i].Normal = Normal;
            }

            // Set the position and texture coordinate for each vertex
            Vertices[0].Position = lowerLeft;
            Vertices[0].TextureCoordinate = textureLowerLeft;
            Vertices[1].Position = upperLeft;
            Vertices[1].TextureCoordinate = textureUpperLeft;
            Vertices[2].Position = lowerRight;
            Vertices[2].TextureCoordinate = textureLowerRight;
            Vertices[3].Position = upperRight;
            Vertices[3].TextureCoordinate = textureUpperRight;
        }

        public void Translate(Vector3 amount)
        {
            float lastZ = Vertices[0].Position.Z;
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i].Position += amount;
            }
        }
    }
}
