using System.ComponentModel.DataAnnotations;

namespace MaritimeTest.Entities {
    public class Range {
        [Key]
        public int Id { get; set; }
        public float Value { get; set; }
        public double Avarage { get; set; }
        public double Deviation { get; set; }
        public double[] Frequencies { get; set; }

    }
}