
process.stdin.resume()
process.stdin.setEncoding('utf8')
//关闭命令行输入
process.stdin.on("end", function () {
  process.stdin.pause();
});
//获取命令行输入
process.stdin.on('data', function (text) {
  process.stdin.emit("end");
  process.stdout.write(text.toString().toLowerCase())
})

console.log('log')
console.info('info')
console.trace('trace')
console.error('error')
console.warn('warn')
