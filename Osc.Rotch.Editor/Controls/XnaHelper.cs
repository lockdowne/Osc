using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osc.Rotch.Editor.Controls
{
    public class XnaHelper : UserControl
    {
        private static XnaHelper instance = new XnaHelper();

        private GraphicsDeviceService service;

        public static XnaHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get { return service.GraphicsDevice; }
        }

        private XnaHelper()
        {
            service = GraphicsDeviceService.AddRef(Handle, ClientSize.Width, ClientSize.Height);
        }

        public Texture2D LoadTexture(string path)
        {
            Bitmap bitmap = new Bitmap(path); // Must be .png type
            // Need a universal graphics device
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);

                return Texture2D.FromStream(GraphicsDevice, stream); 
            }
        }

        public Texture2D LoadTexture(Bitmap image)
        {
            Bitmap bitmap = image; // Must be .png type
            // Need a universal graphics device
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);

                return Texture2D.FromStream(GraphicsDevice, stream);
            }
        }

        public SpriteFont LoadSpriteFont(string path)
        {
            
            return null;
        }
    }
}
