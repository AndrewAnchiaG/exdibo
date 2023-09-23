namespace EXDIBO.Util
{
    public class SeriePastel
    {
        public string name { get; set; }

        public double y { get; set; }

        public bool sliced { get; set; }

        public bool selected { get; set; }

        public SeriePastel() { }

        public SeriePastel(string Name, double Y, bool Sliced = true, bool Selected = true) 
        {
            this.name = Name;
            this.y = Y;
            this.sliced = Sliced;
            this.selected = Selected;
        }



    }
}
