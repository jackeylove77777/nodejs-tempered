console.log(new Date().getSeconds())
setTimeout(() => {
  console.log(new Date().getSeconds());
  console.log('first timeout')
}, 1000)

const task = setTimeout(() => {
  console.log('you can not see this line');
}, 3000)
//清除定时器
clearTimeout(task)


//setInternal按时间间隔循环执行
setInterval(() => {
  console.log('internal call')
},2000)