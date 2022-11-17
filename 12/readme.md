Nodejs的http模块，是基于net.server，经过c++二次封装，也是nodejs的核心模块。

功能比net.server更强，可解析和操作更多细节内容，如值、content-length、请求方法、响应码状态等等，且使用更方便。

而C#主要使用HttpListener构建http服务