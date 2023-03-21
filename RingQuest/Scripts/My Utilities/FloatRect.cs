using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public struct FloatRect : IEquatable<FloatRect>
    {
        Vector4 data;

        public FloatRect(float x, float y, float z, float w)
        {
            data = new Vector4(x, y, z, w);
        }
        public FloatRect() : this(0,0,0,0) { }
        public FloatRect(Vector2 Location, Vector2 Size) : this(Location.X, Location.Y, Size.X, Size.Y) { }

        public Rectangle rectangle { get { return new Rectangle((int)X, (int)Y, (int)Width, (int)Height); } }

        public float X
        {
            get
            {
                return data.X;
            }
            set
            {
                data.X = value;
            }
        }

        public float Y
        {
            get
            {
                return data.Y;
            }
            set
            {
                data.Y = value;
            }
        }

        public float Width
        {
            get
            {
                return data.Z;
            }
            set
            {
                data.Z = value;
            }
        }

        public float Height
        {
            get
            {
                return data.W;
            }
            set
            {
                data.W = value;
            }
        }

        public Vector2 Location
        {
            get
            {
                return new Vector2(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2 Size
        {
            get
            {
                return new Vector2(Width, Height);
            }
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public Point LocationAsPoint
        {
            get
            {
                return new Point((int)X, (int)Y);
            }
        }

        public Point SizeAsPoint
        {
            get
            {
                return new Point((int)Width, (int)Height);
            }
        }


        public bool Equals(FloatRect other)
        {
            return data == other.data;
        }
    }
}
