const express = require('express');
const app = express();

//当访问根路径时触发
app.get('/', function (req, res) {
   res.send('Hello Express');
})

//自己的中间件
app.use(function(req,res,next){
   console.log("%s %s",req.method,req.url);
   next();
});

var server = app.listen(8000, function () {
   var host = server.address().address
   var port = server.address().port
   console.log(host, port);
})