using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWebAPI.Models {
    public interface ICommentRepository {
        IEnumerable<Comment> Get();
        bool TryGet(int id, out Comment comment);
        Comment Add(Comment comment);
        bool Delete(int id);
        bool Update(Comment comment);
    }
}
