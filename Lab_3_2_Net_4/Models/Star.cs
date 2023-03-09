namespace Lab_3_2_Net_4.Models
{
    public class Star
    {
        public int FullStar { get; set; }
        public int HalfStar { get; set; }
        public int NonStar { get; set; }

        public Star() { }
        public Star(int starPoint)
        {
            FullStar = starPoint / 2;
            HalfStar = starPoint % 2 == 0 ? 0 : 1;
            NonStar = (10 - starPoint) / 2;
        }
    }
}
