using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaminProject.Models
{
    public class BaseInformation
    {
        [Key]
        public int? ID { get; set; }

        [Display(Name ="عنوان")]
        [MaxLength(50,ErrorMessage ="حداکثر مجاز 50 کارکتر می باشد")]
        [Required(ErrorMessage ="وارد کردن عنوان الزامی است")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "استفاده از کاراکتر(های) غیر مجاز")]
        public string Title { get; set; }


        [Display(Name = "آدرس")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "استفاده از کاراکتر(های) غیر مجاز")]
        public string Address1 { get; set; }

        [Display(Name = "آدرس دوم")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "استفاده از کاراکتر(های) غیر مجاز")]
        public string Address2 { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Phone { get; set; }


        [Display(Name = "شماره همراه")]
        public string Mobile { get; set; }

        [Display(Name = "محتوا")]
        [Required(ErrorMessage = "وارد کردن محتوا الزامی است")]
        [AllowHtml]
        public string Content { get; set; }

        [NotMapped]
        [Display(Name = "لوگو مشتری")]
        public HttpPostedFileBase ContentFile { get; set; }

        public byte[] Logo { get; set; }

        [NotMapped]
        public string Base64Image
        {
            get
            {
                if (Logo != null)
                    return Convert.ToBase64String(Logo);
                else
                    return string.Empty;
            }
        }

        [Display(Name = "لینک تلگرام")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "استفاده از کاراکتر(های) غیر مجاز")]
        public string Telegram { get; set; }

        [Display(Name = "لینک اینستاگرام")]
        [MaxLength(100, ErrorMessage = "حداکثر 100 کارکتر")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "استفاده از کاراکتر(های) غیر مجاز")]
        public string Instagram { get; set; }

    }

}