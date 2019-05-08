using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpWebAPI.Models;

namespace CSharpWebAPI {
    public class InitialData : DictionaryCommentRepository {
        public InitialData() {
            // make fake data
            Add(new Comment {
                Author = "8q",
                    Email = "123456789@mail.addr",
                    Text = "This is text."
            });
            Add(new Comment {
                Author = "abc",
                    Email = "def@gamil.com",
                    Text = "XSS test<svg>123"
            });
        }
    }
}
