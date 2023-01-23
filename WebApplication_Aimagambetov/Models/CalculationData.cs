using System.ComponentModel.DataAnnotations;

namespace WebApplication_Aimagambetov.Models
{
    public class CalculationData
    {
        [Key]
        public int Id { get; set; }
        
        public int? UserId { get; set; }
        
        public User User { get; set; }
        
        public string Name { get; set; }
        
        public double H0 { get; set; }
        
        public double t_nachMat { get; set; }
       
        public double T_nachTemp { get; set; }
       
        public double Wg { get; set; }
       
        public double Cg { get; set; }
       
        public double Gm { get; set; }
       
        public double Cm { get; set; }
       
        public double aV { get; set; }
       
        public double D { get; set; }
       
    }
}
