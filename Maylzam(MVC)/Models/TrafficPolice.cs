using System.ComponentModel.DataAnnotations;

namespace Maylzam_MVC_.Models
{
    ///traffic police
    ///

    public class TrafficPolice
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }/*
        [Required(ErrorMessage = "Please Enter The front of Personal Cards Image")]*/
        [Display(Name = "The front of Personal Cards")]
        public string? Personal_Card { get; set; }
        /*[Required(ErrorMessage = "Please Enter The back of Personal Cards Image")]*/
        [Display(Name = "The back of Personal Cards")]
        public string? Personal_Cardback { get; set; }
        [Display(Name = "Please Enter The Policer Card Image")]
        public string? PolicerCardImage { get; set; }
        public string? Profile_Image { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

}
