namespace Lab_3_1_Net_4.Models
{
    public class ChuyenNganh
    {
        public string Image_string { get; set; }
        public string Subname_string { get; set; }
        public List<ChuyenNganh> cacChuyenNganh;

        public ChuyenNganh()
        {

        }
        public ChuyenNganh(string image_string, string subname_string)
        {
            Image_string = image_string;
            Subname_string = subname_string;
        }
    }

}
