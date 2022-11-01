const fs = require('fs')

fs.readFile('./main.js', (er, buf) => {
  if (!er) {
    console.log(Buffer.isBuffer(buf));
    console.log(buf); //输出二进制，以十六进制表示。等同于console.log(buf.toString(‘hex’))
    console.log(buf.toString()); //转化伪字符串输出，toString方法默认为utf8编码
  }
})

const buf = Buffer.from('哈哈哈')
console.log(buf);
console.log(buf.toString());