# CSharpWebAPI

C# 课程作业4 - WebAPI

## 作业要求

仿照视频自制一个 WebAPI 服务

## 功能描述

简单的评论和删除评论功能，邮箱用来显示 Gravatar，附带一个~~简陋~~简洁的前端实现（

## 运行截图

![](https://raw.githubusercontent.com/8qwe24657913/CSharpWebAPI/master/images/PC.png)

简单的评论API

![](https://raw.githubusercontent.com/8qwe24657913/CSharpWebAPI/master/images/responsive.png)

响应式设计

> 顺带一提，MVVM框架用的是 Vue 而非视频中的 Knockout，Knockout 绑定 vm 对象用的是 with(){} 语句……要什么 IE6 兼容，avalon 兼容 IE8 我都嫌 vbs 实现双向绑定太奇技淫巧（而且有奇怪的bug）不想用（

### 附录：遇到的问题及解决方法

1. `new HttpResponseMessage<T>(...)` 被弃用，改用 `Request.CreateResponse<T>(...)`
2. Ninject 在新版本中遇到的问题，解决方法见 `NinjectDependencyResolver`
3. `System.Web.Http` 与 `System.Net.Http.Formatting`中各有一个 `HttpRequestMessageExtensions` 类，使用`extern alias` 解决（见[此处](https://stackoverflow.com/questions/36413123/cs0433-ambiguous-reference-system-net-http-httprequestmessageextensions)）
4. `JsonObject` 格式化报错，使用 `JsonMediaTypeFormatter`
5. 这个问题是传到 Github 后发现的：Github 告诉我自带的 bootstrap 有 XSS 风险，需要更新，感谢 Github

其中`extern alias`的问题用户体验不是很好，VS 给出了错误原因但没有任何解决方法提示，还好 stackoverflow 捞了一手（

