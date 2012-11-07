using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{
    public class EntityManager
    {
        List<GameObject> goList = new List<GameObject>();
        List<RenderableGameObject> renderableList = new List<RenderableGameObject>();

        public void AddGameObject(GameObject obj)
        {
            goList.Add(obj);
        }
        public void AddRenderableGameObject(RenderableGameObject obj)
        {
            renderableList.Add(obj);
        }

        public void RemoveGameObject(GameObject obj)
        {
            goList.Remove(obj);
        }
        public void RemoveRenderableGameObject(RenderableGameObject obj)
        {
            renderableList.Remove(obj);
        }



        public void Update(GameTime gTime)
        {
            for (int i = 0; i < goList.Count; i++)
                goList[i].Update(gTime);

            for (int i = 0; i < renderableList.Count; i++)
                renderableList[i].Update(gTime);

        }


        public void Draw(GameTime gTime, SpriteBatch sb)
        {
            for (int i = 0; i < renderableList.Count; i++)
                renderableList[i].Draw(gTime, sb);

        }

    }
}
