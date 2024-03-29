﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using game_states;
using Microsoft.Xna.Framework.Content;

namespace game_objects
{
    public class GameObjectsManager
    {
        private List<GameObject> gameObjects;
        private List<DrawableGameObject> drawableGameObjects;
        private List<CollidableGameObject> collidableGameObjects;
        private List<GameObject> toRemove;
        private List<GameObject> toAdd;

        private GraphicsDevice graphicsDevice;
        private Renderer2D r2D;
        private Renderer3D r3D;

        private bool updating;

        public List<CollidableGameObject> CollidableGameObjects
        {
            get { return collidableGameObjects; }
        }

        public Renderer2D R2D
        {
            get { return r2D; }
        }

        public Renderer3D R3D
        {
            get { return r3D; }
        }

        public List<GameObject> GameObjects
        {
            get { return gameObjects; }
        }

        public GameObjectsManager(GraphicsDevice graphicsDevice)
        {
            gameObjects = new List<GameObject>();
            drawableGameObjects = new List<DrawableGameObject>();
            collidableGameObjects = new List<CollidableGameObject>();
            toRemove = new List<GameObject>();
            toAdd = new List<GameObject>();

            this.graphicsDevice = graphicsDevice;
            r2D = new Renderer2D(graphicsDevice);
            r3D = new Renderer3D(graphicsDevice);
        }

        public void AddObject(GameObject obj)
        {
            if (!updating)
            {
                gameObjects.Add(obj);
                if (obj is DrawableGameObject)
                {
                    drawableGameObjects.Add((DrawableGameObject)obj);
                    if (obj is CollidableGameObject)
                        collidableGameObjects.Add((CollidableGameObject)obj);
                }
            }
            else
            {
                toAdd.Add(obj);
            }
        }

        public void RemoveObject(GameObject obj)
        {
            if (!updating)
            {
                gameObjects.Remove(obj);
                if (obj is DrawableGameObject)
                {
                    drawableGameObjects.Remove((DrawableGameObject)obj);
                    if (obj is CollidableGameObject)
                        collidableGameObjects.Remove((CollidableGameObject)obj);
                }
            }
            else
            {
                toRemove.Add(obj);
            }
        }

        public void Load(ContentManager cManager)
        {
            foreach (DrawableGameObject dgObj in drawableGameObjects)
                dgObj.Load(cManager);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = toRemove.Count - 1; i >= 0; i--)
            {
                RemoveObject(toRemove[i]);
                toRemove.RemoveAt(i);
            }

            updating = true;
            foreach (GameObject gObj in gameObjects)
            {
                gObj.Update(gameTime);
            }

            updating = false;
            for (int i = toAdd.Count - 1; i >= 0; i--)
            {
                AddObject(toAdd[i]);
                toAdd.RemoveAt(i);
            }
        }

        public void Draw(GameTime gameTime)
        {
            Renderer lastRenderer = null;
            foreach (DrawableGameObject dgObj in drawableGameObjects)
            {
                if (lastRenderer != dgObj.Renderer)
                {
                    if (lastRenderer is Renderer2D)
                        ((Renderer2D)lastRenderer).End();
                    lastRenderer = dgObj.Renderer;
                }

                if (drawableGameObjects.IndexOf(dgObj) == 7)
                {
                    int a = 0;
                }
                dgObj.Draw(gameTime);
            }
            r2D.End();
        }
    }
}
