using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{

    public class Display
    {
        private uint displayWidth;
        private uint displayHeght;
        private long numberOfColors;

        public uint DisplayWidth
        {
            get { return this.displayHeght;}

            set
            {
                if(value<0 || value>1311)
                {
                    throw new ArgumentOutOfRangeException("Display width is too big or too small");
                }
                this.displayWidth = value;
            }
        }

        public uint DisplayHeight
        {
            get { return this.displayHeght; }

            set
            {
                if (value < 0 || value > 737)
                {
                    throw new ArgumentOutOfRangeException("Display height is too big or too small");
                }
                this.displayWidth = value;
            }
        }

        public long DisplayColors
        {
            get { return this.numberOfColors; }

            set
            {
                if (value < 0 || value > 16777216)
                {
                    throw new ArgumentOutOfRangeException("Display colors must on the range of [0..16777216]");
                }
                this.numberOfColors = value;
            }
        }

        public uint DisplaySize
        {
            get { return this.displayHeght*this.displayWidth;}
        }


        public Display(uint width, uint height, long colors)
        {
            this.displayWidth = width;
            this.displayHeght = height;
            this.numberOfColors = colors;

        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("Width: " + this.displayWidth);
            info.Add("Height: " + this.displayHeght);
                info.Add("Number of Colors: " + this.numberOfColors);

            return String.Join(", ", info);
        }
    }

    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        public enum Type { LiIon, NiMH, NiCd }

        public Type TypeBattery { get; set; }

        public string Model
        {
            get { return this.model; }

            set
            {
                this.model = value;
            }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }

            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("Hours idle cannot be smaller than 0!");
                }
                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk cannot be smaller than 0!");
                }
                this.hoursTalk = value;
            }
        }

        public Battery(string model,int idle, int talk)
        {
            this.model = model;
            this.hoursIdle = idle;
            this.hoursTalk = talk;
        }

    }

}
