using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CSharpWebAPI.Models {
    //[Authorize]
    public class CommentsController : ApiController {
        ICommentRepository repository;
        public CommentsController(ICommentRepository repository) {
            this.repository = repository;
        }
        #region GET
        public IQueryable<Comment> Get() {
            return repository.Get().AsQueryable();
        }
        public Comment GetComment(int id) {
            Comment comment;
            if (!repository.TryGet(id, out comment)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return comment;
        }
        #endregion
        #region DELETE
        public void DeleteComment(int id) {
            Comment comment;
            if (!repository.TryGet(id, out comment)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Delete(id);
        }
        #endregion
        #region POST
        public HttpResponseMessage PostComment(Comment comment) {
            comment = repository.Add(comment);
            var response = Request.CreateResponse<Comment>(HttpStatusCode.Created, comment);
            //response.Headers.Location = new Uri(Request.RequestUri, $"/api/comments/{comment.ID}");
            return response;
        }
        #endregion
        #region Paging GET
        public IEnumerable<Comment> GetComments(int pageIndex, int pageSize) {
            return repository.Get().Skip(pageIndex * pageSize).Take(pageSize);
        }
        #endregion

    }
}
