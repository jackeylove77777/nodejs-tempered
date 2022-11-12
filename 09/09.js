const fs = require('fs')
const read_able = fs.createReadStream('./123.txt')
const write_able = fs.createWriteStream('./456.txt');

read_able.pipe(write_able)

//文件监视
fs.watchFile('./123.txt', { persistent: true, interval: 300 }, (status) => {
  if (status) {
    console.log(status);
  }
})

//文件锁
fs.open('./watch.txt', 'wx', (err, fp) => {
  if (err) console.log(err)
  else {
    console.log(fp)
    setTimeout(() => {
      fs.close(fp)
      console.log('watch.txt unwatch');
    },10000)
  }
})