// stores/counter.js
import { defineStore } from 'pinia'

export const useBlogStore = defineStore('blogs', {
  state: () => ({
    blogs: [
      {
        title: '标题1',
        author: '作者1',
        content: '我是标题1的内容',
        date: '2024-01-2',
        comments: [
          { author: '小米', date: '2024-01-22', content: '东西不错1' },
          { author: '小d', date: '2024-08-22', content: '东西不错1' },
          { author: 'ryan', date: '2024-05-2', content: '东西不错1' }
        ]
      },
      {
        title: '标题2',
        author: '作者2',
        content: '我是标题2的内容',
        date: '2024-01-2',
        comments: [
          { author: 'bbb', date: '2024-01-2', content: '东西不错2' },
          { author: 'dd', date: '2024-05-22', content: '东西不错2' },
          { author: '22', date: '2024-01-26', content: '东西不错2' }
        ]
      },
      {
        title: '标题3',
        author: '作者3',
        content: '我是标题3的内容',
        date: '2024-01-2',
        comments: [
          { author: '33', date: '2024-01-2', content: '东西不错3' },
          { author: '13', date: '2024-01-12', content: '东西不错3' },
          { author: '63', date: '2024-01-23', content: '东西不错3' }
        ]
      }
    ]
  }),
  getters: {},
  actions: {
    addBlog(blog: any) {
      this.blogs.push({
        id: this.blogs.length + 1,
        title: blog.title,
        content: blog.content
      })
    }
  }
})


