const express = require('express')

const app = express()

app.get('/', (req, res) => {
  res.send('hello world')
})
var server = app.listen(8000, function () {
  var host = server.address().address;
  var port = server.address().port;
  console.log(host, port);
});