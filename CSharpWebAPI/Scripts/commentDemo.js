/* eslint-disable linebreak-style */
const commentModel = {
    ID: 1,
    Author: '',
    Email: '',
    Text: '',
    GravatarUrl: '',
}
const noop = () => {}
const app = new Vue({
    el: '#app',
    data: {
        comments: [],
        myComment: {
            ...commentModel,
        },
    },
    methods: {
        async deleteComment(comment) {
            if (comment.isDeleting) return
            comment.isDeleting = true
            try {
                await $.ajax({
                    type: 'DELETE',
                    url: `/api/Comments/${comment.ID}`,
                    dataType: 'json',
                })
                const index = this.comments.indexOf(comment)
                if (index !== -1) this.comments.splice(index, 1)
            } catch (e) {
                alert(`删除失败：${e.responseJSON.ExceptionMessage}`)
                comment.isDeleting = false
            }
        },
        async onSubmit() {
            try {
                const comment = await $.post(
                    '/api/Comments',
                    this.myComment,
                    noop,
                    'json'
                )
                comment.isDeleting = false
                this.comments.push(comment)
                this.myComment = {
                    ...commentModel,
                }
            } catch (e) {
                alert(`提交失败：${e.responseJSON.ExceptionMessage}`)
            }
        },
    },
})
$.get(
    '/api/Comments',
    res => {
        app.comments = res
    },
    'json'
)
