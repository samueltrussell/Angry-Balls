using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

//using directives for monogame featureset
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Angry_Balls
{
    class SaveButton : TBoxItem
    {
        private bool save = false;

        public SaveButton(AngryBallsEnvironment.GameState gameState)
        {
            image = Game1.saveImage;

            if (gameState == AngryBallsEnvironment.GameState.levelBuilder)
            {
                save = true;
            }
            position = new Vector2(150, 75);
            size = new Vector2(80, 75);

            dragable = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeft = new Vector2(position.X - size.X / 2, position.Y - size.Y / 2);

            if (save)
                spriteBatch.Draw(image, new Rectangle(topLeft.ToPoint(), size.ToPoint()), Color.White);
        }
    }
}
