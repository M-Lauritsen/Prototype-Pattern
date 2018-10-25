using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern
{
    class Program
    {
        abstract class ColorPrototype
        {
            public abstract ColorPrototype Clone();
        }

        class Color : ColorPrototype
        {
            private int _red;
            private int _green;
            private int _blue;

            // Constructor
            public Color(int red, int green, int blue)
            {
                _red = red;
                _green = green;
                _blue = blue;
            }

            //Create Shallow Copy
            public override ColorPrototype Clone()
            {
                Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);

                return MemberwiseClone() as ColorPrototype;
            }
        }

        //Prototype Manager
        class ColorManager
        {
            private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

            //Indexer
            public ColorPrototype this[string key]
            {
                get { return _colors[key]; }
                set { _colors.Add(key, value); }
            }
                
        }
        
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager();

            // Initialize with standard colors
            colorManager["RED"] = new Color(255, 0, 0);

            colorManager["GREEN"] = new Color(0, 255, 0);

            colorManager["BLUE"] = new Color(0, 0, 255);

            //User adds personalized colors
            colorManager["ANGRY"] = new Color(255, 54, 0);

            colorManager["PEACE"] = new Color(128, 211, 128);

            colorManager["FLAME"] = new Color(211, 34, 20);

            //User clones selected colors
            Color color1 = colorManager["RED"].Clone() as Color;
            Color color2 = colorManager["PEACE"].Clone() as Color;
            Color color3 = colorManager["FLAME"].Clone() as Color;

            Console.ReadKey();
        }
    }
}
