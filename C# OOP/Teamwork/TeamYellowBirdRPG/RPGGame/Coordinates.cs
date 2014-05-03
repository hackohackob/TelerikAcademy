namespace RPGGame
{
    public class Coordinates
    {
        private int x;
        private int y;

        public Coordinates(int xPosition, int yPosition)
        {
            this.X = xPosition;
            this.Y = yPosition;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value >= 0 && value < ConsoleClass.HorizontalLinePosition)
                {
                    this.x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value >= 0 && value < ConsoleClass.VerticalLinePosition)
                {
                    this.y = value;
                }
            }
        }
    }
}
