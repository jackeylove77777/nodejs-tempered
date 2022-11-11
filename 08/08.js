const fs = require('fs')

//读取当前目录下所有文件名
fs.readdir('./', (err, files) => {
  if (!err) {
    console.log(files)
  }
})
//同步写入文件，再同步读取
const f = fs.openSync('./123.txt', 'w+')
const write_buf = Buffer.from('123456789')
fs.writeSync(f, write_buf, 0, write_buf.length, 0)

//同步读取
const read_buf = Buffer.alloc(write_buf.length)
fs.readSync(f, read_buf, 0, read_buf.length, 0)

console.log(read_buf.toString());
