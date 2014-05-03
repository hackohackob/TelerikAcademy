using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class GSMAll
    {
         private string model ;
        private string manufacturer ;
        private string owner;
        private decimal price;
        private Display display ;
        private Battery battery;



        public static readonly GSMAll iPhone4S = new GSMAll("iPhone 4S","Apple","Telerik",1300,new Display(960,640,6000000),new Battery("iPhone",60,2));


        public string Model
        {
            get { return this.model; }
             set
            {
                if (value == null)
                    throw new ArgumentNullException("Model can't be null!");

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Manufacturer can't be null!");

                this.manufacturer = value;
            }
        }

        public string Owner { get; set; }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                this.price = value;
            }
        }

        public Display Display
        {
            get { return this.display; }

            set
            {
                this.display = value;
            }
        }

        public Battery Battery { get; set; }


        public GSMAll(string model, string manufacturer, string owner , decimal price , Display display , Battery battery)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;
            this.display = display;
            this.battery = battery;

        }

        public GSMAll(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("Model - " + this.Model);
            info.Add("Manufacturer - " + this.Manufacturer);

            if (this.Owner != null)
                info.Add("Owner - " + this.Owner);

            if (this.Price!=0)
                info.Add("Price - " + this.Price);

            if (this.Display != null)
                info.Add("Display - " + this.Display);

            if (this.Battery != null)
                info.Add("Battery - " + this.Battery);

            return String.Join(Environment.NewLine, info);
        }
    }
}
