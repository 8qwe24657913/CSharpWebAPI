using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cambia;

namespace CSharpWebAPI.Models {
    public class Comment {
        public int ID {
            get;
            set;
        }

        [Required]
        [StringLength(10, ErrorMessage = "Author is too long!")]
        public string Author {
            get;
            set;
        }

        [Required]
        public string Text {
            get;
            set;
        }

        [Required]
        public string Email {
            get;
            set;
        }
        public string GravatarUrl {
            get {
                return HttpUtility.HtmlDecode(Gravatar.GenerateUrl(Email ?? "", 80));
            }
            set {}
        }
    }
}
