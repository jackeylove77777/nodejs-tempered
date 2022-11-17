const http = require('http')

const server = http.createServer((req, res) => {
  res.writeHead(200, { "Content-Type": "text/plain" })
  res.write("Hello dasdaddasas")
  res.end()
})

server.listen(8000, _ => {
  console.log("server started on port: 8000");
})

