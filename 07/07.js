//流代码更简洁优雅，拓展性也强
const http = require('http')
const fs = require('fs')
const zlib = require('zlib')

//内存得到优化，性能得到提升
http.createServer(function (req, res) {
  res.writeHead(200, { "content-encoding": "gzip" })
  fs.createReadStream('./07.js').pipe(zlib.createGzip()).pipe(res)
}).listen(8001)

//不使用流的方式
// http.createServer((req, res) => {d
//   fs.readFile('./07.js', (err, data) => {
//     if (err) {
//       res.statusCode = 500
//       res.end(String(err))
//     } else {
//       res.end(data)
//     }
//   })
// })

